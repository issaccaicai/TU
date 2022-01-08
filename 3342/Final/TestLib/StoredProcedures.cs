using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace TestLib
{
    public class StoredProcedures
    {

        public DataSet GetSecurityQuestions(string CustomerEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSecurityQuestions";
            objCommand.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet GetMerchantSecurityQuestions(string MerchantEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMerchantSecurityQuestions";
            objCommand.Parameters.AddWithValue("@Email", MerchantEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }
        public DataSet GetPassword(string CustomerEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPassword";
            objCommand.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }
        public DataSet GetMerchantPassword(string MerchantEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMerchantPassword";
            objCommand.Parameters.AddWithValue("@Email", MerchantEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }


        public Boolean ResetPassword(string CustomerEmail, string CustomerPassword)
        {


            if (CustomerPassword != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ResetPassword";
                objCommand.Parameters.AddWithValue("@CustomerEmail", CustomerEmail);
                objCommand.Parameters.AddWithValue("@CustomerPassword", CustomerPassword);

                objDB.DoUpdateUsingCmdObj(objCommand);
                if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
                
            }
            else
            {
                return false;
            }
        }

        public Boolean ResetPasswords(string CustomerPassword, string CustomerUserName)
        {


            if (CustomerPassword != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ResetPasswords";
                
                objCommand.Parameters.AddWithValue("@CustomerPassword", CustomerPassword);
                objCommand.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);


                objDB.DoUpdateUsingCmdObj(objCommand);
                if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            else
            {
                return false;
            }
        }

        public Boolean ResetMerchantPasswords(string MerchantPassword, string MerchantUserName)
        {


            if (MerchantPassword != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ResetMerchantPasswords";

                objCommand.Parameters.AddWithValue("@Password", MerchantPassword);
                objCommand.Parameters.AddWithValue("@Email", MerchantUserName);


                objDB.DoUpdateUsingCmdObj(objCommand);
                if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            else
            {
                return false;
            }
        }

        public Boolean AddProducts(string ProductTitle, string Description, string ImageURL, int Quantity, double Price)
        {


                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddProducts";
                objCommand.Parameters.AddWithValue("@ProductTitle", ProductTitle);
                objCommand.Parameters.AddWithValue("@Description", Description);
                objCommand.Parameters.AddWithValue("@ImageURL", ImageURL);
                objCommand.Parameters.AddWithValue("@Quantity", Quantity);
                objCommand.Parameters.AddWithValue("@Price", Price);

                objDB.DoUpdateUsingCmdObj(objCommand);
                if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            
        }
        public Boolean UpdateInventory(int Quantity, string ProductNumber)
        {


            if (Quantity != 0)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateInventory";
                objCommand.Parameters.AddWithValue("@quantity", Quantity);
                objCommand.Parameters.AddWithValue("@ProductNumber", ProductNumber);

                objDB.DoUpdateUsingCmdObj(objCommand);
                if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            else
            {
                return false;
            }
        }

    }
}
