using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    class ROOM_ATTENDANTS
    {
        SqlConnection con = new SqlConnection("Data Source=HENRY\\SQL_2017;Initial Catalog=Hotel;Integrated Security=True");

        //function to get list of all room attendants
        public DataTable getRoomAttendants()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM room_attendants", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }

        //function to add new room atendants
        public bool AddRoomAttendants(int attendant_id, String first_name, String last_name, int room_no)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO room_attendants(attendant_id, first_name, last_name, room_no)VALUES(@att_id, @fname, @lname, @rmno)", con);
            cmd.Parameters.Add("@att_id", SqlDbType.Int).Value = attendant_id;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@rmno", SqlDbType.Int).Value = room_no;
            con.Open();
            if(cmd.ExecuteNonQuery() == 1)
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
        //function to edit room attendants
        public bool EditRoomAttendants(int attendant_id, String first_name, String last_name, int room_no)
        {
            SqlCommand cmd = new SqlCommand("UPDATE room_attendants SET first_name=@fname, last_name=@lname, room_no=@rmno WHERE attendant_id=@att_id",con);
            cmd.Parameters.Add("@att_id", SqlDbType.Int).Value = attendant_id;
            cmd.Parameters.Add("fname", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@rmno", SqlDbType.Int).Value = room_no;
            con.Open();
            if(cmd.ExecuteNonQuery() == 1)
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

        //function to remove room attendants
        public bool removeRoomAttendants(int attendant_id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM room_attendants WHERE attendant_id=@att_id", con);
            cmd.Parameters.Add("@att_id", SqlDbType.Int).Value = attendant_id;
            con.Open();
            if(cmd.ExecuteNonQuery() == 1)
            {
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
           
        
       


    }
}
