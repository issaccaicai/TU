using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch20DB
{
    class InvoiceList : List<Invoice>
    {
        public override string ToString()
        {
            string s = "";
            foreach (Invoice i in this)
                s += i.ToString() + "\r\n";
            return s;
        }
    }
}
