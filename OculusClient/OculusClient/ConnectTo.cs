using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OculusClient
{
    public partial class ConnectTo : Form
    {
        frm_Main main;

        public ConnectTo(frm_Main _main)
        {
            InitializeComponent();

            main = _main;

            txtb_ServerIP.Text = OculusClient.Properties.Settings.Default.ServerIP;
            chk_AutoConnect.Checked = OculusClient.Properties.Settings.Default.AutoConnect;
            txtb_UserName.Text = OculusClient.Properties.Settings.Default.Username;
            txtb_Password.Text = OculusClient.Properties.Settings.Default.Password;
            chk_RememberMe.Checked = OculusClient.Properties.Settings.Default.RememberMe;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            OculusClient.Properties.Settings.Default.ServerIP = txtb_ServerIP.Text;
            OculusClient.Properties.Settings.Default.AutoConnect = chk_AutoConnect.Checked;

            OculusClient.Properties.Settings.Default.Username = txtb_UserName.Text;
            OculusClient.Properties.Settings.Default.Password = txtb_Password.Text;

            OculusClient.Properties.Settings.Default.RememberMe = chk_RememberMe.Checked;

            OculusClient.Properties.Settings.Default.Save();
            main.setupConnection();
            Dispose();
        }
    }
}
