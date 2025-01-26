namespace ChatApplicationUser
{
    partial class EnterUserName
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
            this.btn_Enter = new System.Windows.Forms.Button();
            this.txtBox_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Enter
            // 
            this.btn_Enter.AutoSize = true;
            this.btn_Enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enter.Location = new System.Drawing.Point(108, 74);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(137, 30);
            this.btn_Enter.TabIndex = 0;
            this.btn_Enter.Text = "Enter";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // txtBox_Name
            // 
            this.txtBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Name.Location = new System.Drawing.Point(16, 20);
            this.txtBox_Name.Margin = new System.Windows.Forms.Padding(99);
            this.txtBox_Name.Name = "txtBox_Name";
            this.txtBox_Name.Size = new System.Drawing.Size(311, 26);
            this.txtBox_Name.TabIndex = 1;
            // 
            // EnterUserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 116);
            this.ControlBox = false;
            this.Controls.Add(this.txtBox_Name);
            this.Controls.Add(this.btn_Enter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterUserName";
            this.Text = "Enter Your Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.TextBox txtBox_Name;
    }
}