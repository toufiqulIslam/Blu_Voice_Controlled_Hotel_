using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace BLU_HotelBooking
{
    public partial class RoomBookingBanner : UserControl
    {
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        public bool hided;
        public int height;
        public RoomBookingBanner()
        {
            InitializeComponent();
            height = panelPopup.Height;
            panelPopup.Height -= panelPopup.Height;
            hided = true;

            string[] personCount = new string[] { "1 Person", "2 Person", "4 Person", "6 Person", "More" };
            PersoncomboBox.DataSource = personCount;
            string[] DayCount = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "More" };
            DayscomboBox.DataSource = DayCount;
        }

        private void RoomBooking_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckIndateTime_ValueChanged(object sender, EventArgs e)
        {
            CheckIndateTime.CustomFormat = "dd/MMMM/yyyy";
            if (DateTime.Parse(CheckIndateTime.Text) < DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
            {
                checkInerrorProvider.SetError(CheckIndateTime,"Invalid CheckIn Date");
                this.DayscomboBox.Text = "0";
            }
            else if (checkoutDate.Text!=" " && DateTime.Parse(checkoutDate.Text) >= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
            {
                checkInerrorProvider.Clear();
                CheckOuterrorProvider.Clear();
                TimeSpan timeSpan = DateTime.Parse(checkoutDate.Text.ToString()) - DateTime.Parse(CheckIndateTime.Text.ToString());
                this.DayscomboBox.Text = timeSpan.Days.ToString();
            }
            else
                checkInerrorProvider.Clear();

            if (DayscomboBox.Text != "0")
                OnValueChanged(EventArgs.Empty);
        }

        private void checkoutDate_ValueChanged(object sender, EventArgs e)
        {
            checkoutDate.CustomFormat = "dd/MMMM/yyyy";
            if (DateTime.Parse(checkoutDate.Text) < DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
            {
                CheckOuterrorProvider.SetError(checkoutDate, "Invalid CheckOut Date");
                this.DayscomboBox.Text = "0";
            }
            else if (CheckIndateTime.Text!=" " && DateTime.Parse(CheckIndateTime.Text) >= DateTime.Parse(DateTime.Now.ToString("dd/MMMM/yyyy")))
            {
                checkInerrorProvider.Clear();
                CheckOuterrorProvider.Clear();
                TimeSpan timeSpan = DateTime.Parse(checkoutDate.Text.ToString()) - DateTime.Parse(CheckIndateTime.Text.ToString());
                this.DayscomboBox.Text = timeSpan.Days.ToString();
            }
            else
                CheckOuterrorProvider.Clear();

            if (DayscomboBox.Text!="0")
                OnValueChanged(EventArgs.Empty);
        }

        private void PersoncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)PersoncomboBox.SelectedValue == "More")
            {
                PersoncomboBox.SelectedIndex = -1;
            }
        }

        private void PersoncomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PersoncomboBox.SelectedIndex != -1)
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                PersonErrorProvider.SetError(this.PersoncomboBox, "Only Numerical is valid");
            }
            else
                PersonErrorProvider.Clear();
        }

        private void PersoncomboBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PersoncomboBox.Text))
                PersoncomboBox.SelectedIndex = 0;
        }

       /* private void DayscomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DayscomboBox.SelectedIndex != -1)
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                DaysStayerrorProvider.SetError(this.DayscomboBox, "Only Numerical is valid");
            }
            else
                DaysStayerrorProvider.Clear();
        }

        private void DayscomboBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DayscomboBox.Text))
                DayscomboBox.SelectedIndex = 0;
        }

        private void DayscomboBox_SelectedIndexChanged(object sender, EventArgs e)
         {
             if ((string)DayscomboBox.SelectedValue == "More")
             {
                 DayscomboBox.SelectedIndex = -1;
             }
         }  */

        private void PopupClose_Click(object sender, EventArgs e)
        {
            RoomPopuplabel1.Text = "Room ";
            PopupTimerRB.Start();
        }

        private void PopupTimerRB_Tick(object sender, EventArgs e)
        {
            panelPopup.Height = panelPopup.Height - 20;
            if (panelPopup.Height <= 0)
            {
                PopupTimerRB.Stop();
                this.hided = true;
                this.Refresh();
            }
        }

        public event EventHandler ButtonClicked;
        protected virtual void OnButtonClicked(EventArgs e)
        {
            var handler = ButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        private void OkPopupbutton_Click_1(object sender, EventArgs e)
        {
            OnButtonClicked(EventArgs.Empty);
        }

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            var handler = ValueChanged;
            if (handler != null)
                handler(this, e);
        }

        private void DayscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
