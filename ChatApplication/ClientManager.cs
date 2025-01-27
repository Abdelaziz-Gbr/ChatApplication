using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication
{
    internal class ClientManager
    {
        public event Action ClientLoggedOut;

        private List<Client> clients = new List<Client>();
        
        public ClientManager() { }
        public void AddClient(Client client)
        {
            int id = clients.Count;
            client.setId(id);
            client.onStoppedWorking += RemoveClient;
            clients.Add(client);
            SendUpdatedConnectedClientsToAllUsers();
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
            SendUpdatedConnectedClientsToAllUsers();
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

        internal void SendUpdatedConnectedClientsToAllUsers()
        {
            foreach (Client client in clients)
                client.SendConnectedClients(getClientsName());
        }
    }
}
