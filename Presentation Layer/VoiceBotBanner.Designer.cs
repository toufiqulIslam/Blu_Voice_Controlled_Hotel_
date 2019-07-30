namespace BLU_HotelBooking
{
    partial class VoiceBotBanner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceBotBanner));
            this.label1 = new System.Windows.Forms.Label();
            this.colortimer = new System.Windows.Forms.Timer(this.components);
            this.YellowButon = new BLU_HotelBooking.circularButton();
            this.OrangeButton = new BLU_HotelBooking.circularButton();
            this.WhiteButton = new BLU_HotelBooking.circularButton();
            this.RedButton = new BLU_HotelBooking.circularButton();
            this.circularButton1 = new BLU_HotelBooking.circularButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hi, There. Click Me To Assist You";
            // 
            // colortimer
            // 
            this.colortimer.Tick += new System.EventHandler(this.colortimer_Tick);
            // 
            // YellowButon
            // 
            this.YellowButon.AutoSize = true;
            this.YellowButon.BackColor = System.Drawing.Color.Yellow;
            this.YellowButon.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.YellowButon.FlatAppearance.BorderSize = 0;
            this.YellowButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YellowButon.Location = new System.Drawing.Point(559, 381);
            this.YellowButon.Name = "YellowButon";
            this.YellowButon.Size = new System.Drawing.Size(31, 33);
            this.YellowButon.TabIndex = 5;
            this.YellowButon.UseVisualStyleBackColor = false;
            // 
            // OrangeButton
            // 
            this.OrangeButton.BackColor = System.Drawing.Color.OrangeRed;
            this.OrangeButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.OrangeButton.FlatAppearance.BorderSize = 0;
            this.OrangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrangeButton.Location = new System.Drawing.Point(633, 381);
            this.OrangeButton.Name = "OrangeButton";
            this.OrangeButton.Size = new System.Drawing.Size(31, 33);
            this.OrangeButton.TabIndex = 4;
            this.OrangeButton.UseVisualStyleBackColor = false;
            // 
            // WhiteButton
            // 
            this.WhiteButton.AutoSize = true;
            this.WhiteButton.BackColor = System.Drawing.Color.White;
            this.WhiteButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.WhiteButton.FlatAppearance.BorderSize = 0;
            this.WhiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteButton.Location = new System.Drawing.Point(596, 381);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(31, 33);
            this.WhiteButton.TabIndex = 3;
            this.WhiteButton.UseVisualStyleBackColor = false;
            // 
            // RedButton
            // 
            this.RedButton.BackColor = System.Drawing.Color.Red;
            this.RedButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.RedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedButton.Location = new System.Drawing.Point(522, 381);
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(31, 33);
            this.RedButton.TabIndex = 2;
            this.RedButton.UseVisualStyleBackColor = false;
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.Color.MediumBlue;
            this.circularButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circularButton1.BackgroundImage")));
            this.circularButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.circularButton1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Location = new System.Drawing.Point(491, 213);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(208, 162);
            this.circularButton1.TabIndex = 0;
            this.circularButton1.UseVisualStyleBackColor = false;
            this.circularButton1.Click += new System.EventHandler(this.circularButton1_Click);
            // 
            // VoiceBotBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.Controls.Add(this.YellowButon);
            this.Controls.Add(this.OrangeButton);
            this.Controls.Add(this.WhiteButton);
            this.Controls.Add(this.RedButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circularButton1);
            this.Name = "VoiceBotBanner";
            this.Size = new System.Drawing.Size(1252, 731);
            this.Load += new System.EventHandler(this.VoiceBotBanner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private circularButton RedButton;
        private circularButton WhiteButton;
        private circularButton OrangeButton;
        private circularButton YellowButon;
        private System.Windows.Forms.Timer colortimer;
        public circularButton circularButton1;
    }
}
