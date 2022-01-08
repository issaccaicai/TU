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
    public class Restaurant
    {
        DBConnect objDB = new DBConnect();
        public DataSet displayRestaurant()
        {

            SqlCommand cmdCategories = new SqlCommand("getCategories");
            cmdCategories.CommandType = CommandType.StoredProcedure;
            var DS = objDB.GetDataSetUsingCmdObj(cmdCategories);


            return DS;
        }

        public DataSet displayAllRep()
        {

            SqlCommand cmdCategories = new SqlCommand("getAllRep");
            cmdCategories.CommandType = CommandType.StoredProcedure;
            var DS = objDB.GetDataSetUsingCmdObj(cmdCategories);


            return DS;
        }



    }
}
