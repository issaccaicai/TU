using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_review
{
    class PersonList : List<Person>
    {
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.Count; i++)
                s += this[i].ToString() + "\r\n\r\n";
            return s;
        }
    }
}
