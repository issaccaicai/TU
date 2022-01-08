using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestLib;

namespace APITest
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        StoredProcedures procedures = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = procedures.GetSecurityQuestions(txtEmailAddress.Text);
            try
            {
                lblQuestion1.Text = ds.Tables[0].Rows[0]["Question1"].ToString();
                lblQuestion2.Text = ds.Tables[0].Rows[0]["Question2"].ToString();
                lblQuestion3.Text = ds.Tables[0].Rows[0]["Question3"].ToString();
            }
            catch
            {
                lblMessage.Text = "Invalid e-mail";
            }

        }

        protected void btnSubmitAnswers_Click(object sender, EventArgs e)
        {
            DataSet ds = procedures.GetSecurityQuestions(txtEmailAddress.Text);
            try
            {
                if (txtAnswer1.Text == ds.Tables[0].Rows[0]["Q1"].ToString() &&
                   txtAnswer2.Text == ds.Tables[0].Rows[0]["Q2"].ToString() &&
                   txtAnswer3.Text == ds.Tables[0].Rows[0]["Q3"].ToString())
                {
                    ds = procedures.GetPassword(txtEmailAddress.Text);
                    lblMessage.Text = "Your password is: " + ds.Tables[0].Rows[0]["CustomerPassword"].ToString();
                }
            }
            catch
            {
                lblMessage.Text = "Invalid Answer.";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (txtConfirmReset.Text == txtReset.Text)
            {

                procedures.ResetPassword(txtEmailAddress.Text, txtReset.Text);

                lblResetMessage.Text = "*Successfully reset";
            }
            else
            {
               lblResetMessage.Text = "*Password does not match";
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}