using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ChatApplication
{
    internal delegate void ServiceStatus(bool up);
    internal delegate void NewMessageArrived(string message);
    internal class Server
    {
        public event ServiceStatus OnServiceStatusChanged;
        public event NewMessageArrived onNewMessageArrived;
        private int PORT = 45000;
        private IPAddress serverIP = IPAddress.Loopback;
        private TcpListener listener;
        private ClientManager clientManager;
        public Server()
        { 
            listener = new TcpListener(serverIP, PORT);
            clientManager = new ClientManager();
        }
        
        public async void StartService()
        {
            listener.Start();
            OnServiceStatusChanged?.Invoke(true);
            while(true)
            {
                TcpClient clientSocket = await listener.AcceptTcpClientAsync();
                _ = Task.Run(async () =>
                {
                    string clientName = await GetClientName(clientSocket);
                    if(clientName != null)
                    {
                        Client newCLient = new Client(clientName, clientSocket);
                        newCLient.MessageRecieved += RecieveMessageFromClient;
                        clientManager.AddClient(newCLient);
                    }
                });
            }
        }

        private async Task<string> GetClientName(TcpClient newClient)
        {
            StreamReader sr = new StreamReader(newClient.GetStream());
            StreamWriter sw = new StreamWriter(newClient.GetStream());
            sw.AutoFlush = true;
            try
            {
                string name = await sr.ReadLineAsync();
                if (clientManager.CheckNameIsTaken(name))
                {
                    sw.WriteLine("User Name Taken#Please Enter Antoher User Name.");
                    return await GetClientName(newClient);
                }
                else
                {
                    sw.WriteLine("success#continue");
                    sr = null;
                    sw = null;
                    return name;
                }    
            }
            catch
            {
                //do nothing connection lost
            }
            
            return null;
        }

        public void SendMessageToAllClients(string message) 
        {
            clientManager.SendMessageToAll(message);
        }

        internal void Stop()
        {
            clientManager.Quit();
            OnServiceStatusChanged?.Invoke(false);
        }


        private void RecieveMessageFromClient(Message message)
        {
            //only print messages that's meant for the admin to see.
            if (message.IsMessageToAdmin() || message.IsMessageToAll())
                onNewMessageArrived?.Invoke($"From:{message.sender} -> {message.message}");

            //forward message to people meant to recieve.
            clientManager.ForwardMessage(message);
        }

        public void AddObserverToConnectClientsList(ConnctedClientsListUpdate func)
        {
            clientManager.OnConnectedClientsListUpdated += func;
        }
    }
}
