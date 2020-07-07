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
    public partial class RoomAttendantForm : Form
    {
        ROOMS room = new ROOMS();
        ROOM_ATTENDANTS attendants = new ROOM_ATTENDANTS();
        public RoomAttendantForm()
        {
            InitializeComponent();
        }

        private void btnAddNewAttendant_Click(object sender, EventArgs e)
        {
           try
            {
                int attendant_id = Convert.ToInt32(txtAttendantID.Text);
                String first_name = txtFirstName.Text;
                String last_name = txtLastName.Text;
                int room_no = Convert.ToInt32(comboBoxRoomNo.SelectedValue);
                if (attendants.AddRoomAttendants(attendant_id, first_name, last_name, room_no))
                {
                    dataGridView1.DataSource = attendants.getRoomAttendants();
                    MessageBox.Show("Room Attendant Added Successfully", "Add Room Attendant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearFields.PerformClick();
                }
                else
                {
                    MessageBox.Show("Failed To Add Room Attendant", "Add Room Attendant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Room Attendant Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAttendantID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBoxRoomNo.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            int room_type = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            comboBoxRoomType.SelectedValue = room.getRoomType(room_type);
        }

        private void RoomAttendantForm_Load(object sender, EventArgs e)
        {
            //show room types
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "category_id";

            //show room number depending on the selected room type
            int room_type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            comboBoxRoomNo.DataSource = room.getRoomsByType(room_type);
            comboBoxRoomNo.DisplayMember = "room_no";
            comboBoxRoomNo.ValueMember = "room_no";

            dataGridView1.DataSource = attendants.getRoomAttendants();
        }

        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               try
            {
                int room_type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
                comboBoxRoomNo.DataSource = room.getRoomsByType(room_type);
                comboBoxRoomNo.DisplayMember = "room_no";
                comboBoxRoomNo.ValueMember = "room_no";
            }
            catch
            {
                //Nothing
            }
         
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int attendant_id = Convert.ToInt32(txtAttendantID.Text);
            String first_name = txtFirstName.Text;
            String last_name = txtLastName.Text;
            int room_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            if(attendants.EditRoomAttendants(attendant_id, first_name, last_name, room_no))
            {
                dataGridView1.DataSource = attendants.getRoomAttendants();
                MessageBox.Show("Room Attendant Updated Successfully", "UPDATE ROOM ATTENDANT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClearFields.PerformClick();
            }
            else
            {
                MessageBox.Show("Failed Updating Room Attendant", "UPDATE ROOM ATTENDANT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int attendant_id = Convert.ToInt32(txtAttendantID.Text);
            if(attendants.removeRoomAttendants(attendant_id))
            {
                dataGridView1.DataSource = attendants.getRoomAttendants();
                MessageBox.Show("Room Attendant Removed Successfully", "DELETE ROOM ATTENDANT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClearFields.PerformClick();
            }
            else
            {
                MessageBox.Show("Room Attendant Removal Failed", "DELETE ROOM ATTENDANT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtAttendantID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            comboBoxRoomType.SelectedValue = 0;
            comboBoxRoomNo.SelectedValue = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "LISHE BORA HOTEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
