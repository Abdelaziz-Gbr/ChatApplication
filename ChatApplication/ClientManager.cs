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

        public void RemoveClient(string name)
        {

            clients.RemoveAt(GetClientIndex(name));
            ClientLoggedOut?.Invoke();
            OnConnectedClientsListUpdated?.Invoke(getClientsName());
        }

        private int GetClientIndex(string name)
        {
            int i = 0;
            for (; i < clients.Count; i++)
            {
                if (clients[i].getName() == name)
                    break;
            }
            return i;
        }

        internal void ForwardMessage(Message message)
        {
            string sender = message.sender;
            string[] recievers = message.reciver;
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

        internal void Quit()
        {
            foreach (Client client in clients)
                client.SendMessageQuitMessage();
            Task.Delay(1000);
            foreach (Client client in clients)
                client.End();
            clients.Clear();

            OnConnectedClientsListUpdated(getClientsName());
        }
    }
}
