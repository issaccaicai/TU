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
    public partial class MerchantAccountPage : System.Web.UI.Page
    {

        StoredProcedures procedures = new StoredProcedures();
        private const int ADDRESS_COLUMN = 0;
        private const int CITY_COLUMN = 1;
        private const int STATE_COLUMN = 2;
        private const int ZIPCODE_COLUMN = 3;
        private const int PHONE_COLUMN = 4;
        private const int EMAIL_COLUMN = 5;
        private const int FIRST_CONTROL = 0;

        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();

        ArrayList merchants = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAccountInfo();
                ShowInventory();
                objcomm.Parameters.Clear();
                ShowAllSales();

                objcomm.Parameters.Clear();
                objcomm.CommandType = CommandType.StoredProcedure;
                objcomm.CommandText = "TP_Get_MerchantSecurityQuestions";
                objcomm.Parameters.AddWithValue("@MerchantId", Convert.ToInt32(Session["merchantID"].ToString()));
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objcomm);

                txtAnswer1.Text = myDataSet.Tables[0].Rows[0]["Q1"].ToString();
                txtAnswer2.Text = myDataSet.Tables[0].Rows[0]["Q2"].ToString();
                txtAnswer3.Text = myDataSet.Tables[0].Rows[0]["Q3"].ToString();
                lblQuestion1.Text = myDataSet.Tables[0].Rows[0]["Question1"].ToString();
                lblQuestion2.Text = myDataSet.Tables[0].Rows[0]["Question2"].ToString();
                lblQuestion3.Text = myDataSet.Tables[0].Rows[0]["Question3"].ToString();

                
            }
        }

        protected void ShowInventory()
        {

            String strSQL = "SELECT * FROM TP_Product ORDER BY ProductNumber";

            gvReport.DataSource = objDB.GetDataSet(strSQL);

            gvReport.DataBind();
        }
        protected void ShowAccountInfo()
        {
            string merchantEmail = Session["email"].ToString();
            string merchantPassword = Session["password"].ToString();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_getMerchantInfo";
            objcomm.Parameters.AddWithValue("@Email", merchantEmail);
            objcomm.Parameters.AddWithValue("@Password", merchantPassword);
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objcomm);

            gvAccountInfo.DataSource = myDataSet;
            gvAccountInfo.DataBind();
        }
        protected string GetAPIKey()
        {
            int id = int.Parse(Session["merchantID"].ToString());
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_getAPIKey";

            objcomm.Parameters.AddWithValue("@MerchantId", id);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);
            string apikey = ds.Tables[0].Rows[0]["APIKey"].ToString();

            return apikey;

        }
        protected void UpdateMerchantInfo(Merchant merchant)
        {
            int id = int.Parse(Session["merchantID"].ToString());
            try
            {
                objcomm.CommandType = CommandType.StoredProcedure;
                objcomm.CommandText = "TP_UpdateMerchantInfo";

                objcomm.Parameters.AddWithValue("@MerchantId", id);
                objcomm.Parameters.AddWithValue("@Address", merchant.address);
                objcomm.Parameters.AddWithValue("@City", merchant.city);
                objcomm.Parameters.AddWithValue("@State", merchant.state);
                objcomm.Parameters.AddWithValue("@Zip", merchant.zip);
                objcomm.Parameters.AddWithValue("@Phone", merchant.phone);
                objcomm.Parameters.AddWithValue("@Email", merchant.email);

                objDB.DoUpdateUsingCmdObj(objcomm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvAccountInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            TextBox TBox;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[ADDRESS_COLUMN].Controls[FIRST_CONTROL];
            string address = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[CITY_COLUMN].Controls[FIRST_CONTROL];
            string city = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[STATE_COLUMN].Controls[FIRST_CONTROL];
            string state = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[ZIPCODE_COLUMN].Controls[FIRST_CONTROL];
            string zipcode = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[PHONE_COLUMN].Controls[FIRST_CONTROL];
            string phone = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[EMAIL_COLUMN].Controls[FIRST_CONTROL];
            string email = TBox.Text;

            Merchant merchant = new Merchant();
            merchant.address = address;
            merchant.city = city;
            merchant.state = state;
            merchant.zip = zipcode;
            merchant.phone = phone;
            merchant.email = email;

            Session["merchant"] = merchant;
            UpdateMerchantInfo(merchant);
            merchants.Add(merchant);
            gvAccountInfo.EditIndex = -1;

            gvAccountInfo.DataSource = merchants;
            gvAccountInfo.DataBind();


        }

        protected void gvAccountInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAccountInfo.EditIndex = e.NewEditIndex;
            ShowAccountInfo();
        }

        protected void gvAccountInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }
        protected void btnGetApikey_Click(object sender, EventArgs e)
        {
            txtAPIKey.Text = GetAPIKey();
        }

        //protected void btnViewSales_Click(object sender, EventArgs e)
        //{
        //}
        protected void ShowAllSales()
        {
            string apikey = GetAPIKey();

            objcomm.Parameters.Clear();
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_getMerchantSales";

            objcomm.Parameters.AddWithValue("@APIKey", apikey);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);
            gvSales.DataSource = ds;
            gvSales.DataBind();
        }

        protected void btnResePassword_Click(object sender, EventArgs e)
        {
            String password = txtConfirmPassword.Text;
            if (txtPassword.Text == "")
            {
                lblDisplay.Text = "Please enter your current password";
                txtPassword.Focus();
            }
            else if (txtPassword.Text != Session["password"].ToString())
            {
                lblDisplay.Text = "Please enter correct current password";
                txtPassword.Focus();
            }
            else if (txtPassword.Text == Session["password"].ToString())
            {
                if (txtNewPassword.Text == "")
                {
                    lblDisplay.Text = "Please enter your new password";
                    txtNewPassword.Focus();
                }
                else if (txtNewPassword.Text == txtConfirmPassword.Text)
                {

                    lblDisplay.Text = "";
                    procedures.ResetMerchantPasswords(password, Session["email"].ToString());

                    lblSuccess.Visible = true;
                    txtPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                {
                    txtConfirmPassword.Focus();
                    lblDisplay.Text = "Passwords do not match. Please enter again";
                }
            }
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
                objcomm.CommandType = CommandType.StoredProcedure;
                objcomm.CommandText = "TP_UpdateMerchantSecurityQuestions";
                objcomm.Parameters.AddWithValue("@MerchantId", Convert.ToInt32(Session["merchantID"]));
                objcomm.Parameters.AddWithValue("@Q1", (txtAnswer1.Text).ToString());
                objcomm.Parameters.AddWithValue("@Q2", (txtAnswer2.Text).ToString());
                objcomm.Parameters.AddWithValue("@Q3", (txtAnswer3.Text).ToString());
                objDB.DoUpdateUsingCmdObj(objcomm);

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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}