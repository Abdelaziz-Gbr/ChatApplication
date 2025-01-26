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
    public partial class EnterUserName : Form
    {
        Connection connection = Program.GetConnection();
        public EnterUserName()
        {
            InitializeComponent();
            connection.OnNameResponseRecieved += NameResponse;
        }

        

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            string name = txtBox_Name.Text;
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("User Name Can't be empty", "Invalid Input");
                return;
            }
            btn_Enter.Enabled = false;
            connection.SendNameAsync(name);

        }

        private void NameResponse(string res)
        {
            string[] serverResponse = res.Split('#');
            string header = serverResponse[0];
            string message = serverResponse[1];
            if (header != "success")
                btn_Enter.Enabled = true;
            else
            {
                connection.OnNameResponseRecieved -= NameResponse;
                Close();
            }
        }
    }
}
