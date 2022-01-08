using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    [Serializable()]
    public class Product: Merchant
    {
        private String ProductNumber;
        private String Description;
        private string ProductTitle;
        private double Price;
        private String ImageURL;
        private int Quantity;
        private String DepartmentNumber;

        private int ProductId;
        public Product()
        {

        }


        public double TotalCost(double Price, int Quantity)
        {
            double totalCost = 0.0;
            totalCost = Price * Quantity;
            return totalCost;
        }

        public string productNumber
        {
            set { this.ProductNumber = value; }
            get { return ProductNumber; }
        }

        public String productTitle
        {
            get { return ProductTitle; }
            set { ProductTitle = value; }
        }

        public string description
        {
            set { this.Description = value; }
            get { return Description; }
        }

        public double price
        {
            set { this.Price = value; }
            get { return Price; }
        }

        public string imageURL
        {
            set { ImageURL = value; }
            get { return ImageURL; }
        }

        public int quantity
        {
            set { this.Quantity = value; }
            get { return Quantity; }
        }

        public string departmentNumber
        {
            set { DepartmentNumber = value; }
            get { return DepartmentNumber; }
        }



        public int productId
        {
            set { ProductId = value; }
            get { return ProductId; }
        }


    }
}
