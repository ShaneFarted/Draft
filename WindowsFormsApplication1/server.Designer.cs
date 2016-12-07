namespace WindowsFormsApplication1
{
    partial class server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(server));
            this.statuBar = new System.Windows.Forms.Label();
            this.startService = new System.Windows.Forms.Button();
            this.showinfo = new System.Windows.Forms.RichTextBox();
            this.serverport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_roundname = new System.Windows.Forms.Label();
            this.lb_timename = new System.Windows.Forms.Label();
            this.bt_startdrafting = new System.Windows.Forms.Button();
            this.lb_secondname = new System.Windows.Forms.Label();
            this.lb_roundn = new System.Windows.Forms.Label();
            this.lb_pickname = new System.Windows.Forms.Label();
            this.lb_round = new System.Windows.Forms.Label();
            this.lb_pick = new System.Windows.Forms.Label();
            this.lb_second = new System.Windows.Forms.Label();
            this.lv_allprice = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.overall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.round = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pickedby = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.bt_export = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_clientnumber = new System.Windows.Forms.Label();
            this.bt_nextround = new System.Windows.Forms.Button();
            this.lv_participantslist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.bt_clearselected = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bt_assignfor = new System.Windows.Forms.Button();
            this.cb_pick = new System.Windows.Forms.ComboBox();
            this.bt_tooffline = new System.Windows.Forms.Button();
            this.bt_tocomputer = new System.Windows.Forms.Button();
            this.bt_playercount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statuBar
            // 
            this.statuBar.AutoSize = true;
            this.statuBar.BackColor = System.Drawing.Color.Transparent;
            this.statuBar.ForeColor = System.Drawing.Color.White;
            this.statuBar.Location = new System.Drawing.Point(111, 285);
            this.statuBar.Name = "statuBar";
            this.statuBar.Size = new System.Drawing.Size(41, 12);
            this.statuBar.TabIndex = 0;
            this.statuBar.Text = "未启动";
            // 
            // startService
            // 
            this.startService.Location = new System.Drawing.Point(30, 22);
            this.startService.Name = "startService";
            this.startService.Size = new System.Drawing.Size(87, 23);
            this.startService.TabIndex = 1;
            this.startService.Text = "启动服务器";
            this.startService.UseVisualStyleBackColor = true;
            this.startService.Click += new System.EventHandler(this.startService_Click);
            // 
            // showinfo
            // 
            this.showinfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showinfo.Location = new System.Drawing.Point(30, 136);
            this.showinfo.Name = "showinfo";
            this.showinfo.Size = new System.Drawing.Size(354, 133);
            this.showinfo.TabIndex = 2;
            this.showinfo.Text = "";
            this.showinfo.TextChanged += new System.EventHandler(this.showinfo_TextChanged);
            // 
            // serverport
            // 
            this.serverport.Location = new System.Drawing.Point(273, 24);
            this.serverport.Name = "serverport";
            this.serverport.Size = new System.Drawing.Size(100, 21);
            this.serverport.TabIndex = 4;
            this.serverport.Text = "请指定端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(226, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "端口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(173, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "选秀实况";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "服务器状态：";
            // 
            // lb_roundname
            // 
            this.lb_roundname.AutoSize = true;
            this.lb_roundname.BackColor = System.Drawing.Color.Transparent;
            this.lb_roundname.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_roundname.ForeColor = System.Drawing.Color.White;
            this.lb_roundname.Location = new System.Drawing.Point(28, 79);
            this.lb_roundname.Name = "lb_roundname";
            this.lb_roundname.Size = new System.Drawing.Size(84, 19);
            this.lb_roundname.TabIndex = 8;
            this.lb_roundname.Text = "当前轮次：";
            // 
            // lb_timename
            // 
            this.lb_timename.AutoSize = true;
            this.lb_timename.BackColor = System.Drawing.Color.Transparent;
            this.lb_timename.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_timename.ForeColor = System.Drawing.Color.Red;
            this.lb_timename.Location = new System.Drawing.Point(224, 80);
            this.lb_timename.Name = "lb_timename";
            this.lb_timename.Size = new System.Drawing.Size(114, 19);
            this.lb_timename.TabIndex = 8;
            this.lb_timename.Text = "本签剩余时间：";
            // 
            // bt_startdrafting
            // 
            this.bt_startdrafting.Location = new System.Drawing.Point(30, 53);
            this.bt_startdrafting.Name = "bt_startdrafting";
            this.bt_startdrafting.Size = new System.Drawing.Size(87, 23);
            this.bt_startdrafting.TabIndex = 1;
            this.bt_startdrafting.Text = "开始选秀";
            this.bt_startdrafting.UseVisualStyleBackColor = true;
            this.bt_startdrafting.Click += new System.EventHandler(this.bt_startdrafting_Click);
            // 
            // lb_secondname
            // 
            this.lb_secondname.AutoSize = true;
            this.lb_secondname.BackColor = System.Drawing.Color.Transparent;
            this.lb_secondname.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_secondname.ForeColor = System.Drawing.Color.Red;
            this.lb_secondname.Location = new System.Drawing.Point(363, 80);
            this.lb_secondname.Name = "lb_secondname";
            this.lb_secondname.Size = new System.Drawing.Size(24, 19);
            this.lb_secondname.TabIndex = 8;
            this.lb_secondname.Text = "秒";
            // 
            // lb_roundn
            // 
            this.lb_roundn.AutoSize = true;
            this.lb_roundn.BackColor = System.Drawing.Color.Transparent;
            this.lb_roundn.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_roundn.ForeColor = System.Drawing.Color.White;
            this.lb_roundn.Location = new System.Drawing.Point(118, 79);
            this.lb_roundn.Name = "lb_roundn";
            this.lb_roundn.Size = new System.Drawing.Size(24, 19);
            this.lb_roundn.TabIndex = 8;
            this.lb_roundn.Text = "轮";
            // 
            // lb_pickname
            // 
            this.lb_pickname.AutoSize = true;
            this.lb_pickname.BackColor = System.Drawing.Color.Transparent;
            this.lb_pickname.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_pickname.ForeColor = System.Drawing.Color.White;
            this.lb_pickname.Location = new System.Drawing.Point(171, 79);
            this.lb_pickname.Name = "lb_pickname";
            this.lb_pickname.Size = new System.Drawing.Size(39, 19);
            this.lb_pickname.TabIndex = 8;
            this.lb_pickname.Text = "号签";
            // 
            // lb_round
            // 
            this.lb_round.AutoSize = true;
            this.lb_round.BackColor = System.Drawing.Color.Transparent;
            this.lb_round.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_round.ForeColor = System.Drawing.Color.Red;
            this.lb_round.Location = new System.Drawing.Point(97, 79);
            this.lb_round.Name = "lb_round";
            this.lb_round.Size = new System.Drawing.Size(19, 20);
            this.lb_round.TabIndex = 9;
            this.lb_round.Text = "1";
            // 
            // lb_pick
            // 
            this.lb_pick.AutoSize = true;
            this.lb_pick.BackColor = System.Drawing.Color.Transparent;
            this.lb_pick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pick.ForeColor = System.Drawing.Color.Red;
            this.lb_pick.Location = new System.Drawing.Point(145, 78);
            this.lb_pick.Name = "lb_pick";
            this.lb_pick.Size = new System.Drawing.Size(19, 20);
            this.lb_pick.TabIndex = 9;
            this.lb_pick.Text = "1";
            // 
            // lb_second
            // 
            this.lb_second.AutoSize = true;
            this.lb_second.BackColor = System.Drawing.Color.Transparent;
            this.lb_second.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_second.ForeColor = System.Drawing.Color.Red;
            this.lb_second.Location = new System.Drawing.Point(330, 79);
            this.lb_second.Name = "lb_second";
            this.lb_second.Size = new System.Drawing.Size(29, 20);
            this.lb_second.TabIndex = 9;
            this.lb_second.Text = "70";
            // 
            // lv_allprice
            // 
            this.lv_allprice.BackgroundImageTiled = true;
            this.lv_allprice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.ename,
            this.position,
            this.overall,
            this.price,
            this.round,
            this.pickedby});
            this.lv_allprice.FullRowSelect = true;
            this.lv_allprice.Location = new System.Drawing.Point(403, 53);
            this.lv_allprice.MultiSelect = false;
            this.lv_allprice.Name = "lv_allprice";
            this.lv_allprice.Size = new System.Drawing.Size(404, 219);
            this.lv_allprice.TabIndex = 10;
            this.lv_allprice.UseCompatibleStateImageBehavior = false;
            this.lv_allprice.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "编号";
            this.id.Width = 50;
            // 
            // ename
            // 
            this.ename.Text = "英文名";
            // 
            // position
            // 
            this.position.Text = "位置";
            this.position.Width = 45;
            // 
            // overall
            // 
            this.overall.Text = "总评";
            this.overall.Width = 42;
            // 
            // price
            // 
            this.price.Text = "价格";
            this.price.Width = 54;
            // 
            // round
            // 
            this.round.Text = "轮数";
            this.round.Width = 67;
            // 
            // pickedby
            // 
            this.pickedby.Text = "被选";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(576, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "名单总览";
            // 
            // bt_export
            // 
            this.bt_export.Location = new System.Drawing.Point(689, 278);
            this.bt_export.Name = "bt_export";
            this.bt_export.Size = new System.Drawing.Size(118, 23);
            this.bt_export.TabIndex = 11;
            this.bt_export.Text = "导出为Excel文件";
            this.bt_export.UseVisualStyleBackColor = true;
            this.bt_export.Click += new System.EventHandler(this.bt_export_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(224, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "当前人数：";
            // 
            // lb_clientnumber
            // 
            this.lb_clientnumber.AutoSize = true;
            this.lb_clientnumber.BackColor = System.Drawing.Color.Transparent;
            this.lb_clientnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_clientnumber.ForeColor = System.Drawing.Color.Red;
            this.lb_clientnumber.Location = new System.Drawing.Point(314, 52);
            this.lb_clientnumber.Name = "lb_clientnumber";
            this.lb_clientnumber.Size = new System.Drawing.Size(19, 20);
            this.lb_clientnumber.TabIndex = 9;
            this.lb_clientnumber.Text = "0";
            // 
            // bt_nextround
            // 
            this.bt_nextround.Location = new System.Drawing.Point(131, 52);
            this.bt_nextround.Name = "bt_nextround";
            this.bt_nextround.Size = new System.Drawing.Size(87, 23);
            this.bt_nextround.TabIndex = 1;
            this.bt_nextround.Text = "强行过人";
            this.bt_nextround.UseVisualStyleBackColor = true;
            this.bt_nextround.Click += new System.EventHandler(this.bt_nextround_Click);
            // 
            // lv_participantslist
            // 
            this.lv_participantslist.BackgroundImageTiled = true;
            this.lv_participantslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader2});
            this.lv_participantslist.FullRowSelect = true;
            this.lv_participantslist.Location = new System.Drawing.Point(830, 53);
            this.lv_participantslist.MultiSelect = false;
            this.lv_participantslist.Name = "lv_participantslist";
            this.lv_participantslist.Size = new System.Drawing.Size(185, 219);
            this.lv_participantslist.TabIndex = 10;
            this.lv_participantslist.UseCompatibleStateImageBehavior = false;
            this.lv_participantslist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "签位";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "状态";
            this.columnHeader8.Width = 37;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "IP";
            this.columnHeader9.Width = 47;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "人数";
            this.columnHeader2.Width = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(892, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "玩家总览";
            // 
            // bt_clearselected
            // 
            this.bt_clearselected.Location = new System.Drawing.Point(689, 17);
            this.bt_clearselected.Name = "bt_clearselected";
            this.bt_clearselected.Size = new System.Drawing.Size(118, 23);
            this.bt_clearselected.TabIndex = 12;
            this.bt_clearselected.Text = "清除选定“被选”";
            this.bt_clearselected.UseVisualStyleBackColor = true;
            this.bt_clearselected.Click += new System.EventHandler(this.bt_clearselected_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(419, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "为";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(492, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "号";
            // 
            // bt_assignfor
            // 
            this.bt_assignfor.Location = new System.Drawing.Point(516, 278);
            this.bt_assignfor.Name = "bt_assignfor";
            this.bt_assignfor.Size = new System.Drawing.Size(44, 23);
            this.bt_assignfor.TabIndex = 13;
            this.bt_assignfor.Text = "指定";
            this.bt_assignfor.UseVisualStyleBackColor = true;
            this.bt_assignfor.Click += new System.EventHandler(this.bt_assignfor_Click);
            // 
            // cb_pick
            // 
            this.cb_pick.FormattingEnabled = true;
            this.cb_pick.Items.AddRange(new object[] {
            "1",
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
            "30"});
            this.cb_pick.Location = new System.Drawing.Point(443, 279);
            this.cb_pick.Name = "cb_pick";
            this.cb_pick.Size = new System.Drawing.Size(44, 20);
            this.cb_pick.TabIndex = 14;
            // 
            // bt_tooffline
            // 
            this.bt_tooffline.Location = new System.Drawing.Point(830, 279);
            this.bt_tooffline.Name = "bt_tooffline";
            this.bt_tooffline.Size = new System.Drawing.Size(75, 23);
            this.bt_tooffline.TabIndex = 15;
            this.bt_tooffline.Text = "改为离线";
            this.bt_tooffline.UseVisualStyleBackColor = true;
            this.bt_tooffline.Click += new System.EventHandler(this.bt_tooffline_Click);
            // 
            // bt_tocomputer
            // 
            this.bt_tocomputer.Location = new System.Drawing.Point(940, 279);
            this.bt_tocomputer.Name = "bt_tocomputer";
            this.bt_tocomputer.Size = new System.Drawing.Size(75, 23);
            this.bt_tocomputer.TabIndex = 15;
            this.bt_tocomputer.Text = "改为电脑";
            this.bt_tocomputer.UseVisualStyleBackColor = true;
            this.bt_tocomputer.Click += new System.EventHandler(this.bt_tocomputer_Click);
            // 
            // bt_playercount
            // 
            this.bt_playercount.Location = new System.Drawing.Point(958, 19);
            this.bt_playercount.Name = "bt_playercount";
            this.bt_playercount.Size = new System.Drawing.Size(39, 23);
            this.bt_playercount.TabIndex = 16;
            this.bt_playercount.Text = "统计";
            this.bt_playercount.UseVisualStyleBackColor = true;
            this.bt_playercount.Click += new System.EventHandler(this.bt_playercount_Click);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 321);
            this.Controls.Add(this.bt_playercount);
            this.Controls.Add(this.bt_tocomputer);
            this.Controls.Add(this.bt_tooffline);
            this.Controls.Add(this.cb_pick);
            this.Controls.Add(this.bt_assignfor);
            this.Controls.Add(this.bt_clearselected);
            this.Controls.Add(this.bt_export);
            this.Controls.Add(this.lv_participantslist);
            this.Controls.Add(this.lv_allprice);
            this.Controls.Add(this.lb_second);
            this.Controls.Add(this.lb_clientnumber);
            this.Controls.Add(this.lb_pick);
            this.Controls.Add(this.lb_round);
            this.Controls.Add(this.lb_secondname);
            this.Controls.Add(this.lb_timename);
            this.Controls.Add(this.lb_pickname);
            this.Controls.Add(this.lb_roundn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_roundname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverport);
            this.Controls.Add(this.showinfo);
            this.Controls.Add(this.bt_nextround);
            this.Controls.Add(this.bt_startdrafting);
            this.Controls.Add(this.startService);
            this.Controls.Add(this.statuBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "server";
            this.Text = "游侠选秀服务器 v1.0  内测版-- 野炮帝 版权所有 联赛Q群：287914769 本软件仅供游侠联赛群玩家免费使用，盗版必究";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statuBar;
        private System.Windows.Forms.Button startService;
        private System.Windows.Forms.RichTextBox showinfo;
        private System.Windows.Forms.TextBox serverport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_roundname;
        private System.Windows.Forms.Label lb_timename;
        private System.Windows.Forms.Button bt_startdrafting;
        private System.Windows.Forms.Label lb_secondname;
        private System.Windows.Forms.Label lb_roundn;
        private System.Windows.Forms.Label lb_pickname;
        private System.Windows.Forms.Label lb_round;
        private System.Windows.Forms.Label lb_pick;
        private System.Windows.Forms.Label lb_second;
        private System.Windows.Forms.ListView lv_allprice;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader ename;
        private System.Windows.Forms.ColumnHeader position;
        private System.Windows.Forms.ColumnHeader overall;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader round;
        private System.Windows.Forms.ColumnHeader pickedby;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_export;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_clientnumber;
        private System.Windows.Forms.Button bt_nextround;
        private System.Windows.Forms.ListView lv_participantslist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_clearselected;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bt_assignfor;
        private System.Windows.Forms.ComboBox cb_pick;
        private System.Windows.Forms.Button bt_tooffline;
        private System.Windows.Forms.Button bt_tocomputer;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button bt_playercount;
    }
}