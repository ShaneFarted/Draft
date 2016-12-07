using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class client : Form
    {
        public Socket newclient;
        public bool Connected;
        public Thread myThread;
        public Thread timeThread;
        public Thread autorefreashThread;
        public Thread uiProctor;
        public delegate void MyInvoke(string str);
        public int roundcount=-1,pickcount=-1,timecount=-1;
        private string InvatationCode = "88888";
        private string clientrank;

        public client()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void client_Load(object sender, EventArgs e)
        {
            
        }
        public void Connect()
        {
            byte[] data = new byte[1024];
            newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string ipadd = serverIP.Text.Trim();
            int port = Convert.ToInt32(serverPort.Text.Trim());
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);
            try
            {
                if(invcode.Text!=InvatationCode)
                {
                    MessageBox.Show("邀请码错误");
                    return;
                }
                newclient.Connect(ie);
                bt_connect.Enabled = false;
                bt_disconnect.Enabled = true;
                Connected = true;
            }
            catch (SocketException e)
            {
                MessageBox.Show("连接服务器失败    " + e.Message);
                return;
            }
            //新建接受服务器消息线程
            ThreadStart myThreaddelegate = new ThreadStart(ReceiveMsg);
            ThreadStart timeThreadDelegate = new ThreadStart(countdown);
            ThreadStart autorefreshThreadDelegate = new ThreadStart(autorefresh);
            myThread = new Thread(myThreaddelegate);
            timeThread = new Thread(timeThreadDelegate);
            autorefreashThread = new Thread(autorefreshThreadDelegate);
            uiProctor = new Thread(new ThreadStart(uiUpdate));
            myThread.Start();
            //初始化轮次倒计时线程
            timeThread.Start();
            uiProctor.Start();
        }

        /// <summary>
        /// UI更新函数
        /// </summary>
        public void uiUpdate()
        {
            while (true)
            {
                if (listissynced())
                {
                    lb_liststatus.Text = "正常";
                    lb_liststatus.ForeColor = Color.White;
                }
                else
                {
                    lb_liststatus.Text = "状态异常，请尝试同步名单";
                    lb_liststatus.ForeColor = Color.Red;
                }   
            }
        }

        /// <summary>
        /// 倒数计时函数
        /// </summary>
        public void countdown()
        {
            while(true)
            {
                while (timecount > 0)
                {
                    timecount -= 1;
                    Thread.Sleep(1000);
                    lb_second.Text = timecount.ToString();
                    lb_round.Text = roundcount.ToString();
                    lb_pick.Text = pickcount.ToString();
                    if (mypick.Text.Trim() == lb_pick.Text)
                    {
                        this.bt_pickplayer.Enabled = true;
                    }
                }
                if (timecount==0) //时间到，自动选一个当前价格 第2高 的球员，并向服务器同步最新轮次签位时间，区别是否为自选
                {
                    this.bt_pickplayer.Enabled = false;
                    if (mypick.Text == lb_pick.Text) //为自己签位，时间到，进行自选后走向下一轮
                    {
                        lv_pricelist.Focus();
                        lv_pricelist.Items[1].Selected = true;
                        timecount = -2;
                        PickPlayerNum(1);
                        Thread.Sleep(1100);
                        RequestSyncTime();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        RequestSyncTime();
                    }
                }
                else if (timecount == -2) //选后自动跳到-2，并向服务器同步最新轮次签位时间
                {
                    this.bt_pickplayer.Enabled = false;
                }

            }
            
        }
        /// <summary>
        /// 名单状态守护
        /// </summary>
        /// <returns></returns>
        public bool listissynced()
        {
            int pick=int.Parse(lb_pick.Text);
            int round=int.Parse(lb_round.Text);
            int selected;
            if (round % 2 == 0 && round>0)//偶数轮
            {
                selected = (round - 1) * 30 + (30 - pick);
            }
            else if (round % 2 != 0)  //奇数轮
                selected = (round - 1) * 30 + pick-1;
            else
                selected = 0;
            if (lv_pricelist.Items.Count == 395 - selected)
                return true;
                return false;

        }

        /// <summary>
        /// 90秒自动强制刷新名单
        /// </summary>
        public void autorefresh()
        {
            while(true)
            {
                Random ran=new Random();
                Thread.Sleep(90000 - ran.Next(-5000, 5000));
                try
                {
                    byte[] data = new byte[25];
                    data = Encoding.UTF8.GetBytes("RequestList");
                    int i = newclient.Send(data);
                    data = Encoding.UTF8.GetBytes("RequestMyPlayers," + mypick.Text + ",");
                    i = newclient.Send(data);
                    lv_pricelist.Focus();
                    lv_pricelist.Items[1].Selected = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("自动刷新名单失败！请手动尝试");
                }
                
            }
        }
        /// <summary>
        /// 接受来自服务器的消息函数
        /// </summary>
        public void ReceiveMsg()
        {
            while (true)
            {
                byte[] data = new byte[204800];  //定义数据大小
                int recv = newclient.Receive(data);
                string stringdata = Encoding.UTF8.GetString(data, 0, recv);
                //判断所得数据的类型 索引0为类型，其后为数据
                string[] stringdatatype=stringdata.Split(',');

                switch (stringdatatype[0])
                {
                    //若为价格表
                    case "PriceList":
                        {
                            this.lv_pricelist.Items.Clear();
                            for (int i = 1; i < stringdatatype.Length - 1; i += 6)
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = stringdatatype[i];
                                lvi.SubItems.Add(stringdatatype[i + 1]);
                                lvi.SubItems.Add(stringdatatype[i + 2]);
                                lvi.SubItems.Add(stringdatatype[i + 3]);
                                lvi.SubItems.Add(stringdatatype[i + 4]);
                                lvi.SubItems.Add(stringdatatype[i + 5]);
                                lvi.ForeColor = Color.White;
                                this.lv_pricelist.Items.Add(lvi);
                            }
                            lv_pricelist.Focus();
                            lv_pricelist.Items[1].Selected = true;
                            break;
                        }
                    //若为开始计时信号
                    case "StartSig":
                        {
                            //Random ran = new Random();
                            timecount = 60;
                            roundcount = 1;
                            pickcount = 1;
                            break;
                        }
                    //若为服务器重启后继续信号
                    case "ContinueSig":
                        {
                            break;
                        }
                    //若为删除价格表某行
                    case "DeleteRow":
                        {
                            this.lv_pricelist.Items[int.Parse(stringdatatype[1])].Remove();
                            break;
                        }
                    //若为同步时间请求
                    case "SyncTime":
                        {
                            try
                            {
                                timecount = int.Parse(stringdatatype[3]);
                                roundcount = int.Parse(stringdatatype[1]);
                                pickcount = int.Parse(stringdatatype[2]);
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show("服务器时间同步失败!请重新修复卡时间!");
                            }
                            break;
                        }
                    case "Notification":
                        {
                            bx_receiveMsg.AppendText(stringdatatype[1]);
                            break;
                        }
                    case "MyPlayers":
                        {
                            this.lv_myplayers.Items.Clear();
                            for (int i = 1; i < stringdatatype.Length - 1; i +=3 )
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = stringdatatype[i];
                                lvi.SubItems.Add(stringdatatype[i + 1]);
                                lvi.SubItems.Add(stringdatatype[i + 2]);
                                lvi.ForeColor = Color.White;
                                this.lv_myplayers.Items.Add(lvi);
                            }
                            break;
                        }
                    case "RequestIntroduction":
                        {
                            autorefreashThread.Start(); //启动线程,每90秒刷新名单
                            showMsg(stringdatatype[1] + stringdatatype[2]+stringdatatype[3] + "\r\n");
                            //clientrank=stringdatatype[2].ToString();
                            string introstring = "Introduction,玩家"+ myid.Text +"加入服务器 签位：,"+ mypick.Text;
                            Byte[] byteIntroLine = System.Text.Encoding.UTF8.GetBytes(introstring);
                            newclient.Send(byteIntroLine, byteIntroLine.Length, 0);
                            break;
                        }
                    case "Rejected":
                        {
                            MessageBox.Show("您选的球员已被其他玩家选走，请重新挑选，或联系管理员");
                            break;
                        }

                    //默认直接显示在选秀实况里面
                    default:
                        {
                            showMsg(stringdata + "\r\n");
                            break;
                        }
                        
                }

                    
                
                //receiveMsg.AppendText(stringdata + "\r\n");
            }
        }


        public void showMsg(string msg)
        {
            {
                //在线程里以安全方式调用控件
                if (bx_receiveMsg.InvokeRequired)
                {
                    MyInvoke _myinvoke = new MyInvoke(showMsg);
                    bx_receiveMsg.Invoke(_myinvoke, new object[] { msg });
                }
                else
                {
                    bx_receiveMsg.AppendText(msg);
                }
            }
        }


        private void SendMsg_Click(object sender, EventArgs e)
        {
            int m_length = mymessage.Text.Length;
            byte[] data = new byte[m_length];
            data = Encoding.UTF8.GetBytes(mymessage.Text);
            int i = newclient.Send(data);
            showMsg("我说：" + mymessage.Text + "\r\n");
            //receiveMsg.AppendText("我说："+mymessage.Text + "\r\n");
            mymessage.Text = "";
            //newclient.Shutdown(SocketShutdown.Both);
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(myid.Text)||string.IsNullOrEmpty(mypick.Text))
            {
                MessageBox.Show("请输入正确的名称和签位");
                return;
            }
            myid.ReadOnly = true;
            mypick.Enabled = false;
            Connect();
            
            
        }

        /// <summary>
        /// 我的球队已选球员按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_namelist_Click(object sender, EventArgs e)
        {
            picklist pl=new picklist(newclient,mypick.Text);
            pl.ShowDialog();
        }

        /// <summary>
        /// 同步服务器名单按钮,发送请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_synclist_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[11];
            data = Encoding.UTF8.GetBytes("RequestList");
            int i = newclient.Send(data);

        }

        /// <summary>
        /// 确认选入按钮，发送请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_pickplayer_Click(object sender, EventArgs e)
        {
            int prow = this.lv_pricelist.SelectedItems[0].Index;
            ListViewItem lvi = new ListViewItem();
            lvi.Text = this.lv_pricelist.Items[prow].SubItems[0].Text ;
            lvi.SubItems.Add(this.lv_pricelist.Items[prow].SubItems[1].Text);
            lvi.SubItems.Add(this.lv_pricelist.Items[prow].SubItems[4].Text);
            lvi.ForeColor = Color.White;
            this.lv_myplayers.Items.Add(lvi);
            PickPlayerNum(prow);
            GoNextRound();
            lv_pricelist.Focus();
            lv_pricelist.Items[1].Selected = true;
        }

        /// <summary>
        /// 向服务器提交进入下一轮请求
        /// </summary>
        public void GoNextRound()
        {
            timecount = -2;
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes("GoNextRound,"+lb_round.Text+"," +lb_pick.Text+",");
            int i = newclient.Send(data);
        }

        /// <summary>
        /// 请求同步时间
        /// </summary>
        public void RequestSyncTime()
        {
            byte[] data = new byte[25];
            data = Encoding.UTF8.GetBytes("RequestSyncTime,");
            int i = newclient.Send(data);
        }

        /// <summary>
        /// 选指定某行球员
        /// </summary>
        /// <param name="RowNumber"></param>
        public void PickPlayerNum(int RowNumber)
        {
            this.bt_pickplayer.Enabled = false;
            string pid, pename, pposition, poverall, pprice, pround,  participantname, participantround, participantpick;
            int selectedrow;
            if (this.lv_pricelist.SelectedItems.Count>0)
            {
                selectedrow = this.lv_pricelist.SelectedItems[0].Index; //Dangerous
            }
            else
                selectedrow=0;
            

            pid = this.lv_pricelist.Items[RowNumber].SubItems[0].Text;
            pename = this.lv_pricelist.Items[RowNumber].SubItems[1].Text;
            pposition = this.lv_pricelist.Items[RowNumber].SubItems[2].Text;
            poverall = this.lv_pricelist.Items[RowNumber].SubItems[3].Text;
            pprice = this.lv_pricelist.Items[RowNumber].SubItems[4].Text;
            pround = this.lv_pricelist.Items[RowNumber].SubItems[5].Text;

            participantname = this.myid.Text;
            participantround = this.lb_round.Text;
            participantpick = this.mypick.Text;

            byte[] data = new byte[10240];
            data = Encoding.UTF8.GetBytes("RequestPick," + pid + "," + pename + "," + pposition + "," + poverall + "," + pprice + "," + pround + "," + RowNumber.ToString() + "," + participantname + "," + participantround + "," + participantpick);
            int i = newclient.Send(data);
        }

        private void bt_fixtime_Click(object sender, EventArgs e)
        {
            RequestSyncTime();
        }

        private void bt_syncmyplayer_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[25];
            data = Encoding.UTF8.GetBytes("RequestMyPlayers,"+ mypick.Text+",");
            int i = newclient.Send(data);
            lv_pricelist.Focus();
            lv_pricelist.Items[1].Selected = true;
        }

        private void client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("\n确定要强退吗？\n\n注：在管理未通知的前提下强行关闭客户端可能会导致你的球员数据信息出错", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    byte[] data = new byte[30];
                    data = Encoding.UTF8.GetBytes("Disconnect," + mypick.Text + ",号签玩家" + myid.Text + "掉线" );
                    int i = newclient.Send(data);
                    newclient.Close();
                    timeThread.Abort();
                    myThread.Abort();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }
        /// <summary>
        /// 导出Excel文件按钮
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
                DoExport(this.lv_myplayers, sfd.FileName);
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

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = new byte[30];
                data = Encoding.UTF8.GetBytes("Disconnect," + mypick.Text + ",号签玩家" + myid.Text + "掉线");
                int i = newclient.Send(data);
                newclient.Close();
                autorefreashThread.Abort();
                timeThread.Abort();
                myThread.Abort();
                bt_connect.Enabled = true;
                bt_disconnect.Enabled = false;
            }
            catch (System.Exception ex)
            {
            }
        }

        private void bx_receiveMsg_TextChanged(object sender, EventArgs e)
        {
            bx_receiveMsg.SelectionStart = bx_receiveMsg.Text.Length;
            bx_receiveMsg.ScrollToCaret();
        }



        

  
    }
}
