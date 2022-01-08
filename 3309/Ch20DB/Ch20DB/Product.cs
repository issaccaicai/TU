using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch20DB
{
    class Product
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int OnHandQuantity { get; set; }

        public Product() { }

        public Product(string productCode, string description, double unitPrice,
            int onHandQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }


        public override string ToString()
        {
            return ProductCode + " " + Description + " " +
                UnitPrice + " " + OnHandQuantity + "\r\n";
        }

    }
}
