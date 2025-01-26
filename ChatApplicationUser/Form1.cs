using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void btn_SendToAll_Click(object sender, EventArgs e)
        {
            string message = txtBox_MessageInput.Text;
            txtBox_Messages.Text += $"me({connection.getName()}) -> {message}{Environment.NewLine}";
            connection.SendMessageToAll(message);
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
    }
}
