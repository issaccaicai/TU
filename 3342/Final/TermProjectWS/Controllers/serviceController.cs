using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TestLib;
using Utilities;
using System.Security.Cryptography;

namespace TermProjectWS.Controllers
{
    [Produces("application/json")]
    [Route("api/service/Merchants")]
    public class serviceController : Controller
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        [HttpGet("GetDepartments")]
        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetDepartments";
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            int count = myDS.Tables[0].Rows.Count;

            for (int row = 0; row < count; row++)
            {
                string departmentName = objDB.GetField("DepartmentName", row).ToString();
                string departmentNumber = objDB.GetField("DepartmentNumber", row).ToString();

                Department department = new Department(departmentNumber, departmentName);
                departments.Add(department);
            }
            return departments;
        }

        [HttpGet("GetProductCatalog/{DepartmentNumber}")]
        public List<Product> GetProductCatalog(string departmentNumber)
        {
            List<Product> products = new List<Product>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProductCatalog";
            objCommand.Parameters.AddWithValue("@departmentNumber", departmentNumber);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            int count = myDS.Tables[0].Rows.Count;
            for (int row = 0; row < count; row++)
            {
                Product product = new Product();
                //string productNumber = objDB.GetField("ProductNumber", row).ToString();

                product.productNumber = objDB.GetField("ProductNumber", row).ToString();
                product.productTitle = objDB.GetField("ProductTitle", row).ToString();
                product.description = objDB.GetField("Description", row).ToString();
                product.price = double.Parse(objDB.GetField("Price", row).ToString());
                product.imageURL = objDB.GetField("ImageURL", row).ToString();
                product.departmentNumber = objDB.GetField("DepartmentNumber", row).ToString();
                products.Add(product);

            }

            return products;
        }

        [HttpPost()]
        [HttpPost("RegisterSite")]
        public Boolean RegisterSite([FromBody]RegisterSite rs, string SiteID, string Description, string APIKey, string Email, string ContactInformation)
        {
            if (rs != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP__RegisterSite";

                objCommand.Parameters.AddWithValue("@siteID", rs.SiteID);
                objCommand.Parameters.AddWithValue("@description", rs.Description);
                objCommand.Parameters.AddWithValue("@apiKey", rs.APIKey);
                objCommand.Parameters.AddWithValue("@email", rs.Email);
                objCommand.Parameters.AddWithValue("@contactInformation", rs.ContactInformation);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
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


        //[HttpPost("RecordPurchase/{ProductNumber}/{Quantity}/{SiteID}/{APIKey}")]

        [HttpPost()]
        [HttpPost("RecordPurchase")]
        public Boolean RecordPurchase([FromBody]Product product, [FromBody]Customer customer)
        {


            //objCommand.Parameters.Clear();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_getCustomerInfo";
            //objCommand.Parameters.AddWithValue("@customerId", rp.CustomerId);
            //DataSet custDS = objDB.GetDataSetUsingCmdObj(objCommand);
            //rp.CustomerName = custDS.Tables[0].Rows[0]["CustomerName"].ToString();
            //rp.CustomerPhone = custDS.Tables[0].Rows[0]["CustomerPhone"].ToString();
            //rp.CustomerEmail = custDS.Tables[0].Rows[0]["CustomerEmail"].ToString();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProductProductID";
            objCommand.Parameters.AddWithValue("@ProductNumber", product.productNumber);
            DataSet apikeyDS = objDB.GetDataSetUsingCmdObj(objCommand);
            product.aPIKey = apikeyDS.Tables[0].Rows[0]["APIKey"].ToString();

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSellerAPI";
            objCommand.Parameters.AddWithValue("@APIKey", product.aPIKey);
            DataSet sellerDS = objDB.GetDataSetUsingCmdObj(objCommand);
            product.sellerSite = sellerDS.Tables[0].Rows[0]["SellerSite"].ToString();

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomerUserName";
            objCommand.Parameters.AddWithValue("@CustomerId", product.customerId);
            DataSet customerDS = objDB.GetDataSetUsingCmdObj(objCommand);

            // change to product product.customerAddress.....

            //product.customerName = customerDS.Tables[0].Rows[0]["CustomerName"].ToString();
            //product.address = customerDS.Tables[0].Rows[0]["CustomerAddress"].ToString();
            //product.city = customerDS.Tables[0].Rows[0]["CustomerCity"].ToString();
            //product.state = customerDS.Tables[0].Rows[0]["CustomerState"].ToString();
            //product.zip = customerDS.Tables[0].Rows[0]["CustomerZip"].ToString();
            //product.phone = customerDS.Tables[0].Rows[0]["CustomerPhone"].ToString();
            //product.email = customerDS.Tables[0].Rows[0]["CustomerEmail"].ToString();

            product.customerName = customerDS.Tables[0].Rows[0]["CustomerName"].ToString();
            product.customerAddress = customerDS.Tables[0].Rows[0]["CustomerAddress"].ToString();
            product.customerCity = customerDS.Tables[0].Rows[0]["CustomerCity"].ToString();
            product.customerState = customerDS.Tables[0].Rows[0]["CustomerState"].ToString();
            product.customerZip = customerDS.Tables[0].Rows[0]["CustomerZip"].ToString();
            product.customerPhone = customerDS.Tables[0].Rows[0]["CustomerPhone"].ToString();
            product.customerEmail = customerDS.Tables[0].Rows[0]["CustomerEmail"].ToString();




            if (product != null)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddOrder";
                objCommand.Parameters.AddWithValue("@Quantity", product.quantity);
                objCommand.Parameters.AddWithValue("@ProductNumber", product.productNumber);
                objCommand.Parameters.AddWithValue("@APIKey", product.aPIKey);
                objCommand.Parameters.AddWithValue("@SellerSite", product.sellerSite);
                objCommand.Parameters.AddWithValue("@CustomerId", product.customerId);
                objCommand.Parameters.AddWithValue("@CustomerName", product.customerName);
                objCommand.Parameters.AddWithValue("@CustomerAddress", product.customerAddress);
                objCommand.Parameters.AddWithValue("@CustomerCity", product.customerCity);
                objCommand.Parameters.AddWithValue("@CustomerState", product.customerState);
                objCommand.Parameters.AddWithValue("@CustomerZip", product.customerZip);
                objCommand.Parameters.AddWithValue("@CustomerPhone", product.customerPhone);
                objCommand.Parameters.AddWithValue("@CustomerEmail", product.customerEmail);

                objCommand.Parameters.AddWithValue("@Total", product.total);
                objCommand.Parameters.AddWithValue("@Time", product.time);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
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



        [HttpPost()]
        [HttpPost("Register/Merchant")]
        public Boolean RegisterMerchant([FromBody]Merchant merchant)
        {
            //Generate an API key
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            merchant.aPIKey = Convert.ToBase64String(key);

            //Check if there is already an username stored in the database
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMerchant";
            objCommand.Parameters.AddWithValue("@APIKey", merchant.aPIKey);
            objCommand.Parameters.AddWithValue("@SellerSite", merchant.sellerSite);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count == 0) //If there is no other apikey or username already exists
            {
                if (merchant != null)
                {
                    objCommand.Parameters.Clear();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_AddMerchant";
                    objCommand.Parameters.AddWithValue("@APIKey", merchant.aPIKey);
                    objCommand.Parameters.AddWithValue("@SellerSite", merchant.sellerSite);
                    objCommand.Parameters.AddWithValue("@Url", merchant.url);
                    objCommand.Parameters.AddWithValue("@Description", merchant.description);
                    objCommand.Parameters.AddWithValue("@Email", merchant.email);
                    objCommand.Parameters.AddWithValue("@Phone", merchant.phone);
                    objCommand.Parameters.AddWithValue("@Address", merchant.address);
                    objCommand.Parameters.AddWithValue("@City", merchant.city);
                    objCommand.Parameters.AddWithValue("@State", merchant.state);
                    objCommand.Parameters.AddWithValue("@Zip", merchant.zip);
                    objCommand.Parameters.AddWithValue("@Password", merchant.password);
                    objCommand.Parameters.AddWithValue("@Q1", merchant.q1);
                    objCommand.Parameters.AddWithValue("@Q2", merchant.q2);
                    objCommand.Parameters.AddWithValue("@Q3", merchant.q3);
                    objCommand.Parameters.AddWithValue("@Question1", merchant.ques1);
                    objCommand.Parameters.AddWithValue("@Question2", merchant.ques2);
                    objCommand.Parameters.AddWithValue("@Question3", merchant.ques3);

                    int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                    if (returnValue > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

    }
}
