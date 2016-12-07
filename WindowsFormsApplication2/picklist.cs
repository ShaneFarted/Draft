using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace WindowsFormsApplication2
{
    public partial class picklist : Form
    {
        public Socket newclient;


        public picklist(Socket clientsocket,string pick)
        {
            InitializeComponent();
            Pick = pick;
        }

        private string Pick;
        

        private void picklist_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 同步名单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_synclist_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[21];
            data = Encoding.UTF8.GetBytes("RequestSelectedList,"+ Pick + ",");
            int i = newclient.Send(data);
        }
    }
}
