using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_review
{
    sealed class Faculty: Employee
    {
        private double annualSalary;

        public Faculty(string id, string firstName, string lastName,
                   string department, double annualSalary) :
                   base(id, firstName, lastName,department)
        {
            this.annualSalary = annualSalary;
        }
        public double AnnualSalary
        {
            get
            {
                return annualSalary;
            }
            set
            {
                annualSalary = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\r\n" + "Annual Salary: " + annualSalary.ToString("$#,##0.00");
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
            return base.GetDisplayText(sep) + "sep" + annualSalary;
        }
    }
}
