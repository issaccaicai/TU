using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch20DB
{
    class InvoiceLineItem
    {
        public int InvoiceID { get; set; }
        public string ProductCode { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double ItemTotal { get; set; }


        public InvoiceLineItem() { }


        public InvoiceLineItem(int invoiceID, string productCode, double unitPrice,
            int quantity, double itemTotal)
        {
            InvoiceID = invoiceID;
            ProductCode = productCode;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ItemTotal = itemTotal;
        }


        public override string ToString()
        {
            return InvoiceID + " " + ProductCode + " " + UnitPrice + " " + Quantity + " " +
                ItemTotal;
        }
    }
}
