using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilities;
namespace restaurantLibrary
{
    public class Search
    {
        DBConnect objDB = new DBConnect();
        public DataSet displaySearch()
        {

            SqlCommand cmdCategories = new SqlCommand("getCategories");
            cmdCategories.CommandType = CommandType.StoredProcedure;
            var DS = objDB.GetDataSetUsingCmdObj(cmdCategories);


            return DS ;
        }
    }
}
