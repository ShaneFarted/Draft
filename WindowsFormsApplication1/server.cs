using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            initPricelist();
        }

        public bool btnstatu = true;    //开始停止服务按钮状态
        public Thread myThread;             //声明一个线程实例
        public Thread TimeThread;       //倒计时线程
        public Thread uiProctector;     //ui守护线程
        public Socket serversock;                //声明一个Socket实例
        public Socket[] Client;
        private byte[] bytes = new byte[10240];
        private byte[] data = new byte[1024];  
        public IPEndPoint localEP;
        public int localPort;
        public int roundcount = 1, pickcount = 1, timecount = 70;     //轮次倒计时
        public bool m_Listening;   //监听状态
        public int clientnumber = 0;
        private string[] SelectedPlayer=new string[31];
        private int[] SelectedCount = new int[31];
        //用来设置服务端监听的端口号
        public int setPort
        {
            get { return localPort; }
            set { localPort = value; }
        }
        public string strPriceList;

        /// <summary>
        /// ui更新函数
        /// </summary>
        public void uiUpdate()
        {
            while(true)
            {
                if (timecount == 55) //对于电脑的选秀位置，直接在50秒就强行过人
                {
                    if (this.lv_participantslist.Items[pickcount - 1].SubItems[1].Text == "")
                    {
                        bt_nextround_Click(null, EventArgs.Empty);
                    }
                }
                else if (timecount == 30)
                    checkstatus();
                else if (timecount == 5)
                    checkstatus();
                else if (timecount == 1)//给掉线的在1秒的时候强行选一个
                {
                    if (this.lv_participantslist.Items[pickcount - 1].SubItems[1].Text == "离线")
                    {
                        bt_nextround_Click(null, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// 用于轮次倒计时
        /// </summary>
        public void countdown()
        {
            while (timecount > 0)
            {
                timecount -= 1;
                Thread.Sleep(1000);
                if (timecount == 0)
                {

                    if (roundcount % 2 == 1) //轮数为奇
                    {
                        pickcount += 1;
                        if (pickcount == 31)  //签数到31，轮数+1
                        {
                            roundcount += 1;
                            pickcount = 30;
                            lb_round.Text = roundcount.ToString();
                        }
                        lb_pick.Text = pickcount.ToString();
                    }
                    else   //轮数为偶
                    {
                        pickcount -= 1;
                        if (pickcount == 0)  //签数到0，轮数+1
                        {
                            roundcount += 1;
                            pickcount = 1;
                            lb_round.Text = roundcount.ToString();
                        }
                        lb_pick.Text = pickcount.ToString();
                    }
                    timecount = 70;
                }
                lb_second.Text = timecount.ToString();
                
            }
        }

        //用来往richtextbox框中显示消息
        public void showClientMsg(string msg)
        {
            showClientMsg(msg + "\r\n");
        }

        /// <summary>
        /// 监听函数
        /// </summary>
        public void Listen()
        {
            //设置端口
            setPort = int.Parse(serverport.Text.Trim());  //从服务端界面指定的端口号设定端口号
            //初始化SOCKET实例
            serversock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //初始化终结点实例
            localEP = new IPEndPoint(IPAddress.Any, setPort);
            try
            {
                //绑定
                serversock.Bind(localEP);
                //监听 最多100人
                serversock.Listen(100);
                //用于设置按钮状态
                m_Listening = true;
                //开始接受连接，异步。
                serversock.BeginAccept(new AsyncCallback(OnConnectRequest), serversock);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Byte[] byteDataLineReceive = new Byte[10240];
        }

        public void ReceiveTarget(IAsyncResult res) { 
            try
            {
            
            Socket client = (Socket)res.AsyncState; 
            int size = client.EndReceive(res); 
            Byte[] byteDataLineReceive = new Byte[10240];
            if (size > 0) 
            {
                //int recv = Client[i].Receive(byteDataLineReceive);
                string stringdata = Encoding.UTF8.GetString(bytes, 0, size);
                string[] stringdatatype = stringdata.Split(',');
                DateTimeOffset now = DateTimeOffset.Now;
                //获取客户端的IP和端口
                string ip = client.RemoteEndPoint.ToString();

                switch (stringdatatype[0])
                {
                    //如果客户端断线
                    case "STOP":
                        {
                            //当客户端终止连接时
                            showinfo.AppendText(ip + "尝试离线");
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }
                    //如果客户端请求名单，则给客户端返回服务器的球员名单数据
                    case "RequestList":
                        {
                            strPriceList = "PriceList,";
                            transPricelist();
                            //string strPriceListt = "PriceList,1,L.James,SF,96,2100,第一轮,2,K.Durant,SF,93,2050,第一轮,3,JamesHarden,SG,94,2050,第一轮,4,RussellWestbrook,PG,94,2050,第一轮,5,PaulGeorge,SF,88,2000,第一轮,6,AnthonyDavis,PF,94,1950,第一轮,7,CarmeloAnthony,SF,86,1950,第一轮,8,StephenCurry,PG,94,1950,第一轮,9,ChrisPaul,PG,90,1900,第一轮,10,LaMarcusAldridge,PF,89,1900,第一轮,11,DwightHoward,C,88,1850,第一轮,12,DwyaneWade,SG,87,1850,第一轮,13,KyrieIrving,PG,88,1850,第一轮,14,JohnWall,PG,87,1850,第一轮,15,DeMarcusCousins,C,89,1850,第一轮,16,DamianLillard,PG,85,1800,第一轮,17,KawhiLeonard,SF,86,1800,第一轮,18,KlayThompson,SG,87,1750,第一轮,19,KobeBryant,SG,84,1700,第一轮,20,MikeConley,PG,86,1700,第一轮,";
                            //strPriceListt += "21,BlakeGriffin,PF,88,1700,第一轮,22,MarcGasol,C,89,1650,第一轮,23,TimDuncan,PF,89,1600,第一轮,24,PauGasol,PF,87,1600,第一轮,25,DerrickRose,PG,84,1600,第一轮,26,DeMarDeRozan,SG,85,1550,第一轮,27,JimmyButler,SG,85,1550,第一轮,28,DirkNowitzki,PF,85,1550,第一轮,29,RudyGay,SF,82,1550,第一轮,30,TonyParker,PG,84,1550,第一轮,31,DeAndreJordan,C,86,1500,第二轮,32,ZachRandolph,PF,86,1450,第二轮,33,AndreDrummond,C,85,1400,第二轮,34,GordonHayward,SF,82,1350,第二轮,35,AlJefferson,C,85,1350,第二轮,36,ChrisBosh,PF,85,1300,第二轮,37,JonasValanciunas,C,84,1300,第二轮,38,JeffTeague,PG,85,1300,第二轮,39,AlHorford,C,86,1300,第二轮,40,KyleLowry,PG,85,1300,第二轮";
                            Byte[] bytePriceList = System.Text.Encoding.UTF8.GetBytes(strPriceList);
                            client.Send(bytePriceList, bytePriceList.Length, 0);
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }
                    //如果客户端请求选人
                    case "RequestPick":
                        {
                            //判断 是否是已选的球员
                            if (this.lv_allprice.Items[int.Parse(stringdatatype[1]) - 1].SubItems[6].Text!="")
                            {
                                string rjt = "Rejected,";
                                Byte[] byterjt = System.Text.Encoding.UTF8.GetBytes(rjt);
                                client.Send(byterjt, byterjt.Length, 0);
                                client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                                break;
                            }
                            //服务端公告
                            showinfo.AppendText("玩家" + stringdatatype[8] + "在第" + stringdatatype[9] + "轮" + stringdatatype[10] + "号签选中球员" + stringdatatype[2] + "价格:" + stringdatatype[5] + "编号：" + stringdatatype[1] + "\n");
                            //给球员加上已选签位标记
                            this.lv_allprice.Items[int.Parse(stringdatatype[1]) - 1].SubItems[6].Text = stringdatatype[10];
                            SelectedPlayer[int.Parse(stringdatatype[10])] += stringdatatype[1] + "," + stringdatatype[2] + "," + stringdatatype[5] + ",";
                            //给回请求，删除对应的球员
                            string delString = "DeleteRow," + stringdatatype[7] + ",";
                            Byte[] bytedelString = System.Text.Encoding.UTF8.GetBytes(delString);
                            //给客户端发回选秀信息通知，和删除信息一起发送
                            string notiString = "Notification,\n玩家 " + stringdatatype[8] + " 在第" + stringdatatype[9] + "轮" + stringdatatype[10] + "号签选中球员" + stringdatatype[2] + "价格:" + stringdatatype[5] + "编号：" + stringdatatype[1] + " \n";
                            Byte[] bytenotiString = System.Text.Encoding.UTF8.GetBytes(notiString);
                            
                            try
                            {
                                for (int i = 0; i < 29; i++)
                                {
                                    if(Client[i]!=null&&Client[i].Connected)
                                    {
                                        Client[i].Send(bytedelString, bytedelString.Length, 0);
                                        Client[i].Send(bytenotiString, bytenotiString.Length, 0);
                                    }
                                    //Client[i].EndSend(res);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show("发送选人通知出错: " + ex.Message );

                            }
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }

                    case "GoNextRound":
                        {
                            if (stringdatatype[1]==lb_round.Text&&stringdatatype[2]==lb_pick.Text)
                            {
                                timecount = 0;
                                Thread.Sleep(1200);
                            }
                            string timesyncString = "SyncTime," + lb_round.Text + "," + lb_pick.Text + "," + lb_second.Text;

                            Byte[] bytetimesyncString = System.Text.Encoding.UTF8.GetBytes(timesyncString);
                            try
                            {
                                for (int i = 0; i < 29;i++ )
                                    if (Client[i]!=null&&Client[i].Connected)
                                    Client[i].Send(bytetimesyncString, bytetimesyncString.Length, 0);
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show("进入下一轮出错: "+ex.Message.ToString());
                            }
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }

                    case "RequestSyncTime":
                        {
                            string timesyncString = "SyncTime," + roundcount.ToString() + "," + pickcount.ToString() + "," + timecount.ToString();
                            Byte[] bytetimesyncString = System.Text.Encoding.UTF8.GetBytes(timesyncString);
                            client.Send(bytetimesyncString, bytetimesyncString.Length, 0);
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }

                    case "RequestMyPlayers":
                        {
                            string myplayerstring = SelectedPlayer[int.Parse(stringdatatype[1])];
                            Byte[] myplayerString = System.Text.Encoding.UTF8.GetBytes(myplayerstring);
                            client.Send(myplayerString, myplayerString.Length, 0);
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }
                    case "Introduction":
                        {
                            try
                            {
                                //状态列表
                                this.lv_participantslist.Items[int.Parse(stringdatatype[2]) - 1].SubItems[1].Text = "在线";
                                this.lv_participantslist.Items[int.Parse(stringdatatype[2]) - 1].SubItems[2].Text = ip;
                                Client[int.Parse(stringdatatype[2]) - 1] = Client[99];
                            }
                            catch (System.Exception ex)
                            {
                            }
                            showinfo.AppendText(ip + "    " + stringdatatype[1] + stringdatatype[2] +"\n");
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }
                    case "Disconnect":
                        {
                            showinfo.AppendText(ip + "    " + stringdatatype[1] + stringdatatype[2] + "\n");
                            //stringdatatype[1]为用户的签位
                            int index=int.Parse(stringdatatype[1])-1;
                            this.lv_participantslist.Items[index].SubItems[1].Text = "离线";
                            client.Close();
                            Client[index].Close();
                            //for (int i=index;i<clientnumber;i++)
                            //{
                            //    Client[i]=Client[i+1];
                            //}
                            clientnumber--;
                            lb_clientnumber.Text = clientnumber.ToString(); 
                            break;
                        }

                    //显示客户端发送过来的信息
                    default:
                        {
                            showinfo.AppendText(ip + "    " + stringdata + "\n");
                            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client);
                            break;
                        }
                }


            }
                //断线会引发BUG client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), client); 
        }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        } 

        //当有客户端连接时的处理
        public void OnConnectRequest(IAsyncResult ar)
        {
            //设置心跳
            Random rd = new Random();
            byte[] inOptionValues = new byte[4 * 3];
            BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0); //开
            BitConverter.GetBytes((uint)15000).CopyTo(inOptionValues, 4);//多久第一次开始探测
            BitConverter.GetBytes((uint)20000).CopyTo(inOptionValues, 8);//时间间隔20+ - 0.8秒，三次不到算断
            //初始化一个SOCKET，用于其它客户端的连接
            Socket server1 = (Socket)ar.AsyncState;
            Client[99] = server1.EndAccept(ar);
            Client[99].IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);

            //将要发送给连接上来的客户端的提示字符串
            string strDateLine = "RequestIntroduction,加入服务器成功!你是第,"+ (clientnumber+1) +",位玩家 \n ";
            Byte[] byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);
            //将提示信息发送给客户端
            Client[99].BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(ReceiveTarget), Client[99]);
            Client[99].Send(byteDateLine, byteDateLine.Length, 0);
            clientnumber++;
            lb_clientnumber.Text=clientnumber.ToString();
            //等待新的客户端连接
            server1.BeginAccept(new AsyncCallback(OnConnectRequest), server1);
        }
        //开始停止服务按钮
        private void startService_Click(object sender, EventArgs e)
        {
            Client = new Socket[65535];
            //新建一个委托线程 开始监听(Listen)
            ThreadStart myThreadDelegate = new ThreadStart(Listen);

            //实例化新线程
            myThread = new Thread(myThreadDelegate);
            uiProctector = new Thread(new ThreadStart(uiUpdate));
            if (btnstatu)
            {
                myThread.Start();
                uiProctector.Start();
                statuBar.Text = "服务已启动，等待客户端连接";
                btnstatu = false;
                startService.Text = "停止服务";

            }
            else
            {
                //停止服务（功能还有问题，无法停止）
                m_Listening = false;
                serversock.Close();
                myThread.Abort();
                showClientMsg("服务器停止服务");
                btnstatu = true;
                startService.Text = "开始服务";
                statuBar.Text = "服务已停止";
                m_Listening = false;
            }

        }
        //窗口关闭时中止线程。
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myThread != null)
            {
                TimeThread.Abort();
                myThread.Abort();
            }
        }

        /// <summary>
        /// 开始选秀按钮，发送开始选秀信号量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_startdrafting_Click(object sender, EventArgs e)
        {
            //开始倒计时线程
            ThreadStart TimeThreadDelegate = new ThreadStart(countdown);
            TimeThread = new Thread(TimeThreadDelegate);
            TimeThread.Start();
            //将开始计时信号量发送给客户端
            string strDateLine = "StartSig";
            Byte[] byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);
            try
            {
                for (int i = 0; i < 29; i++)
                {
                    if (Client[i] != null && Client[i].Connected)
                        Client[i].Send(byteDateLine, byteDateLine.Length, 0);
                }
            }
            catch
            {
            }
            timecount = 70;
            roundcount = 1;
            pickcount = 1;
            
        }

        /// <summary>
        /// 价格表初始化
        /// </summary>
        public void initPricelist()
        {
            string[] id = new string[]{"1",
"2",
"3",
"4",
"5",
"6",
"7",
"8",
"9",
"10",
"11",
"12",
"13",
"14",
"15",
"16",
"17",
"18",
"19",
"20",
"21",
"22",
"23",
"24",
"25",
"26",
"27",
"28",
"29",
"30",
"31",
"32",
"33",
"34",
"35",
"36",
"37",
"38",
"39",
"40",
"41",
"42",
"43",
"44",
"45",
"46",
"47",
"48",
"49",
"50",
"51",
"52",
"53",
"54",
"55",
"56",
"57",
"58",
"59",
"60",
"61",
"62",
"63",
"64",
"65",
"66",
"67",
"68",
"69",
"70",
"71",
"72",
"73",
"74",
"75",
"76",
"77",
"78",
"79",
"80",
"81",
"82",
"83",
"84",
"85",
"86",
"87",
"88",
"89",
"90",
"91",
"92",
"93",
"94",
"95",
"96",
"97",
"98",
"99",
"100",
"101",
"102",
"103",
"104",
"105",
"106",
"107",
"108",
"109",
"110",
"111",
"112",
"113",
"114",
"115",
"116",
"117",
"118",
"119",
"120",
"121",
"122",
"123",
"124",
"125",
"126",
"127",
"128",
"129",
"130",
"131",
"132",
"133",
"134",
"135",
"136",
"137",
"138",
"139",
"140",
"141",
"142",
"143",
"144",
"145",
"146",
"147",
"148",
"149",
"150",
"151",
"152",
"153",
"154",
"155",
"156",
"157",
"158",
"159",
"160",
"161",
"162",
"163",
"164",
"165",
"166",
"167",
"168",
"169",
"170",
"171",
"172",
"173",
"174",
"175",
"176",
"177",
"178",
"179",
"180",
"181",
"182",
"183",
"184",
"185",
"186",
"187",
"188",
"189",
"190",
"191",
"192",
"193",
"194",
"195",
"196",
"197",
"198",
"199",
"200",
"201",
"202",
"203",
"204",
"205",
"206",
"207",
"208",
"209",
"210",
"211",
"212",
"213",
"214",
"215",
"216",
"217",
"218",
"219",
"220",
"221",
"222",
"223",
"224",
"225",
"226",
"227",
"228",
"229",
"230",
"231",
"232",
"233",
"234",
"235",
"236",
"237",
"238",
"239",
"240",
"241",
"242",
"243",
"244",
"245",
"246",
"247",
"248",
"249",
"250",
"251",
"252",
"253",
"254",
"255",
"256",
"257",
"258",
"259",
"260",
"261",
"262",
"263",
"264",
"265",
"266",
"267",
"268",
"269",
"270",
"271",
"272",
"273",
"274",
"275",
"276",
"277",
"278",
"279",
"280",
"281",
"282",
"283",
"284",
"285",
"286",
"287",
"288",
"289",
"290",
"291",
"292",
"293",
"294",
"295",
"296",
"297",
"298",
"299",
"300",
"301",
"302",
"303",
"304",
"305",
"306",
"307",
"308",
"309",
"310",
"311",
"312",
"313",
"314",
"315",
"316",
"317",
"318",
"319",
"320",
"321",
"322",
"323",
"324",
"325",
"326",
"327",
"328",
"329",
"330",
"331",
"332",
"333",
"334",
"335",
"336",
"337",
"338",
"339",
"340",
"341",
"342",
"343",
"344",
"345",
"346",
"347",
"348",
"349",
"350",
"351",
"352",
"353",
"354",
"355",
"356",
"357",
"358",
"359",
"360",
"361",
"362",
"363",
"364",
"365",
"366",
"367",
"368",
"369",
"370",
"371",
"372",
"373",
"374",
"375",
"376",
"377",
"378",
"379",
"380",
"381",
"382",
"383",
"384",
"385",
"386",
"387",
"388",
"389",
"390",
"391",
"392",
"393",
"394",
"395",
 };
            string[] ename = new string[] {"L.James",
"K.Durant",
"James Harden",
"Carmelo Anthony",
"Paul George",
" Russell Westbrook",
"Stephen Curry",
"Anthony Davis",
"Chris Paul",
"LaMarcus Aldridge",
"Kyrie Irving",
"John Wall",
"Klay Thompson",
"Dwyane Wade",
"Damian Lillard",
"Kawhi Leonard",
"Mike Conley",
"Kobe Bryant",
"DeMarcus Cousins",
"Dwight Howard",
"Rudy Gay",
"Blake Griffin",
"DeMar DeRozan",
"Jimmy Butler",
"Derrick Rose",
"Tim Duncan",
"Pau Gasol",
"Dirk Nowitzki",
"Marc Gasol",
"Gordon Hayward",
"Tony Parker",
"DeAndre Jordan",
"Zach Randolph",
"Jeff Teague",
"Andre Drummond",
"Al Jefferson",
"Chris Bosh",
"Kyle Lowry",
"Kevin Love",
"Monta Ellis",
"Kevin Martin",
"Jonas Valanciunas",
"Nikola Vucevic",
"Al Horford",
"Tyson Chandler",
"Joakim Noah",
"Andrew Bogut",
"Eric Bledsoe",
"Brook Lopez",
"Goran Dragic",
"Brandon Knight",
"Paul Millsap",
"Draymond Green",
"Greg Monroe",
"Andrew Wiggins",
"Wesley Matthews",
"Serge Ibaka",
"Paul Pierce",
"Andre Iguodala",
"Victor Oladipo",
"Ty Lawson",
"Brandon Jennings",
"Hassan Whiteside",
"Kemba Walker",
"Rudy Gobert",
"Marcin Gortat",
"Isaiah Thomas",
"Deron Williams",
"Gerald Green",
"Khris Middleton",
"Kyle Korver",
"Joe Johnson",
"Jamal Crawford",
"Louis Williams",
"Jeff Green",
"Nicolas Batum",
"Harrison Barnes",
"Trevor Ariza",
"Kenneth Faried",
"Derrick Favors",
"Chandler Parsons",
"Luol Deng",
"Timofey Mozgov",
"Iman Shumpert",
"Nikola Pekovic",
"J.R. Smith",
"David West",
"Tyreke Evans",
"Ray Allen",
"Bradley Beal",
"Tristan Thompson",
" G.Antetokounmpo",
"J.J. Redick",
"Jrue Holiday",
"Darren Collison",
"Rajon Rondo",
"Reggie Jackson",
"Gorgui Dieng",
"Mason Plumlee",
"Tobias Harris",
"Taj Gibson",
"Markieff Morris",
"Amar'e Stoudemire",
"Nene",
"Wilson Chandler",
"Danilo Gallinari",
"Nick Young",
"DeMarre Carroll",
"Michael Kidd-Gilchrist",
"Jared Dudley",
"Courtney Lee",
"Manu Ginobili",
"Anderson Varejao",
"Larry Sanders",
"Robin Lopez",
"Kevin Garnett",
"David Lee",
"Jabari Parker",
"Nerlens Noel",
"Jordan Hill",
"Omer Asik",
"Enes Kanter",
"John Henson",
"Jared Sullinger",
"Michael Carter-Williams",
"Jusuf Nurkic",
"Roy Hibbert",
"Joel Embiid",
"Ricky Rubio",
"Patrick Beverley",
"Corey Brewer",
"Dennis Schroder",
"Danny Green",
"Avery Bradley",
"Alec Burks",
"Gerald Henderson",
"O.J. Mayo",
"Lance Stephenson",
"Dion Waiters",
"Josh Smith",
"P.J. Tucker",
"Tony Wroten",
"Tayshaun Prince",
"Vince Carter",
"Alex Len",
"Tony Allen",
"Marco Belinelli",
"Wesley Johnson",
"Tony Snell",
"Kent Bazemore",
"Boris Diaw",
"Eric Gordon",
"James Johnson",
"Rodney Stuckey",
"Terrence Ross",
"Mo Williams",
"Ersan Ilyasova",
"Nikola Mirotic",
"Tiago Splitter",
"Steven Adams",
"Terrence Jones",
"Ed Davis",
"JaVale McGee",
"Miles Plumlee",
"Arron Afflalo",
"Chris Andersen",
"Alexis Ajinca",
"Marreese Speights",
"Carlos Boozer",
"Amir Johnson",
"J.J. Hickson",
"Kosta Koufos",
"Jeremy Lin",
"Steve Nash",
"George Hill",
"Tyler Zeller",
"Devin Harris",
"D.J. Augustin",
"Aaron Brooks",
"Brandon Bass",
"Marcus Morris",
"S.Muhammad",
"Zaza Pachulia",
"Zach LaVine",
"Bismack Biyombo",
"Trevor Booker",
"Thaddeus Young",
"Samuel Dalembert",
"Kris Humphries",
"Anthony Morrow",
"Mike Dunleavy",
"Ben McLemore",
"Tim Hardaway",
"Luis Scola",
"Jameer Nelson",
"Chris Kaman",
"Cody Zeller",
"Kyle O'Quinn",
"Andray Blatche",
"Ian Mahinmi",
"Kelly Olynyk",
"Carl Landry",
"Donatas Motiejunas",
"Julius Randle",
"Jae Crowder",
"Brandan Wright",
"Elfrid Payton",
"Jordan Clarkson",
"J.J. Barea",
"Patrick Mills",
"Marcus Smart",
"Mario Chalmers",
"C.J. Watson",
"Shawn Marion",
"Matt Barnes",
"Marcus Thornton",
"Jodie Meeks",
"Evan Turner",
"Reggie Evans",
"Jason Terry",
"Shaun Livingston",
"Andrea Bargnani",
"Jeremy Lamb",
"Evan Fournier",
"Andre Miller",
"Henry Sims",
"Robert Covington",
"Jarrett Jack",
"Dorell Wright",
"Jerryd Bayless",
"Kirk Hinrich",
"Solomon Hill",
"Norris Cole",
"Kendall Marshall",
"Beno Udrih",
"Thabo Sefolosha",
"Jason Richardson",
"Caron Butler",
"Kyle Singler",
"C.J. Miles",
"Randy Foye",
"Steve Blake",
"Richard Jefferson",
"Cole Aldrich",
"Steve Blake",
"Ben Gordon",
"Aaron Gordon",
"Josh McRoberts",
"Patrick Patterson",
"Greivis Vasquez",
"Jose Calderon",
"Al-Farouq Aminu",
"Nate Robinson",
"Cory Joseph",
"Kendrick Perkins",
"Rasual Butler",
"Jason Thompson",
"Glen Davis",
"Lavoy Allen",
"Elton Brand",
"Ryan Hollins",
"Festus Ezeli",
"M. Dellavedova",
"Emeka Okafor",
"Jason Smith",
"Andrew Bynum",
"Jermaine O'Neal",
"Isaiah Canaan",
"Jarnell Stokes",
"Jon Leuer",
"Steve Novak",
"Derrick Williams",
"Omri Casspi",
"Danny Granger",
"Dante Exum",
"Raymond Felton",
"Channing Frye",
"Mike Scott",
"Dorell Wright",
"Ryan Anderson",
"Raymond Felton",
"Otto Porter",
"Donald Sloan",
"Austin Rivers",
"Pablo Prigioni",
"Alonzo Gee",
"Henry Walker",
"Andrei Kirilenko",
"Justin Holiday",
"Kevin Seraphin",
"Spencer Hawes",
"Nick Collison",
" Caldwell-Pope",
"C.J. McCollum",
"Udonis Haslem",
"Trey Burke",
"Jonas Jerebko",
"Thomas Robinson",
"Noah Vonleh",
"Langston Galloway",
"James Ennis",
"Jordan Farmar",
"Aron Baynes",
"Nick Calathes",
"Mike Miller",
"Gary Neal",
"Shelvin Mack",
"Andrei Kirilenko",
"Kyle Anderson",
"Maurice Harkless",
"K.J. Mcdaniels",
"Greg Oden",
"Ekpe Udoh",
"Joey Dorsey",
"Meyers Leonard",
"Anthony Bennett",
"Charlie Villanueva",
"John Salmons",
"Doug McDermott",
"Jordan Crawford",
"Leandro Barbosa",
"Matt Bonner",
"Kenyon Martin",
"Jeremy Evans",
"Mitch McGary",
"Dewayne Dedmon",
"Andre Roberson",
"Vitor Faverani",
"Quincy Acy",
"Nazr Mohammed",
"Wayne Ellington",
"Xavier Henry",
"Sim Bhullar",
"James Jones",
"Mirza Teletovic",
"Quincy Pondexter",
"Ramon Sessions",
"Shabazz Napier",
"Shane Larkin",
"Drew Gooden III",
"C.J. McCollum",
"Rashard Lewis",
"Tyler Hansbrough",
"Nate Wolters",
"Ish Smith",
"Brian Roberts",
"Will Barton",
"Jordan Hamilton",
"Dante Cunningham",
"Chris Copeland",
"Will Bynum",
"Tony Douglas",
"Alexey Shved",
"Willie Green",
"Nik Stauskas",
"Louis Amundson",
"Luke Ridnour",
"Ray McCallum",
"Adreian Payne",
"T.J. Warren",
"Jakarr Sampson",
"Jeff Adrien",
"Marvin Williams",
"K.Papanikolaou",
"Hollis Thompson",
"Garrett Temple",
"Hedo Turkoglu",
"Phil Pressey",
"Tyler Ennis",
"Jeff Taylor",
"Jerami Grant",
"Joe Ingles",
"Shawne Williams",
"Anthony Tolliver",
"Cory Jefferson",
"Darrell Arthur",
"Luc Mbah a Moute",
"Jeff Withey",
"Jerome Jordan",
"Mike Muscala",
"Ronnie Price",
"E'twaun Moore",
"Cleanthony Early",
"Darius Miller",
"Gerald Wallace",
"Ryan Kelly",
"Andrew Nicholson",
"DeJuan Blair",
"Landry Fields",
"Ronny Turiaf",
"Pero Antic",
"Carlos Delfino",
"Travis Outlaw",
"Chuck Hayes",
"Tim Frazier",
};
            string[] position = new string[] { "SF",
"SF",
"SG",
"SF",
"SF",
"PG",
"PG",
"PF",
"PG",
"PF",
"PG",
"PG",
"SG",
"SG",
"PG",
"SF",
"PG",
"SG",
"C",
"C",
"SF",
"PF",
"SG",
"SG",
"PG",
"PF",
"PF",
"PF",
"C",
"SF",
"PG",
"C",
"PF",
"PG",
"C",
"C",
"PF",
"PG",
"PF",
"SG",
"SG",
"C",
"C",
"C",
"C",
"C",
"C",
"PG",
"C",
"PG",
"PG",
"PF",
"PF",
"PF",
"SF",
"SG",
"PF",
"SF",
"SF",
"SG",
"PG",
"PG",
"C",
"PG",
"C",
"C",
"PG",
"PG",
"SF",
"SG",
"SG",
"SG",
"SG",
"SG",
"SF",
"SF",
"PF",
"SF",
"PF",
"PF",
"SF",
"SF",
"C",
"SG",
"C",
"SG",
"PF",
"PG",
"SG",
"SG",
"PF",
"SF",
"SG",
"PG",
"PG",
"PG",
"PG",
"C",
"C",
"SF",
"PF",
"PF",
"PF",
"PF",
"SF",
"SF",
"SF",
"SF",
"SF",
"SF",
"SG",
"SG",
"C",
"C",
"C",
"PF",
"PF",
"SF",
"C",
"C",
"C",
"C",
"C",
"C",
"PG",
"C",
"C",
"C",
"PG",
"PG",
"SF",
"PG",
"SG",
"SG",
"SG",
"SF",
"SG",
"SG",
"SG",
"SF",
"SF",
"PG",
"SF",
"SG",
"C",
"SG",
"SG",
"SF",
"SF",
"SG",
"PF",
"SG",
"SF",
"SG",
"SF",
"PG",
"PF",
"PF",
"C",
"C",
"PF",
"PF",
"C",
"C",
"SG",
"C",
"C",
"C",
"PF",
"PF",
"C",
"C",
"PG",
"PG",
"PG",
"C",
"PG",
"PG",
"PG",
"PF",
"SF",
"SG",
"C",
"PG",
"C",
"PF",
"PF",
"C",
"PF",
"SG",
"SF",
"SG",
"SG",
"PF",
"PG",
"C",
"PF",
"C",
"C",
"C",
"C",
"PF",
"PF",
"PF",
"SF",
"C",
"PG",
"PG",
"PG",
"PG",
"PG",
"PG",
"PG",
"SF",
"SF",
"SG",
"SG",
"SF",
"PF",
"PG",
"PG",
"C",
"SG",
"SG",
"PG",
"C",
"SF",
"PG",
"SF",
"PG",
"PG",
"SF",
"PG",
"PG",
"PG",
"SG",
"SG",
"SG",
"SF",
"SG",
"SG",
"PG",
"SF",
"C",
"PG",
"SG",
"PF",
"PF",
"PF",
"PG",
"PG",
"SF",
"PG",
"PG",
"C",
"SG",
"PF",
"PF",
"PF",
"PF",
"C",
"C",
"PG",
"C",
"C",
"C",
"C",
"PG",
"PF",
"PF",
"SF",
"SF",
"SF",
"SF",
"PG",
"PG",
"PF",
"PF",
"SF",
"PF",
"PG",
"SG",
"PG",
"PG",
"PG",
"SF",
"SF",
"SF",
"SG",
"C",
"C",
"PF",
"SG",
"PG",
"PF",
"PG",
"PF",
"PF",
"PF",
"PG",
"SF",
"PG",
"C",
"PG",
"SF",
"PG",
"PG",
"SF",
"SF",
"SF",
"SG",
"C",
"C",
"C",
"C",
"PF",
"PF",
"SG",
"SF",
"SG",
"SG",
"C",
"PF",
"PF",
"C",
"C",
"SG",
"C",
"PF",
"C",
"SG",
"SG",
"C",
"SF",
"PF",
"SF",
"PG",
"PG",
"PG",
"PF",
"PG",
"PF",
"SG",
"PG",
"PG",
"PG",
"SG",
"SF",
"SF",
"SF",
"PG",
"PG",
"SG",
"SG",
"SG",
"PF",
"PG",
"PG",
"PF",
"SF",
"SG",
"PF",
"PF",
"SF",
"SG",
"SF",
"SF",
"PG",
"PG",
"SF",
"SF",
"SF",
"SF",
"PF",
"PF",
"PF",
"PF",
"C",
"C",
"C",
"PG",
"SG",
"SF",
"SF",
"SF",
"SF",
"PF",
"PF",
"SF",
"C",
"C",
"SF",
"SF",
"C",
"C",
};
            string[] overall = new string[] {"96",
"94",
"94",
"88",
"88",
"94",
"94",
"94",
"90",
"89",
"88",
"87",
"87",
"87",
"85",
"86",
"86",
"84",
"89",
"88",
"82",
"88",
"85",
"85",
"84",
"89",
"87",
"85",
"89",
"82",
"84",
"86",
"86",
"85",
"85",
"85",
"85",
"85",
"82",
"80",
"80",
"84",
"85",
"86",
"83",
"83",
"81",
"83",
"83",
"81",
"82",
"85",
"83",
"84",
"79",
"78",
"81",
"80",
"78",
"79",
"81",
"81",
"81",
"81",
"81",
"82",
"81",
"78",
"77",
"78",
"79",
"78",
"79",
"80",
"79",
"78",
"79",
"77",
"81",
"84",
"78",
"79",
"80",
"76",
"80",
"77",
"79",
"80",
"76",
"76",
"77",
"79",
"76",
"80",
"80",
"79",
"78",
"78",
"79",
"78",
"79",
"79",
"78",
"78",
"77",
"76",
"75",
"76",
"77",
"75",
"75",
"78",
"78",
"77",
"77",
"77",
"79",
"75",
"76",
"78",
"76",
"78",
"77",
"80",
"76",
"78",
"79",
"77",
"78",
"77",
"75",
"75",
"76",
"76",
"76",
"75",
"75",
"74",
"74",
"75",
"74",
"76",
"74",
"75",
"76",
"78",
"73",
"73",
"73",
"73",
"77",
"78",
"77",
"77",
"74",
"77",
"75",
"77",
"78",
"74",
"79",
"78",
"74",
"74",
"74",
"74",
"74",
"76",
"76",
"76",
"76",
"75",
"75",
"74",
"77",
"77",
"75",
"75",
"75",
"76",
"74",
"74",
"75",
"69",
"75",
"76",
"74",
"74",
"74",
"72",
"73",
"73",
"72",
"77",
"72",
"77",
"75",
"75",
"75",
"75",
"75",
"76",
"76",
"76",
"74",
"76",
"76",
"75",
"75",
"75",
"74",
"74",
"74",
"74",
"73",
"73",
"75",
"73",
"75",
"71",
"74",
"74",
"72",
"72",
"74",
"73",
"73",
"73",
"71",
"73",
"73",
"73",
"73",
"73",
"74",
"73",
"72",
"72",
"72",
"71",
"72",
"70",
"70",
"70",
"70",
"71",
"68",
"74",
"74",
"74",
"72",
"73",
"72",
"74",
"74",
"72",
"73",
"73",
"74",
"74",
"74",
"69",
"71",
"73",
"73",
"73",
"73",
"72",
"72",
"73",
"69",
"70",
"72",
"71",
"73",
"72",
"73",
"73",
"71",
"68",
"72",
"71",
"74",
"69",
"69",
"69",
"69",
"72",
"72",
"73",
"73",
"73",
"72",
"70",
"73",
"74",
"73",
"72",
"72",
"72",
"70",
"71",
"71",
"72",
"71",
"72",
"70",
"72",
"70",
"70",
"72",
"68",
"68",
"68",
"68",
"71",
"71",
"71",
"71",
"72",
"72",
"72",
"70",
"70",
"72",
"70",
"72",
"72",
"72",
"70",
"71",
"69",
"68",
"68",
"71",
"69",
"71",
"71",
"71",
"70",
"69",
"71",
"71",
"71",
"71",
"71",
"72",
"69",
"69",
"68",
"70",
"69",
"69",
"69",
"69",
"70",
"69",
"70",
"71",
"71",
"71",
"71",
"71",
"70",
"70",
"70",
"70",
"70",
"69",
"70",
"70",
"70",
"70",
"70",
"70",
"70",
"70",
"70",
"70",
"70",
"69",
"69",
"69",
"69",
"69",
"69",
"69",
"69",
"69",
"69",
"69",
"68",
"68",
"69",
"69",
};
            string[] price = new string[] { "2050",
"2000",
"2000",
"2000",
"1950",
"1900",
"1900",
"1900",
"1850",
"1850",
"1850",
"1800",
"1800",
"1800",
"1750",
"1750",
"1700",
"1700",
"1650",
"1650",
"1650",
"1600",
"1550",
"1550",
"1550",
"1500",
"1500",
"1500",
"1500",
"1500",
"1450",
"1400",
"1350",
"1350",
"1300",
"1300",
"1250",
"1250",
"1250",
"1225",
"1225",
"1225",
"1225",
"1225",
"1175",
"1175",
"1175",
"1150",
"1150",
"1125",
"1125",
"1100",
"1100",
"1100",
"1100",
"1075",
"1075",
"1075",
"1050",
"1050",
"1025",
"1025",
"1025",
"1025",
"1025",
"1025",
"1000",
"1000",
"975",
"975",
"975",
"975",
"950",
"950",
"950",
"950",
"950",
"950",
"925",
"925",
"925",
"925",
"900",
"875",
"875",
"875",
"850",
"850",
"850",
"850",
"825",
"800",
"775",
"750",
"750",
"750",
"750",
"725",
"725",
"725",
"725",
"700",
"700",
"700",
"675",
"675",
"675",
"675",
"650",
"650",
"650",
"625",
"600",
"600",
"600",
"600",
"600",
"575",
"550",
"550",
"550",
"550",
"550",
"525",
"525",
"525",
"525",
"525",
"525",
"525",
"500",
"500",
"500",
"500",
"475",
"475",
"475",
"475",
"475",
"450",
"450",
"450",
"450",
"450",
"450",
"450",
"425",
"425",
"425",
"425",
"425",
"425",
"425",
"400",
"400",
"400",
"375",
"375",
"375",
"375",
"375",
"375",
"375",
"375",
"350",
"350",
"350",
"350",
"350",
"350",
"350",
"350",
"350",
"350",
"350",
"325",
"325",
"325",
"325",
"325",
"325",
"325",
"325",
"325",
"325",
"325",
"325",
"300",
"300",
"300",
"300",
"300",
"300",
"300",
"300",
"300",
"300",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"275",
"250",
"250",
"250",
"250",
"250",
"250",
"250",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"225",
"200",
"200",
"200",
"200",
"200",
"200",
"200",
"200",
"200",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"175",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"150",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"125",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"100",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"75",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
"50",
};
            string[] round = new string[] { "第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第一轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第二轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第三轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第四轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第五轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第六轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第七轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第八轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第九轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十一轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十二轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
"第十三轮",
};
            for (int i = 0; i < 395; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = id[i];
                lvi.SubItems.Add(ename[i]);
                lvi.SubItems.Add(position[i]);
                lvi.SubItems.Add(overall[i]);
                lvi.SubItems.Add(price[i]);
                lvi.SubItems.Add(round[i]);
                lvi.SubItems.Add("");
                this.lv_allprice.Items.Add(lvi);
            }
            //初始化participantslist
            for (int i = 0; i < 30; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i+1).ToString();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                this.lv_participantslist.Items.Add(lvi);
            }
            //初始化SelectedPlayer
            for (int i = 1; i <= 30;i++ )
            {
                SelectedPlayer[i] = "MyPlayers,";
            }


        }
        /// <summary>
        /// 将listview里面的价格表转化成可以提供给客户端的string
        /// </summary>
        public void transPricelist()
        {
            foreach (ListViewItem item in this.lv_allprice.Items)
            {
                if (item.SubItems[6].Text.ToString() == "")
                {

                    strPriceList += item.SubItems[0].Text.ToString() + ",";
                    strPriceList += item.SubItems[1].Text.ToString() + ",";
                    strPriceList += item.SubItems[2].Text.ToString() + ",";
                    strPriceList += item.SubItems[3].Text.ToString() + ",";
                    strPriceList += item.SubItems[4].Text.ToString() + ",";
                    strPriceList += item.SubItems[5].Text.ToString() + ",";
                }

            }
        }
        /// <summary>
        /// 强行过人按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_nextround_Click(object sender, EventArgs e)
        {
            timecount = 0;
            int selectedbefore=0;
            //让客户端删掉当前最贵的
            string autoselect="DeleteRow,0,";
            foreach (ListViewItem item in this.lv_allprice.Items)
            {
                if (item.SubItems[6].Text.ToString() != "")
                {
                    selectedbefore++;
                }
                else
                    break;
            }
            //给'被选'加上标签
            lv_allprice.Items[selectedbefore].SubItems[6].Text = lb_pick.Text;
            //给我的球员SelectedPlayer数组增加数据
            SelectedPlayer[int.Parse(lb_pick.Text)] += this.lv_allprice.Items[selectedbefore].SubItems[0].Text + "," + this.lv_allprice.Items[selectedbefore].SubItems[1].Text + "," + this.lv_allprice.Items[selectedbefore].SubItems[4].Text + ",";
            //套接Notification的string
            string notificationstring="Notification, \n管理强行过人："+ lb_round.Text +"轮" +lb_pick.Text + "号签选了：";
            notificationstring+=this.lv_allprice.Items[selectedbefore].SubItems[1].Text +",价格：";
            notificationstring+=this.lv_allprice.Items[selectedbefore].SubItems[4].Text +",编号：";
            notificationstring+=this.lv_allprice.Items[selectedbefore].SubItems[0].Text+ " \n";
            showinfo.AppendText(notificationstring);
            //套接完毕，发送
            Byte[] byteAutoselectLine = System.Text.Encoding.UTF8.GetBytes(autoselect);
            Byte[] byteNotificationLine = System.Text.Encoding.UTF8.GetBytes(notificationstring);
            try
            {
                for (int i = 0; i < 29; i++)
                    if (Client[i]!=null&&Client[i].Connected)
                    {
                        Client[i].Send(byteNotificationLine, byteNotificationLine.Length, 0);
                        //Thread.Sleep(100);
                        Client[i].Send(byteAutoselectLine, byteAutoselectLine.Length, 0);
                    }
                //for (int i = 0; i < 29; i++)
                //    if (Client[i]!=null&&Client[i].Connected)
                    
            }
            catch (System.Exception ex)
            {
            }
            Thread.Sleep(1600);
            //套接SyncTime的string
            string timesyncString = "SyncTime," + roundcount.ToString() + "," + pickcount.ToString() + ",69";
            Byte[] bytetimesyncString = System.Text.Encoding.UTF8.GetBytes(timesyncString);
            try
            {
                for (int i = 0; i < 29; i++)
                    if (Client[i]!=null&&Client[i].Connected)
                    Client[i].Send(bytetimesyncString, bytetimesyncString.Length, 0);
            }
            catch (System.Exception ex)
            {
            }
            
            
        }
        /// <summary>
        /// 导出为Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_export_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DoExport(this.lv_allprice, sfd.FileName);
            }
        }
        //导出Excel方法
        private void DoExport(ListView listView, string strFileName)
        {
            int rowNum = listView.Items.Count;
            int columnNum = listView.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表第一行
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;
                MessageBox.Show("价格表导出成功!");
            }
        }

        /// <summary>
        /// 清空选定的‘被选’
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_clearselected_Click(object sender, EventArgs e)
        {
            if (lv_allprice.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择一个球员");
                return;
            }
            int prow = this.lv_allprice.SelectedItems[0].Index;
            this.lv_allprice.Items[prow].SubItems[6].Text = "";
            updateSelected();

        }
        /// <summary>
        /// 更新SelectedPlayer[]公有函数
        /// </summary>
        public void updateSelected()
        {
            for (int i = 1; i <= 30; i++)
            {
                SelectedPlayer[i] = "MyPlayers,";
            }
            //SelectedPlayer[int.Parse(lb_pick.Text)] += this.lv_allprice.Items[selectedbefore].SubItems[0].Text + "," + this.lv_allprice.Items[selectedbefore].SubItems[1].Text + "," + this.lv_allprice.Items[selectedbefore].SubItems[4].Text + ",";
            int index;
            for (int i = 1; i <= this.lv_allprice.Items.Count; i++)
            {
                if (lv_allprice.Items[i-1].SubItems[6].Text != "")
                {
                    index = int.Parse(lv_allprice.Items[i-1].SubItems[6].Text);
                    SelectedPlayer[index] += this.lv_allprice.Items[i-1].SubItems[0].Text + "," + this.lv_allprice.Items[i-1].SubItems[1].Text + "," + this.lv_allprice.Items[i-1].SubItems[4].Text + ",";
                }
            }
        }

        public void checkstatus()
        {
            for (int i=0;i<30;i++)
            {
                if(Client[i]!=null && Client[i].Connected)
                {
                    this.lv_participantslist.Items[i].SubItems[1].Text = "在线";
                }
                else if (Client[i] == null)
                    this.lv_participantslist.Items[i].SubItems[1].Text = "";
                else
                    this.lv_participantslist.Items[i].SubItems[1].Text = "离线";
            }
        }

        private void showinfo_TextChanged(object sender, EventArgs e)
        {
            showinfo.SelectionStart = showinfo.Text.Length;
            showinfo.ScrollToCaret();
        }

        private void bt_assignfor_Click(object sender, EventArgs e)
        {
            if (lv_allprice.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择一个球员");
                return;
            }
            int prow = this.lv_allprice.SelectedItems[0].Index;
            this.lv_allprice.Items[prow].SubItems[6].Text = cb_pick.Text.ToString();
            updateSelected();
        }

        private void bt_tooffline_Click(object sender, EventArgs e)
        {
            if (lv_participantslist.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请在玩家总览内选择一个玩家签位");
                return;
            }
            int index = this.lv_participantslist.SelectedItems[0].Index;
            this.lv_participantslist.Items[index].SubItems[1].Text = "离线";
            try
            {
                Client[index].Close();
            }
            catch (System.Exception ex)
            {
            }
            clientnumber--;
            lb_clientnumber.Text = clientnumber.ToString();
        }

        private void bt_tocomputer_Click(object sender, EventArgs e)
        {
            if (lv_participantslist.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请在玩家总览内选择一个玩家签位");
                return;
            }
            int index = this.lv_participantslist.SelectedItems[0].Index;
            this.lv_participantslist.Items[index].SubItems[1].Text = "";
            try
            {
                Client[index].Close();
            }
            catch (System.Exception ex)
            {
            }
            clientnumber--;
            lb_clientnumber.Text = clientnumber.ToString(); 
        }

        private void bt_playercount_Click(object sender, EventArgs e)
        {
            int index;
            for (int i = 1; i <= 30; i++)
            {
                SelectedCount[i] = 0;
            }
            for (int i = 1; i <= this.lv_allprice.Items.Count; i++)
            {
                if (lv_allprice.Items[i - 1].SubItems[6].Text != "")
                {
                    index = int.Parse(lv_allprice.Items[i - 1].SubItems[6].Text);
                    SelectedCount[index]++;
                }
            }
            for (int i = 0; i < 30; i++)
            {
                this.lv_participantslist.Items[i].SubItems[3].Text = SelectedCount[i+1].ToString();
            }
        }
    }
}
