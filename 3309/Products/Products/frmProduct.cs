using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool b = ProductDB.InsertProduct(txtID.Text, txtDescription.Text, Convert.ToDouble(txtPrice.Text),
                Convert.ToInt32(txtQuantity.Text));
            if (b)
            {
                string pid = ProductDB.GetMaxProductID();
                MessageBox.Show("ID " + pid + " just added.");
            }
            else
            {
                MessageBox.Show("Record not added.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
