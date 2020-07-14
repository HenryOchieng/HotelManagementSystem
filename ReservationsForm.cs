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
    public partial class ReservationsForm : Form
    {
        ROOMS room = new ROOMS();
        RESERVATIONS reservation = new RESERVATIONS();
        public ReservationsForm()
        {
            InitializeComponent();
        }

        private void btnAddNewReservation_Click(object sender, EventArgs e)
        {
            try
            {
                int client_id = Convert.ToInt32(txtClientID.Text);
                int room_no = Convert.ToInt32(comboRoomNo.SelectedValue);
                DateTime date_in = dateTimePickerDateIn.Value;
                DateTime date_out = dateTimePickerDateOut.Value;

                if(DateTime.Compare(date_in.Date, DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("The Date In Must Be Greater Than or Equal To Today's Date!", "Incorrect Date In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(DateTime.Compare(date_out.Date, date_in.Date) < 0)
                {
                    MessageBox.Show("The Date Out Must Be Greater Than Or Equal To The Date In!", "Incorrect Date Out!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    if (reservation.addReservation(client_id, room_no, date_in, date_out))
                    {
                        room.setRoomFree(room_no, "NO");
                        dataGridView1.DataSource = reservation.getReservations();
                        MessageBox.Show("New Reservation Added Successfully!", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClearFields.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Reservation Addition Failed!", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Add Reservation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtReservationID.Text = "";
            txtClientID.Text = "";
            comboRoomType.SelectedValue = 0;
            comboRoomNo.SelectedValue = 0;
            dateTimePickerDateIn.Value = DateTime.Now;
            dateTimePickerDateOut.Value = DateTime.Now;
        }

        private void ReservationsForm_Load(object sender, EventArgs e)
        {
            //show room types
            comboRoomType.DataSource = room.roomTypeList();
            comboRoomType.DisplayMember = "label";
            comboRoomType.ValueMember = "category_id";

            //show room number depending on the selected room type
            String room_type = comboRoomType.SelectedValue.ToString();
            comboRoomNo.DataSource = room.getRoomsByType(room_type);
            comboRoomNo.DisplayMember = "room_no";
            comboRoomNo.ValueMember = "room_no";

            dataGridView1.DataSource = reservation.getReservations();

        }

        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String room_type = comboRoomType.SelectedValue.ToString();
                comboRoomNo.DataSource = room.getRoomsByType(room_type);
                comboRoomNo.DisplayMember = "room_no";
                comboRoomNo.ValueMember = "room_no";
            }catch(Exception)
            {
                //nothing
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReservationID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtClientID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboRoomNo.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String room_type = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboRoomType.SelectedValue = room.getRoomType(room_type);
            dateTimePickerDateIn.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            dateTimePickerDateOut.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
            
           
          

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int reservation_id = Convert.ToInt32(txtReservationID.Text);
                int client_id = Convert.ToInt32(txtClientID.Text);
                int room_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                DateTime date_in = dateTimePickerDateIn.Value;
                DateTime date_out = dateTimePickerDateOut.Value;
                if(DateTime.Compare(date_in.Date, DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("The Date In Must Be Greater Than Or Equal To Today's Date.", "Incorrect Date In!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if(DateTime.Compare(date_out.Date, date_in.Date)<0)
                {
                    MessageBox.Show("The Date Out Must Be Greater Than or Equal To The Date In.", "Incorrect Date Out!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(reservation.editReservation(reservation_id,client_id,room_no,date_in,date_out))
                    {
                        room.setRoomFree(room_no, "NO");
                        dataGridView1.DataSource = reservation.getReservations();
                        MessageBox.Show("Reservation Data Updated Successfully.", "Update Reservation Data!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClearFields.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Reservation Data Update Failed.", "Update Reservation Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Reservation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int reservation_id = Convert.ToInt32(txtReservationID.Text);
                int room_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                if(reservation.removeReservation(reservation_id))
                {
                    room.setRoomFree(room_no, "YES");
                    dataGridView1.DataSource = reservation.getReservations();
                    MessageBox.Show("Reservation Deleted Successfully.", "Delete Reservation!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearFields.PerformClick();
                }
                else
                {
                    MessageBox.Show("Reservation Deletion Failed.", "Delete Reservation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Reservation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm If You Want To Exit", "LISHE BORA HOTEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit== DialogResult.Yes)
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
