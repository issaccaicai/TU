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
    public partial class frmMain : Form
    {
        ProductList pl;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetProductByID_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            if (txtProductID.Text != "")
            {
                Product p = ProductDB.GetProduct(txtProductID.Text);
                if (p != null)
                {
                    txtOutput.Text = "ID: " + p.ProductCode + "\r\n" +
                        "Description: " + p.Description + "\r\n" +
                        "Price: $" + p.UnitPrice.ToString() + "\r\n" +
                        "Quantity: " + p.OnHandQuantity.ToString() + "\r\n\r\n";
                }
                else
                    MessageBox.Show("Product ID " + txtProductID.Text + " not found.");
            }
            else
                MessageBox.Show("Please enter a Product ID.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            frmProduct fp = new frmProduct();
            fp.ShowDialog();
        }

        private void btnDeleteProductByID_Click(object sender, EventArgs e)
        {
            bool b = ProductDB.DeleteProduct(txtProductID.Text);
            if (b)
            {
                MessageBox.Show("ID " + txtProductID.Text + " just deleted.");
            }
            else
            {
                MessageBox.Show("Record not deleted.");
            }
            txtOutput.Text = "";
        }

        private void btnGetAllProducts_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            pl = ProductDB.GetProducts();
            if (pl != null)
            {
                foreach (Product p in pl)
                    txtOutput.Text += "ID: " + p.ProductCode + "\r\n" +
                        "Description: " + p.Description + "\r\n" + 
                        "Price: $"+ p.UnitPrice.ToString() + "\r\n" + 
                        "Quantity: "+ p.OnHandQuantity.ToString() + "\r\n\r\n";
            }

            else
            {
                MessageBox.Show("Bust");
            }
        }

        private void btnCalcInventory_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            double inv = ProductDB.GetInventory();
            txtOutput.Text += "Total Inventory : $" + inv + "\r\n\r\n";


        }
    }
}
