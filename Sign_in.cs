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
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data source=HENRY\\SQL_2017;Initial Catalog=Hotel;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM users WHERE username='" + textBoxusername.Text + "' AND password = '" + textBoxpassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                this.Hide();
                Main main = new Main();
                main.Show();
            }
            else
            {
                if(textBoxusername.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Your Username To Login", "NO USERNAME!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(textBoxpassword.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Your Password To Login", "NO PASSWORD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Login Credentials", "INVALID LOGIN CREDENTIALS!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxusername.Clear();
            textBoxpassword.Clear();
            textBoxusername.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "EXIT SIGN_IN PAGE?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
