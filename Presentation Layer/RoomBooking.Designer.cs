namespace BLU_HotelBooking
{
    partial class RoomBookingBanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomBookingBanner));
            this.CheckInlabel = new System.Windows.Forms.Label();
            this.CheckIndateTime = new System.Windows.Forms.DateTimePicker();
            this.checkoutDate = new System.Windows.Forms.DateTimePicker();
            this.Checkoutlabel = new System.Windows.Forms.Label();
            this.PersoncomboBox = new System.Windows.Forms.ComboBox();
            this.labelPerson = new System.Windows.Forms.Label();
            this.panelPopup = new System.Windows.Forms.Panel();
            this.OkPopupbutton = new System.Windows.Forms.Button();
            this.PopupClose = new System.Windows.Forms.Button();
            this.tablePopupLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DuePopuplabel1 = new System.Windows.Forms.Label();
            this.NamePopuplabel1 = new System.Windows.Forms.Label();
            this.CheckInPopuplabel1 = new System.Windows.Forms.Label();
            this.CheckoutPopuplabel1 = new System.Windows.Forms.Label();
            this.EmailPopuplabel1 = new System.Windows.Forms.Label();
            this.PhonePopuplabel1 = new System.Windows.Forms.Label();
            this.RoomPopuplabel1 = new System.Windows.Forms.Label();
            this.PaidPopuplabel1 = new System.Windows.Forms.Label();
            this.DuePopupLabel = new System.Windows.Forms.Label();
            this.paidPopupLabel = new System.Windows.Forms.Label();
            this.RoomPopupLabel = new System.Windows.Forms.Label();
            this.PhonePopupLabel = new System.Windows.Forms.Label();
            this.EmailPopupLabel = new System.Windows.Forms.Label();
            this.CheckOutPopuplabel = new System.Windows.Forms.Label();
            this.CheckInPopuplabel = new System.Windows.Forms.Label();
            this.NamePopuplabel = new System.Windows.Forms.Label();
            this.DaysLabel = new System.Windows.Forms.Label();
            this.DayscomboBox = new System.Windows.Forms.ComboBox();
            this.PersonErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PopupTimerRB = new System.Windows.Forms.Timer(this.components);
            this.checkInerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CheckOuterrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DaysStayerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkInCheckOutTime = new System.Windows.Forms.Label();
            this.PaymentLabel = new System.Windows.Forms.Label();
            this.panelPopup.SuspendLayout();
            this.tablePopupLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInerrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckOuterrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DaysStayerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckInlabel
            // 
            this.CheckInlabel.AutoSize = true;
            this.CheckInlabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckInlabel.ForeColor = System.Drawing.Color.Black;
            this.CheckInlabel.Location = new System.Drawing.Point(28, 65);
            this.CheckInlabel.Name = "CheckInlabel";
            this.CheckInlabel.Size = new System.Drawing.Size(88, 23);
            this.CheckInlabel.TabIndex = 0;
            this.CheckInlabel.Text = "Check In";
            // 
            // CheckIndateTime
            // 
            this.CheckIndateTime.CalendarFont = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckIndateTime.CalendarForeColor = System.Drawing.Color.White;
            this.CheckIndateTime.CalendarMonthBackground = System.Drawing.SystemColors.Highlight;
            this.CheckIndateTime.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.CheckIndateTime.CustomFormat = " ";
            this.CheckIndateTime.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckIndateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CheckIndateTime.Location = new System.Drawing.Point(156, 65);
            this.CheckIndateTime.Name = "CheckIndateTime";
            this.CheckIndateTime.Size = new System.Drawing.Size(303, 29);
            this.CheckIndateTime.TabIndex = 1;
            this.CheckIndateTime.ValueChanged += new System.EventHandler(this.CheckIndateTime_ValueChanged);
            // 
            // checkoutDate
            // 
            this.checkoutDate.CalendarFont = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutDate.CalendarForeColor = System.Drawing.Color.White;
            this.checkoutDate.CalendarMonthBackground = System.Drawing.SystemColors.Highlight;
            this.checkoutDate.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.checkoutDate.CustomFormat = " ";
            this.checkoutDate.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.checkoutDate.Location = new System.Drawing.Point(156, 125);
            this.checkoutDate.Name = "checkoutDate";
            this.checkoutDate.Size = new System.Drawing.Size(303, 29);
            this.checkoutDate.TabIndex = 3;
            this.checkoutDate.ValueChanged += new System.EventHandler(this.checkoutDate_ValueChanged);
            // 
            // Checkoutlabel
            // 
            this.Checkoutlabel.AutoSize = true;
            this.Checkoutlabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Checkoutlabel.ForeColor = System.Drawing.Color.Black;
            this.Checkoutlabel.Location = new System.Drawing.Point(28, 125);
            this.Checkoutlabel.Name = "Checkoutlabel";
            this.Checkoutlabel.Size = new System.Drawing.Size(102, 23);
            this.Checkoutlabel.TabIndex = 2;
            this.Checkoutlabel.Text = "Check Out";
            // 
            // PersoncomboBox
            // 
            this.PersoncomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PersoncomboBox.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersoncomboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(59)))));
            this.PersoncomboBox.FormattingEnabled = true;
            this.PersoncomboBox.Location = new System.Drawing.Point(156, 183);
            this.PersoncomboBox.Name = "PersoncomboBox";
            this.PersoncomboBox.Size = new System.Drawing.Size(303, 35);
            this.PersoncomboBox.TabIndex = 4;
            this.PersoncomboBox.SelectedIndexChanged += new System.EventHandler(this.PersoncomboBox_SelectedIndexChanged);
            this.PersoncomboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PersoncomboBox_KeyPress);
            this.PersoncomboBox.Leave += new System.EventHandler(this.PersoncomboBox_Leave);
            // 
            // labelPerson
            // 
            this.labelPerson.AutoSize = true;
            this.labelPerson.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerson.ForeColor = System.Drawing.Color.Black;
            this.labelPerson.Location = new System.Drawing.Point(28, 183);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(74, 23);
            this.labelPerson.TabIndex = 6;
            this.labelPerson.Text = "Person";
            // 
            // panelPopup
            // 
            this.panelPopup.BackColor = System.Drawing.Color.DarkCyan;
            this.panelPopup.Controls.Add(this.OkPopupbutton);
            this.panelPopup.Controls.Add(this.PopupClose);
            this.panelPopup.Controls.Add(this.tablePopupLayoutPanel);
            this.panelPopup.Controls.Add(this.DuePopupLabel);
            this.panelPopup.Controls.Add(this.paidPopupLabel);
            this.panelPopup.Controls.Add(this.RoomPopupLabel);
            this.panelPopup.Controls.Add(this.PhonePopupLabel);
            this.panelPopup.Controls.Add(this.EmailPopupLabel);
            this.panelPopup.Controls.Add(this.CheckOutPopuplabel);
            this.panelPopup.Controls.Add(this.CheckInPopuplabel);
            this.panelPopup.Controls.Add(this.NamePopuplabel);
            this.panelPopup.Location = new System.Drawing.Point(32, 288);
            this.panelPopup.Name = "panelPopup";
            this.panelPopup.Size = new System.Drawing.Size(427, 402);
            this.panelPopup.TabIndex = 7;
            // 
            // OkPopupbutton
            // 
            this.OkPopupbutton.BackColor = System.Drawing.Color.Purple;
            this.OkPopupbutton.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.OkPopupbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkPopupbutton.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkPopupbutton.ForeColor = System.Drawing.Color.White;
            this.OkPopupbutton.Location = new System.Drawing.Point(144, 358);
            this.OkPopupbutton.Name = "OkPopupbutton";
            this.OkPopupbutton.Size = new System.Drawing.Size(75, 32);
            this.OkPopupbutton.TabIndex = 30;
            this.OkPopupbutton.Text = "OK";
            this.OkPopupbutton.UseVisualStyleBackColor = false;
            this.OkPopupbutton.Click += new System.EventHandler(this.OkPopupbutton_Click_1);
            // 
            // PopupClose
            // 
            this.PopupClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PopupClose.BackgroundImage")));
            this.PopupClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PopupClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.PopupClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopupClose.Location = new System.Drawing.Point(389, 8);
            this.PopupClose.Name = "PopupClose";
            this.PopupClose.Size = new System.Drawing.Size(35, 23);
            this.PopupClose.TabIndex = 10;
            this.PopupClose.UseVisualStyleBackColor = true;
            this.PopupClose.Click += new System.EventHandler(this.PopupClose_Click);
            // 
            // tablePopupLayoutPanel
            // 
            this.tablePopupLayoutPanel.ColumnCount = 1;
            this.tablePopupLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePopupLayoutPanel.Controls.Add(this.DuePopuplabel1, 0, 7);
            this.tablePopupLayoutPanel.Controls.Add(this.NamePopuplabel1, 0, 0);
            this.tablePopupLayoutPanel.Controls.Add(this.CheckInPopuplabel1, 0, 1);
            this.tablePopupLayoutPanel.Controls.Add(this.CheckoutPopuplabel1, 0, 2);
            this.tablePopupLayoutPanel.Controls.Add(this.EmailPopuplabel1, 0, 3);
            this.tablePopupLayoutPanel.Controls.Add(this.PhonePopuplabel1, 0, 4);
            this.tablePopupLayoutPanel.Controls.Add(this.RoomPopuplabel1, 0, 5);
            this.tablePopupLayoutPanel.Controls.Add(this.PaidPopuplabel1, 0, 6);
            this.tablePopupLayoutPanel.Location = new System.Drawing.Point(117, 37);
            this.tablePopupLayoutPanel.Name = "tablePopupLayoutPanel";
            this.tablePopupLayoutPanel.RowCount = 8;
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePopupLayoutPanel.Size = new System.Drawing.Size(307, 315);
            this.tablePopupLayoutPanel.TabIndex = 9;
            // 
            // DuePopuplabel1
            // 
            this.DuePopuplabel1.AutoSize = true;
            this.DuePopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DuePopuplabel1.ForeColor = System.Drawing.Color.White;
            this.DuePopuplabel1.Location = new System.Drawing.Point(3, 273);
            this.DuePopuplabel1.Name = "DuePopuplabel1";
            this.DuePopuplabel1.Size = new System.Drawing.Size(22, 23);
            this.DuePopuplabel1.TabIndex = 9;
            this.DuePopuplabel1.Text = "0";
            // 
            // NamePopuplabel1
            // 
            this.NamePopuplabel1.AutoSize = true;
            this.NamePopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePopuplabel1.ForeColor = System.Drawing.Color.White;
            this.NamePopuplabel1.Location = new System.Drawing.Point(3, 0);
            this.NamePopuplabel1.Name = "NamePopuplabel1";
            this.NamePopuplabel1.Size = new System.Drawing.Size(64, 23);
            this.NamePopuplabel1.TabIndex = 2;
            this.NamePopuplabel1.Text = "Name";
            // 
            // CheckInPopuplabel1
            // 
            this.CheckInPopuplabel1.AutoSize = true;
            this.CheckInPopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckInPopuplabel1.ForeColor = System.Drawing.Color.White;
            this.CheckInPopuplabel1.Location = new System.Drawing.Point(3, 39);
            this.CheckInPopuplabel1.Name = "CheckInPopuplabel1";
            this.CheckInPopuplabel1.Size = new System.Drawing.Size(88, 23);
            this.CheckInPopuplabel1.TabIndex = 3;
            this.CheckInPopuplabel1.Text = "Check In";
            // 
            // CheckoutPopuplabel1
            // 
            this.CheckoutPopuplabel1.AutoSize = true;
            this.CheckoutPopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckoutPopuplabel1.ForeColor = System.Drawing.Color.White;
            this.CheckoutPopuplabel1.Location = new System.Drawing.Point(3, 78);
            this.CheckoutPopuplabel1.Name = "CheckoutPopuplabel1";
            this.CheckoutPopuplabel1.Size = new System.Drawing.Size(99, 23);
            this.CheckoutPopuplabel1.TabIndex = 4;
            this.CheckoutPopuplabel1.Text = "Check out";
            // 
            // EmailPopuplabel1
            // 
            this.EmailPopuplabel1.AutoSize = true;
            this.EmailPopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailPopuplabel1.ForeColor = System.Drawing.Color.White;
            this.EmailPopuplabel1.Location = new System.Drawing.Point(3, 117);
            this.EmailPopuplabel1.Name = "EmailPopuplabel1";
            this.EmailPopuplabel1.Size = new System.Drawing.Size(63, 23);
            this.EmailPopuplabel1.TabIndex = 5;
            this.EmailPopuplabel1.Text = "Email";
            // 
            // PhonePopuplabel1
            // 
            this.PhonePopuplabel1.AutoSize = true;
            this.PhonePopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhonePopuplabel1.ForeColor = System.Drawing.Color.White;
            this.PhonePopuplabel1.Location = new System.Drawing.Point(3, 156);
            this.PhonePopuplabel1.Name = "PhonePopuplabel1";
            this.PhonePopuplabel1.Size = new System.Drawing.Size(58, 23);
            this.PhonePopuplabel1.TabIndex = 6;
            this.PhonePopuplabel1.Text = "+880";
            // 
            // RoomPopuplabel1
            // 
            this.RoomPopuplabel1.AutoSize = true;
            this.RoomPopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomPopuplabel1.ForeColor = System.Drawing.Color.White;
            this.RoomPopuplabel1.Location = new System.Drawing.Point(3, 195);
            this.RoomPopuplabel1.Name = "RoomPopuplabel1";
            this.RoomPopuplabel1.Size = new System.Drawing.Size(67, 23);
            this.RoomPopuplabel1.TabIndex = 7;
            this.RoomPopuplabel1.Text = "Room ";
            // 
            // PaidPopuplabel1
            // 
            this.PaidPopuplabel1.AutoSize = true;
            this.PaidPopuplabel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaidPopuplabel1.ForeColor = System.Drawing.Color.White;
            this.PaidPopuplabel1.Location = new System.Drawing.Point(3, 234);
            this.PaidPopuplabel1.Name = "PaidPopuplabel1";
            this.PaidPopuplabel1.Size = new System.Drawing.Size(22, 23);
            this.PaidPopuplabel1.TabIndex = 8;
            this.PaidPopuplabel1.Text = "0";
            // 
            // DuePopupLabel
            // 
            this.DuePopupLabel.AutoSize = true;
            this.DuePopupLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DuePopupLabel.ForeColor = System.Drawing.Color.Black;
            this.DuePopupLabel.Location = new System.Drawing.Point(3, 311);
            this.DuePopupLabel.Name = "DuePopupLabel";
            this.DuePopupLabel.Size = new System.Drawing.Size(47, 23);
            this.DuePopupLabel.TabIndex = 8;
            this.DuePopupLabel.Text = "Due";
            // 
            // paidPopupLabel
            // 
            this.paidPopupLabel.AutoSize = true;
            this.paidPopupLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidPopupLabel.ForeColor = System.Drawing.Color.Black;
            this.paidPopupLabel.Location = new System.Drawing.Point(3, 274);
            this.paidPopupLabel.Name = "paidPopupLabel";
            this.paidPopupLabel.Size = new System.Drawing.Size(51, 23);
            this.paidPopupLabel.TabIndex = 7;
            this.paidPopupLabel.Text = "Paid";
            // 
            // RoomPopupLabel
            // 
            this.RoomPopupLabel.AutoSize = true;
            this.RoomPopupLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomPopupLabel.ForeColor = System.Drawing.Color.Black;
            this.RoomPopupLabel.Location = new System.Drawing.Point(3, 234);
            this.RoomPopupLabel.Name = "RoomPopupLabel";
            this.RoomPopupLabel.Size = new System.Drawing.Size(92, 23);
            this.RoomPopupLabel.TabIndex = 6;
            this.RoomPopupLabel.Text = "Room No";
            // 
            // PhonePopupLabel
            // 
            this.PhonePopupLabel.AutoSize = true;
            this.PhonePopupLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhonePopupLabel.ForeColor = System.Drawing.Color.Black;
            this.PhonePopupLabel.Location = new System.Drawing.Point(3, 196);
            this.PhonePopupLabel.Name = "PhonePopupLabel";
            this.PhonePopupLabel.Size = new System.Drawing.Size(68, 23);
            this.PhonePopupLabel.TabIndex = 5;
            this.PhonePopupLabel.Text = "Phone";
            // 
            // EmailPopupLabel
            // 
            this.EmailPopupLabel.AutoSize = true;
            this.EmailPopupLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailPopupLabel.ForeColor = System.Drawing.Color.Black;
            this.EmailPopupLabel.Location = new System.Drawing.Point(3, 154);
            this.EmailPopupLabel.Name = "EmailPopupLabel";
            this.EmailPopupLabel.Size = new System.Drawing.Size(63, 23);
            this.EmailPopupLabel.TabIndex = 4;
            this.EmailPopupLabel.Text = "Email";
            // 
            // CheckOutPopuplabel
            // 
            this.CheckOutPopuplabel.AutoSize = true;
            this.CheckOutPopuplabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckOutPopuplabel.ForeColor = System.Drawing.Color.Black;
            this.CheckOutPopuplabel.Location = new System.Drawing.Point(3, 113);
            this.CheckOutPopuplabel.Name = "CheckOutPopuplabel";
            this.CheckOutPopuplabel.Size = new System.Drawing.Size(102, 23);
            this.CheckOutPopuplabel.TabIndex = 3;
            this.CheckOutPopuplabel.Text = "Check Out";
            // 
            // CheckInPopuplabel
            // 
            this.CheckInPopuplabel.AutoSize = true;
            this.CheckInPopuplabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckInPopuplabel.ForeColor = System.Drawing.Color.Black;
            this.CheckInPopuplabel.Location = new System.Drawing.Point(3, 73);
            this.CheckInPopuplabel.Name = "CheckInPopuplabel";
            this.CheckInPopuplabel.Size = new System.Drawing.Size(88, 23);
            this.CheckInPopuplabel.TabIndex = 2;
            this.CheckInPopuplabel.Text = "Check In";
            // 
            // NamePopuplabel
            // 
            this.NamePopuplabel.AutoSize = true;
            this.NamePopuplabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamePopuplabel.ForeColor = System.Drawing.Color.Black;
            this.NamePopuplabel.Location = new System.Drawing.Point(3, 37);
            this.NamePopuplabel.Name = "NamePopuplabel";
            this.NamePopuplabel.Size = new System.Drawing.Size(64, 23);
            this.NamePopuplabel.TabIndex = 1;
            this.NamePopuplabel.Text = "Name";
            // 
            // DaysLabel
            // 
            this.DaysLabel.AutoSize = true;
            this.DaysLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysLabel.ForeColor = System.Drawing.Color.Black;
            this.DaysLabel.Location = new System.Drawing.Point(28, 233);
            this.DaysLabel.Name = "DaysLabel";
            this.DaysLabel.Size = new System.Drawing.Size(118, 23);
            this.DaysLabel.TabIndex = 9;
            this.DaysLabel.Text = "Days to Stay";
            // 
            // DayscomboBox
            // 
            this.DayscomboBox.Enabled = false;
            this.DayscomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DayscomboBox.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayscomboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(59)))));
            this.DayscomboBox.FormattingEnabled = true;
            this.DayscomboBox.Location = new System.Drawing.Point(156, 227);
            this.DayscomboBox.Name = "DayscomboBox";
            this.DayscomboBox.Size = new System.Drawing.Size(84, 35);
            this.DayscomboBox.TabIndex = 8;
            this.DayscomboBox.SelectedIndexChanged += new System.EventHandler(this.DayscomboBox_SelectedIndexChanged);
            // 
            // PersonErrorProvider
            // 
            this.PersonErrorProvider.ContainerControl = this;
            // 
            // PopupTimerRB
            // 
            this.PopupTimerRB.Tick += new System.EventHandler(this.PopupTimerRB_Tick);
            // 
            // checkInerrorProvider
            // 
            this.checkInerrorProvider.ContainerControl = this;
            // 
            // CheckOuterrorProvider
            // 
            this.CheckOuterrorProvider.ContainerControl = this;
            // 
            // DaysStayerrorProvider
            // 
            this.DaysStayerrorProvider.ContainerControl = this;
            // 
            // checkInCheckOutTime
            // 
            this.checkInCheckOutTime.AutoSize = true;
            this.checkInCheckOutTime.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInCheckOutTime.ForeColor = System.Drawing.Color.Honeydew;
            this.checkInCheckOutTime.Location = new System.Drawing.Point(325, 17);
            this.checkInCheckOutTime.Name = "checkInCheckOutTime";
            this.checkInCheckOutTime.Size = new System.Drawing.Size(438, 28);
            this.checkInCheckOutTime.TabIndex = 10;
            this.checkInCheckOutTime.Text = "Check-in and Check-out Time 10.00 AM";
            // 
            // PaymentLabel
            // 
            this.PaymentLabel.AutoSize = true;
            this.PaymentLabel.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentLabel.ForeColor = System.Drawing.Color.Black;
            this.PaymentLabel.Location = new System.Drawing.Point(246, 230);
            this.PaymentLabel.Name = "PaymentLabel";
            this.PaymentLabel.Size = new System.Drawing.Size(139, 28);
            this.PaymentLabel.TabIndex = 11;
            this.PaymentLabel.Text = "Payment : 0";
            // 
            // RoomBookingBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Controls.Add(this.PaymentLabel);
            this.Controls.Add(this.checkInCheckOutTime);
            this.Controls.Add(this.DaysLabel);
            this.Controls.Add(this.DayscomboBox);
            this.Controls.Add(this.panelPopup);
            this.Controls.Add(this.labelPerson);
            this.Controls.Add(this.PersoncomboBox);
            this.Controls.Add(this.checkoutDate);
            this.Controls.Add(this.Checkoutlabel);
            this.Controls.Add(this.CheckIndateTime);
            this.Controls.Add(this.CheckInlabel);
            this.Name = "RoomBookingBanner";
            this.Size = new System.Drawing.Size(1018, 731);
            this.Load += new System.EventHandler(this.RoomBooking_Load);
            this.panelPopup.ResumeLayout(false);
            this.panelPopup.PerformLayout();
            this.tablePopupLayoutPanel.ResumeLayout(false);
            this.tablePopupLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInerrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckOuterrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DaysStayerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CheckInlabel;
        private System.Windows.Forms.Label Checkoutlabel;
        private System.Windows.Forms.Label labelPerson;
        private System.Windows.Forms.Label DuePopupLabel;
        private System.Windows.Forms.Label paidPopupLabel;
        private System.Windows.Forms.Label RoomPopupLabel;
        private System.Windows.Forms.Label PhonePopupLabel;
        private System.Windows.Forms.Label EmailPopupLabel;
        private System.Windows.Forms.Label CheckOutPopuplabel;
        private System.Windows.Forms.Label CheckInPopuplabel;
        private System.Windows.Forms.Label NamePopuplabel;
        public System.Windows.Forms.Panel panelPopup;
        public System.Windows.Forms.DateTimePicker CheckIndateTime;
        public System.Windows.Forms.DateTimePicker checkoutDate;
        public System.Windows.Forms.ComboBox PersoncomboBox;
        public System.Windows.Forms.Label DuePopuplabel1;
        public System.Windows.Forms.Label NamePopuplabel1;
        public System.Windows.Forms.Label CheckInPopuplabel1;
        public System.Windows.Forms.Label CheckoutPopuplabel1;
        public System.Windows.Forms.Label EmailPopuplabel1;
        public System.Windows.Forms.Label PhonePopuplabel1;
        public System.Windows.Forms.Label RoomPopuplabel1;
        public System.Windows.Forms.Label PaidPopuplabel1;
        private System.Windows.Forms.Label DaysLabel;
        public System.Windows.Forms.ComboBox DayscomboBox;
        private System.Windows.Forms.Button PopupClose;
        public System.Windows.Forms.TableLayoutPanel tablePopupLayoutPanel;
        public System.Windows.Forms.Timer PopupTimerRB;
        private System.Windows.Forms.Button OkPopupbutton;
        public System.Windows.Forms.ErrorProvider checkInerrorProvider;
        public System.Windows.Forms.ErrorProvider CheckOuterrorProvider;
        private System.Windows.Forms.ErrorProvider DaysStayerrorProvider;
        public System.Windows.Forms.ErrorProvider PersonErrorProvider;
        private System.Windows.Forms.Label checkInCheckOutTime;
        public System.Windows.Forms.Label PaymentLabel;
    }
}
