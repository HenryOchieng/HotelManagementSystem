using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    //this class will manage all reservations
    class RESERVATIONS
    {
        SqlConnection con = new SqlConnection("Data Source=HENRY\\SQL_2017;Initial Catalog=Hotel;Integrated Security=True");

        //function to get list of all reservations tables
        public DataTable getReservations()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM reservations ",con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }

        //fuction to add new Reservations
        public bool addReservation( int client_id, int room_no, DateTime date_in, DateTime date_out)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO reservations(room_no, client_id, date_in, date_out)VALUES(@R_no, @C_id, @D_in, @D_out)", con);
            cmd.Parameters.Add("@C_id", SqlDbType.Int).Value = client_id;
            cmd.Parameters.Add("@R_no", SqlDbType.Int).Value = room_no;
            cmd.Parameters.Add("@D_in", SqlDbType.Date).Value = date_in;
            cmd.Parameters.Add("@D_out", SqlDbType.Date).Value = date_out;
            con.Open();

            if(cmd.ExecuteNonQuery()==1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        //function to edit reservations
        public bool editReservation(int reservation_id, int client_id, int room_no, DateTime date_in, DateTime date_out)
        {
            SqlCommand cmd = new SqlCommand("UPDATE reservations SET room_no=@R_no, client_id=@C_id, date_in=@D_in, date_out=@D_out WHERE reservations_id=@R_id", con);
            cmd.Parameters.Add("@R_id", SqlDbType.Int).Value = reservation_id;
            cmd.Parameters.Add("@R_no", SqlDbType.Int).Value = room_no;
            cmd.Parameters.Add("@C_id", SqlDbType.Int).Value = client_id;
            cmd.Parameters.Add("@D_in", SqlDbType.Date).Value = date_in;
            cmd.Parameters.Add("@D_out", SqlDbType.Date).Value = date_out;
            con.Open();
            if(cmd.ExecuteNonQuery()==1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        //function to remove reservation
        public bool removeReservation(int reservation_id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM reservations WHERE reservations_id=@R_id", con);
            cmd.Parameters.Add("@R_id", SqlDbType.Int).Value = reservation_id;
            con.Open();
            if(cmd.ExecuteNonQuery()==1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
       
    }
}
