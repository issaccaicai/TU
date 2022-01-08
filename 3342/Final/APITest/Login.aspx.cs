using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace APITest
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {
                String accountType = ddlAccountType.SelectedValue.ToString();
                

                HttpCookie cookie = Request.Cookies["CIS3342_Cookie"];
                txtUserName.Text = cookie.Values["username"].ToString();
                txtPassword.Text = cookie.Values["password"].ToString();
                ddlAccountType.SelectedValue = cookie.Values["accountType"].ToString();
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Session.Add("customerID", "");
            Session.Add("username", "");
            Session.Add("email", "");
            Session.Add("password", "");
            Session.Add("accountType", "");

            String username = txtUserName.Text;
            String password = txtPassword.Text;
            String accountType = ddlAccountType.SelectedValue;

            if (username == "")
            {
                txtUserName.Focus();
                lblMessage.Text = "Please enter your Username or Email address";
            }
            else if (password == "")
            {
                txtPassword.Focus();
                lblMessage.Text = "Please enter your password";
            }
            else
            {
                if (accountType == "customer")
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_LoginCustomer";
                    objCommand.Parameters.AddWithValue("@CustomerUserName", username);
                    objCommand.Parameters.AddWithValue("@CustomerPassword", password);
                    DataSet CustomerDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    try
                    {
                        lblMessage.Text = "";
                        lblSignIn.Text = "Sign in successfully! Hello <b>" + CustomerDS.Tables[0].Rows[0]["CustomerName"].ToString() + "</b>" + " !";
                        Session["customerID"] = CustomerDS.Tables[0].Rows[0]["CustomerId"].ToString();
                        Session["username"] = username;
                        Session["accountType"] = accountType;
                        Session["password"] = password;
                        lblSignIn.Visible = true;

                        if (chkRemember.Checked == true)
                        {
                            HttpCookie customerCookie = new HttpCookie("CIS3342_Cookie");
                            customerCookie.Values["username"] = txtUserName.Text;
                            customerCookie.Values["password"] = txtPassword.Text;
                            customerCookie.Values["accountType"] = ddlAccountType.SelectedValue;
                            customerCookie.Values["LastTimeVisited"] = DateTime.Now.ToString();
                            customerCookie.Expires = new DateTime(2222, 2, 2);
                            Response.Cookies.Add(customerCookie);
                        }

                        Response.AddHeader("REFRESH", "3;URL=Shopping.aspx");
                    }
                    catch
                    {
                        lblMessage.Text = "Incorrect Username OR Password";
                        txtPassword.Focus();
                    }
                }
                else if (accountType == "merchant")
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_LoginMerchant";
                    objCommand.Parameters.AddWithValue("@Email", username);
                    objCommand.Parameters.AddWithValue("@Password", password);
                    DataSet MerchantDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    try
                    {
                        string merchantName = MerchantDS.Tables[0].Rows[0]["SellerSite"].ToString();
                        string merchantID = MerchantDS.Tables[0].Rows[0]["MerchantId"].ToString();
                        lblMessage.Text = "";
                        lblSignIn.Text = "Sign in successfully! Welcome back <b>" + merchantName + "</b>"; 
                        Session["merchantID"] = merchantID;
                        Session["email"] = username;
                        Session["accountType"] = accountType;
                        Session["password"] = password;
                        lblSignIn.Visible = true;
                        if (chkRemember.Checked == true)
                        {
                            HttpCookie customerCookie = new HttpCookie("CIS3342_Cookie");
                            customerCookie.Values["username"] = txtUserName.Text;
                            customerCookie.Values["password"] = txtPassword.Text;
                            customerCookie.Values["accountType"] = ddlAccountType.SelectedValue;
                            customerCookie.Values["LastTimeVisited"] = DateTime.Now.ToString();
                            customerCookie.Expires = new DateTime(2222, 2, 2);
                            Response.Cookies.Add(customerCookie);
                        }
                        Response.AddHeader("REFRESH", "3;URL=MerchantAccountPage.aspx");
                    }
                    catch
                    {
                        lblMessage.Text = "Incorrect Username OR Password";
                        txtPassword.Focus();
                    }
                }
            }
        }

        protected void lbForgotPassword_Click(object sender, EventArgs e)
        {
            if (ddlAccountType.SelectedValue.ToString() == "customer")
            {
                Response.Redirect("ForgotPassword.aspx");
            }
            else if (ddlAccountType.SelectedValue.ToString() == "merchant")
            {
                Response.Redirect("MerchantForgotPassword.aspx");
            }
        }
    }
}