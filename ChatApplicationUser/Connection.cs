using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplicationUser
{
    internal delegate void ConnectionStatusChanged(bool status);
    internal delegate void NameResponseRecieved(string message);
    internal delegate void MessageRecieved(string message);
    internal delegate void ConnectedClientsUpdated(string[] clients);
    internal class Connection
    {
        public event ConnectionStatusChanged OnConnectionStatusChanged;
        public event NameResponseRecieved OnNameResponseRecieved;
        public event MessageRecieved OnMessageRecieved;
        public event ConnectedClientsUpdated OnConnectedClientsUpdated;

        private TcpClient tcpClient;
        private int SERVER_PORT = 45000;
        private IPAddress SERVER_IP = IPAddress.Loopback;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        private string name;
        public Connection() 
        {
        }
        public void Connect()
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(SERVER_IP, SERVER_PORT);
            }
            catch 
            {
                MessageBox.Show("Couldn't connect to the server.", "Error");
                OnConnectionStatusChanged?.Invoke(false);
                return;
            }
            streamReader = new StreamReader(tcpClient.GetStream());
            streamWriter = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };
            OnConnectionStatusChanged?.Invoke(true);
        }

        public void Close()
        {
            WriteToServer("-1");
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
                OnConnectionStatusChanged?.Invoke(false);
            }
        }

        internal void SendMessageToAll(string message)
        {
            WriteToServer($"{name}##{message}");
        }

        internal async Task SendNameAsync(string name)
        {
            this.name = name;
            WriteToServer(name);
            string serverResponse = await ReadFromServer();
            string success = serverResponse.Split('#')[0];
            if (success == "success")
                RecieveMessages();
            OnNameResponseRecieved?.Invoke(serverResponse);
        }

        private async void RecieveMessages()
        {
            while(true)
            {
                string msg = await ReadFromServer();
                string TrueMessage = ParseIncomming(msg);
                
                if(TrueMessage != null)
                    OnMessageRecieved?.Invoke(TrueMessage);
            }
        }

        private string ParseIncomming(string msg)
        {
            string[] res = msg.Split('#');
            if (res[0] == "CC")
            {
                //don't view the message as it shows a list of connected clients.
                string[] connectedClients = res[2].Split(',');
                /*foreach(string c in  connectedClients)
                    MessageBox.Show($"{c}", $"from {name}");*/
                OnConnectedClientsUpdated?.Invoke(connectedClients);
                return null;
            }
            return $"From:{res[0]} -> {res[2]}";
        }

        private void WriteToServer(string message) 
        {
            try
            {
                streamWriter?.WriteLineAsync(message);
            }
            catch
            {
                MessageBox.Show("Couldn't connect to the server.", "Error");
                OnConnectionStatusChanged?.Invoke(false);
                return;
            }
        }
        private async Task<string> ReadFromServer()
        {
            try
            {
                string serverResponse = await streamReader.ReadLineAsync();
                return serverResponse;
            }
            catch
            {
                MessageBox.Show("Couldn't connect to the server.", "Error");
                OnConnectionStatusChanged?.Invoke(false);
                return null;
            }
        }

        internal object getName()
        {
            return name;
        }
    }
}
