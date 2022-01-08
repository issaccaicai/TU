using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceLineItems
{
    public static class InvoiceDB
    {
        public static List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            SqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT * FROM Invoices";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                SqlDataReader invoiceReader =
                    selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (invoiceReader.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.InvoiceID = (int)invoiceReader["InvoiceID"];
                    invoice.CustomerID = (int)invoiceReader["CustomerID"];
                    invoice.InvoiceDate = (DateTime)invoiceReader["InvoiceDate"];
                    invoice.ProductTotal = (decimal)invoiceReader["ProductTotal"];
                    invoice.SalesTax = (decimal)invoiceReader["SalesTax"];
                    invoice.Shipping = (decimal)invoiceReader["Shipping"];
                    invoice.InvoiceTotal = (decimal)invoiceReader["InvoiceTotal"];
                    invoices.Add(invoice);
                }
                invoiceReader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return invoices;
        }

    }
}
