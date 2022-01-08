using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public class RecordPurchase
    {
        

        public string ProductNumber { get; set; }
        public int Quantity { get; set; }
        public string SiteID { get; set; }
        public string APIKey { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }



        public RecordPurchase(string productNumber, int quantity, string siteID, string aPIKey, string customerId, string customerName, string customerPhone, string customerEmail)
        {
            this.ProductNumber = productNumber;
            this.Quantity = quantity;
            this.SiteID = siteID;
            this.APIKey = aPIKey;
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.CustomerPhone = customerPhone;
            this.CustomerEmail = customerEmail;
        }

        public RecordPurchase()
        {

        }








    }
}
