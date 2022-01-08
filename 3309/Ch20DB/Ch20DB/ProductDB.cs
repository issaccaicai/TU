using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ch20DB
{
    class ProductDB
    {

        public static ProductList GetProducts()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            ProductList pl = new ProductList();
            Product p = null;
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
                    p = new Product();
                    p.ProductCode = (string)dr["ProductCode"];
                    p.Description = (string)dr["Description"];
                    p.UnitPrice = (double)(decimal)dr["UnitPrice"];
                    p.OnHandQuantity = (Int32)dr["OnHandQuantity"];
                    pl.Add(p);
                }
            }
            catch (Exception ex)
            {
                pl = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return pl;
        }
    }
}
