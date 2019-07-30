using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLU_HotelBooking.Data_Access_Layer;

namespace BLU_HotelBooking.Business_Logic_Layer
{
    public class RoomList
    {
        public string Room { get; set; }
        public string Booking { get; set; }
        public string CheckIn { get; set; }
        public string Checkout { get; set; }
    }

    public class Booked
    {
        public string Info { get; set; }
    }

    class CheckNWork
    {
        DataAccess dataAcc = new DataAccess();
        public bool BookedPanel(string BookedDetails)
        {
            if (dataAcc.BookedPanelDetails(BookedDetails))
                return true;
            else
                return false;
        }
        public bool BookingInfo(string room, string name, string checkin, string checkout, string email, string phone, int paid, int due)
        {
            if (dataAcc.BookingInfoStore(room, name, checkin, checkout,  email, phone, paid, due))
                return true;
            else
                return false;
        }
        public bool update(string room, string status, string checkIndate, string checkOutDate)
        {
            if (dataAcc.updateRoomInfo(room, status, checkIndate, checkOutDate))
                return true;
            else
                return false;
        }
        RoomList r;
        public List<RoomList> Search(string name)
        {
            var roomlist = dataAcc.Search(name);
            if (roomlist != null)
            {

                List<RoomList> list = new List<RoomList>();
                for (int i = 0; i < roomlist.Rows.Count; i++)
                {
                    r = new RoomList();
                    r.Room = roomlist.Rows[i][0].ToString();
                    r.Booking = roomlist.Rows[i][1].ToString();
                    r.CheckIn = roomlist.Rows[i][2].ToString();
                    r.Checkout = roomlist.Rows[i][3].ToString();

                    list.Add(r);
                }
                return list;
            }
            else
                return null;
        }
        public bool LoginInfo(string name, string pass)
        {
            var loginData = dataAcc.loginInfo();
            for (int i = 0; i < loginData.Rows.Count; i++)
            {
                if ((loginData.Rows[i]["Name"].ToString() == name) && (loginData.Rows[i]["Password"].ToString() == pass))
                {
                    return true;
                }

            }
                return false;
        }

        Booked b;
        public List<Booked> bookedInfo()
        {
            var bookedData = dataAcc.BookedInfo();
            if (bookedData != null)
            {

                List<Booked> list = new List<Booked>();
                for (int i = 0; i < bookedData.Rows.Count; i++)
                {
                    b = new Booked();
                    b.Info = bookedData.Rows[i][0].ToString();

                    list.Add(b);
                }
                return list;
            }
            else
                return null;
        }

    }
}
