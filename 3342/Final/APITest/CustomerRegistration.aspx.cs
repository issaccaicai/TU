using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TestLib;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace APITest
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcommand = new SqlCommand();
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //objcommand.CommandType = CommandType.StoredProcedure;
            //objcommand.CommandText = "TP_GetUserNameAndEmail";

            //objcommand.Parameters.AddWithValue("@CustomerUserName", txtUserName.Text);
            //objcommand.Parameters.AddWithValue("@CustomerEmail", txtEmail.Text);

            //DataSet ds = objDB.GetDataSetUsingCmdObj(objcommand);

            //if (ds.Tables[0].Rows.Count == 0)
            //{
                Customer customer = new Customer();

            if (txtFullName.Text == "" && txtUserName.Text == "" && txtPassword.Text == "" && txtEmail.Text == "" && txtPhone.Text == "" && txtAddress.Text == "" &&
                txtCity.Text == "" && ddlState.SelectedValue == "" && txtZipCode.Text == "" && txtQ1.Text == "" && txtQ2.Text == "" && txtQ3.Text == "" && ddlQ1.SelectedValue == "" &&
                ddlQ2.SelectedValue == "" && ddlQ3.SelectedValue == "")
            {

            }
            else {
                customer.customerName = txtFullName.Text;
                customer.customerUserName = txtUserName.Text;
                customer.customerPassword = txtPassword.Text;
                customer.customerEmail = txtEmail.Text;
                customer.customerPhone = txtPhone.Text;
                customer.customerAddress = txtAddress.Text;
                customer.customerCity = txtCity.Text;
                customer.customerState = ddlState.SelectedValue;
                customer.customerZip = txtZipCode.Text;
                customer.q1 = txtQ1.Text;
                customer.q2 = txtQ2.Text;
                customer.q3 = txtQ3.Text;
                customer.question1 = ddlQ1.SelectedValue;
                customer.question2 = ddlQ2.SelectedValue;
                customer.question3 = ddlQ3.SelectedValue;


                if (customer != null)
                {
                    try
                    {
                        //objcommand.Parameters.Clear();
                        objcommand.CommandType = CommandType.StoredProcedure;
                        objcommand.CommandText = "TP_AddCustomer";

                        objcommand.Parameters.AddWithValue("@CustomerName", customer.customerName);
                        objcommand.Parameters.AddWithValue("@CustomerUserName", customer.customerUserName);
                        objcommand.Parameters.AddWithValue("@CustomerPassword", customer.customerPassword);
                        objcommand.Parameters.AddWithValue("@CustomerEmail", customer.customerEmail);
                        objcommand.Parameters.AddWithValue("@CustomerPhone", customer.customerPhone);
                        objcommand.Parameters.AddWithValue("@CustomerAddress", customer.customerAddress);
                        objcommand.Parameters.AddWithValue("@CustomerCity", customer.customerCity);
                        objcommand.Parameters.AddWithValue("@CustomerState", customer.customerState);
                        objcommand.Parameters.AddWithValue("@CustomerZip", customer.customerZip);
                        objcommand.Parameters.AddWithValue("@Q1", customer.q1);
                        objcommand.Parameters.AddWithValue("@Q2", customer.q2);
                        objcommand.Parameters.AddWithValue("@Q3", customer.q3);
                        objcommand.Parameters.AddWithValue("@Question1", customer.question1);
                        objcommand.Parameters.AddWithValue("@Question2", customer.question2);
                        objcommand.Parameters.AddWithValue("@Question3", customer.question3);


                        int retVal = objDB.DoUpdateUsingCmdObj(objcommand);

                        if (retVal > 0)
                        {
                            lblVal.Text = "Successfully Registered";
                            lblVal.Visible = true;
                        }
                        else
                        {
                            lblVal.Text = "A problem occured in create your account.";
                            lblVal.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                //}
                //else
                //{
                //    lblVal.Text = "The username and email are taken";
                //    lblVal.Visible = true;
                //}
            }
        }
    }
}