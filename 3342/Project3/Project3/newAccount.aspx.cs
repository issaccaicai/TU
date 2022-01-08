using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Project3
{
    public partial class newAccount : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string name = txtName.Text;

            lblInvail.Visible = false;
            
            
            if (name == "")
            {
                lblInvail.Text = "** Please Enter your Name. **";
                lblInfo.Text = "";
                lblInfo.Visible = false;
                lblInvail.Visible = true;
                return;
            }

            if (selectReviewer.Checked)
            {
                SqlCommand myCommand = new SqlCommand("createReviewerAccount");
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter myPar = new SqlParameter("@reviewerId", SqlDbType.Int);
                myPar.Direction = ParameterDirection.ReturnValue;
                
                myCommand.Parameters.AddWithValue("@reviewerName", name);

                myCommand.Parameters.Add(myPar);

                objDB.DoUpdateUsingCmdObj(myCommand);

                int reviewerId = Convert.ToInt32(myPar.Value);
                lblInfo.Text = "Congratulation! Your *" + selectReviewer.Text + "* accout has been created." + "<br>" +
                                        
                                        "Your Name: " + name + "<br>" +
                                        "ID: " + reviewerId + "<br>" +
                                        "**(Remember your ID to login!)**";
                txtName.Text = "";
                return;
            }
            if (selectReresentative.Checked)
            {

                SqlCommand myCommand = new SqlCommand("createReprAccount");
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter myPar = new SqlParameter("@representativeId", SqlDbType.Int);
                myPar.Direction = ParameterDirection.ReturnValue;
                
                myCommand.Parameters.AddWithValue("@representativeName", name);

                myCommand.Parameters.Add(myPar);

                objDB.DoUpdateUsingCmdObj(myCommand);

                int representativeId = Convert.ToInt32(myPar.Value);
                lblInfo.Text = "Congratulation! Your *" + selectReresentative.Text + "* accout has been created." + "<br>" +
                                        
                                        "Your Name: " + name + "<br>" +
                                        "ID: " + representativeId + "<br>" +
                                        "**(Remember your ID to login!)**";
                txtName.Text = "";
                return;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}