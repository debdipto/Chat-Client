using AmaranthineServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OculusClient
{
    class PollingThread
    {
        private TcpClient clientSocket;
        String myName;
        frm_Main form;

        public PollingThread(frm_Main _form, String _myName, TcpClient _clientSocket)
        {
            clientSocket = _clientSocket;
            myName = _myName;
            form = _form;
        }

        public void displayInMainForm(String message,Boolean balloon=false)
        {
            try
            {
                if (form.InvokeRequired)
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.displayLine(message,balloon);
                    });
                }
                else
                {
                    form.displayLine(message,balloon);
                }
            }
            catch (Exception)
            {
            }
        }

        public String writeToServer(String message)
        {
            try
            {
                if (form.InvokeRequired)
                {
                    String returnValue = String.Empty;
                    form.Invoke((MethodInvoker)delegate
                    {
                        returnValue=form.writeToServer(message);
                    });
                    return returnValue;
                }
                else
                {
                    return form.writeToServer(message);
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Write to Server failed");                
                throw ex;
            }
        }

        public string readFromServer()
        {
            String dataFromClient = String.Empty;
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Flush();
                byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                networkStream.Flush();

                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
            }
            catch (Exception e)
            {
                displayInMainForm("Disconnected");
                Exception ex = new Exception("Read from Server failed");
                throw ex;
            }
            return dataFromClient;
        }

        public void getClientList(String[] message)
        {
            try
            {
                if (form.InvokeRequired)
                {
                    String returnValue = String.Empty;
                    form.Invoke((MethodInvoker)delegate
                    {
                        form.getClientList(message);
                    });
                }
                else
                {
                    form.getClientList(message);
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Client list population failed");
                throw ex;
            }
        }

        public void poll()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        String returnData = readFromServer();
                        dynamic returnObject = JsonConvert.DeserializeObject(returnData);
                        int mnemonic = (int)returnObject.Action;
                        switch (mnemonic)
                        {
                            case (int)Mnemonics.Actions.clientlist:
                                {
                                    ReplyPayload<String> clients = JsonConvert.DeserializeObject<ReplyPayload<String>>(returnData);

                                    getClientList(clients.reply);
                                }
                                break;
                            case (int)Mnemonics.Actions.senddatanow:
                                {
                                    ReplyPayload<MessageContainer> clients = JsonConvert.DeserializeObject<ReplyPayload<MessageContainer>>(returnData);

                                    displayInMainForm(clients.reply[0].username + ">" + clients.reply[0].message, true);

                                    if (form != Form.ActiveForm)
                                    {
                                        SoundPlayer simpleSound = new SoundPlayer(OculusClient.Properties.Resources.BEEP2);
                                        simpleSound.Play();
                                    }
                                }
                                break;
                            case (int)Mnemonics.Actions.heartBeat:
                                {

                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        displayInMainForm("[Exception] " + e.StackTrace);
                    }
                }                
            }
            catch(Exception e)
            {
                form.displayLine("Error: " + e.Message + " Disconnecting self.",true);
                form.disconnect();
                return;
            }
        }
    }
}
