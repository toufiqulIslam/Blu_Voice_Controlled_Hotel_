namespace BLU_HotelBooking
{
    partial class BookedRooms
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBookedLogin = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginBookedButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PassAdmintextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameAdmintextBox = new System.Windows.Forms.TextBox();
            this.panelBookedLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(955, 737);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelBookedLogin
            // 
            this.panelBookedLogin.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBookedLogin.Controls.Add(this.label3);
            this.panelBookedLogin.Controls.Add(this.LoginBookedButton);
            this.panelBookedLogin.Controls.Add(this.label2);
            this.panelBookedLogin.Controls.Add(this.PassAdmintextBox);
            this.panelBookedLogin.Controls.Add(this.label1);
            this.panelBookedLogin.Controls.Add(this.NameAdmintextBox);
            this.panelBookedLogin.Location = new System.Drawing.Point(73, 38);
            this.panelBookedLogin.Name = "panelBookedLogin";
            this.panelBookedLogin.Size = new System.Drawing.Size(242, 245);
            this.panelBookedLogin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Administrative Login";
            // 
            // LoginBookedButton
            // 
            this.LoginBookedButton.BackColor = System.Drawing.Color.Red;
            this.LoginBookedButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginBookedButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBookedButton.ForeColor = System.Drawing.Color.White;
            this.LoginBookedButton.Location = new System.Drawing.Point(79, 203);
            this.LoginBookedButton.Name = "LoginBookedButton";
            this.LoginBookedButton.Size = new System.Drawing.Size(87, 35);
            this.LoginBookedButton.TabIndex = 4;
            this.LoginBookedButton.Text = "Login";
            this.LoginBookedButton.UseVisualStyleBackColor = false;
            this.LoginBookedButton.Click += new System.EventHandler(this.LoginBookedButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // PassAdmintextBox
            // 
            this.PassAdmintextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassAdmintextBox.Location = new System.Drawing.Point(3, 141);
            this.PassAdmintextBox.Multiline = true;
            this.PassAdmintextBox.Name = "PassAdmintextBox";
            this.PassAdmintextBox.PasswordChar = '*';
            this.PassAdmintextBox.Size = new System.Drawing.Size(236, 43);
            this.PassAdmintextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // NameAdmintextBox
            // 
            this.NameAdmintextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameAdmintextBox.Location = new System.Drawing.Point(3, 59);
            this.NameAdmintextBox.Multiline = true;
            this.NameAdmintextBox.Name = "NameAdmintextBox";
            this.NameAdmintextBox.Size = new System.Drawing.Size(236, 43);
            this.NameAdmintextBox.TabIndex = 0;
            // 
            // BookedRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Controls.Add(this.panelBookedLogin);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BookedRooms";
            this.Size = new System.Drawing.Size(955, 737);
            this.Load += new System.EventHandler(this.BookedRooms_Load);
            this.panelBookedLogin.ResumeLayout(false);
            this.panelBookedLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button LoginBookedButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panelBookedLogin;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox PassAdmintextBox;
        public System.Windows.Forms.TextBox NameAdmintextBox;
    }
}
