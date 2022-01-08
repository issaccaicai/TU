using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    [Serializable()]
    public class Customer: ContactInformation
    {
        private int CustomerId;
        private string CustomerUserName;
        private string CustomerPassword;
        private string Q1;

        private string Q2;

        private string Q3;
        private string Question1;
        private string Question2;
        private string Question3;

        public Customer()
        {

        }


        public int customerId
        {
            get { return CustomerId; }
            set { CustomerId = value; }
        }
        public string customerUserName
        {
            get { return CustomerUserName; }
            set { CustomerUserName = value; }
        }

        public string customerPassword
        {
            get { return CustomerPassword; }
            set { CustomerPassword = value; }
        }
        public string q1
        {
            get { return Q1; }
            set { Q1 = value; }
        }

        public string q2
        {
            get { return Q2; }
            set { Q2 = value; }
        }
        public string q3
        {
            get { return Q3; }
            set { Q3 = value; }
        }

        public string question1
        {
            get { return Question1; }
            set { Question1 = value; }
        }
        public string question2
        {
            get { return Question2; }
            set { Question2 = value; }
        }
        public string question3
        {
            get { return Question3; }
            set { Question3 = value; }
        }

    }
}
