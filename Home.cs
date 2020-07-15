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
        Login main = new Login();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm If You Want To Exit", "LISHE BORA HOTEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
           ClientsForm client = new ClientsForm();
           client.Owner = this;
           client.Show();
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            RoomsForm rooms = new RoomsForm();
            rooms.Owner = this;
            rooms.Show();
        }

        private void buttonReservations_Click(object sender, EventArgs e)
        {
            ReservationsForm reservations = new ReservationsForm();
            reservations.Owner = this;
            reservations.Show();
        }
    
        private void buttonRoomAttendants_Click(object sender, EventArgs e)
        {
            RoomAttendantForm room_attendant = new RoomAttendantForm();
            room_attendant.Owner = this;
            room_attendant.Show();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            buttonClients.Enabled = false;
            buttonRooms.Enabled = false;
            buttonReservations.Enabled = false;
            buttonRoomAttendants.Enabled = false;
            
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if(main.ShowDialog(this) == DialogResult.OK)
            {
                this.buttonClients.Enabled = true;
                this.buttonRooms.Enabled = true;
                this.buttonReservations.Enabled = true;
                this.buttonRoomAttendants.Enabled = true;
            }
            else
            {
                //nothing
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            buttonClients.Enabled = false;
            buttonRooms.Enabled = false;
            buttonReservations.Enabled = false;
            buttonRoomAttendants.Enabled = false;
        }
    }
}
