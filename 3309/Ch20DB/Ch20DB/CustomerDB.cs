using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ch20DB
{
    static class CustomerDB
    {

        // 
        public static Customer GetCustomer(int CustomerID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            Customer c = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    c = new Customer();
                    c.CustomerID = (Int32)dr["CustomerID"];
                    c.Name = (string)dr["Name"];
                    c.Address = (string)dr["Address"];
                    c.City = (string)dr["City"];
                    c.State = (string)dr["State"];
                    c.ZipCode = (string)dr["ZipCode"];
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
        public static bool InsertCustomer(string Name, string Address, string City,
            string State, string ZipCode)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return false;
            string sqlString = "INSERT INTO Customers VALUES (@Name, @Address, @City, @State, @ZipCode)";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@Address", Address);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@ZipCode", ZipCode);
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
                if(conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            if (n < 1)
                return false;
            return true;
        }


        public static bool UpdateCustomer(int CustomerID, string Name, string Address, string City,
            string State, string ZipCode)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return false;
            string sqlString = "UPDATE Customers SET Name = @Name, Address = @Address, " +
                "City = @City, State = @State, ZipCode = @ZipCode WHERE CustomerID = @CustomerID";
            //MessageBox.Show(sqlString);
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@CustomerID", CustomerID);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@Address", Address);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@ZipCode", ZipCode);
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
        public static bool DeleteCustomer(int CustomerID)
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return false;
            string sqlString = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            comm.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public static CustomerList GetCustomers()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            CustomerList cl = new CustomerList();
            Customer c = null;
            if (conn == null)
                return null;
            string sqlString = "SELECT * FROM Customers";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = comm.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (dr.Read())
                {
                    c = new Customer();
                    c.CustomerID = (Int32)dr["CustomerID"];
                    c.Name = (string)dr["Name"];
                    c.Address = (string)dr["Address"];
                    c.City = (string)dr["City"];
                    c.State = (string)dr["State"];
                    c.ZipCode = (string)dr["ZipCode"];
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



        public static int GetMaxCustomerID()
        {
            SqlConnection conn = MMABooksDB.GetConnection();
            if (conn == null)
                return -1;
            string sqlString = "SELECT MAX(CustomerID) FROM Customers";
            SqlCommand comm = new SqlCommand(sqlString, conn);
            SqlDataReader dr = null;
            int CustomerID = -1;
            try
            {
                conn.Open();
                CustomerID = (Int32)comm.ExecuteScalar();
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

            return CustomerID;
        }

    }
}
