using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLU_HotelBooking
{
    public partial class Availability : UserControl
    {
        public Availability()
        {
            InitializeComponent();
        }

        private void Availability_Load(object sender, EventArgs e)
        {

        }

        private void check101_CheckedChanged(object sender, EventArgs e)
        {
            if (check101.Checked)
            {
                label101Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label101Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check102_CheckedChanged(object sender, EventArgs e)
        {
            if (check102.Checked)
            {
                label102Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label102Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check103_CheckedChanged(object sender, EventArgs e)
        {
            if (check103.Checked)
            {
                label103Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label103Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check104_CheckedChanged(object sender, EventArgs e)
        {
            if (check104.Checked)
            {
                label104Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label104Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check201_CheckedChanged(object sender, EventArgs e)
        {
            if (check201.Checked)
            {
                label201Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label201Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check202_CheckedChanged(object sender, EventArgs e)
        {
            if (check202.Checked)
            {
                label202Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label202Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check203_CheckedChanged(object sender, EventArgs e)
        {
            if (check203.Checked)
            {
                label203Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label203Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check204_CheckedChanged(object sender, EventArgs e)
        {
            if (check204.Checked)
            {
                label204Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label204Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
       }

        private void check301_CheckedChanged(object sender, EventArgs e)
        {
            if (check301.Checked)
            {
                label301Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label301Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check302_CheckedChanged(object sender, EventArgs e)
        {
            if (check302.Checked)
            {
                label302Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label302Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
        }

        private void check401_CheckedChanged(object sender, EventArgs e)
        {
            if (check401.Checked)
            {
                label401Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label401Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
    }

        private void check402_CheckedChanged(object sender, EventArgs e)
        {
            if (check402.Checked)
            {
                label402Book.Text = "Booked";
                OnPaymentChanged(EventArgs.Empty);
            }
            else
            {
                label402Book.Text = "Available";
                OnPaymentChanged(EventArgs.Empty);
            }
                
        }

         public event EventHandler PaymentEvent;
        protected virtual void OnPaymentChanged(EventArgs e)
        {
            var handler = PaymentEvent;
            if (handler != null)
                handler(this, e);
        }

        public event EventHandler DateChanged;
        protected virtual void OnDateChanged(EventArgs e)
        {
            var handler = DateChanged;
            if (handler != null)
                handler(this, e);
        }

        private void AvailableDateTime_ValueChanged(object sender, EventArgs e)
        {
            OnDateChanged(EventArgs.Empty);
        }
    }
}
