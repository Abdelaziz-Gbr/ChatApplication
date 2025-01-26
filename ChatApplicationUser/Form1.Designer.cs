namespace ChatApplicationUser
{
    partial class ChatWithUs_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connnect = new System.Windows.Forms.Button();
            this.txtBox_Messages = new System.Windows.Forms.TextBox();
            this.txtBox_MessageInput = new System.Windows.Forms.TextBox();
            this.btn_SendToAll = new System.Windows.Forms.Button();
            this.btn_SendSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkedList_ConnectedUsers = new System.Windows.Forms.CheckedListBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Connnect
            // 
            this.btn_Connnect.AutoSize = true;
            this.btn_Connnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Connnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Connnect.Location = new System.Drawing.Point(0, 0);
            this.btn_Connnect.Name = "btn_Connnect";
            this.btn_Connnect.Size = new System.Drawing.Size(807, 30);
            this.btn_Connnect.TabIndex = 0;
            this.btn_Connnect.Text = "Connect";
            this.btn_Connnect.UseVisualStyleBackColor = true;
            this.btn_Connnect.Click += new System.EventHandler(this.btn_Connnect_Click);
            // 
            // txtBox_Messages
            // 
            this.txtBox_Messages.BackColor = System.Drawing.SystemColors.Info;
            this.txtBox_Messages.Enabled = false;
            this.txtBox_Messages.Location = new System.Drawing.Point(12, 61);
            this.txtBox_Messages.Multiline = true;
            this.txtBox_Messages.Name = "txtBox_Messages";
            this.txtBox_Messages.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBox_Messages.Size = new System.Drawing.Size(614, 334);
            this.txtBox_Messages.TabIndex = 1;
            // 
            // txtBox_MessageInput
            // 
            this.txtBox_MessageInput.Location = new System.Drawing.Point(12, 418);
            this.txtBox_MessageInput.Name = "txtBox_MessageInput";
            this.txtBox_MessageInput.Size = new System.Drawing.Size(614, 20);
            this.txtBox_MessageInput.TabIndex = 2;
            // 
            // btn_SendToAll
            // 
            this.btn_SendToAll.AutoSize = true;
            this.btn_SendToAll.Location = new System.Drawing.Point(633, 418);
            this.btn_SendToAll.Name = "btn_SendToAll";
            this.btn_SendToAll.Size = new System.Drawing.Size(75, 23);
            this.btn_SendToAll.TabIndex = 3;
            this.btn_SendToAll.Text = "Send All";
            this.btn_SendToAll.UseVisualStyleBackColor = true;
            this.btn_SendToAll.Click += new System.EventHandler(this.btn_SendToAll_Click);
            // 
            // btn_SendSelected
            // 
            this.btn_SendSelected.AutoSize = true;
            this.btn_SendSelected.Location = new System.Drawing.Point(714, 418);
            this.btn_SendSelected.Name = "btn_SendSelected";
            this.btn_SendSelected.Size = new System.Drawing.Size(87, 23);
            this.btn_SendSelected.TabIndex = 4;
            this.btn_SendSelected.Text = "Send Selected";
            this.btn_SendSelected.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(633, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Disconnected";
            // 
            // chkedList_ConnectedUsers
            // 
            this.chkedList_ConnectedUsers.FormattingEnabled = true;
            this.chkedList_ConnectedUsers.Location = new System.Drawing.Point(633, 61);
            this.chkedList_ConnectedUsers.Name = "chkedList_ConnectedUsers";
            this.chkedList_ConnectedUsers.Size = new System.Drawing.Size(167, 334);
            this.chkedList_ConnectedUsers.TabIndex = 7;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.AutoSize = true;
            this.btn_disconnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconnect.ForeColor = System.Drawing.Color.Red;
            this.btn_disconnect.Location = new System.Drawing.Point(0, 30);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(807, 30);
            this.btn_disconnect.TabIndex = 8;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Visible = false;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(12, 37);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(0, 20);
            this.lbl_name.TabIndex = 9;
            // 
            // ChatWithUs_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 450);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.chkedList_ConnectedUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SendSelected);
            this.Controls.Add(this.btn_SendToAll);
            this.Controls.Add(this.txtBox_MessageInput);
            this.Controls.Add(this.txtBox_Messages);
            this.Controls.Add(this.btn_Connnect);
            this.Name = "ChatWithUs_Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connnect;
        private System.Windows.Forms.TextBox txtBox_Messages;
        private System.Windows.Forms.TextBox txtBox_MessageInput;
        private System.Windows.Forms.Button btn_SendToAll;
        private System.Windows.Forms.Button btn_SendSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkedList_ConnectedUsers;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Label lbl_name;
    }
}

