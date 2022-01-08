using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ch20DB
{
    static class MMABooksDB
    {
        // 
        public static string GetConnectionString()
        {
            string s = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename=C:\Users\Joseph\Desktop\Database\MMABooks2.mdf;" +
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
