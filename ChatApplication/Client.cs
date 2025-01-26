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
    internal delegate void OnStopWorking(int id);
    internal class Client
    {
        public event RecievedMessage MessageRecieved;
        private TcpClient socket;
        private string name;
        private StreamReader sr;
        private StreamWriter sw;
        private bool Working = true;
        public event OnStopWorking onStoppedWorking;
        private int id;

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
                string msg = await sr.ReadLineAsync();
                //MessageBox.Show(msg);
                if (msg != null)
                {
                    if (msg == "-1")
                    {
                        End();
                        return;
                    }
                    Message RecievedMsg = Message.Parse(msg);
                    MessageBox.Show("1");
                    MessageRecieved(RecievedMsg);
                }/*
                try
                {
                    string msg = await sr.ReadLineAsync();
                    //MessageBox.Show(msg);
                    if (msg != null)
                    {
                        if (msg == "-1")
                        {
                            End();
                            return;
                        }
                        Message RecievedMsg = Message.Parse(msg);
                        MessageBox.Show("1");
                        MessageRecieved(RecievedMsg);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                    End();
                }*/
            }
        }

        private void End()
        {
            Working = false;
            onStoppedWorking?.Invoke(id);
        }

        public void SendMessage(Message msg)
        {
            try
            {
                sw.WriteLineAsync(msg.ToString());
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Client {name} unreachable", "Attention!");
            }
        }

        internal string getName()
        {
            return name;
        }

        public void Stop()
        {
            Working = false;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }
}
