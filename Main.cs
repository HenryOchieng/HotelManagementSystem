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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm Client = new ClientsForm();
            Client.ShowDialog();
        }

        private void manageRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomsForm Room = new RoomsForm();
            Room.ShowDialog();
        }

        private void manageResevationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationsForm Reservation = new ReservationsForm();
            Reservation.ShowDialog();
        }
    }
}
