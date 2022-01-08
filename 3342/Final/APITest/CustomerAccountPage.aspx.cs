using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using TestLib;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace APITest
{
    public partial class CustomerAccountPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        StoredProcedures procedures = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAccountInfo();
                objCommand.Parameters.Clear();
                ShowOrderHistory();

                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_Get_SecurityQuestions";
                objCommand.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(Session["customerID"].ToString()));
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                txtAnswer1.Text = myDataSet.Tables[0].Rows[0]["Q1"].ToString();
                txtAnswer2.Text = myDataSet.Tables[0].Rows[0]["Q2"].ToString();
                txtAnswer3.Text = myDataSet.Tables[0].Rows[0]["Q3"].ToString();
                lblQuestion1.Text = myDataSet.Tables[0].Rows[0]["Question1"].ToString();
                lblQuestion2.Text = myDataSet.Tables[0].Rows[0]["Question2"].ToString();
                lblQuestion3.Text = myDataSet.Tables[0].Rows[0]["Question3"].ToString();
            }
        }
        protected void ShowAccountInfo()
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomerUN";
            objCommand.Parameters.AddWithValue("@CustomerUserName", Session["username"].ToString());
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvAccountInfo.DataSource = myDataSet;
            gvAccountInfo.DataBind();
        }

        protected void ShowOrderHistory()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOrderHistory";
            objCommand.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(Session["customerID"].ToString()));
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvOrder.DataSource = myDataSet;
            gvOrder.DataBind();
        }

        protected void gvAccountInfo_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            lblSuccess.Visible = false;
            // Set the row to edit-mode in the GridView
            gvAccountInfo.EditIndex = e.NewEditIndex;
            ShowAccountInfo();
        }

        protected void gvAccountInfo_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to the original state
            // No rows currently being edited
            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }

        protected void gvAccountInfo_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            TextBox TBox;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[0].Controls[0];
            String username = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[1].Controls[0];
            String name = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[2].Controls[0];
            String address = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[3].Controls[0];
            String city = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[4].Controls[0];
            String state = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[5].Controls[0];
            String zip = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[6].Controls[0];
            String phone = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[7].Controls[0];
            String email = TBox.Text;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateCustomerAccount";
            objCommand.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(Session["customerID"]));
            objCommand.Parameters.AddWithValue("@CustomerUserName", username);
            objCommand.Parameters.AddWithValue("@CustomerName", name);
            objCommand.Parameters.AddWithValue("@CustomerAddress", address);
            objCommand.Parameters.AddWithValue("@CustomerCity", city);
            objCommand.Parameters.AddWithValue("@CustomerState", state);
            objCommand.Parameters.AddWithValue("@CustomerZip", zip);
            objCommand.Parameters.AddWithValue("@CustomerPhone", phone);
            objCommand.Parameters.AddWithValue("@CustomerEmail", email);
            objDB.DoUpdateUsingCmdObj(objCommand);

            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtAnswer1.ReadOnly = false;
            txtAnswer2.ReadOnly = false;
            txtAnswer3.ReadOnly = false;
            btnEdit.Visible = false;
            btnEditAnwsers.Visible = true;
            btnCancel.Visible = true;
        }

        protected void btnEditAnwsers_Click(object sender, EventArgs e)
        {
            if (txtAnswer1.Text == "" || txtAnswer2.Text == "" || txtAnswer3.Text == "")
            {
                lblSecurity.Text = "Please answer all questions";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateSecurityQuestions";
                objCommand.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(Session["customerID"]));
                objCommand.Parameters.AddWithValue("@Q1", (txtAnswer1.Text).ToString());
                objCommand.Parameters.AddWithValue("@Q2", (txtAnswer2.Text).ToString());
                objCommand.Parameters.AddWithValue("@Q3", (txtAnswer3.Text).ToString());
                objDB.DoUpdateUsingCmdObj(objCommand);

                txtAnswer1.ReadOnly = true;
                txtAnswer2.ReadOnly = true;
                txtAnswer3.ReadOnly = true;
                btnEdit.Visible = true;
                btnEditAnwsers.Visible = false;
                btnCancel.Visible = false;
                lblResetSuccess.Visible = true;
                lblSecurity.Text = "";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            txtAnswer1.ReadOnly = true;
            txtAnswer2.ReadOnly = true;
            txtAnswer3.ReadOnly = true;
            btnEdit.Visible = true;
            btnEditAnwsers.Visible = false;
            btnCancel.Visible = false;

            lblSecurity.Text = "";
        }


        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            //String plainTextPassword = txtConfirmReset.Text;
            //String encryptedPassword;

            //UTF8Encoding encoder = new UTF8Encoding();      
            //Byte[] textBytes;                              
            
            //textBytes = encoder.GetBytes(plainTextPassword);

            //RijndaelManaged rmEncryption = new RijndaelManaged();
            //MemoryStream myMemoryStream = new MemoryStream();
            //CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);
            
            //myEncryptionStream.Write(textBytes, 0, textBytes.Length);
            //myEncryptionStream.FlushFinalBlock();
            
            //myMemoryStream.Position = 0;
            //Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
            //myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);
            
            //myEncryptionStream.Close();
            //myMemoryStream.Close();
            
            //encryptedPassword = Convert.ToBase64String(encryptedBytes);

            String password = txtConfirmReset.Text;
            if (txtCurrentPassword.Text == "")
            {
                lblDisplay.Text = "Please enter your current password";
                txtCurrentPassword.Focus();
            }
            else if (txtCurrentPassword.Text != Session["password"].ToString())
            {
                lblDisplay.Text = "Please enter correct current password";
                txtCurrentPassword.Focus();
            }
            else if (txtCurrentPassword.Text == Session["password"].ToString())
            {
                if (txtReset.Text == "")
                {
                    lblDisplay.Text = "Please enter your new password";
                    txtReset.Focus();
                }
                else if (txtReset.Text == txtConfirmReset.Text)
                {

                    lblDisplay.Text = "";
                    procedures.ResetPasswords(password, Session["username"].ToString());

                    lblSuccess.Visible = true;
                    txtCurrentPassword.Text = "";
                    txtReset.Text = "";
                    txtConfirmReset.Text = "";
                }
                else
                {
                    txtConfirmReset.Focus();
                    lblDisplay.Text = "Passwords do not match. Please enter again";
                }
            }
        }

        protected void lbAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAccountPage.aspx");
        }

        protected void lbCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void lbWishlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wishlist.aspx");
        }
    }
}