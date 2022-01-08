using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch20DB
{
    class CustomerList : List<Customer>
    {
        public override string ToString()
        {
            string s = "";
            foreach(Customer c in this)
                s += c.ToString() + "\r\n";
            return s;
        }
    }
}
