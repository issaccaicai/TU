using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch20DB
{
    class Invoice
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime invoiceDate;
        public double ProductTotal { get; set; }
        public double SalesTax { get; set; }
        public double Shipping { get; set; }
        public double InvoiceTotal { get; set; }
        public List<InvoiceLineItem> InvoiceLineItems;

        public Invoice()
        {

        }


        public Invoice(int id, int customerId, string invoiceDate, double productTotal, double salesTax,
            double shipping, double invoiceTotal)
        {
            InvoiceID = id;
            CustomerID = customerId;
            InvoiceDate = invoiceDate;
            ProductTotal = productTotal;
            SalesTax = salesTax;
            Shipping = shipping;
            InvoiceTotal = invoiceTotal;
        }


        public string InvoiceDate
        {
            get { return invoiceDate.ToShortDateString(); }
            set
            {
                try
                {
                    invoiceDate = DateTime.Parse(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        public override string ToString()
        {
            return "IId:" + InvoiceID + "   CId:" + CustomerID + "   Date:" + InvoiceDate + "   PTot:" + ProductTotal.ToString("C") + "   STax:" +
                SalesTax.ToString("C") + "   Ship:" + Shipping.ToString("C") + "   ITot" + InvoiceTotal.ToString("C") + "\r\n" + itemString();
                ;
        }


        public string itemString()
        {
            string s = "";
            foreach (InvoiceLineItem i in InvoiceLineItems)
                s += i.ToString() + "\r\n";
            return s;
        }


        public double CalcSubtotal()
        {
            double st = 0.0;
            foreach(InvoiceLineItem ili in InvoiceLineItems)
            {
                st += ili.UnitPrice;
            }
            return st;
        }


        public double CalcShipping()
        {
            return InvoiceLineItems.Count * 1.0;
        }


        public double CalcSalesTax()
        {
            return (CalcSubtotal() + CalcShipping())  * 0.08;
        }


        public double CalcTotal()
        {
            return CalcSubtotal() + CalcShipping() + CalcSalesTax();
        }
    }
}
