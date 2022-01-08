using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ch20DB
{
    class InvoiceDB
    {

        // Get an invoice
        public static Invoice GetInvoice(int InvoiceID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            Invoice i = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    i = new Invoice();
                    i.InvoiceID = (Int32)dr["InvoiceID"];
                    i.CustomerID = (Int32)dr["CustomerID"];
                    i.InvoiceDate = (string)dr["InvoiceDate"];
                    i.ProductTotal = (double)dr["ProductTotal"];
                    i.SalesTax = (double)dr["SalesTax"];
                    i.Shipping = (double)dr["Shipping"];
                    i.InvoiceTotal = (double)dr["InvoiceTotal"];
                }
            }
            catch (Exception ex)
            {
                i = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return i;
        }



        // Insert an invoice
        // 
        public static bool InsertInvoice(int InvoiceID, int CustomerID, string InvoiceDate, 
            double ProductTotal, double SalesTax, double Shipping, double InvoiceTotal,
            List<InvoiceLineItem> il)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            //int maxId = -1;
            //int maxId = 
            if (conn == null)
                return false;
            string sqlString = "INSERT INTO Invoices VALUES (@CustomerID, @InvoiceDate, @ProductTotal, @SalesTax, @Shipping, @InvoiceTotal)";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            comm.Parameters.AddWithValue("@CustomerID", CustomerID);
            comm.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
            comm.Parameters.AddWithValue("@ProductTotal", ProductTotal);
            comm.Parameters.AddWithValue("@SalesTax", SalesTax);
            comm.Parameters.AddWithValue("@Shipping", Shipping);
            comm.Parameters.AddWithValue("@InvoiceTotal", InvoiceTotal);
            InvoiceID = GetMaxInvoiceID();
            conn.Close();
            // Insert line items
            foreach(InvoiceLineItem i in il)
            {
                InsertInvoiceLineItem(InvoiceID, i.ProductCode, i.UnitPrice, i.Quantity, i.ItemTotal);
            }
            int n = 0;
            try
            {
                conn.Open();
                n = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            if (n < 1)
                return false;
            return true;
        }


        public static bool InsertInvoice(Invoice i)
        {
            return InsertInvoice(i.InvoiceID, i.CustomerID, i.InvoiceDate,
            i.ProductTotal, i.SalesTax, i.Shipping, i.InvoiceTotal,
            i.InvoiceLineItems);
        }


        // 
        public static InvoiceList GetInvoices(int CustomerID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            InvoiceList il = new InvoiceList();
            Invoice i = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM Invoices WHERE CustomerID = @CustomerID";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (dr.Read())
                {
                    i = new Invoice();
                    i.InvoiceID = (Int32)dr["InvoiceID"];
                    i.CustomerID = (Int32)dr["CustomerID"];
                    i.InvoiceDate = ((DateTime)dr["InvoiceDate"]).ToShortDateString();
                    i.ProductTotal = (double)(decimal)dr["ProductTotal"];
                    i.SalesTax = (double)(decimal)dr["SalesTax"];
                    i.Shipping = (double)(decimal)dr["Shipping"];
                    i.InvoiceTotal = (double)(decimal)dr["InvoiceTotal"];
                    il.Add(i);
                }
                conn.Close();
                foreach (Invoice j in il)
                {
                    j.InvoiceLineItems = GetLineItems(j.InvoiceID);
                }
            }
            catch (Exception ex)
            {
                il = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return il;
        }


        public static int GetMaxInvoiceID()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return -1;
            string sqlString = "SELECT MAX(InvoiceID) FROM Invoices";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            SqlDataReader dr = null;
            int InvoiceID = -1;
            try
            {
                conn.Open();
                InvoiceID = (Int32)comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return InvoiceID;
        }


        // 
        public static List<InvoiceLineItem> GetLineItems(int InvoiceID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            List<InvoiceLineItem> il = new List<InvoiceLineItem>();
            InvoiceLineItem i = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM InvoiceLineItems WHERE InvoiceID = @InvoiceID";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (dr.Read())
                {
                    i = new InvoiceLineItem();
                    i.InvoiceID = (Int32)dr["InvoiceID"];
                    i.ProductCode = (string)dr["ProductCode"];
                    i.UnitPrice = (double)(decimal)dr["UnitPrice"];
                    i.Quantity = (Int32)dr["Quantity"];
                    i.ItemTotal = (double)(decimal)dr["ItemTotal"];
                    il.Add(i);
                }
            }
            catch (Exception ex)
            {
                il = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return il;
        }


        public static bool InsertInvoiceLineItem(int invoiceID, string productCode, 
            double unitPrice, int quantity, double itemTotal)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return false;
            string sqlString = "INSERT INTO InvoiceLineItems VALUES (@invoiceID, @productCode, @unitPrice, @quantity, @itemTotal)";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@invoiceID", invoiceID);
            comm.Parameters.AddWithValue("@productCode", productCode);
            comm.Parameters.AddWithValue("@unitPrice", unitPrice);
            comm.Parameters.AddWithValue("@quantity", quantity);
            comm.Parameters.AddWithValue("@itemTotal", itemTotal);
            int n = 0;
            try
            {
                conn.Open();
                n = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            if (n < 1)
                return false;
            return true;
        }

    }
}
