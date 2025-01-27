using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApplication
{
    internal class Message
    {
        public string message;
        public string sender;
        public string[] reciver;
        public Message(string message, string sender, string[] reciver)
        {
            this.message = message;
            this.sender = sender;
            this.reciver = reciver;
        }
        public Message() { }

        public static Message Parse(string recievedMessage) 
        {
            string[] msgSplit = recievedMessage.Split('#');
            Message res = new Message();
            res.sender = msgSplit[0];
            if (msgSplit[1].Length > 0)
                res.reciver = msgSplit[1].Split(',');
            else 
                res.reciver = null;
            res.message = msgSplit[2];
            return res;
        }

        public override string ToString()
        {
            string recievers = "";
            if(reciver != null) 
                foreach (string r in reciver) recievers += r + ",";
            return $"{sender}#{recievers}#{message}";
        }

        public bool IsMessageToAdmin()
        {
            if(reciver != null && reciver.Contains("admin"))
                return true;
            return false;
        }

        public bool IsMessageToAll()
        {
            if(reciver == null)
                return true;
            return false;
        }
    }
}
