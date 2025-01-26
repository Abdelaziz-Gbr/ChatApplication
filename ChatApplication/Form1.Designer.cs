namespace ChatApplication
{
    partial class ChatApplication_Server
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
            this.btn_StartService = new System.Windows.Forms.Button();
            this.txtBox_MessagesBox = new System.Windows.Forms.TextBox();
            this.txtBox_MessageInpu = new System.Windows.Forms.TextBox();
            this.btn_SendToAll = new System.Windows.Forms.Button();
            this.btn_SendToClients = new System.Windows.Forms.Button();
            this.btn_BlockSelected = new System.Windows.Forms.Button();
            this.chkedList_ConnectedUsers = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_StopService = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_StartService
            // 
            this.btn_StartService.AutoSize = true;
            this.btn_StartService.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_StartService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartService.Location = new System.Drawing.Point(0, 0);
            this.btn_StartService.Name = "btn_StartService";
            this.btn_StartService.Padding = new System.Windows.Forms.Padding(8);
            this.btn_StartService.Size = new System.Drawing.Size(1167, 46);
            this.btn_StartService.TabIndex = 0;
            this.btn_StartService.Text = "Start Service";
            this.btn_StartService.UseVisualStyleBackColor = true;
            this.btn_StartService.Click += new System.EventHandler(this.btn_StartService_Click);
            // 
            // txtBox_MessagesBox
            // 
            this.txtBox_MessagesBox.BackColor = System.Drawing.SystemColors.Info;
            this.txtBox_MessagesBox.Enabled = false;
            this.txtBox_MessagesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_MessagesBox.Location = new System.Drawing.Point(12, 73);
            this.txtBox_MessagesBox.Multiline = true;
            this.txtBox_MessagesBox.Name = "txtBox_MessagesBox";
            this.txtBox_MessagesBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBox_MessagesBox.Size = new System.Drawing.Size(870, 429);
            this.txtBox_MessagesBox.TabIndex = 1;
            // 
            // txtBox_MessageInpu
            // 
            this.txtBox_MessageInpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_MessageInpu.Location = new System.Drawing.Point(12, 539);
            this.txtBox_MessageInpu.Name = "txtBox_MessageInpu";
            this.txtBox_MessageInpu.Size = new System.Drawing.Size(560, 26);
            this.txtBox_MessageInpu.TabIndex = 2;
            // 
            // btn_SendToAll
            // 
            this.btn_SendToAll.AutoSize = true;
            this.btn_SendToAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SendToAll.Location = new System.Drawing.Point(578, 539);
            this.btn_SendToAll.Name = "btn_SendToAll";
            this.btn_SendToAll.Size = new System.Drawing.Size(100, 30);
            this.btn_SendToAll.TabIndex = 3;
            this.btn_SendToAll.Text = "Send To All";
            this.btn_SendToAll.UseVisualStyleBackColor = true;
            this.btn_SendToAll.Click += new System.EventHandler(this.btn_SendToAll_Click);
            // 
            // btn_SendToClients
            // 
            this.btn_SendToClients.AutoSize = true;
            this.btn_SendToClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SendToClients.Location = new System.Drawing.Point(684, 539);
            this.btn_SendToClients.Name = "btn_SendToClients";
            this.btn_SendToClients.Size = new System.Drawing.Size(198, 30);
            this.btn_SendToClients.TabIndex = 4;
            this.btn_SendToClients.Text = "Send To Selected Clients";
            this.btn_SendToClients.UseVisualStyleBackColor = true;
            // 
            // btn_BlockSelected
            // 
            this.btn_BlockSelected.AutoSize = true;
            this.btn_BlockSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BlockSelected.Location = new System.Drawing.Point(1053, 537);
            this.btn_BlockSelected.Name = "btn_BlockSelected";
            this.btn_BlockSelected.Size = new System.Drawing.Size(102, 30);
            this.btn_BlockSelected.TabIndex = 5;
            this.btn_BlockSelected.Text = "Block Client";
            this.btn_BlockSelected.UseVisualStyleBackColor = true;
            // 
            // chkedList_ConnectedUsers
            // 
            this.chkedList_ConnectedUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkedList_ConnectedUsers.FormattingEnabled = true;
            this.chkedList_ConnectedUsers.Location = new System.Drawing.Point(888, 103);
            this.chkedList_ConnectedUsers.Name = "chkedList_ConnectedUsers";
            this.chkedList_ConnectedUsers.Size = new System.Drawing.Size(267, 394);
            this.chkedList_ConnectedUsers.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1026, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server Status: ";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_status.Location = new System.Drawing.Point(1100, 49);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(35, 13);
            this.lbl_status.TabIndex = 8;
            this.lbl_status.Text = "Down";
            // 
            // btn_StopService
            // 
            this.btn_StopService.AutoSize = true;
            this.btn_StopService.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_StopService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StopService.ForeColor = System.Drawing.Color.Red;
            this.btn_StopService.Location = new System.Drawing.Point(0, 46);
            this.btn_StopService.Name = "btn_StopService";
            this.btn_StopService.Padding = new System.Windows.Forms.Padding(8);
            this.btn_StopService.Size = new System.Drawing.Size(1167, 46);
            this.btn_StopService.TabIndex = 9;
            this.btn_StopService.Text = "Stop Service";
            this.btn_StopService.UseVisualStyleBackColor = true;
            this.btn_StopService.Visible = false;
            this.btn_StopService.Click += new System.EventHandler(this.btn_StopService_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(888, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Connected Users";
            // 
            // ChatApplication_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 577);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_StopService);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkedList_ConnectedUsers);
            this.Controls.Add(this.btn_BlockSelected);
            this.Controls.Add(this.btn_SendToClients);
            this.Controls.Add(this.btn_SendToAll);
            this.Controls.Add(this.txtBox_MessageInpu);
            this.Controls.Add(this.txtBox_MessagesBox);
            this.Controls.Add(this.btn_StartService);
            this.Name = "ChatApplication_Server";
            this.Text = "Chat Application Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartService;
        private System.Windows.Forms.TextBox txtBox_MessagesBox;
        private System.Windows.Forms.TextBox txtBox_MessageInpu;
        private System.Windows.Forms.Button btn_SendToAll;
        private System.Windows.Forms.Button btn_SendToClients;
        private System.Windows.Forms.Button btn_BlockSelected;
        private System.Windows.Forms.CheckedListBox chkedList_ConnectedUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_StopService;
        private System.Windows.Forms.Label label2;
    }
}

