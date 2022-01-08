using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch20DB
{
    class ShoppingCart : List<Product>
    {

        public List<int> Quantities = new List<int>();

        public override string ToString()
        {
            string s = "";
            for(int i=0; i<this.Count; i++)
            {
                s += this[i].ToString() + " Qty: " + Quantities[i];
            }
            return s;
        }


        public double ProductTotal()
        {
            double tc = 0.0;
            for(int i= 0; i < this.Count; i++)
                tc += this[i].UnitPrice * Quantities[i];
            return tc;
        }


        public double SalesTax()
        {
            return ProductTotal() * 0.08;
        }


        public double Shipping()
        {
            return 5.00 + (this.Count - 1 * 1.00);
        }


        public double InvoiceTotal()
        {
            return ProductTotal() + SalesTax() + Shipping();
        }

    }
}
