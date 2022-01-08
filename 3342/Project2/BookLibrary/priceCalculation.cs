using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using Utilities;

namespace BookLibrary
{
    public class priceCalculation
    {
        DBConnect objDB = new DBConnect();
    
        public double Calculation(string Title, string Type, string RB)
        {
            String strSql = "SELECT BasePrice FROM Books" + "WHERE Title = " + Title;
            DataSet price = objDB.GetDataSet(strSql);
            DataTable dtBooks = price.Tables[0];

            for (int row = 0; row < dtBooks.Rows.Count; row++)
            {

                DataRow drBookRecord = dtBooks.Rows[row];

            }
            double hard = 1.5;
            double paper = 1;
            double eBook = 0.9;

            double rentPrice = 0.85;
            double buyPrice = 1;

            if (Type == "Hardcover")
            {
                if (RB == "Rent")
                {
                    double Price = Convert.ToDouble(price.Tables[0].Rows[0]["Hardcover"]) * hard * rentPrice;
                }
                if (RB == "But")
                {
                    double Price = Convert.ToDouble(price.Tables[0].Rows[0]["Hardcover"]) * hard * buyPrice;
                }
            }

            else if (Type == "Paper-Back")
            {
                if (RB == "Rent")
                {
                    double Price = Convert.ToDouble(price.Tables[0].Rows[0]["Paper-Back"]) * paper * rentPrice;
                }
                if (RB == "But")
                {
                    double Price = Convert.ToDouble(price.Tables[0].Rows[0]["c"]) * paper * buyPrice;
                }
                
            }
            else if (Type == "E-Book")
            {
                if (RB == "Rent")
                {
                    double Price = Convert.ToDouble(price.Tables[0].Rows[0]["E-Book"]) * eBook * rentPrice;
                }
                if (RB == "But")
                {
                    double Price = Convert.ToDouble(price.Tables[0].Rows[0]["E-Book"]) * eBook * buyPrice;
                }
            }
            return -1;
        }

    }
}
