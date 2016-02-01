using AmaranthineServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OculusClient
{
    public partial class frm_Main : Form
    {
        TcpClient clientSocket = null;
        PollingThread pollingThread=null;
        Thread polling = null;
        static object locker = new object();
        String oldClientList = String.Empty;
        String c = Char.ConvertFromUtf32(30);

        public frm_Main()
        {
            InitializeComponent();

            if (OculusClient.Properties.Settings.Default.AutoConnect && OculusClient.Properties.Settings.Default.Username != "" && OculusClient.Properties.Settings.Default.Password != "")
            {
                setupConnection();                                
            }
        }        

        public void setupConnection()
        {
            if (clientSocket != null)
                disconnect();

            displayLine("Client started");
            
            try
            {
                clientSocket = new TcpClient();
                displayLine("Checking IP address:" + OculusClient.Properties.Settings.Default.ServerIP);
                clientSocket.Connect(OculusClient.Properties.Settings.Default.ServerIP, 6669);
                displayLine("Server Connected");

                String status=writeToServer(OculusClient.Properties.Settings.Default.Username + ":" + OculusClient.Properties.Settings.Default.Password+"$$",true);
                displayLine(status);
                if (status == "OculusMessage:Authentication Failed")
                {
                    disconnect();
                    return;
                }
                pollingThread = new PollingThread(this, OculusClient.Properties.Settings.Default.Username, clientSocket);
                polling = new Thread(new ThreadStart(pollingThread.poll));
                polling.Start();
                this.Text = OculusClient.Properties.Settings.Default.Username;
                return;
            }
            catch (Exception)
            {
                displayLine("No server found in that IP");
            }

            displayLine("Server Not Found");
        }

        public string readFromServer()
        {            
            String read = String.Empty;
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Flush();
                byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                networkStream.Flush();

                String dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                read = dataFromClient.Substring(0, dataFromClient.IndexOf("$$"));                
            }
            catch(Exception e)
            {
                displayLine("Disconnected");
                Exception ex = new Exception("Read from Server failed");
                throw ex;
            }            
            return read;
        }

        public String writeToServer(String serverResponse,Boolean read=false)
        {
            String readValue = String.Empty;
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                serverResponse = serverResponse.Trim() + c;
                byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();

                if (read)
                {
                    byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    networkStream.Flush();

                    String dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    readValue = dataFromClient.Substring(0, dataFromClient.LastIndexOf("$$"));
                }
                return readValue;
            }
            catch(Exception e)
            {
                displayLine("Disconnected");
                disconnect();
                return readValue;
            }            
        }

        private void connectToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectTo connectTo = new ConnectTo(this);
            connectTo.Show();
        }

        public void displayLine(String message,Boolean balloon=false)
        {
            try
            {
                txtb_ClientDisplay.AppendText(Environment.NewLine + message);
                if (balloon && !this.ContainsFocus)
                {
                    ntfy_Tray.BalloonTipTitle = message;
                    ntfy_Tray.BalloonTipText = "New message from "+message.Split('>')[0];
                    ntfy_Tray.ShowBalloonTip(3000);
                }
            }
            catch (Exception)
            { }
        }

        public void disconnect()
        {            
            try
            {
                this.Text = "Oculus Client v1.0";
                if (polling != null && polling.IsAlive)
                    polling.Abort();
                polling = null;

                if (clientSocket != null)
                {
                    clientSocket.Close();
                    clientSocket = null;
                }

                if (!OculusClient.Properties.Settings.Default.RememberMe)
                {
                    OculusClient.Properties.Settings.Default.Username = "";
                    OculusClient.Properties.Settings.Default.Password = "";

                    OculusClient.Properties.Settings.Default.Save();
                }
            }
            catch (Exception)
            { }
            displayLine("Client offline");            
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnect();
            displayLine("Client offline");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnect();
            Dispose();
        }

        private void callClientList()
        {
            IMPacket askForClientList = new IMPacket();
            askForClientList.Action = Mnemonics.Actions.clientlist;
            String JSONServerResponse = JsonConvert.SerializeObject(askForClientList);
            writeToServer(JSONServerResponse);
        }

        public void getClientList(String[] response)
        {
            try
            {
                cmb_ClientList.Items.Clear();
                foreach (String client in response)
                {
                    if (client.Trim() != String.Empty)
                        cmb_ClientList.Items.Add(client);
                }
                cmb_ClientList.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                displayLine("Unable to get client list.");
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            sendData();
        }

        private void sendData()
        {
            if (txtb_SendData.Text == String.Empty)
                return;
            try
            {
                IMPacket sendIM = new IMPacket();
                sendIM.Action = Mnemonics.Actions.senddatanow;
                sendIM.SourceUsername = OculusClient.Properties.Settings.Default.Username;
                sendIM.TargetUsername = cmb_ClientList.Items[cmb_ClientList.SelectedIndex].ToString();
                sendIM.Message = txtb_SendData.Text;
                String JSONServerResponse = JsonConvert.SerializeObject(sendIM);
                writeToServer(JSONServerResponse);
                displayLine(OculusClient.Properties.Settings.Default.Username+">"+ txtb_SendData.Text);                
                txtb_SendData.Text = String.Empty;                
            }
            catch (Exception ex)
            {
                displayLine("Error Message at Send Button:" + ex.Message);
            }
            
        }

        private void btn_SendFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                writeToServer("senddata:" + OculusClient.Properties.Settings.Default.Username + ":" + cmb_ClientList.Items[cmb_ClientList.SelectedIndex] + ":" + File.ReadAllText(openFileDialog1.FileName));
            }
        }

        private void cmb_ClientList_DropDown(object sender, EventArgs e)
        {
            callClientList();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnect();
        }

        private void txtb_SendData_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtb_SendData_KeyDown(object sender, KeyEventArgs e)
        {
              
        }

        private void txtb_SendData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendData();
            }   
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            disconnect();
            Dispose();
        }

        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            disconnect();
            Dispose();
        }
    }
}
