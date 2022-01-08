using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mMABooksDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.mMABooksDataSet.Products);

        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            this.Validate();
            this.productsBindingSource.EndEdit();

            this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);
        }

        private void fillByProductCodeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.FillByProductCode(this.mMABooksDataSet.Products, productCodeToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void getAllProductsToolStripButton_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter.Fill(this.mMABooksDataSet.Products);
        }

        private void cancelToolStripButton_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.CancelEdit();
        }
    }
}
