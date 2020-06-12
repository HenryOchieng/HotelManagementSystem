using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection("Data Source=HENRY\\SQL_2017;Initial Catalog=Hotel;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM users WHERE username='"+ txtUsername.Text +"' AND password='"+ txtPassword.Text +"' ", con);
            DataTable table = new DataTable();
            
            //if the username and password exists(if the table contains more than zero rows)
            sda.Fill(table);
            if(table.Rows.Count > 0 )
            {
                this.Hide();
                Main main = new Main();
                main.Show();
                
                 
            }
            else
            {
                if(txtUsername.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Your Username To Login!", "No Username" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Your Password To login!", "No Password", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Login Credentials!", "Invalid Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnClear.PerformClick();
                    
                }
              
            }
            


        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           // txtPassword.PasswordChar = '*';//
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
