using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ch20DB
{
    public partial class frmMain : Form
    {
        Customer c;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text != "")
            {
                c = CustomerDB.GetCustomer(Convert.ToInt32(txtCustomerID.Text));
                if (c != null)
                {
                    txtCustomerID.Text = c.CustomerID.ToString();
                    txtName.Text = c.Name;
                    txtAddress.Text = c.Address;
                    txtCity.Text = c.City;
                    txtState.Text = c.State;
                    txtZipCode.Text = c.ZipCode;
                }
                else
                    MessageBox.Show("Customer ID " + txtCustomerID.Text + " not found.");
            }
            else
                MessageBox.Show("Please enter a Customer ID.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool b = CustomerDB.UpdateCustomer(Convert.ToInt32(txtCustomerID.Text), txtName.Text, txtAddress.Text,
                txtCity.Text, txtState.Text, txtZipCode.Text);
            if (b)
            {
                MessageBox.Show("ID " + txtCustomerID.Text + " just updated.");
            }
            else
            {
                MessageBox.Show("Record not updated.");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            bool b = CustomerDB.InsertCustomer(txtName.Text, txtAddress.Text, 
                txtCity.Text, txtState.Text, txtZipCode.Text);
            if (b) {
                int cid = CustomerDB.GetMaxCustomerID();
                MessageBox.Show("ID " + cid + " just added.");
            }
            else
            {
                MessageBox.Show("Record not added.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool b = CustomerDB.DeleteCustomer(Convert.ToInt32(txtCustomerID.Text));
            if (b)
            {
                MessageBox.Show("ID " + txtCustomerID.Text + " just deleted.");
            }
            else
            {
                MessageBox.Show("Record not deleted.");
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            frmAllCustomers fac = new frmAllCustomers();
            fac.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrder fo = new frmOrder();
            fo.ShowDialog();
        }
    }
}
