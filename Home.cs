using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void buttonsignin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm If You Want To Quit", "LISHE BORA HOTEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
