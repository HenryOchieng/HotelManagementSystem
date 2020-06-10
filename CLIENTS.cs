using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    //Client Client to Add, Edit, Remove and Get all clients//
     class CLIENTS
    {
        //funtion to add new client//
        SqlConnection con = new SqlConnection("Data Source=HENRY\\SQL_2017;Initial Catalog=Hotel;Integrated Security=True");
        public  bool addClients(String fname, String lname, String phone_no, String country)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO clients(first_name, last_name, phone_no, country)VALUES(@fnm, @lnm, @phn, @cnt)",con);
            cmd.Parameters.Add("@fnm", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lnm", SqlDbType.VarChar).Value = lname;   
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone_no;
            cmd.Parameters.Add("@cnt", SqlDbType.VarChar).Value = country;

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
        //function to get client table list//
        public DataTable getClients()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM clients", con);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            return table;

        }
        //function to Edit Client List//
        public bool editClients(int id, String fname, String lname, String phone_no, String country)
        {
            SqlCommand cmd = new SqlCommand("UPDATE clients SET first_name=@fnm, last_name=@lnm, phone_no=@phn, country=@cnt WHERE client_id = @cid", con);
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fnm", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lnm", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone_no;
            cmd.Parameters.Add("@cnt", SqlDbType.VarChar).Value = country;
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
        //fuction to delete client list//
        public bool removeClients(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE client_id = @cid", con);
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
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
    }
}
