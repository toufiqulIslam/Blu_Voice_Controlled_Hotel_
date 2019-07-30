using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Data.SqlClient;
using BLU_HotelBooking.Business_Logic_Layer;
using System.Globalization;

namespace BLU_HotelBooking
{
    public partial class Booking : Form
    {
        CheckNWork cw = new CheckNWork();
        int loginCount = 1;
        List<RoomList> list = new List<RoomList>();

        int panel_width;
        bool hided;

        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        Choices sList = new Choices();

        public Booking()
        {
            InitializeComponent();
            Loginpanel.Visible = false;
            BluDisplaylabel.Visible = false;

            roomBookingBanner2.Visible = false;
            availability2.Visible = false;
            clientInfo1.Visible = false;
            bookedRooms2.Visible = false;
            MenuArrowlabl.Visible = false;
            MenuArrowpictureBox.Visible = false;

            panel_width = Sliderpanel.Width;
            Sliderpanel.Width-= Sliderpanel.Width;
            hided = true;
            DoneButton.Visible = false;
            voiceBotBanner3.ButtonClicked += new EventHandler(voiceBotBanner3_Buttonclick);
            roomBookingBanner2.ButtonClicked += new EventHandler(roomBookingBanner2_ButtonClick);
            roomBookingBanner2.ValueChanged += new EventHandler(roomBookingBanner2_ValueChanged);
            availability2.DateChanged += new EventHandler(availability2_DateChanged);
            availability2.PaymentEvent += new EventHandler(roomBookingBanner2_ValueChanged);

            MyBookingsTextButton.Enabled=false;
            AvailabilityTextButton.Enabled=false;

            VoiceHelppanel.Visible = false;
    }

        private void closebookingbutton_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure you want to close the application?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (ask == DialogResult.Yes)
            {
                HomeButton.PerformClick();
                sSynth.Speak("BLU is Shutting Down");
                
                Application.Exit();
            }
            else
            {

            }
        }

        private void minimizebookingbutton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void panelbookingControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X;
                mouseY = MousePosition.Y;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panelbookingControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelbookingControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void loginBookingButton_Click(object sender, EventArgs e)
        {
            loginCount++;
            if (loginCount % 2 == 0)
            {
                loginBookingButton.Text = "Login";
                MyBookingsTextButton.Enabled = false;
                AvailabilityTextButton.Enabled = false;

                userNameLogintextBox.Enabled = true;
                passLogintextBox.Enabled = true;
                loginButton.Enabled = true;
                userNameLogintextBox.Text = passLogintextBox.Text = "";
                Loginpanel.Visible = true;
            }
            else
                Loginpanel.Visible = false;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userNameLogintextBox.Text == "" || passLogintextBox.Text == "")
            {
                sSynth.SpeakAsync("Please Fillup All Information");
                MessageBox.Show("Please Fillup All Information Correctly"); 
            }
            else if (userNameLogintextBox.Text != "Secure" || passLogintextBox.Text != "BLUissecure")
            {
                sSynth.SpeakAsync("Invalid Login Info , Please Retry");
                MessageBox.Show("Username & Password Doesn't Match", "Warning");
            }
            else
            {
                sSynth.SpeakAsync("Welcome To BLU");
                userNameLogintextBox.Enabled = false;
                passLogintextBox.Enabled = false;

                MyBookingsTextButton.Enabled = true;
                AvailabilityTextButton.Enabled = true;
                BookedTextButton.Enabled = true;

                Loginpanel.Visible = false;
                loginButton.Enabled = false;
                loginBookingButton.Text = "Log Out";
                loginCount++;

            }
        }

        int MenuArrowCount = 0;
        private void sliderButton_Click(object sender, EventArgs e)
        {
            MenuArrowCount++;
            Slidertimer.Start();
            if (MenuArrowCount % 2 != 0)
            {
                MenuArrowlabl.Visible = false;
                MenuArrowpictureBox.Visible = false;
            }
        }
       
        private void Slidertimer_Tick(object sender, EventArgs e)
        {
            if (hided) {
                Sliderpanel.Width = Sliderpanel.Width + 10;
                if(Sliderpanel.Width >= panel_width)
                {
                    hided = false;
                    Slidertimer.Stop();
                    this.Refresh();
                }
            }
            else
            {
                Sliderpanel.Width = Sliderpanel.Width - 10;
                if (Sliderpanel.Width <= 0)
                {
                    Slidertimer.Stop();
                    hided = true;
                    sliderButton.Visible = true;
                    MenuArrowlabl.Visible = true;
                    MenuArrowpictureBox.Visible = true;
                    this.Refresh();
                }
            }
        }

        private void HomeButtonLogo_Click(object sender, EventArgs e)
        {
            HomeButton.PerformClick();
        }

        private void BookedButton_Click(object sender, EventArgs e)
        {
            BookedTextButton.PerformClick();
        }

        private void AvailabilityButton_Click(object sender, EventArgs e)
        {
            if (loginBookingButton.Text == "Login")
                sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
            else
                AvailabilityTextButton.PerformClick();
        }

        private void MyBookings_Click(object sender, EventArgs e)
        {
            if (loginBookingButton.Text == "Login")
                sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
            else
                MyBookingsTextButton.PerformClick();
        }
        int voicehelpCount = 0;
        private void VoiceNobutton_Click(object sender, EventArgs e)
        {
            sSynth.SpeakAsync("Ok , I'll Stop Hearing");
            sRecognize.RecognizeAsyncCancel();
            if (voicehelpCount == 0)
                voicehelpCount = 1;
        }

        private void VoiceYesbutton_Click(object sender, EventArgs e)
        {
            sSynth.SpeakAsync("Thank You, I'll Assist You");
            if (voicehelpCount == 1)
            {
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                voicehelpCount = 0;
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            VoiceHelppanel.Visible = true;
            BookingNotifyTimer.Stop();
            clearDisplay();
            roomBookingBanner2.DayscomboBox.SelectedIndex = 0;
            roomBookingBanner2.PersoncomboBox.SelectedIndex = 0;
            availability2.Visible = false;
            roomBookingBanner2.Visible = false;
            DoneButton.Visible = false;
            clientInfo1.Visible = false;
            BluDisplaylabel.Visible = true;
            bookedRooms2.Visible = false;
        }

        private void BookedTextButton_Click(object sender, EventArgs e)
        {
            VoiceHelppanel.Visible = false;
            BookingNotifyTimer.Stop();
            availability2.Visible = false;
            roomBookingBanner2.Visible = false;
            DoneButton.Visible = false;
            clientInfo1.Visible = false;
            BluDisplaylabel.Visible = false;
            bookedRooms2.panelBookedLogin.Visible = true;
            bookedRooms2.Visible = true;
            bookedRooms2.flowLayoutPanel1.Visible = false;
            bookedRooms2.NameAdmintextBox.Text = "";
            bookedRooms2.PassAdmintextBox.Text = "";
            sSynth.SpeakAsync("An Administrative Login Required");
        }
        private void MyBookingsTextButton_Click(object sender, EventArgs e)
        {
                VoiceHelppanel.Visible = false;
                BookingNotifyTimer.Stop();
                DoneButton.Visible = true;
                clientInfo1.Visible = true;
                roomBookingBanner2.Visible = true;
                voiceBotBanner3.Visible = false;
                availability2.Visible = false;
                BluDisplaylabel.Visible = false;
                bookedRooms2.Visible = false;

            //if (availability2.check101.Checked == true)
            //    availability2.check101.Checked = false;

        }
        int checkFirstTime = 0;
        private void AvailabilityTextButton_Click(object sender, EventArgs e)
        {
            BookingNotifyTimer.Stop();

            if (checkFirstTime==0 || DateTime.Parse(availability2.AvailableDateTime.Text) == DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
            {

                list = cw.Search("RoomList");

                if (list != null)
                {

                    if (list[0].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[0].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("101", "available", null, null);
                            availability2.check101.Enabled = true; availability2.label101Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[0].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[0].Checkout.ToString()))
                        {
                            availability2.check101.Enabled = false; availability2.label101Book.Text = "Booked";
                        }
                    }
                    if (list[1].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[1].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("102", "available", null, null);
                            availability2.check102.Enabled = true; availability2.label102Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[1].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[1].Checkout.ToString()))
                        {
                            availability2.check102.Enabled = false; availability2.label102Book.Text = "Booked";
                        }
                    }
                    if (list[2].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[2].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("103", "available", null, null);
                            availability2.check103.Enabled = true; availability2.label103Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[2].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[2].Checkout.ToString()))
                        {
                            availability2.check103.Enabled = false; availability2.label103Book.Text = "Booked";
                        }
                    }
                    if (list[3].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[3].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("104", "available", null, null);
                            availability2.check104.Enabled = true; availability2.label104Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[3].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[3].Checkout.ToString()))
                        {
                            availability2.check104.Enabled = false; availability2.label104Book.Text = "Booked";
                        }
                    }
                    if (list[4].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[4].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("201", "available", null, null);
                            availability2.check201.Enabled = true; availability2.label201Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[4].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[4].Checkout.ToString()))
                        {
                            availability2.check201.Enabled = false; availability2.label201Book.Text = "Booked";
                        }
                    }
                    if (list[5].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[5].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("202", "available", null, null);
                            availability2.check202.Enabled = true; availability2.label202Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[5].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[5].Checkout.ToString()))
                        {
                            availability2.check202.Enabled = false; availability2.label202Book.Text = "Booked";
                        }
                    }
                    if (list[6].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[6].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("203", "available", null, null);
                            availability2.check203.Enabled = true; availability2.label203Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[6].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[6].Checkout.ToString()))
                        {
                            availability2.check203.Enabled = false; availability2.label203Book.Text = "Booked";
                        }
                    }
                    if (list[7].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[7].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("204", "available", null, null);
                            availability2.check204.Enabled = true; availability2.label204Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[7].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[7].Checkout.ToString()))
                        {
                            availability2.check204.Enabled = false; availability2.label204Book.Text = "Booked";
                        }
                    }
                    if (list[8].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[8].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("301", "available", null, null);
                            availability2.check301.Enabled = true; availability2.label301Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[8].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[8].Checkout.ToString()))
                        {
                            availability2.check301.Enabled = false; availability2.label301Book.Text = "Booked";
                        }
                    }
                    if (list[9].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[9].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("302", "available", null, null);
                            availability2.check302.Enabled = true; availability2.label302Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[9].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[9].Checkout.ToString()))
                        {
                            availability2.check302.Enabled = false; availability2.label302Book.Text = "Booked";
                        }
                    }
                    if (list[10].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[10].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("401", "available", null, null);
                            availability2.check401.Enabled = true; availability2.label401Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[10].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[10].Checkout.ToString()))
                        {
                            availability2.check401.Enabled = false; availability2.label401Book.Text = "Booked";
                        }
                    }
                    if (list[11].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[11].Checkout.ToString()) <= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
                        {
                            cw.update("402", "available", null, null);
                            availability2.check402.Enabled = true; availability2.label402Book.Text = "Available";
                        }
                        else if (DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) >= DateTime.Parse(list[11].CheckIn.ToString())
                            && DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")) < DateTime.Parse(list[11].Checkout.ToString()))
                        {
                            availability2.check402.Enabled = false; availability2.label402Book.Text = "Booked";
                        }
                    }
                }
                else
                    MessageBox.Show("Error Occured When Checking Rooms");
            }

            VoiceHelppanel.Visible = false;
            availability2.Visible = true;
            roomBookingBanner2.Visible = false;
            DoneButton.Visible = false;
            clientInfo1.Visible = false;
            BluDisplaylabel.Visible = false;
            bookedRooms2.Visible = false;
            checkFirstTime = 1;
            //if (availability2.AvailableDateTime.Text != null)
            //{
            //    availability2.AvailableDateTime.Text = DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")).ToString();
            //}
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (clientInfo1.usernameSignuptextBox.Text == "" ||
                clientInfo1.DOBClient.Text == "" || roomBookingBanner2.CheckIndateTime.Text == " " ||
                clientInfo1.phonSignupetextBox.Text == "" || roomBookingBanner2.checkoutDate.Text == " " ||
                clientInfo1.emailsignuptextBox.Text == "")
            {
                if (clientInfo1.usernameSignuptextBox.Text == "")
                    clientInfo1.NameValidation = 1;
                if (clientInfo1.DOBClient.Text == " ")
                    clientInfo1.DOBerrorProvider1.SetError(clientInfo1.DOBClient, "Can not be empty");
                if (clientInfo1.emailsignuptextBox.Text == "")
                    clientInfo1.EmailValidation = 1;
                if (clientInfo1.phonSignupetextBox.Text == "")
                    clientInfo1.PhoneValidation = 1;
                if (clientInfo1.CreditCard.Checked == true || clientInfo1.DebitCard.Checked == true ||
                        clientInfo1.masterCard.Checked == true)
                {
                    if (clientInfo1.accNoSignuptextBox.Text == "Account No")
                    {
                        clientInfo1.accNoValidation = 1;
                        //clientInfo1.Refresh();
                    }
                }

                else if (clientInfo1.Bkash.Checked == true)
                {
                    if (clientInfo1.textBox2Bkash.Text == "")
                    {
                        clientInfo1.bkashaccNoValidation = 1;
                       // clientInfo1.Refresh();
                    }
                }

                clientInfo1.Refresh();
                if (roomBookingBanner2.CheckIndateTime.Text == " ")
                    roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Can not be empty");
                if (roomBookingBanner2.checkoutDate.Text == " ")
                    roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Can not be empty");

                sSynth.SpeakAsync("Missing With some Information, Please Recheck");
                MessageBox.Show("Please Fillup All Information Correctly");

            }

            else if (clientInfo1.CreditCard.Checked == false &&
                clientInfo1.DebitCard.Checked == false && clientInfo1.masterCard.Checked == false &&
                clientInfo1.Bkash.Checked == false)
            {
                sSynth.SpeakAsync("Please Choose a Payment Method");
                MessageBox.Show("Please Choose a Payment Method");
            }

            else if ((DateTime.Parse(roomBookingBanner2.CheckIndateTime.Text.ToString()) >= DateTime.Parse(roomBookingBanner2.checkoutDate.Text.ToString()))
                || (DateTime.Parse(roomBookingBanner2.CheckIndateTime.Text.ToString()) < DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy"))))
            {
                sSynth.SpeakAsync("Please Recheck your checkIn and checkOut Dates");
                MessageBox.Show("Please Give Correct CheckIn and Checkout Dates");
                roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid CheckIn Date");
                roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid CheckOut Date");
            }
            else if (clientInfo1.UsernameerrorProvidersignup.GetError(clientInfo1.usernameSignuptextBox) != "")
            {
                clientInfo1.NameValidation = 1;
                sSynth.SpeakAsync("Enter A Valid Name");
                MessageBox.Show("Enter A Valid Name");
                clientInfo1.Refresh();
            }
            else if (clientInfo1.emailerrorProvidersignup.GetError(clientInfo1.emailsignuptextBox) != "")
            {
                clientInfo1.EmailValidation = 1;
                sSynth.SpeakAsync("Enter A Valid Email");
                MessageBox.Show("Enter A Valid Email");
                clientInfo1.Refresh();
            }
            else if (clientInfo1.PhoneerrorProvider.GetError(clientInfo1.phonSignupetextBox) != "")
            {
                clientInfo1.PhoneValidation = 1;
                sSynth.SpeakAsync("Enter A Valid Phone Number");
                MessageBox.Show("Enter A Valid Phone Number");
                clientInfo1.Refresh();
            }
            else if (roomBookingBanner2.PersonErrorProvider.GetError(roomBookingBanner2.PersoncomboBox) != "")
            {
                clientInfo1.PhoneValidation = 1;
                sSynth.SpeakAsync("Enter A Valid Person Number");
                MessageBox.Show("Enter A Valid Person Number");
                clientInfo1.Refresh();
            }

            else
            {
                roomBookingBanner2.checkInerrorProvider.Clear();
                if (clientInfo1.CreditCard.Checked == true || clientInfo1.DebitCard.Checked == true ||
                clientInfo1.masterCard.Checked == true)
                {

                    if (clientInfo1.accNoSignuptextBox.Text == "Account No")
                    {
                        sSynth.SpeakAsync("Please Enter An Account Number");
                        MessageBox.Show("Please Enter An Account Number");
                    }
                    else if (clientInfo1.AccNoerrorProvidersignup.GetError(clientInfo1.accNoSignuptextBox) != "")
                    {
                        sSynth.SpeakAsync("Enter A Valid Card Number");
                        MessageBox.Show("Enter A Valid Card Number");
                    }
                    else if (clientInfo1.SecurityNumerrorProvider.GetError(clientInfo1.SecurityNumtextBox2) != "")
                    {
                        sSynth.SpeakAsync("Enter a valid security number");
                        MessageBox.Show("Enter a valid security number");
                    }
                    else if (clientInfo1.AmounterrorProvider.GetError(clientInfo1.AmountPaytextBox) != "")
                    {
                        sSynth.SpeakAsync("Lowest Pay amount is 1000");
                        MessageBox.Show("Lowest Pay amount is 1000tk");
                    }
                    else if (clientInfo1.AmountPaytextBox.Text == "0" || clientInfo1.AmountPaytextBox.Text == "")
                    {
                        sSynth.SpeakAsync("Enter An Amount You Want To Pay Advance");
                        MessageBox.Show("Enter An Amount, You Want To Pay Advance");
                    }
                    else
                        ConfirmingClientInfo(0);
                }

                else if (clientInfo1.Bkash.Checked == true)
                {
                    if (clientInfo1.textBox2Bkash.Text == "")
                    {
                        sSynth.SpeakAsync("Please Enter An Account Number");
                        MessageBox.Show("Please Enter An Account Number");
                    }
                    else if (clientInfo1.BkasherrorProvider.GetError(clientInfo1.textBox2Bkash) != "")
                    {
                        sSynth.SpeakAsync("Enter A Valid Bkash Account Number");
                        MessageBox.Show("Enter A Valid Bkash Account Number");
                    }
                    else if (clientInfo1.AmountPaytextBox.Text == "" || clientInfo1.AmountPaytextBox.Text == "0")
                    {
                        sSynth.SpeakAsync("Enter An Amount You Want To Pay Advance");
                        MessageBox.Show("Enter An Amount, You Want To Pay Advance");
                    }
                    else
                        ConfirmingClientInfo(0);
                }
                else
                    ConfirmingClientInfo(0);
            }
        }

        public void ConfirmingClientInfo(int check) {
            int payAmount=0;
            int PersonCount=0;

            if (roomBookingBanner2.CheckIndateTime.Text != "" && roomBookingBanner2.checkoutDate.Text != " ")
            {
                roomBookingBanner2.RoomPopuplabel1.Text = "Room ";

                if (availability2.check101.Checked != true && availability2.check102.Checked != true && availability2.check103.Checked != true
                        && availability2.check104.Checked != true && availability2.check201.Checked != true
                        && availability2.check202.Checked != true && availability2.check203.Checked != true && availability2.check204.Checked != true
                        && availability2.check301.Checked != true && availability2.check302.Checked != true && availability2.check401.Checked != true
                        && availability2.check402.Checked != true)
                {
                    roomBookingBanner2.PaymentLabel.Text = "Payment : " + "0";
                    sSynth.SpeakAsync("Please Select At Least One Hotel Room");
                    MessageBox.Show("Please Select At Least One Room From Availability Tab");
                    AvailabilityTextButton.PerformClick();

                }
                else
                {

                    //erroProviders
                    clientInfo1.UsernameerrorProvidersignup.Clear();
                    clientInfo1.passSignuperrorProvider.Clear();
                    clientInfo1.DOBerrorProvider1.Clear();
                    clientInfo1.BkasherrorProvider.Clear();

                    if (availability2.check101.Checked == true)
                    {
                        if (validCheckInOut("101", roomBookingBanner2.CheckIndateTime.Text.ToString(), roomBookingBanner2.checkoutDate.Text.ToString()))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 101";
                            payAmount += int.Parse(availability2.Pricelabel101.Text);
                            PersonCount += int.Parse((availability2.Personlabel101.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check102.Checked == true)
                    {
                        if (validCheckInOut("102", roomBookingBanner2.CheckIndateTime.Text.ToString(), roomBookingBanner2.checkoutDate.Text.ToString()))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 102";
                            payAmount += int.Parse(availability2.Pricelabel102.Text);
                            PersonCount += int.Parse((availability2.Personlabel102.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check103.Checked == true)
                    {
                        if (validCheckInOut("103", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 103";
                            payAmount += int.Parse(availability2.Pricelabel103.Text);
                            PersonCount += int.Parse((availability2.Personlabel103.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check104.Checked == true)
                    {
                        if (validCheckInOut("104", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 104";
                            payAmount += int.Parse(availability2.Pricelabel104.Text);
                            PersonCount += int.Parse((availability2.Personlabel104.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check201.Checked == true)
                    {
                        if (validCheckInOut("201", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 201";
                            payAmount += int.Parse(availability2.Pricelabel201.Text);
                            PersonCount += int.Parse((availability2.Personlabel201.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check202.Checked == true)
                    {
                        if (validCheckInOut("202", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 202";
                            payAmount += int.Parse(availability2.Pricelabel202.Text);
                            PersonCount += int.Parse((availability2.Personlabel202.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check203.Checked == true)
                    {
                        if (validCheckInOut("203", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 203";
                            payAmount += int.Parse(availability2.Pricelabel203.Text);
                            PersonCount += int.Parse((availability2.Personlabel203.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check204.Checked == true)
                    {
                        if (validCheckInOut("204", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 204";
                            payAmount += int.Parse(availability2.Pricelabel203.Text);
                            PersonCount += int.Parse((availability2.Personlabel204.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check301.Checked == true)
                    {
                        if (validCheckInOut("301", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 301";
                            payAmount += int.Parse(availability2.Pricelabel301.Text);
                            PersonCount += int.Parse((availability2.Personlabel301.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check302.Checked == true)
                    {
                        if (validCheckInOut("302", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 302";
                            payAmount += int.Parse(availability2.Pricelabel302.Text);
                            PersonCount += int.Parse((availability2.Personlabel302.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check401.Checked == true)
                    {
                        if (validCheckInOut("401", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 401";
                            payAmount += int.Parse(availability2.Pricelabel401.Text);
                            PersonCount += int.Parse((availability2.Personlabel401.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }
                    if (availability2.check402.Checked == true)
                    {
                        if (validCheckInOut("402", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        {
                            roomBookingBanner2.checkInerrorProvider.Clear();
                            roomBookingBanner2.CheckOuterrorProvider.Clear();
                            roomBookingBanner2.RoomPopuplabel1.Text += " 402";
                            payAmount += int.Parse(availability2.Pricelabel402.Text);
                            PersonCount += int.Parse((availability2.Personlabel402.Text.Replace(" person", null)).Replace("Max : ", null));
                            roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        }
                        else
                        {
                            roomBookingBanner2.checkInerrorProvider.SetError(roomBookingBanner2.CheckIndateTime, "Invalid Checkin Date");
                            roomBookingBanner2.CheckOuterrorProvider.SetError(roomBookingBanner2.checkoutDate, "Invalid Checkout Date");

                        }
                    }

                    if (roomBookingBanner2.checkInerrorProvider.GetError(roomBookingBanner2.CheckIndateTime) == "" &&
                        roomBookingBanner2.CheckOuterrorProvider.GetError(roomBookingBanner2.checkoutDate) == "")
                    {
                        roomBookingBanner2.PaymentLabel.Text = "Payment : " + (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text)));
                        roomBookingBanner2.DuePopuplabel1.Text = ((payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text))) - int.Parse(clientInfo1.AmountPaytextBox.Text)).ToString();

                        if (int.Parse(roomBookingBanner2.PersoncomboBox.Text.Replace(" Person", null)) > PersonCount)
                        {
                            sSynth.SpeakAsync("Not Enough Room For Chosen Amount of Persons");
                            MessageBox.Show("Not Enough Room For Chosen Amount of Persons");
                        }
                        else if (int.Parse(clientInfo1.AmountPaytextBox.Text) > (payAmount * (int.Parse(roomBookingBanner2.DayscomboBox.Text))))
                        {
                            sSynth.SpeakAsync("You don't need to Pay more than your required Payment");
                            MessageBox.Show("You don't need to Pay more than your required Payment");
                            clientInfo1.AccNoerrorProvidersignup.SetError(clientInfo1.accNoSignuptextBox, "Invalid PayAmount");
                        }
                        else if (check == 0)
                        {
                            clientInfo1.AccNoerrorProvidersignup.Clear();
                            //Popup Values
                            roomBookingBanner2.NamePopuplabel1.Text = clientInfo1.usernameSignuptextBox.Text;
                            roomBookingBanner2.CheckInPopuplabel1.Text = roomBookingBanner2.CheckIndateTime.Text;
                            roomBookingBanner2.CheckoutPopuplabel1.Text = roomBookingBanner2.checkoutDate.Text;
                            roomBookingBanner2.EmailPopuplabel1.Text = clientInfo1.emailsignuptextBox.Text;
                            roomBookingBanner2.PhonePopuplabel1.Text = "+880" + clientInfo1.phonSignupetextBox.Text;
                            roomBookingBanner2.PaidPopuplabel1.Text = clientInfo1.AmountPaytextBox.Text;

                            sSynth.SpeakAsync("Please check the summery of your information");

                            TimerPopupInfo.Start();
                        }
                    }
                }
            }
        }

        private bool validCheckInOut(string roomNo, string checkIn, string checkOut)
        {
            list = cw.Search("RoomList");

            if (list != null)
            {
                for(int i = 0; i<list.Count; i++)
                {
                    if (list[i].Room == roomNo)
                    {
                        if (list[i].CheckIn != string.Empty)
                        {
                            //MessageBox.Show(DateTime.Parse(list[i].CheckIn).ToString("dd/MMMM/yyyy"));
                            if (DateTime.Parse(roomBookingBanner2.CheckIndateTime.Text.ToString()) == DateTime.Parse(list[i].CheckIn.ToString())
                              || (DateTime.Parse(roomBookingBanner2.CheckIndateTime.Text.ToString()) < DateTime.Parse(list[i].Checkout.ToString())
                              && DateTime.Parse(roomBookingBanner2.CheckIndateTime.Text.ToString()) > DateTime.Parse(list[i].CheckIn.ToString()))
                              || (DateTime.Parse(roomBookingBanner2.CheckIndateTime.Text.ToString()) < DateTime.Parse(list[i].Checkout.ToString())
                              && DateTime.Parse(roomBookingBanner2.checkoutDate.Text.ToString()) > DateTime.Parse(list[i].CheckIn.ToString()))
                              || (DateTime.Parse(roomBookingBanner2.checkoutDate.Text.ToString()) < DateTime.Parse(list[i].Checkout.ToString())
                              && DateTime.Parse(roomBookingBanner2.checkoutDate.Text.ToString()) > DateTime.Parse(list[i].CheckIn.ToString())))
                            {
                                sSynth.SpeakAsync("Sorry, We already have booking for this Room");
                                MessageBox.Show("Invalid Date\n We have booking for Room : "+roomNo+" from "+ list[i].CheckIn.ToString()+" to "+ list[i].Checkout.ToString());
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        protected virtual void roomBookingBanner2_ButtonClick(object sender, EventArgs e)
        {
            
            if (cw.BookingInfo(roomBookingBanner2.RoomPopuplabel1.Text, roomBookingBanner2.NamePopuplabel1.Text, roomBookingBanner2.CheckInPopuplabel1.Text,
                    roomBookingBanner2.CheckoutPopuplabel1.Text, clientInfo1.emailsignuptextBox.Text, roomBookingBanner2.PhonePopuplabel1.Text,
                    int.Parse(roomBookingBanner2.PaidPopuplabel1.Text), int.Parse(roomBookingBanner2.DuePopuplabel1.Text)))
            {
                if (availability2.check101.Checked == true)
                {
                    availability2.check101.Enabled = false;
                    cw.update("101", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check102.Checked == true)
                {
                    availability2.check102.Enabled = false;
                    cw.update("102", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check103.Checked == true)
                {
                    availability2.check103.Enabled = false;
                    cw.update("103", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check104.Checked == true)
                {
                    availability2.check104.Enabled = false;
                    cw.update("104", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check201.Checked == true)
                {
                    availability2.check201.Enabled = false;
                    cw.update("201", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check202.Checked == true)
                {
                    availability2.check202.Enabled = false;
                    cw.update("202", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check203.Checked == true)
                {
                    availability2.check203.Enabled = false;
                    if (cw.update("203", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text))
                        MessageBox.Show("hello");
                }
                if (availability2.check204.Checked == true)
                {
                    availability2.check204.Enabled = false;
                    cw.update("204", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check301.Checked == true)
                {
                    availability2.check301.Enabled = false;
                    cw.update("301", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check302.Checked == true)
                {
                    availability2.check302.Enabled = false;
                    cw.update("302", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check401.Checked == true)
                {
                    availability2.check401.Enabled = false;
                    cw.update("401", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }
                if (availability2.check402.Checked == true)
                {
                    availability2.check402.Enabled = false;
                    cw.update("402", "booked", roomBookingBanner2.CheckIndateTime.Text, roomBookingBanner2.checkoutDate.Text);
                }

                string BookedDetails = roomBookingBanner2.NamePopuplabel1.Text + "\n" + roomBookingBanner2.RoomPopuplabel1.Text + " " +
                        "\nPhone: " + roomBookingBanner2.PhonePopuplabel1.Text + "\nCheck In: " + roomBookingBanner2.CheckInPopuplabel1.Text
                        + "\nCheck Out: " + roomBookingBanner2.CheckoutPopuplabel1.Text + "\nDue: " + roomBookingBanner2.DuePopuplabel1.Text;

                if (cw.BookedPanel(BookedDetails))
                {
                    clearDisplay();
                    bookedRooms2.Refresh();
                    roomBookingBanner2.PopupTimerRB.Start();
                    bookedRooms2.flowLayoutPanel1.Controls.Add(bookedRooms2.addPanel(bookedRooms2.addLabel(BookedDetails)));
                    this.sSynth.SpeakAsync("It was Pleasure To assist you, Thank You");
                }
                else
                    MessageBox.Show("Error Occured When Updating Room Booked Info");
            }
            else
            {
                MessageBox.Show("Error Occured When Storing Information");
                sSynth.SpeakAsync("Error Occured When Storing Information");
                sSynth.SpeakAsync("Dont Worry I'm Trying To solve");
            }
        }

        protected virtual void roomBookingBanner2_ValueChanged(object sender, EventArgs e)
        {
            ConfirmingClientInfo(1);
        }

        protected virtual void availability2_DateChanged(object sender, EventArgs e)
        {
            ShowAvailabilityDatewise();
        }

        private void ShowAvailabilityDatewise()
        {
            string availableDate = availability2.AvailableDateTime.Text.ToString();

            if (DateTime.Parse(availableDate) < DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
            {
                sSynth.SpeakAsync("Please enter a valid date");
                MessageBox.Show("You can't decide any date before today");
                availability2.AvailableRoomDateerrorProvider.SetError(availability2.AvailableDateTime, "Any date before today is invalid");
            }
            else
            {
                availability2.AvailableRoomDateerrorProvider.Clear(); 
            
            list = cw.Search("RoomList");

                if (list != null)
                {

                    if (list[0].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[0].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {
                            availability2.check101.Enabled = true; availability2.label101Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[0].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[0].Checkout.ToString()))
                        {
                            availability2.check101.Enabled = false; availability2.label101Book.Text = "Booked";
                        }
                    }
                    if (list[1].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[1].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {
                            availability2.check102.Enabled = true; availability2.label102Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[1].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[1].Checkout.ToString()))
                        {
                            availability2.check102.Enabled = false; availability2.label102Book.Text = "Booked";
                        }
                    }
                    if (list[2].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[2].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check103.Enabled = true; availability2.label103Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[2].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[2].Checkout.ToString()))
                        {
                            availability2.check103.Enabled = false; availability2.label103Book.Text = "Booked";
                        }
                    }
                    if (list[3].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[3].Checkout.ToString()) <= DateTime.Parse(availableDate) ||
                            DateTime.Parse(availableDate) < DateTime.Parse(list[3].CheckIn.ToString()))
                        {
                            availability2.check104.Enabled = true; availability2.label104Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[3].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[3].Checkout.ToString()))
                        {
                            availability2.check104.Enabled = false; availability2.label104Book.Text = "Booked";
                        }
                    }
                    if (list[4].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[4].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check201.Enabled = true; availability2.label201Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[4].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[4].Checkout.ToString()))
                        {
                            availability2.check201.Enabled = false; availability2.label201Book.Text = "Booked";
                        }
                    }
                    if (list[5].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[5].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check202.Enabled = true; availability2.label202Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[5].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[5].Checkout.ToString()))
                        {
                            availability2.check202.Enabled = false; availability2.label202Book.Text = "Booked";
                        }
                    }
                    if (list[6].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[6].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check203.Enabled = true; availability2.label203Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[6].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[6].Checkout.ToString()))
                        {
                            availability2.check203.Enabled = false; availability2.label203Book.Text = "Booked";
                        }
                    }
                    if (list[7].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[7].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check204.Enabled = true; availability2.label204Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[7].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[7].Checkout.ToString()))
                        {
                            availability2.check204.Enabled = false; availability2.label204Book.Text = "Booked";
                        }
                    }
                    if (list[8].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[8].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check301.Enabled = true; availability2.label301Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[8].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[8].Checkout.ToString()))
                        {
                            availability2.check301.Enabled = false; availability2.label301Book.Text = "Booked";
                        }
                    }
                    if (list[9].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[9].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check302.Enabled = true; availability2.label302Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[9].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[9].Checkout.ToString()))
                        {
                            availability2.check302.Enabled = false; availability2.label302Book.Text = "Booked";
                        }
                    }
                    if (list[10].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[10].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check401.Enabled = true; availability2.label401Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[10].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[10].Checkout.ToString()))
                        {
                            availability2.check401.Enabled = false; availability2.label401Book.Text = "Booked";
                        }
                    }
                    if (list[11].Booking.ToString() == "booked")
                    {
                        if (DateTime.Parse(list[11].Checkout.ToString()) <= DateTime.Parse(availableDate))
                        {

                            availability2.check402.Enabled = true; availability2.label402Book.Text = "Available";
                        }
                        else if (DateTime.Parse(availableDate) >= DateTime.Parse(list[11].CheckIn.ToString())
                            && DateTime.Parse(availableDate) < DateTime.Parse(list[11].Checkout.ToString()))
                        {
                            availability2.check402.Enabled = false; availability2.label402Book.Text = "Booked";
                        }
                    }
                }
                else
                    MessageBox.Show("Error, When Checking Room Info");
            }
        }

        void clearDisplay()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    if (control is DateTimePicker)
                        (control as DateTimePicker).CustomFormat = " ";
                    if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    if (control is RadioButton)
                        (control as RadioButton).Checked = false;
                        
                }
            };

            func(clientInfo1.Controls);
            func(roomBookingBanner2.Controls);
            func(availability2.panel101.Controls);
            func(availability2.panel102.Controls);
            func(availability2.panel103.Controls);
            func(availability2.panel104.Controls);
            func(availability2.panel201.Controls);
            func(availability2.panel202.Controls);
            func(availability2.panel203.Controls);
            func(availability2.panel204.Controls);
            func(availability2.panel301.Controls);
            func(availability2.panel302.Controls);
            func(availability2.panel401.Controls);
            func(availability2.panel402.Controls);

            //Controls
            roomBookingBanner2.DayscomboBox.SelectedIndex = 0;
            roomBookingBanner2.PersoncomboBox.SelectedIndex = 0;
            clientInfo1.textBox2Bkash.Enabled = false;
            clientInfo1.accNoSignuptextBox.Enabled = false;
            clientInfo1.accNoSignuptextBox.Text = "Account No";
            clientInfo1.SecurityNumtextBox2.Enabled = false;
            clientInfo1.AmountPaytextBox.Enabled = false;

            //ErrorProviders
            clientInfo1.UsernameerrorProvidersignup.Clear();
            clientInfo1.DOBerrorProvider1.Clear();
            clientInfo1.AccNoerrorProvidersignup.Clear();
            clientInfo1.SecurityNumerrorProvider.Clear();
            clientInfo1.AmounterrorProvider.Clear();
            clientInfo1.emailerrorProvidersignup.Clear();
            clientInfo1.PhoneerrorProvider.Clear();
            roomBookingBanner2.checkInerrorProvider.Clear();
            roomBookingBanner2.CheckOuterrorProvider.Clear();
            roomBookingBanner2.PersonErrorProvider.Clear();

            //SquareInfos
            clientInfo1.NameValidation = 0;
            clientInfo1.EmailValidation = 0;
            clientInfo1.PhoneValidation = 0;
            clientInfo1.accNoValidation = 0;
            clientInfo1.bkashaccNoValidation = 0;

            if(checkFirstTime!=0)
                availability2.AvailableDateTime.Text = DateTime.Now.ToString("dd/MMMM/yyyy");
            checkFirstTime = 0;
        }

        private void TimerPopupInfo_Tick(object sender, EventArgs e)
        {
            roomBookingBanner2.panelPopup.Height = roomBookingBanner2.panelPopup.Height + 20;
            if (roomBookingBanner2.panelPopup.Height >= roomBookingBanner2.height)
            {
                roomBookingBanner2.hided = false;
                TimerPopupInfo.Stop();
                this.Refresh();
            }
        }

        private void ShowTimeTimer_Tick(object sender, EventArgs e)
        {
            timeShow.Text = DateTime.Now.ToLongTimeString();
            DateShow.Text = DateTime.Now.ToString("dd/MMMM/yyyy");
            ShowTimeTimer.Start();
        }

        private void NameLabeltimer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter > len)
            {
                if (BluDisplaylabel.ForeColor == Color.Crimson)
                    BluDisplaylabel.ForeColor = Color.White;
                else if (BluDisplaylabel.ForeColor == Color.White)
                    BluDisplaylabel.ForeColor = Color.FromArgb(36, 47, 59);
                else if (BluDisplaylabel.ForeColor == Color.FromArgb(36, 47, 59))
                    BluDisplaylabel.ForeColor = Color.White;

                counter = 0;
                BluDisplaylabel.Text = "";

            }
            else
            {
                BluDisplaylabel.Text = textBLU.Substring(0, counter);
            }
        }

        int counter = 0;
        int len = 0;
        string textBLU;
        bool buttonClick=false;
        protected virtual void voiceBotBanner3_Buttonclick(Object sender, EventArgs e)
        {
            VoiceHelppanel.Visible = true;
            BluDisplaylabel.Visible = true;
            MenuArrowlabl.Visible = true;
            MenuArrowpictureBox.Visible = true;
            textBLU = BluDisplaylabel.Text;
            len = textBLU.Length;
            BluDisplaylabel.Text = "";
            NameLabeltimer.Start();
            buttonClick = true;
        }

        private void Booking_Load(object sender, EventArgs e)
        {

            this.speech();

        }
        private void speech()
        {
            sList.Add(new string[] { "Good Morning", "Good Evening", "Good noon", "Good Night","blue", "Hey blue", "Shut Down", "hello", "test",
                "it works", "how", "are", "you", "today", "i", "am", "fine", "exit","Done", "close", "quit", "so","Thank You",
            "Can You Book A Room For ME", "Can You Please Book A Room For ME","Book A Room For ME","Book A Room",
            "I Want To Book A Room","Tell Me The Time","Tell Me The Time Now","What is The Time","Show Me The Available Rooms",
            "Available Rooms", "stop"});
            Grammar gr = new Grammar(new GrammarBuilder(sList));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        DateTime lastTime;
        private void BookingNotifyTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now> lastTime.AddSeconds(10))
            {

                lastTime = DateTime.Now;
                sSynth.SpeakAsync("Just Say Done");
                sSynth.SpeakAsync("After Finishing Your Choosing");
            }
        }

        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (buttonClick == true)
            {
                voiceBotBanner3.Hide();

                switch (e.Result.Text.ToString())
                {
                    case "exit":
                        sSynth.SpeakAsync("BLU is Shutting Down");
                        Application.Exit();
                        break;
                    case "quit":
                        sSynth.SpeakAsync("BLU is Shutting Down");
                        Application.Exit();
                        break;
                    case "Shut Down":
                        sSynth.SpeakAsync("BLU is Shutting Down");
                        Application.Exit();
                        break;
                    case "Hey blue":
                        sSynth.SpeakAsync("BLU HERE");
                        break;
                    case "blue":
                        sSynth.SpeakAsync("BLU HERE");
                        break;
                    case "What is The Time":
                        sSynth.SpeakAsync("Time is " + DateTime.Now.ToLongTimeString());
                        break;
                    case "Show Me The Available Rooms":
                        sSynth.SpeakAsync("Showing Rooms ");
                        this.AvailabilityTextButton.Enabled = true;
                        this.AvailabilityTextButton.PerformClick();
                        break;
                    case "Available Rooms":
                        sSynth.SpeakAsync("Showing Rooms ");
                        this.AvailabilityTextButton.Enabled = true;
                        this.AvailabilityTextButton.PerformClick();
                        break;
                    case "Can You Book A Room For ME":
                        if (loginBookingButton.Text == "Login")
                            sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
                        else
                        {
                            sSynth.SpeakAsync("Please Select a Available Room First");
                            this.AvailabilityTextButton.PerformClick();
                            lastTime = DateTime.Now;
                            BookingNotifyTimer.Start();

                        }
                        break;
                    case "I Want To Book A Room":
                        if (loginBookingButton.Text == "Login")
                            sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
                        else
                        {
                            sSynth.SpeakAsync("Please Select a Available Room First");
                            this.AvailabilityTextButton.PerformClick();
                            lastTime = DateTime.Now;
                            BookingNotifyTimer.Start();

                        }
                        break;
                    case "Can You Please Book A Room For ME":
                        if (loginBookingButton.Text == "Login")
                            sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
                        else
                        {
                            sSynth.SpeakAsync("Please Select a Available Room First");
                            this.AvailabilityTextButton.PerformClick();
                            lastTime = DateTime.Now;
                            BookingNotifyTimer.Start();

                        }
                        break;
                    case "Book A Room For ME":
                        if (loginBookingButton.Text == "Login")
                            sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
                        else
                        {
                            sSynth.SpeakAsync("Please Select a Available Room First");
                            this.AvailabilityTextButton.PerformClick();
                            lastTime = DateTime.Now;
                            BookingNotifyTimer.Start();

                        }
                        break;
                    case "Book A Room":
                        if (loginBookingButton.Text == "Login")
                            sSynth.SpeakAsync("Authonitication Failed, A Booking Login Required.");
                        else
                        {
                            sSynth.SpeakAsync("Please Select a Available Room First");
                            this.AvailabilityTextButton.PerformClick();
                            lastTime = DateTime.Now;
                            BookingNotifyTimer.Start();

                        }
                        break;
                    case "Done":
                        if (this.BookingNotifyTimer.Enabled == true)
                        {
                            if (availability2.check101.Checked == true || availability2.check102.Checked == true || availability2.check103.Checked == true
                                || availability2.check104.Checked == true || availability2.check201.Checked == true
                                || availability2.check202.Checked == true || availability2.check203.Checked == true || availability2.check204.Checked == true
                                || availability2.check301.Checked == true || availability2.check302.Checked == true || availability2.check401.Checked == true
                                || availability2.check402.Checked == true)
                            {
                                this.BookingNotifyTimer.Stop();
                                this.MyBookingsTextButton.PerformClick();
                                sSynth.SpeakAsync("Please Provide All Of The Information To Finish Your Booking , Thank You");
                            }
                            else
                            {
                                sSynth.SpeakAsync("You must select at least one Room to continue");
                            }
                        }
                        break;

                    default:
                        break;

                }
            }
        }
    }
}
