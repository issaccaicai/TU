using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public class Order
    {
        private string ProductNumber { set; get; }
        private string APIKey { set; get; }
        private int Quantity { set; get; }
        private string SellerSite { set; get; }
        private string CustomerId { set; get; }
        private string CustomerName { set; get; }
        private string CustomerPhone { set; get; }
        private string CustomerEmail { set; get; }
        private string CustomerAddress { set; get; }

        public Order()
        {

        }
    }
}
