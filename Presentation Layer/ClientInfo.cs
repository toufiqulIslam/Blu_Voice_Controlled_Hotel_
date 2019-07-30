using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;

namespace BLU_HotelBooking
{
    public partial class ClientInfo : UserControl
    {
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        public int NameValidation=0;
        public int EmailValidation=0;
        public int PhoneValidation=0;
        public int accNoValidation=0;
        public int bkashaccNoValidation=0;
        public ClientInfo()
        {
            InitializeComponent();
            bkashLabel.Visible = false;
            textBox2Bkash.Visible = false;
            accNoSignuptextBox.Enabled = false;
            textBox2Bkash.Enabled = false;
            AmountPaytextBox.Enabled = false;
            MerchantNumlabel.Visible = false;
        }

        private void accNoSignuptextBox_Enter(object sender, EventArgs e)
        {
            if (accNoSignuptextBox.Text == "Account No")
            {
                accNoSignuptextBox.Text = "";

                accNoSignuptextBox.ForeColor = Color.Black;
            }
        }

        private void accNoSignuptextBox_Leave(object sender, EventArgs e)
        {
            if (accNoSignuptextBox.Text == "")
            {
                accNoSignuptextBox.Text = "Account No";

                accNoSignuptextBox.ForeColor = Color.Silver;
            }

            if (accNoSignuptextBox.Text == "Account No")
            {
                AmountPaytextBox.Enabled = false;
                SecurityNumtextBox2.Enabled = false;
            }

            if (accNoSignuptextBox.Text.Length != 16)
                AccNoerrorProvidersignup.SetError(accNoSignuptextBox, "Invalid Card Number");
            else
            {
                accNoValidation = 0;
                AccNoerrorProvidersignup.Clear();
            }
        }

        private void phonSignupetextBox_Leave(object sender, EventArgs e)
        {
            if (phonSignupetextBox.Text.IndexOf("0") == 0)
                phonSignupetextBox.Text = phonSignupetextBox.Text.Remove(0, 1);
            if (phonSignupetextBox.Text.Length != 10)
            {
                PhoneerrorProvider.SetError(this.phonSignupetextBox, "Invalid Phone Number");
            }
            else if (phonSignupetextBox.Text.Substring(0, 2) != "17" && phonSignupetextBox.Text.Substring(0, 2) != "18" &&
                    phonSignupetextBox.Text.Substring(0, 2) != "19" && phonSignupetextBox.Text.Substring(0, 2) != "16" &&
                    phonSignupetextBox.Text.Substring(0, 2) != "15")
            {
                PhoneerrorProvider.SetError(this.phonSignupetextBox, "Invalid Phone Number");
            }
            else
            {
                this.PhoneerrorProvider.Clear();
                PhoneValidation = 0;
                this.Refresh();
            }
        }

        private void usernameSignuptextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                UsernameerrorProvidersignup.SetError(this.usernameSignuptextBox, "Only Character is valid for Username");
            }
            else
            {
                UsernameerrorProvidersignup.Clear();
                NameValidation = 0;
                this.Refresh();
            }
        }

        private void accNoSignuptextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                AccNoerrorProvidersignup.SetError(this.accNoSignuptextBox, "Only Numerical value is valid as Account number");
            }
            else
            {
                AccNoerrorProvidersignup.Clear();
                accNoValidation = 0;
                this.Refresh();
            }

            if (accNoSignuptextBox.Text != null)
            {
                AmountPaytextBox.Enabled = true;
                SecurityNumtextBox2.Enabled = true;
            }
        }

        private void phonSignupetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                PhoneerrorProvider.SetError(this.phonSignupetextBox, "Only Numeric value is valid as Phone number");
            }
            else if (phonSignupetextBox.Text.IndexOf("0") == 0)
            {
                if (phonSignupetextBox.Text.Count() >= 3)
                {
                    if (phonSignupetextBox.Text != "017" || phonSignupetextBox.Text != "018" ||
                        phonSignupetextBox.Text != "019" || phonSignupetextBox.Text != "016" ||
                        phonSignupetextBox.Text != "015")
                    {
                        PhoneerrorProvider.SetError(this.phonSignupetextBox, "Invalid Phone Number");
                    }
                }
            }
            else if (phonSignupetextBox.Text.IndexOf("0") != 0)
            {
                if (phonSignupetextBox.Text.Count() >= 2)
                {
                    if (phonSignupetextBox.Text != "17" || phonSignupetextBox.Text != "18" ||
                        phonSignupetextBox.Text != "19" || phonSignupetextBox.Text != "16" ||
                        phonSignupetextBox.Text != "15")
                    {
                        PhoneerrorProvider.SetError(this.phonSignupetextBox, "Invalid Phone Number");
                    }

                }
            }
            else
            {
                this.PhoneerrorProvider.Clear();
                PhoneValidation = 0;
                this.Refresh();
            }

            if (phonSignupetextBox.Text.IndexOf("0") == 0)
                phonSignupetextBox.Text = phonSignupetextBox.Text.Remove(0, 1);
        }

        private void emailsignuptextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string pattern = @"^([\w\.\-]+)(@yahoo|@hotmail|@gmail)((\.(\w){3})+)$";
            string pattern = @"^([\w\.\-]+)(@yahoo|@hotmail|@gmail)(.com)$";
            if (Regex.IsMatch(emailsignuptextBox.Text, pattern) == false)
            {
                emailerrorProvidersignup.SetError(this.emailsignuptextBox, "Invalid Email");
               // return;
            }
            else
            {
                emailerrorProvidersignup.Clear();
                EmailValidation = 0;
                this.Refresh();
            }
        }
        
        private void emailsignuptextBox_Leave(object sender, EventArgs e)
        {
            //string pattern = @"^([\w\.\-]+)(@yahoo|@hotmail|@gmail)((\.(\w){3})+)$";
            string pattern = @"^([\w\.\-]+)(@yahoo|@hotmail|@gmail)(.com)$";
            if (Regex.IsMatch(emailsignuptextBox.Text, pattern) == false)
            {
                emailerrorProvidersignup.SetError(this.emailsignuptextBox, "Invalid Email");
                // return;
            }
            else
            {
                emailerrorProvidersignup.Clear();
                EmailValidation = 0;
                this.Refresh();
            }
        }

        private void textBox2Bkash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                PhoneerrorProvider.SetError(this.textBox2Bkash, "Only Numeric value is valid as Account number");
            }
            else if (textBox2Bkash.Text.IndexOf("0") == 0)
            {
                if (textBox2Bkash.Text.Count() >= 3)
                {
                    if (textBox2Bkash.Text != "017" || textBox2Bkash.Text != "018" ||
                        textBox2Bkash.Text != "019" || textBox2Bkash.Text != "016" ||
                        textBox2Bkash.Text != "015")
                    {
                        BkasherrorProvider.SetError(this.textBox2Bkash, "Invalid Phone Number");
                    }
                }
            }
            else if (textBox2Bkash.Text.IndexOf("0") != 0)
            {
                if (textBox2Bkash.Text.Count() == 3)
                {
                    if (textBox2Bkash.Text != "17" || textBox2Bkash.Text != "18" ||
                        textBox2Bkash.Text != "19" || textBox2Bkash.Text != "16" ||
                        textBox2Bkash.Text != "15")
                    {
                        BkasherrorProvider.SetError(this.textBox2Bkash, "Invalid Phone Number");
                    }

                }
            }
            else
            {
                this.BkasherrorProvider.Clear();
                bkashaccNoValidation = 0;
                this.Refresh();
            }

            if (textBox2Bkash.Text != null)
                AmountPaytextBox.Enabled = true;
            if (textBox2Bkash.Text.IndexOf("0") == 0)
                textBox2Bkash.Text = textBox2Bkash.Text.Remove(0, 1);
        }
        private void textBox2Bkash_Leave(object sender, EventArgs e)
        {
            if (textBox2Bkash.Text == string.Empty)
            {
                AmountPaytextBox.Text = "0";
                AmountPaytextBox.Enabled = false;
            }
            if (textBox2Bkash.Text.Length != 10)
            {
                BkasherrorProvider.SetError(textBox2Bkash, "Invalid Phone Number");
            }
            else if (textBox2Bkash.Text.Substring(0, 2) != "17" && textBox2Bkash.Text.Substring(0, 2) != "18" &&
                    textBox2Bkash.Text.Substring(0, 2) != "19" && textBox2Bkash.Text.Substring(0, 2) != "16" &&
                    textBox2Bkash.Text.Substring(0, 2) != "15")
            {
                BkasherrorProvider.SetError(this.textBox2Bkash, "Invalid Phone Number");
            }
            else
            {
                this.BkasherrorProvider.Clear();
                bkashaccNoValidation = 0;
                this.Refresh();
            }
        }

        private void ClientInfo_Load(object sender, EventArgs e)
        {

        }

        private void CreditCard_CheckedChanged(object sender, EventArgs e)
        {
            accNoSignuptextBox.Enabled = true;
            accNoSignuptextBox.Visible = true;
            SecurityNumLabel.Visible = true;
            SecurityNumtextBox2.Visible = true;
            MerchantNumlabel.Visible = false;
            bkashLabel.Visible = false;
            textBox2Bkash.Visible = false;
            bkashaccNoValidation = 0;
            this.Refresh();
        }

        private void DebitCard_CheckedChanged(object sender, EventArgs e)
        {
            accNoSignuptextBox.Enabled = true;
            accNoSignuptextBox.Visible = true;
            SecurityNumLabel.Visible = true;
            SecurityNumtextBox2.Visible = true;
            MerchantNumlabel.Visible = false;
            bkashLabel.Visible = false;
            textBox2Bkash.Visible = false;
            bkashaccNoValidation = 0;
            this.Refresh();
        }

        private void masterCard_CheckedChanged(object sender, EventArgs e)
        {
            accNoSignuptextBox.Enabled = true;
            accNoSignuptextBox.Visible = true;
            SecurityNumLabel.Visible = true;
            SecurityNumtextBox2.Visible = true;
            MerchantNumlabel.Visible = false;
            bkashLabel.Visible = false;
            textBox2Bkash.Visible = false;
            bkashaccNoValidation = 0;
            this.Refresh();
        }

        private void Bkash_CheckedChanged(object sender, EventArgs e)
        {
            if (Bkash.Checked)
            {
                accNoSignuptextBox.Visible = false;
                bkashLabel.Visible = true;
                textBox2Bkash.Visible = true;
                textBox2Bkash.Enabled = true;
                SecurityNumLabel.Visible = false;
                SecurityNumtextBox2.Visible = false;
                MerchantNumlabel.Visible = true;
                accNoValidation = 0;
                this.Refresh();
            }
        }

        private void AmountPaytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                AmounterrorProvider.SetError(this.AmountPaytextBox, "Only Numeric value is valid as Amount");
            }
            else
                AmounterrorProvider.Clear();
        }

        private void AmountPaytextBox_Leave(object sender, EventArgs e)
        {
            if (AmountPaytextBox.Text==string.Empty)
            {
                AmounterrorProvider.SetError(this.AmountPaytextBox, "Lowest Pay amount is 1000tk");
            }
            else if (int.Parse(AmountPaytextBox.Text) < 1000)
            {
                AmounterrorProvider.SetError(this.AmountPaytextBox, "Lowest Pay amount is 1000tk");
            }
            else
                AmounterrorProvider.Clear();
        }

        private void AmountPaytextBox_MouseLeave(object sender, EventArgs e)
        {
            if (AmountPaytextBox.Text == string.Empty)
            {
                if(accNoSignuptextBox.Visible==true)
                { }
            }
        }

        private void SecurityNumtextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                SecurityNumerrorProvider.SetError(this.SecurityNumtextBox2, "Only Numeric value is valid as Amount");
            }
            else if (SecurityNumtextBox2.Text.Length != 4)
                SecurityNumerrorProvider.SetError(this.SecurityNumtextBox2, "Enter a valid security number");
            else
                SecurityNumerrorProvider.Clear();
        }

        private void SecurityNumtextBox2_MouseLeave(object sender, EventArgs e)
        {
            if (SecurityNumtextBox2.Text == string.Empty)
            {
                if (accNoSignuptextBox.Visible == true)
                { }
            }
        }

        private void SecurityNumtextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SecurityNumtextBox2.Text))
            {
                SecurityNumerrorProvider.SetError(this.SecurityNumtextBox2, "Enter a valid security number");
            }
            else
                SecurityNumerrorProvider.Clear();
        }

        private void DOBClient_ValueChanged(object sender, EventArgs e)
        {
            DOBClient.CustomFormat = "dd/MMMM/yyyy";
            if (DOBClient.Text != " ")
                DOBerrorProvider1.Clear();
        }

        private void ClientInfo_Paint(object sender, PaintEventArgs e)
        {
            if (NameValidation == 1)
                ValidationErrorShow(usernameSignuptextBox, e);
            else
                usernameSignuptextBox.BorderStyle = BorderStyle.Fixed3D;
            if (EmailValidation == 1)
                ValidationErrorShow(emailsignuptextBox, e);
            else
                emailsignuptextBox.BorderStyle = BorderStyle.Fixed3D;
            if (PhoneValidation == 1)
                ValidationErrorShow(phonSignupetextBox, e);
            else
                phonSignupetextBox.BorderStyle = BorderStyle.Fixed3D;
            if (accNoValidation == 1)
                ValidationErrorShow(accNoSignuptextBox, e);
            else
                accNoSignuptextBox.BorderStyle = BorderStyle.Fixed3D;
            if (bkashaccNoValidation == 1)
                ValidationErrorShow(textBox2Bkash, e);
            else
                textBox2Bkash.BorderStyle = BorderStyle.Fixed3D;

        }
        public void ValidationErrorShow(dynamic name,PaintEventArgs e)
        {
            name.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.Red);
            Graphics g = e.Graphics;
            int variance = 2;
            g.DrawRectangle(p, new Rectangle(name.Location.X - variance, name.Location.Y - variance,
                name.Width + variance, name.Height + variance));
        }
    }
}
