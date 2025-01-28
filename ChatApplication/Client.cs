using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace ChatApplication
{
    internal delegate void RecievedMessage(Message msg);
    internal delegate void OnStopWorking(string clientName);
    internal class Client
    {
        public event RecievedMessage MessageRecieved;
        private TcpClient socket;
        private string name;
        private StreamReader sr;
        private StreamWriter sw;
        private bool Working = true;
        public event OnStopWorking onStoppedWorking;

        public ClientManager Manager { get; set; }


        public Client(string name, TcpClient socket)
        {
            this.name = name;
            this.socket = socket;
            sr = new StreamReader(socket.GetStream());
            sw = new StreamWriter(socket.GetStream());
            sw.AutoFlush = true;
            AcceptMessages();
        }

        public async void AcceptMessages()
        {
            while (Working)
            {
                try
                {
                    string msg = await sr.ReadLineAsync();
                    if (msg != null)
                    {
                        if (msg == "-1")
                        {
                            End();
                            return;
                        }
                        Message RecievedMsg = Message.Parse(msg);
                        MessageRecieved(RecievedMsg);
                    }
                }
                catch
                {
                    End();
                }
            }
        }

        public void End()
        {
            Working = false;
            socket.Close();
            sr.Close();
            sw.Close();
            onStoppedWorking(name);
        }

        public void SendMessage(Message msg)
        {
            try
            {
                sw.WriteLineAsync(msg.ToString());
            }
            catch
            {
                End();
            }
        }

        internal string getName()
        {
            return name;
        }


        internal void SendConnectedClients(string[] strings)
        {
            
            String msg = "";

            foreach(string s in strings)
            {
                msg += s + ",";
            }
            msg = msg.Substring(0, msg.Length - 1);

            SendMessage
            (
                new Message 
                {
                sender = "CC",
                message = msg
                }
            );
        }

        internal void SendMessageQuitMessage()
        {
            try
            {
                sw.WriteLineAsync("-1");
            }
            catch
            {
                End();
            }
        }
    }
}
