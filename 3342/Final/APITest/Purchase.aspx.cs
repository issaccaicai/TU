using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestLib;
using Utilities;

namespace APITest
{
    public partial class Purchase : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        ArrayList productlist = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showConfirm(ShowTotalPrice());
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCustomerUserName";
                objCommand.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(Session["customerID"].ToString()));
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                lblCustomer.Text = "Customer Name: " + myDS.Tables[0].Rows[0]["CustomerName"].ToString() + "<br />" +
                                   "Customer Shipping Address: " + myDS.Tables[0].Rows[0]["CustomerAddress"].ToString() + "<br />" +
                                   "Customer City: " + myDS.Tables[0].Rows[0]["CustomerCity"].ToString() + "<br />" +
                                   "Customer State: " + myDS.Tables[0].Rows[0]["CustomerState"].ToString() + "<br />" +
                                   "Customer ZipCode:" + myDS.Tables[0].Rows[0]["CustomerZip"].ToString() + "<br />" +
                                   "Customer Phone: " + myDS.Tables[0].Rows[0]["CustomerPhone"].ToString() + "<br />" +
                                   "Customer Email: " + myDS.Tables[0].Rows[0]["CustomerEmail"].ToString();
            }
        }
        public void showConfirm(double totalcost)
        {
            gvPurchase.Columns[0].FooterText = "Total";
            gvPurchase.Columns[4].FooterText = totalcost.ToString("C2");
            productlist = (ArrayList)Session["Productlist"];
            gvPurchase.DataSource = productlist;

            String[] productid = new string[1];
            productid[0] = "ProductNumber";
            gvPurchase.DataKeyNames = productid;
            gvPurchase.DataBind();
        }
        
        public double ShowTotalPrice()
        {
            productlist = (ArrayList)Session["Productlist"];
            double total = 0.0;
            foreach (Product p in productlist)
            {
                double price = p.price;
                int quantity = p.quantity;
                total += p.TotalCost(p.price, p.quantity);
            }

            return total;
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomerUserName";
            objCommand.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(Session["customerID"].ToString()));
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            Email objEmail = new Email();
            String strTO = myDS.Tables[0].Rows[0]["CustomerEmail"].ToString();
            String strFROM = "tug11448@temple.edu";
            String strSubject = "Order Receipt";
            String strMessage = "";
            for (int row = 0; row < gvPurchase.Rows.Count; row++)
            {
                strMessage = "Product Title: " + gvPurchase.Rows[row].Cells[1].Text.ToString() + "." + "<br />" + 
                    "Description: "+ gvPurchase.Rows[row].Cells[2].Text.ToString() + "." + "<br />" +
                    "Quantity: " + gvPurchase.Rows[row].Cells[3].Text.ToString() + "." + "<br />" +
                    "Price: $" + gvPurchase.Rows[row].Cells[4].Text.ToString() + "<br />";
                
            }

            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                lblDisplay.Text = strMessage;
            }
            catch (Exception ex)
            {
                lblDisplay.Text = "Error: " + ex.Message;
            }
        }
    }
}