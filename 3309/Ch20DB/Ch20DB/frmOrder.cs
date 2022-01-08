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
    public partial class frmOrder : Form
    {
        ProductList pl;
        Customer c;
        //ShoppingCart sc = new ShoppingCart();
        Invoice i = null;

        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            pl = ProductDB.GetProducts();
            MessageBox.Show("Count =  " + pl.Count);
            foreach(Product p in pl)
            {
                cbxChoose.Items.Add(p.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindMe_Click(object sender, EventArgs e)
        {
            i = new Invoice();
            i.InvoiceLineItems = new List<InvoiceLineItem>();
            c = CustomerDB.GetCustomer(Convert.ToInt32(txtCustomerID.Text));
            MessageBox.Show("Welcome back " + c.Name);
            i.CustomerID = c.CustomerID;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            lstCart.Items.Add(pl[cbxChoose.SelectedIndex].ToString());
            InvoiceLineItem ili = new InvoiceLineItem();
            ili.InvoiceID = -1;
            ili.ProductCode = pl[cbxChoose.SelectedIndex].ProductCode;
            ili.UnitPrice = pl[cbxChoose.SelectedIndex].UnitPrice;
            ili.Quantity = 1;
            ili.ItemTotal = ili.Quantity * ili.UnitPrice;
            i.InvoiceLineItems.Add(ili);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            i.ProductTotal = i.CalcSubtotal();
            i.Shipping = i.CalcShipping();
            i.SalesTax = i.CalcSalesTax();
            i.InvoiceTotal = i.CalcTotal();
            i.InvoiceDate = DateTime.Now.ToShortDateString();
            InvoiceDB.InsertInvoice(i);
            //MessageBox.Show(i.ToString());
        }
    }
}
