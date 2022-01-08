using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class ProductList : List<Product>
    {
        public override string ToString()
        {
            string s = "";
            foreach (Product p in this)
                s += p.ToString() + "\r\n";
            return s;
        }
    }
}
