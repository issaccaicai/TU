using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_review
{
    sealed class Staff: Employee
    {
        private double hourlyWage;

        public Staff(string id, string firstName, string lastName,
                   string department, double hourlyWage) :
                   base(id, firstName, lastName, department)
        {
            this.hourlyWage = hourlyWage;
        }
        public double HourlyWage
        {
            get
            {
                return hourlyWage;
            }
            set
            {
                hourlyWage = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "\r\n" + "Hourly Wage: " + hourlyWage.ToString("$#,##0.00");
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
            return base.GetDisplayText(sep) + "sep" + hourlyWage;
        }
    }
}
