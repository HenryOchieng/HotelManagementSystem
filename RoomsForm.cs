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
    public partial class RoomsForm : Form
    {
       
        public RoomsForm()
        {
            InitializeComponent();
        }
        ROOMS room = new ROOMS();

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            //display room types
            comboRoomType.DataSource = room.roomTypeList();
            comboRoomType.DisplayMember = "label";
            comboRoomType.ValueMember = "category_id";

            dataGridView1.DataSource = room.getRooms();
        }

        private void btnAddNewRoom_Click(object sender, EventArgs e)
        {
            int room_type = Convert.ToInt32(comboRoomType.SelectedValue.ToString());
            String phone_no = txtPhoneNo.Text;
            String free = "";

            try
            {
                int room_no = Convert.ToInt32(txtRoomNo.Text);
                if (radioButtonYES.Checked)
                {
                    free = "YES";
                }
                else if (radioButtonNO.Checked)
                {
                    free = "NO";
                }

                if (room.addRoom(room_no, room_type, phone_no, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("New Room Added Successfully!", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearFields.PerformClick();

                }
                else
                {
                    MessageBox.Show("Room Addition Failed!", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Room No Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtPhoneNo.Text = "";
            txtRoomNo.Text = "";
            comboRoomType.SelectedIndex = 0;
            radioButtonYES.Checked = false;
            radioButtonNO.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboRoomType.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            txtPhoneNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            String free = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if(free.Equals("YES"))
            {
                radioButtonYES.Checked = true;
            } 
            else if(free.Equals("NO"))
            {
                radioButtonNO.Checked = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            int room_type = Convert.ToInt32(comboRoomType.SelectedValue.ToString());
            String phone_no = txtPhoneNo.Text;
            String free = "";

            try
            {
                int room_no = Convert.ToInt32(txtRoomNo.Text);

                if (radioButtonYES.Checked)
                {
                    free = "YES";
                }
                else if (radioButtonNO.Checked)
                {
                    free = "NO";
                }
                if (room.editRooms(room_no, room_type, phone_no, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room Data Updated Successfully!", "Update Room Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearFields.PerformClick();

                }
                else
                {
                    MessageBox.Show("Room Data Update Failed!", "Update Room Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Room No Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int room_no = Convert.ToInt32(txtRoomNo.Text);
                if (room.removeRoom(room_no))
                {
                   dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room Data Deleted Successfully!", "Delete Room Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearFields.PerformClick();

                }
                else
                {
                    MessageBox.Show("Room Data Deletion Failed!", "Delete Room Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Room No Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm If You Want To Exit Rooms Management", "Exit Rooms Management?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
