using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;

namespace Products
{
    static class MMABooksDB
    {
        // 
        public static string GetConnectionString()
        {
            string s = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename=C:\Users\YING\Desktop\Database\MMABooks.mdf;" +
                @"Integrated Security=True;Connect Timeout=30";
            return s;
        }


        // 
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}
