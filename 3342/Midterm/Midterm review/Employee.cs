using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_review
{
    abstract class Employee: Person
    {
        private string department;

        public Employee(string id, string firstName, string lastName,
                   string department) :
                   base(id, firstName, lastName)
        {
            this.department = department;
        }
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\r\n" + "Department: " + department;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            if (this.ToString() != obj.ToString())
                return false;
            return true;
        }

        public override string GetDisplayText(string sep)
        {
            return base.GetDisplayText(sep) + "sep" + department;
        }


    }
}
