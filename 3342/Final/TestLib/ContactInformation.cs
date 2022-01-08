using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    [Serializable()]
    public class ContactInformation
    {
        private String CustomerName;
        private String CustomerAddress;
        private String CustomerCity;
        private String CustomerState;
        private String CustomerZip;
        private String CustomerPhone;
        private String CustomerEmail;
        private string Time;
        private double Total;

        public ContactInformation()
        {

        }
        
        public string customerName
        {
            get { return CustomerName; }
            set { CustomerName = value; }
        }

        public string customerAddress
        {
            get { return CustomerAddress; }
            set { CustomerAddress = value; }
        }
        public string customerCity
        {
            get { return CustomerCity; }
            set { CustomerCity = value; }
        }
        public string customerState
        {
            get { return CustomerState; }
            set { CustomerState = value; }
        }
        public string customerZip
        {
            get { return CustomerZip; }
            set { CustomerZip = value; }
        }
        public string customerPhone
        {
            get { return CustomerPhone; }
            set { CustomerPhone = value; }
        }
        public string customerEmail
        {
            get { return CustomerEmail; }
            set { CustomerEmail = value; }
        }

        public string time
        {
            get { return Time; }
            set { Time = value; }
        }
        public double total
        {
            get { return Total; }
            set { Total = value; }
        }



    }
}
