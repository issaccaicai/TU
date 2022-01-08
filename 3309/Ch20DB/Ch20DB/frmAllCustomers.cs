using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch20DB
{
    public partial class frmAllCustomers : Form
    {
        CustomerList cl;
        InvoiceList il;


        public frmAllCustomers()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetAllCustomers_Click(object sender, EventArgs e)
        {
            cl = CustomerDB.GetCustomers();
            if(cl != null)
            {
                foreach (Customer c in cl)
                    lstAllCustomers.Items.Add(c.ToString());
            }
            else
            {
                MessageBox.Show("Bust");
            }
        }

        private void lstAllCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            il = InvoiceDB.GetInvoices(cl[lstAllCustomers.SelectedIndex].CustomerID);
            cbxInvoices.Items.Clear();
            foreach(Invoice i in il)
            {
                cbxInvoices.Items.Add(i.ToString());
            }
        }

        private void lstLineItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLineItems.Items.Clear();
            foreach(InvoiceLineItem i in il[cbxInvoices.SelectedIndex].InvoiceLineItems)
            {
                lstLineItems.Items.Add(i);
            }
        }
    }
}
