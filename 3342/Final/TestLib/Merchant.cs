using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    [Serializable()]
    public class Merchant:Customer
    {
        private string Password;
        private string APIKey;
        private string SellerSite;
        private string Url;
        private string Description;
        
        private String Address;
        private String City;
        private String State;
        private String Zip;
        private String Phone;
        private string Email;
        private string Qe1;
        private string Qe2;
        private string Qe3;
        private string Ques1;
        private string Ques2;
        private string Ques3;
        public Merchant()
        {

        }



        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string aPIKey
        {
            get { return APIKey; }
            set { APIKey = value; }
        }
        public string sellerSite
        {
            get { return SellerSite; }
            set { SellerSite = value; }
        }
        public string url
        {
            get { return Url; }
            set { Url = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public string address
        {
            get { return Address; }
            set { Address = value; }
        }
        public string city
        {
            get { return City; }
            set { City = value; }
        }
        public string state
        {
            get { return State; }
            set { State = value; }
        }
        public string zip
        {
            get { return Zip; }
            set { Zip = value; }
        }
        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }








        public string qe1
        {
            get { return Qe1; }
            set { Qe1 = value; }
        }


        public string qe2
        {
            get { return Qe2; }
            set { Qe2 = value; }
        }
        public string qe3
        {
            get { return Qe3; }
            set { Qe3 = value; }
        }
        public string ques1
        {
            get { return Ques1; }
            set { Ques1 = value; }
        }
        public string ques2
        {
            get { return Ques2; }
            set { Ques2 = value; }
        }
        public string ques3
        {
            get { return Ques3; }
            set { Ques3 = value; }
        }

    }
}
