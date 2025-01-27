using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApplication
{
    internal delegate void ConnctedClientsListUpdate(string[] clients);
    internal class ClientManager
    {
        public event Action ClientLoggedOut;
        public event ConnctedClientsListUpdate OnConnectedClientsListUpdated;

        private List<Client> clients = new List<Client>();
        
        public ClientManager() 
        {
            OnConnectedClientsListUpdated += SendUpdatedConnectedClientsToAllUsers;
        }
        public void AddClient(Client client)
        {
            int id = clients.Count;
            client.setId(id);
            client.onStoppedWorking += RemoveClient;
            clients.Add(client);
            OnConnectedClientsListUpdated?.Invoke(getClientsName());
        }

        internal string[] getClientsName()
        {
            string[] clientsName = new string[clients.Count];
            for (int i = 0; i < clients.Count; i++)
            {
                clientsName[i] = clients[i].getName();
            }
            return clientsName;
        }

        internal void SendMessageToAll(string message)
        {
            Message msg = new Message();
            msg.sender = "Admin";
            msg.message = message;
            msg.reciver = null;
            foreach(Client client in clients)
                client.SendMessage(msg);
        }

        public void RemoveClient(int clientId)
        {

            clients.RemoveAt(clientId);
            ClientLoggedOut?.Invoke();
            OnConnectedClientsListUpdated?.Invoke(getClientsName());
        }

        internal void ForwardMessage(Message message)
        {
            string sender = message.sender;
            string[] recievers = message.reciver;
           // MessageBox.Show($"{recievers.Length} --- {recievers[0]} --- {recievers[1]}");
            switch(message.IsMessageToAll())
            {
                case true:
                    {
                        //send to all
                        foreach(Client client in clients)
                        {
                            if(client.getName() == sender)
                                continue;
                            client.SendMessage(message);
                        }
                        break;
                    }
                default:
                    {
                        //send to one or more other clients privatly
                        foreach(Client client in clients)
                        {
                            if (recievers.Contains(client.getName()))
                                client.SendMessage(message);
                                
                        }
                        break;
                    }
            }
        }

        internal bool CheckNameIsTaken(string name)
        {
            foreach(Client client in clients)
                if(client.getName() == name)
                    return true;
            return false;
        }

        internal void SendUpdatedConnectedClientsToAllUsers(string[] connectedClients)
        {
            foreach (Client client in clients)
                client.SendConnectedClients(connectedClients);
        }
    }
}
