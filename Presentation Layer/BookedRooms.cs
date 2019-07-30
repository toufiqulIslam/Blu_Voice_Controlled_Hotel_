using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using BLU_HotelBooking.Business_Logic_Layer;

namespace BLU_HotelBooking
{
    public partial class BookedRooms : UserControl
    {
        CheckNWork cw = new CheckNWork();
        List<Booked> list = new List<Booked>();
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        public BookedRooms()
        {
            InitializeComponent();
            flowLayoutPanel1.Visible = false;
            panelBookedLogin.Visible = false;
            flowLayoutPanel1.Visible = false;
        }
        static int i = 0;
        public Label addLabel(String T)
        {
            i++;
            Label l = new Label();
            l.Name = "Label" + 1;
            l.Text = T;
            l.AutoSize = true;
            l.ForeColor = Color.White;
            l.BackColor = Color.FromArgb(164, 51, 67);
            l.Font = new Font("Cambria", 12, FontStyle.Bold);
            l.TextAlign = ContentAlignment.TopLeft;
            l.Margin = new Padding(5);

            return l;
        }

        public Panel addPanel(Label l)
        {
            Panel p = new Panel();
            p.AutoSize = true;
            p.Name = "Booking";
            p.Controls.Add(l);
            p.ForeColor = Color.White;
            p.BackColor = Color.FromArgb(164, 51, 67);
            l.Margin = new Padding(5);

            return p;
        }

        private void BookedRooms_Load(object sender, EventArgs e)
        {
            BookedUIUpdate();   
        }

        private void BookedUIUpdate()
        {
            list = cw.bookedInfo();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    flowLayoutPanel1.Controls.Add(addPanel
                    (addLabel(list[i].Info.ToString())));
                    
                }
            }
        }

        private void LoginBookedButton_Click(object sender, EventArgs e)
        {
            if (cw.LoginInfo(NameAdmintextBox.Text.ToString(), PassAdmintextBox.Text.ToString()) == true)
            {
                panelBookedLogin.Visible = false;
                flowLayoutPanel1.Visible = true;
                sSynth.Speak("Access Granted");
                flowLayoutPanel1.Visible = true;
            }
            else
            {
                sSynth.SpeakAsync("Login Failed, Please Retry");
                MessageBox.Show("Login Failed");
            }
        }
         
        }
    }
