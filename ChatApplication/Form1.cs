using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class ChatApplication_Server : Form
    {
        private Server server = Program.GetServer();
        public ChatApplication_Server()
        {
            InitializeComponent();
            server.OnServiceStatusChanged += OnServiceStatusChanged;
            server.onNewMessageArrived += NewMessageArrived;
            server.AddObserverToConnectClientsList(ConnectedClientsUpdated);
        }

        private void btn_StartService_Click(object sender, EventArgs e)
        {
            btn_StartService.Visible = false;
            btn_StopService.Visible = true;
            
            server.StartService();
        }

        private void OnServiceStatusChanged(bool up)
        {
            if (up)
            {
                lbl_status.Text = "Up";
                lbl_status.ForeColor = Color.Green;
                btn_StartService.Visible = false;
                btn_StopService.Visible = true;
            }
            else
            {
                lbl_status.Text = "Down";
                lbl_status.ForeColor = Color.Red;
                btn_StartService.Visible = true;
                btn_StopService.Visible = false;
            }

        }

        private void btn_StopService_Click(object sender, EventArgs e)
        {
            //todo tell each client you going to stop
            server.stop();
            btn_StopService.Visible = false;
            btn_StartService.Visible = true;
        }

        private void ConnectedClientsUpdated(string[] clients)
        {
            ((ListBox)chkedList_ConnectedUsers).DataSource = null;
            ((ListBox)chkedList_ConnectedUsers).DataSource = clients;
        }

        private void NewMessageArrived(string message)
        {
            txtBox_MessagesBox.Text += $"{message}{Environment.NewLine}";
        }

        private void btn_SendToAll_Click(object sender, EventArgs e)
        {
            string message = txtBox_MessageInpu.Text;
            txtBox_MessageInpu.Clear();
            txtBox_MessagesBox.Text += $"me(admin) -> {message}{Environment.NewLine}";
            server.SendMessageToAllClients(message);
        }

    }
}
