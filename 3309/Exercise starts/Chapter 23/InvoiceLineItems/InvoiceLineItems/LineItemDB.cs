using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceLineItems
{
    public class LineItemDB
    {
        public static List<LineItem> GetLineItems()
        {
            List<LineItem> lineItems = new List<LineItem>();

            SqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT * FROM InvoiceLineItems";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                SqlDataReader lineItemReader =
                    selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (lineItemReader.Read())
                {
                    LineItem lineItem = new LineItem();
                    lineItem.InvoiceID = (int)lineItemReader["InvoiceID"];
                    lineItem.ProductCode = lineItemReader["ProductCode"].ToString();
                    lineItem.UnitPrice = (decimal)lineItemReader["UnitPrice"];
                    lineItem.Quantity = (int)lineItemReader["Quantity"];
                    lineItem.ItemTotal = (decimal)lineItemReader["ItemTotal"];
                    lineItems.Add(lineItem);
                }
                lineItemReader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return lineItems;
        }

    }
}
