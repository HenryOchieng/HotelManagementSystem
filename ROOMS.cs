using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    //creating class to manage rooms//
    class ROOMS
    {
        SqlConnection con = new SqlConnection("Data Source=HENRY\\SQL_2017;Initial Catalog=Hotel;Integrated Security=True"); 

        //function to get rooms tables list//
        public DataTable roomTypeList()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT [category_id],[label],[price] FROM [dbo].[room_category]", con);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand=cmd;
            adapter.Fill(table);
            return table;
        }

        //function to add rooms//
        public bool  addRoom(int room_no, int room_type, String phone_no, String  free)
        {
            SqlCommand cmd = new SqlCommand("INSERT  INTO rooms(room_no, room_type, phone_no, free) VALUES(@roomno, @roomtype, @phoneno, @free)", con);
            cmd.Parameters.Add("@roomno", SqlDbType.Int).Value = room_no;
            cmd.Parameters.Add("@roomtype", SqlDbType.Int).Value = room_type;
            cmd.Parameters.Add("@phoneno", SqlDbType.VarChar).Value = phone_no;
            cmd.Parameters.Add("@free", SqlDbType.VarChar).Value = free;
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

        //a fuction to get list of all room
        public DataTable getRooms()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM rooms", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;

        }

        //function to get all rooms depending by types
        public DataTable getRoomsByType(int room_no)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM rooms WHERE room_type = @R_type AND free = 'YES' ", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@R_Type", SqlDbType.Int).Value = room_no;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }

        //function to get roomtype
        public int getRoomType(int room_no)
        {
            SqlCommand cmd = new SqlCommand("SELECT room_type FROM rooms WHERE room_no=@roomno ", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@roomno", SqlDbType.Int).Value = room_no;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["room_type"].ToString());
        }


        //function to set table rooms Free column to No
        public bool setRoomFree(int room_no, String YES_or_NO )
        {
            SqlCommand cmd = new SqlCommand("UPDATE rooms SET free=@yes_no WHERE room_no=@roomno", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@roomno", SqlDbType.Int).Value = room_no;
            cmd.Parameters.Add("yes_no", SqlDbType.VarChar).Value = YES_or_NO;
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
            


        //function to edit rooms
        public bool editRooms(int room_no, int room_type, String phone_no, String free)
        {
            SqlCommand cmd = new SqlCommand("UPDATE rooms SET room_type=@roomtype, phone_no=@phoneno, free=@free WHERE room_no=@roomno", con);
            cmd.Parameters.Add("@roomno", SqlDbType.Int).Value = room_no;
            cmd.Parameters.Add("@roomtype", SqlDbType.Int).Value = room_type;
            cmd.Parameters.Add("@phoneno", SqlDbType.VarChar).Value = phone_no;
            cmd.Parameters.Add("@free", SqlDbType.VarChar).Value = free;
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

        //function to delete Rooms
        public bool removeRoom(int room_no)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM rooms WHERE room_no=@roomno", con);
            cmd.Parameters.Add("@roomno", SqlDbType.Int).Value = room_no;
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
