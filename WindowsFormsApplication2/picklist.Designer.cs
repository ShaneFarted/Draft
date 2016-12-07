namespace WindowsFormsApplication2
{
    partial class picklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(picklist));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Overall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_synclist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView1.BackgroundImage")));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Cname,
            this.Ename,
            this.Position,
            this.Overall,
            this.Price});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 55);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(369, 181);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "编号";
            this.Id.Width = 53;
            // 
            // Cname
            // 
            this.Cname.Text = "中文名";
            this.Cname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ename
            // 
            this.Ename.Text = "英文名";
            this.Ename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Position
            // 
            this.Position.Text = "位置";
            this.Position.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Overall
            // 
            this.Overall.Text = "总评";
            this.Overall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Price
            // 
            this.Price.Text = "价格";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_synclist
            // 
            this.bt_synclist.Location = new System.Drawing.Point(306, 17);
            this.bt_synclist.Name = "bt_synclist";
            this.bt_synclist.Size = new System.Drawing.Size(75, 23);
            this.bt_synclist.TabIndex = 1;
            this.bt_synclist.Text = "同步名单";
            this.bt_synclist.UseVisualStyleBackColor = true;
            this.bt_synclist.Click += new System.EventHandler(this.bt_synclist_Click);
            // 
            // picklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(393, 262);
            this.Controls.Add(this.bt_synclist);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.Name = "picklist";
            this.Text = "可选球员";
            this.Load += new System.EventHandler(this.picklist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Cname;
        private System.Windows.Forms.ColumnHeader Ename;
        private System.Windows.Forms.ColumnHeader Position;
        private System.Windows.Forms.ColumnHeader Overall;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.Button bt_synclist;
    }
}