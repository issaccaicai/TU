using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditCard
{
    public class myKey
    {
        string superKey = "ELIE3173";

        public bool isTheKey(string key) {

            if (key == superKey)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
