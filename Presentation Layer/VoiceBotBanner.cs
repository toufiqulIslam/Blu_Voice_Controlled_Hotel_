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
    public partial class VoiceBotBanner : UserControl
    {
        public VoiceBotBanner()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonClicked;
        protected virtual void OnButtonClicked(EventArgs e)
        {
            var handler = ButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();

        private void circularButton1_Click(object sender, EventArgs e)
        {
            OnButtonClicked(EventArgs.Empty);
            sSynth.SpeakAsync("Welcome To Blu Hotel Booking System, You can call me by saying Hey BLU");
            this.colortimer.Stop();
            this.Hide();   
        }

        private void VoiceBotBanner_Load(object sender, EventArgs e)
        {
            colortimer.Start();
            this.colortimer.Interval = 400;
        }

        private void colortimer_Tick(object sender, EventArgs e)
        {
            if (RedButton.BackColor == Color.Red)
            {
                RedButton.BackColor = Color.Yellow;
                YellowButon.BackColor = Color.White;
                WhiteButton.BackColor = Color.OrangeRed;
                OrangeButton.BackColor = Color.Red;
            }
            else if (RedButton.BackColor == Color.Yellow)
            {
                RedButton.BackColor = Color.White;
                YellowButon.BackColor = Color.OrangeRed;
                WhiteButton.BackColor = Color.Red;
                OrangeButton.BackColor = Color.Yellow;
            }
            else if (RedButton.BackColor == Color.White)
            {
                RedButton.BackColor = Color.OrangeRed;
                YellowButon.BackColor = Color.Red;
                WhiteButton.BackColor = Color.Yellow;
                OrangeButton.BackColor = Color.White;
            }
            else if (RedButton.BackColor == Color.OrangeRed)
            {
                RedButton.BackColor = Color.Red;
                YellowButon.BackColor = Color.Yellow;
                WhiteButton.BackColor = Color.White;
                OrangeButton.BackColor = Color.OrangeRed;
            }
        }
    }
}
