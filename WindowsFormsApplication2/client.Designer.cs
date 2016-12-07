namespace WindowsFormsApplication2
{
    partial class client
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client));
            this.label1 = new System.Windows.Forms.Label();
            this.serverPort = new System.Windows.Forms.TextBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bx_receiveMsg = new System.Windows.Forms.RichTextBox();
            this.mymessage = new System.Windows.Forms.TextBox();
            this.SendMsg = new System.Windows.Forms.Button();
            this.bt_connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_timename = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_myid = new System.Windows.Forms.Label();
            this.myid = new System.Windows.Forms.TextBox();
            this.lb_mypick = new System.Windows.Forms.Label();
            this.lb_roundname = new System.Windows.Forms.Label();
            this.lb_pickname = new System.Windows.Forms.Label();
            this.lb_round = new System.Windows.Forms.Label();
            this.lb_pick = new System.Windows.Forms.Label();
            this.lb_second = new System.Windows.Forms.Label();
            this.lb_secondname = new System.Windows.Forms.Label();
            this.lv_pricelist = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Overall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Round = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_synclist = new System.Windows.Forms.Button();
            this.bt_pickplayer = new System.Windows.Forms.Button();
            this.bt_fixtime = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.invcode = new System.Windows.Forms.TextBox();
            this.lv_myplayers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_syncmyplayer = new System.Windows.Forms.Button();
            this.bt_namelist = new System.Windows.Forms.Button();
            this.bt_export = new System.Windows.Forms.Button();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.lb_liststatusname = new System.Windows.Forms.Label();
            this.lb_liststatus = new System.Windows.Forms.Label();
            this.mypick = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // serverPort
            // 
            resources.ApplyResources(this.serverPort, "serverPort");
            this.serverPort.Name = "serverPort";
            // 
            // serverIP
            // 
            resources.ApplyResources(this.serverIP, "serverIP");
            this.serverIP.Name = "serverIP";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // bx_receiveMsg
            // 
            resources.ApplyResources(this.bx_receiveMsg, "bx_receiveMsg");
            this.bx_receiveMsg.Name = "bx_receiveMsg";
            this.bx_receiveMsg.TextChanged += new System.EventHandler(this.bx_receiveMsg_TextChanged);
            // 
            // mymessage
            // 
            resources.ApplyResources(this.mymessage, "mymessage");
            this.mymessage.Name = "mymessage";
            // 
            // SendMsg
            // 
            resources.ApplyResources(this.SendMsg, "SendMsg");
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.UseVisualStyleBackColor = true;
            this.SendMsg.Click += new System.EventHandler(this.SendMsg_Click);
            // 
            // bt_connect
            // 
            resources.ApplyResources(this.bt_connect, "bt_connect");
            this.bt_connect.ForeColor = System.Drawing.Color.Red;
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // lb_timename
            // 
            resources.ApplyResources(this.lb_timename, "lb_timename");
            this.lb_timename.BackColor = System.Drawing.Color.Transparent;
            this.lb_timename.ForeColor = System.Drawing.Color.Red;
            this.lb_timename.Name = "lb_timename";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // lb_myid
            // 
            resources.ApplyResources(this.lb_myid, "lb_myid");
            this.lb_myid.BackColor = System.Drawing.Color.Transparent;
            this.lb_myid.ForeColor = System.Drawing.Color.White;
            this.lb_myid.Name = "lb_myid";
            // 
            // myid
            // 
            resources.ApplyResources(this.myid, "myid");
            this.myid.Name = "myid";
            // 
            // lb_mypick
            // 
            resources.ApplyResources(this.lb_mypick, "lb_mypick");
            this.lb_mypick.BackColor = System.Drawing.Color.Transparent;
            this.lb_mypick.ForeColor = System.Drawing.Color.White;
            this.lb_mypick.Name = "lb_mypick";
            // 
            // lb_roundname
            // 
            resources.ApplyResources(this.lb_roundname, "lb_roundname");
            this.lb_roundname.BackColor = System.Drawing.Color.Transparent;
            this.lb_roundname.ForeColor = System.Drawing.Color.White;
            this.lb_roundname.Name = "lb_roundname";
            // 
            // lb_pickname
            // 
            resources.ApplyResources(this.lb_pickname, "lb_pickname");
            this.lb_pickname.BackColor = System.Drawing.Color.Transparent;
            this.lb_pickname.ForeColor = System.Drawing.Color.White;
            this.lb_pickname.Name = "lb_pickname";
            // 
            // lb_round
            // 
            resources.ApplyResources(this.lb_round, "lb_round");
            this.lb_round.BackColor = System.Drawing.Color.Transparent;
            this.lb_round.ForeColor = System.Drawing.Color.Red;
            this.lb_round.Name = "lb_round";
            // 
            // lb_pick
            // 
            resources.ApplyResources(this.lb_pick, "lb_pick");
            this.lb_pick.BackColor = System.Drawing.Color.Transparent;
            this.lb_pick.ForeColor = System.Drawing.Color.Red;
            this.lb_pick.Name = "lb_pick";
            // 
            // lb_second
            // 
            resources.ApplyResources(this.lb_second, "lb_second");
            this.lb_second.BackColor = System.Drawing.Color.Transparent;
            this.lb_second.ForeColor = System.Drawing.Color.Red;
            this.lb_second.Name = "lb_second";
            // 
            // lb_secondname
            // 
            resources.ApplyResources(this.lb_secondname, "lb_secondname");
            this.lb_secondname.BackColor = System.Drawing.Color.Transparent;
            this.lb_secondname.ForeColor = System.Drawing.Color.Red;
            this.lb_secondname.Name = "lb_secondname";
            // 
            // lv_pricelist
            // 
            resources.ApplyResources(this.lv_pricelist, "lv_pricelist");
            this.lv_pricelist.BackgroundImageTiled = true;
            this.lv_pricelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Ename,
            this.Position,
            this.Overall,
            this.Price,
            this.Round});
            this.lv_pricelist.FullRowSelect = true;
            this.lv_pricelist.MultiSelect = false;
            this.lv_pricelist.Name = "lv_pricelist";
            this.lv_pricelist.UseCompatibleStateImageBehavior = false;
            this.lv_pricelist.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            resources.ApplyResources(this.Id, "Id");
            // 
            // Ename
            // 
            resources.ApplyResources(this.Ename, "Ename");
            // 
            // Position
            // 
            resources.ApplyResources(this.Position, "Position");
            // 
            // Overall
            // 
            resources.ApplyResources(this.Overall, "Overall");
            // 
            // Price
            // 
            resources.ApplyResources(this.Price, "Price");
            // 
            // Round
            // 
            resources.ApplyResources(this.Round, "Round");
            // 
            // bt_synclist
            // 
            resources.ApplyResources(this.bt_synclist, "bt_synclist");
            this.bt_synclist.Name = "bt_synclist";
            this.bt_synclist.UseVisualStyleBackColor = true;
            this.bt_synclist.Click += new System.EventHandler(this.bt_synclist_Click);
            // 
            // bt_pickplayer
            // 
            resources.ApplyResources(this.bt_pickplayer, "bt_pickplayer");
            this.bt_pickplayer.ForeColor = System.Drawing.Color.Red;
            this.bt_pickplayer.Name = "bt_pickplayer";
            this.bt_pickplayer.UseVisualStyleBackColor = true;
            this.bt_pickplayer.Click += new System.EventHandler(this.bt_pickplayer_Click);
            // 
            // bt_fixtime
            // 
            resources.ApplyResources(this.bt_fixtime, "bt_fixtime");
            this.bt_fixtime.Name = "bt_fixtime";
            this.bt_fixtime.UseVisualStyleBackColor = true;
            this.bt_fixtime.Click += new System.EventHandler(this.bt_fixtime_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // invcode
            // 
            resources.ApplyResources(this.invcode, "invcode");
            this.invcode.Name = "invcode";
            // 
            // lv_myplayers
            // 
            resources.ApplyResources(this.lv_myplayers, "lv_myplayers");
            this.lv_myplayers.BackgroundImageTiled = true;
            this.lv_myplayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
            this.lv_myplayers.FullRowSelect = true;
            this.lv_myplayers.Name = "lv_myplayers";
            this.lv_myplayers.UseCompatibleStateImageBehavior = false;
            this.lv_myplayers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // bt_syncmyplayer
            // 
            resources.ApplyResources(this.bt_syncmyplayer, "bt_syncmyplayer");
            this.bt_syncmyplayer.Name = "bt_syncmyplayer";
            this.bt_syncmyplayer.UseVisualStyleBackColor = true;
            this.bt_syncmyplayer.Click += new System.EventHandler(this.bt_syncmyplayer_Click);
            // 
            // bt_namelist
            // 
            resources.ApplyResources(this.bt_namelist, "bt_namelist");
            this.bt_namelist.Name = "bt_namelist";
            this.bt_namelist.UseVisualStyleBackColor = true;
            this.bt_namelist.Click += new System.EventHandler(this.bt_namelist_Click);
            // 
            // bt_export
            // 
            resources.ApplyResources(this.bt_export, "bt_export");
            this.bt_export.Name = "bt_export";
            this.bt_export.UseVisualStyleBackColor = true;
            this.bt_export.Click += new System.EventHandler(this.bt_export_Click);
            // 
            // bt_disconnect
            // 
            resources.ApplyResources(this.bt_disconnect, "bt_disconnect");
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // lb_liststatusname
            // 
            resources.ApplyResources(this.lb_liststatusname, "lb_liststatusname");
            this.lb_liststatusname.BackColor = System.Drawing.Color.Transparent;
            this.lb_liststatusname.ForeColor = System.Drawing.Color.White;
            this.lb_liststatusname.Name = "lb_liststatusname";
            // 
            // lb_liststatus
            // 
            resources.ApplyResources(this.lb_liststatus, "lb_liststatus");
            this.lb_liststatus.BackColor = System.Drawing.Color.Transparent;
            this.lb_liststatus.ForeColor = System.Drawing.Color.White;
            this.lb_liststatus.Name = "lb_liststatus";
            // 
            // mypick
            // 
            this.mypick.FormattingEnabled = true;
            this.mypick.Items.AddRange(new object[] {
            resources.GetString("mypick.Items"),
            resources.GetString("mypick.Items1"),
            resources.GetString("mypick.Items2"),
            resources.GetString("mypick.Items3"),
            resources.GetString("mypick.Items4"),
            resources.GetString("mypick.Items5"),
            resources.GetString("mypick.Items6"),
            resources.GetString("mypick.Items7"),
            resources.GetString("mypick.Items8"),
            resources.GetString("mypick.Items9"),
            resources.GetString("mypick.Items10"),
            resources.GetString("mypick.Items11"),
            resources.GetString("mypick.Items12"),
            resources.GetString("mypick.Items13"),
            resources.GetString("mypick.Items14"),
            resources.GetString("mypick.Items15"),
            resources.GetString("mypick.Items16"),
            resources.GetString("mypick.Items17"),
            resources.GetString("mypick.Items18"),
            resources.GetString("mypick.Items19"),
            resources.GetString("mypick.Items20"),
            resources.GetString("mypick.Items21"),
            resources.GetString("mypick.Items22"),
            resources.GetString("mypick.Items23"),
            resources.GetString("mypick.Items24"),
            resources.GetString("mypick.Items25"),
            resources.GetString("mypick.Items26"),
            resources.GetString("mypick.Items27"),
            resources.GetString("mypick.Items28"),
            resources.GetString("mypick.Items29")});
            resources.ApplyResources(this.mypick, "mypick");
            this.mypick.Name = "mypick";
            // 
            // client
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mypick);
            this.Controls.Add(this.lb_liststatus);
            this.Controls.Add(this.lb_liststatusname);
            this.Controls.Add(this.bt_disconnect);
            this.Controls.Add(this.bt_syncmyplayer);
            this.Controls.Add(this.bt_fixtime);
            this.Controls.Add(this.bt_pickplayer);
            this.Controls.Add(this.bt_synclist);
            this.Controls.Add(this.lv_myplayers);
            this.Controls.Add(this.lv_pricelist);
            this.Controls.Add(this.lb_pick);
            this.Controls.Add(this.lb_round);
            this.Controls.Add(this.lb_pickname);
            this.Controls.Add(this.lb_roundname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_export);
            this.Controls.Add(this.bt_namelist);
            this.Controls.Add(this.lb_secondname);
            this.Controls.Add(this.lb_second);
            this.Controls.Add(this.lb_timename);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.mymessage);
            this.Controls.Add(this.bx_receiveMsg);
            this.Controls.Add(this.myid);
            this.Controls.Add(this.lb_myid);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.invcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_mypick);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.client_FormClosing);
            this.Load += new System.EventHandler(this.client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverPort;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox bx_receiveMsg;
        private System.Windows.Forms.TextBox mymessage;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_timename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_myid;
        private System.Windows.Forms.TextBox myid;
        private System.Windows.Forms.Label lb_mypick;
        private System.Windows.Forms.Label lb_roundname;
        private System.Windows.Forms.Label lb_pickname;
        private System.Windows.Forms.Label lb_round;
        private System.Windows.Forms.Label lb_pick;
        private System.Windows.Forms.Label lb_second;
        private System.Windows.Forms.Label lb_secondname;
        private System.Windows.Forms.ListView lv_pricelist;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Ename;
        private System.Windows.Forms.ColumnHeader Position;
        private System.Windows.Forms.ColumnHeader Overall;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.Button bt_synclist;
        private System.Windows.Forms.ColumnHeader Round;
        private System.Windows.Forms.Button bt_pickplayer;
        private System.Windows.Forms.Button bt_fixtime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox invcode;
        private System.Windows.Forms.ListView lv_myplayers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_syncmyplayer;
        private System.Windows.Forms.Button bt_namelist;
        private System.Windows.Forms.Button bt_export;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Label lb_liststatusname;
        private System.Windows.Forms.Label lb_liststatus;
        private System.Windows.Forms.ComboBox mypick;
    }
}

