using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using System.Data.SqlClient;
using System.Windows.Forms;

namespace Products
{
    static class ProductDB
    {
        // 
        public static Product GetProduct(string ProductID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            Product c = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM Products WHERE ProductCode = @ProductCode";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@ProductCode", ProductID);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    c = new Product();
                    c.ProductCode = (string)dr[0];
                    c.Description = (string)dr[1];
                    c.UnitPrice = (double)(decimal)dr[2];
                    c.OnHandQuantity = (Int32)dr[3];
                }
            }
            catch (Exception ex)
            {
                c = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return c;
        }


        // 
        public static bool InsertProduct(string ProductID, string Description, double Price,
            int Quantity)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return false;
            string sqlString = "INSERT INTO Products VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@ProductCode", ProductID);
            comm.Parameters.AddWithValue("@Description", Description);
            comm.Parameters.AddWithValue("@UnitPrice", Price);
            comm.Parameters.AddWithValue("@OnHandQuantity", Quantity);
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



        // 
        public static bool DeleteProduct(string ProductID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return false;
            string sqlString = "DELETE FROM Products WHERE ProductCode = @ProductCode";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@ProductCode", ProductID);
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


        // 
        public static ProductList GetProducts()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            ProductList cl = new ProductList();
            Product c = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM Products";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (dr.Read())
                {
                    c = new Product();
                    c.ProductCode = (string)dr["ProductCode"];
                    c.Description = (string)dr["Description"];
                    c.UnitPrice = (double)(decimal)dr["UnitPrice"];
                    c.OnHandQuantity = (Int32)dr["OnHandQuantity"];
                    cl.Add(c);
                }
            }
            catch (Exception ex)
            {
                cl = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return cl;
        }



        public static string GetMaxProductID()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return "";
            string sqlString = "SELECT MAX(ProductID) FROM Products";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            SqlDataReader dr = null;
            string ProductID = "";
            try
            {
                conn.Open();
                ProductID = (string)comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "";
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return ProductID;
        }



        public static double GetInventory()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            ProductList cl = new ProductList();
            double total = 0;
            Product c = null;
            if (conn == null)
                return 0;
            string sqlString = "SELECT * FROM Products";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (dr.Read())
                {
                    c = new Product();
                    c.UnitPrice = (double)(decimal)dr["UnitPrice"];
                    c.OnHandQuantity = (Int32)dr["OnHandQuantity"];
                    total += c.UnitPrice * c.OnHandQuantity;
                }
            }
            catch (Exception ex)
            {
                total = 0;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return total;
        }
    }
}









