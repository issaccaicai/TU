using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BookInfo
    {
        private String title;
        private String iSBN;
        private String bookType;
        private String rb;
        private double price;
        private int quantity;
        private double totalCost;
        
        public String Title
        {
            get { return title; }

            set { title = value; }
        }
        

        public String ISBN
        {
            get { return iSBN; }

            set { iSBN = value; }
        }

        public String Type
        {
            get { return bookType; }

            set { bookType = value; }
        }

        public String RB
        {
            get { return rb; }

            set { rb = value; }
        }

        public double Price
        {
            get { return price; }

            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }

            set { quantity = value; }
        }

        public double TotalCost
        {
            get { return totalCost; }

            set { totalCost = value; }
        }
    }
}
