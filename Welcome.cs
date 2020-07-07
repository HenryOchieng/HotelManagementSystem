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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

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
            client.Show();
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            RoomsForm rooms = new RoomsForm();
            rooms.Show();
        }

        private void buttonReservations_Click(object sender, EventArgs e)
        {
            ReservationsForm reservations = new ReservationsForm();
            reservations.Show();
        }

        private void buttonRoomAttendants_Click(object sender, EventArgs e)
        {
            RoomAttendantForm room_attendant = new RoomAttendantForm();
            room_attendant.Show();
        }
    }
}
