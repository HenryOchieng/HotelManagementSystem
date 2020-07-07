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
    public partial class ClientsForm : Form
    {
        CLIENTS client = new CLIENTS();
        public ClientsForm()
        {
            InitializeComponent();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtClientID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNo.Text = "";
            txtCountry.Text = "";
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;
            String phone_no = txtPhoneNo.Text;
            String country = txtCountry.Text;

            if(fname.Trim().Equals("") || lname.Trim().Equals("") || phone_no.Trim().Equals("") || country.Trim().Equals(""))
            {
                MessageBox.Show("Please Fill In All The Required Fields(First Name, Last Name, PhoneNo & Country)", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
            }
            else
            {
                Boolean addClient = client.addClients(fname, lname, phone_no, country);
                if(addClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client Added Successfully!", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClearFields.PerformClick();
                }
                else
                {
                    MessageBox.Show("Client Addition Failed! ", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
            }

          
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id;
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;
            String phone_no = txtPhoneNo.Text;
            String country = txtCountry.Text;

            try
            {
                id = Convert.ToInt32(txtClientID.Text);
                if(fname.Trim().Equals("") || lname.Trim().Equals("") || phone_no.Trim().Equals("") || country.Trim().Equals("") )
                {
                    MessageBox.Show("Please Fill In All The Required Fields(FirstName, LastName, PhoneNo & Country)","Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean insertClient = client.editClients(id,fname, lname, phone_no, country);
                    if(insertClient)
                    {
                        dataGridView1.DataSource = client.getClients();
                        MessageBox.Show("Client Updated Successfully!", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClearFields.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Client Update Failed!", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }catch (Exception ex)
           

            {
                MessageBox.Show(ex.Message, "ID ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //show selected client data from the datagridview to the textboxes//
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClientID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhoneNo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtClientID.Text);

                if(client.removeClients(id))
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client Deleted Successfully.", "Delete Client!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clearing textboxes after removal//
                    btnClearFields.PerformClick();
                }
                else
                {
                    MessageBox.Show("Client Deletion Failed.", "Delete Client!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ID ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm If You Want To Exit", "LISHE BORA HOTEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit==DialogResult.Yes)
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
