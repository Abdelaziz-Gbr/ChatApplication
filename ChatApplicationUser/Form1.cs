using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChatApplicationUser
{
    public partial class ChatWithUs_Client : Form
    {
        private Connection connection = Program.GetConnection();
        private EnterUserName enterUserName;
        public ChatWithUs_Client()
        {
            InitializeComponent();
            connection.OnConnectionStatusChanged += ConnectionStatusUpdated;
            connection.OnNameResponseRecieved += NameResponseRecieved;
            connection.OnMessageRecieved += MessageRecieved;
            connection.OnConnectedClientsUpdated += ConectedClientsUpdated;
        }

        private void btn_Connnect_Click(object sender, EventArgs e)
        {
            connection.Connect();
        }

        private void ConnectionStatusUpdated(bool connected)
        {
            if(connected)
            {
                label1.Text = "Connected";
                label1.ForeColor = Color.Green;
                btn_Connnect.Visible = false;
                btn_disconnect.Visible = true;
                enterUserName = new EnterUserName();
                enterUserName.Show();
            }
            else
            {
                label1.Text = "Disconnected";
                label1.ForeColor = Color.Red;
                if (enterUserName != null)
                    enterUserName.Close();
                btn_Connnect.Visible = true;
                btn_disconnect.Visible = false;
                lbl_name.Text = "";
                ConectedClientsUpdated(new string[0]);
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            connection.EndConnectionWithServer();
        }

        private void btn_SendToAll_Click(object sender, EventArgs e)
        {
            string message = getMessageText();
            connection.SendMessage(message, null);
        }

        private string getMessageText()
        {
            string message = txtBox_MessageInput.Text;
            txtBox_MessageInput.Clear();
            txtBox_Messages.Text += $"me({connection.getName()}) -> {message}{Environment.NewLine}";
            return message;
        }

        private void NameResponseRecieved(string res)
        {
            string[] serverResponse = res.Split('#');
            string header = serverResponse[0];
            string message = serverResponse[1];
            if(header == "success")
                lbl_name.Text = $"as {connection.getName()}";
            else
                MessageBox.Show(message, header);
        }

        private void MessageRecieved(string msg)
        {
            txtBox_Messages.Text += $"{msg}{Environment.NewLine}";
        }

        private void ConectedClientsUpdated(string[] clients)
        {
            chkedList_ConnectedUsers.Items.Clear();
            chkedList_ConnectedUsers.Items.AddRange(clients);
        }

        private void btn_SendSelected_Click(object sender, EventArgs e)
        {
            string[] selectedClient = chkedList_ConnectedUsers.SelectedItems.Cast<string>().ToArray();
            connection.SendMessage(getMessageText(), selectedClient);
        }
    }
}
