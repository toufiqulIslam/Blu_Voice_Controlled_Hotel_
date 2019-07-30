using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLU_HotelBooking.Data_Access_Layer
{
    class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public bool BookedPanelDetails(string BookedDetails)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
                con.Open();
                string query = string.Format
                    ("INSERT INTO Booked(Details) VALUES('{0}')", BookedDetails);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool BookingInfoStore(string room,string name,string checkin,string checkout,string email,string phone,int paid,int due)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
                con.Open();
                string query = string.Format
                    ("INSERT INTO BookingInfo(Room,CustomerName,CheckIn,CheckOut,CustomerEmail,CustomerPhone,Paid,Due) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7})",
                    room, name, checkin, checkout, email, phone, paid, due);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool updateRoomInfo(string room, string status, string checkIndate, string checkOutDate)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
                con.Open();
                string query = string.Format("UPDATE RoomList SET Booking='{0}', CheckInDate='{1}', CheckoutDate='{2}' WHERE Room='{3}'",
                    status, checkIndate, checkOutDate, room);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable Search(string name)
        {

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
                con.Open();
                string query = string.Format("SELECT * FROM {0}", name);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public DataTable loginInfo()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
                con.Open();
                string query = string.Format("SELECT * FROM Admin");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception p)
            {
                return null;
            }
        }

        public DataTable BookedInfo()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=MAVERICK\MSSQL2014;Initial Catalog=HotelBLU;Integrated Security=True");
                con.Open();
                string query = string.Format("SELECT * FROM Booked");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            catch (Exception p)
            {
                return null;
            }
        }

        //~DataAccess()
        //{
        //    if (con.State == ConnectionState.Open)
        //    {
        //        con.Close();
        //    }
        //}
    }
}
