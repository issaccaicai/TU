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
    public partial class login : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

            lblId.Visible = false;
            txtId.Visible = false;
            btnSubmitId.Visible = false;
            btnBack.Visible = false;
            lblVal.Visible = false;
            //lblDes.Visible = false;
            lblTest.Visible = false;

            btnMyReviews.Visible = false;
            AddRestaurant.Visible = false;

            gvReview.Visible = false;
            gvRP.Visible = false;
            btnLogin.Visible = false;


            btnSearch.Visible = false;
            btnReservation.Visible = false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("newAccount.aspx");
        }

        protected void btnReviewer_Click(object sender, EventArgs e)
        {
            btnReviewer.Visible = false;
            btnRepresentative.Visible = false;
            btnCreate.Visible = false;
            btnVisitor.Visible = false;
            lblId.Visible = true;
            txtId.Visible = true;
            btnSubmitId.Visible = true;
            btnBack.Visible = true;
            lblVal.Visible = false;
            btnLogin.Visible = true;

            Session["USER"] = "Reviewer";

        }

        protected void btnRepresentative_Click(object sender, EventArgs e)
        {
            btnRepresentative.Visible = false;
            btnReviewer.Visible = false;
            btnCreate.Visible = false;
            btnVisitor.Visible = false;
            lblId.Visible = true;
            txtId.Visible = true;
            btnSubmitId.Visible = true;
            btnBack.Visible = true;
            lblVal.Visible = false;

            Session["USER"] = "Representative";

        }

        protected void btnVisitor_Click(object sender, EventArgs e)
        {
            Session["USER"] = "Visitor";
            Response.Redirect("search.aspx");
            btnSearch.Visible = true;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

            
        }

        protected void btnSubmitId_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                lblVal.Text = "**Please enter your ID.**";
                lblVal.Visible = true;

                lblId.Visible = true;
                txtId.Visible = true;
                btnSubmitId.Visible = true;
                btnBack.Visible = true;
                return;
            }
            //int idCheck = Convert.ToInt32(txtId.Text);
            //SqlCommand studentCmd = new SqlCommand("getAccountId");
            //studentCmd.CommandType = CommandType.StoredProcedure;
            //studentCmd.Parameters.AddWithValue("@id", idCheck);
            //DataSet studentDS = objDB.GetDataSetUsingCmdObj(studentCmd);

            //if (studentDS.Tables[0].Rows.Count == 0)
            //{
                //lblId.Visible = true;
                //txtId.Visible = true;
                //btnSubmitId.Visible = true;
               // btnBack.Visible = true;

                //lblVal.Text = "**No such record found.**";
               // return;
            //}
            else
            {
                //SqlCommand accountInfo = new SqlCommand("getAccountName");
                //accountInfo.CommandType = CommandType.StoredProcedure;
                // accountInfo.Parameters.AddWithValue("@id", idCheck);
                //DataSet studentInfoDS = objDB.GetDataSetUsingCmdObj(accountInfo);

                // string firstN = objDB.GetField("FirstName", 0).ToString();
                string User = Session["USER"].ToString();
                Session["Id"] = txtId.Text;

                

                lblVal.Visible = false;
                //lblDes.Text = "Welcome back " + firstN + ".";

                // lblDes.Text = "Welcome back! " + User + ". Your Reviewer ID: "+ Session["Id"].ToString();
                //lblDes.Visible = true;
                lblId.Visible = false;
                txtId.Visible = false;
                btnSubmitId.Visible = false;
                btnBack.Visible = false;
                lblVal.Visible = false;

                btnMyReviews.Visible = true;
                AddRestaurant.Visible = true;
                btnSearch.Visible = true;


                int RID = 0;
                for (int row = 0; row < gvReview.Rows.Count; row++)
                {
                    RID = Convert.ToInt32(gvReview.Rows[row].Cells[1].Text);

                }

                SqlCommand Info = new SqlCommand("getAllReviewer");
                Info.CommandType = CommandType.StoredProcedure;
                DataSet studentInfoDS = objDB.GetDataSetUsingCmdObj(Info);
                gvReview.DataSource = studentInfoDS;
                gvReview.DataBind();

                if (RID == Convert.ToInt32(Session["Id"]))
                {
                    if (User == "Reviewer")
                    {
                        lblTest.Text = "Welcome back! <br/>" + "USER TYPE: | " + User + "<br/> Your ID: " + Session["Id"];
                        btnReservation.Visible = false;
                        btnMyReviews.Visible = true;
                        lblTest.Visible = true;
                    }

                }

                else
                {
                    lblTest.Text = "No USER RECORD FOUND! PLEASE RE-Login";
                    lblTest.Visible = true;
                }


                int RPID = 0;
                for (int row = 0; row < gvReview.Rows.Count; row++)
                {
                    RID = Convert.ToInt32(gvReview.Rows[row].Cells[1].Text);

                }

                SqlCommand Info1 = new SqlCommand("getAllRep");
                Info1.CommandType = CommandType.StoredProcedure;
                DataSet studentInfoDS1 = objDB.GetDataSetUsingCmdObj(Info1);
                gvRP.DataSource = studentInfoDS1;
                gvRP.DataBind();

                if (RPID == Convert.ToInt32(Session["Id"]))
                {
                    if (User == "Representative")
                    {
                        lblTest.Text = "Welcome back! <br/>" + "USER TYPE:  | " + User + "<br/> Your ID: " + Session["Id"];
                        btnReservation.Visible = true;
                        btnMyReviews.Visible = false;
                        lblTest.Visible = true;
                    }
                }
                else
                {
                    lblTest.Text = "NO USER RECORD FOUND!";
                    lblTest.Visible = true;

                    lblId.Visible = false;
                    txtId.Visible = false;
                    btnSubmitId.Visible = false;
                    btnBack.Visible = false;
                    lblVal.Visible = false;
                    //lblDes.Visible = false;

                    btnMyReviews.Visible = false;
                    AddRestaurant.Visible = false;

                    gvReview.Visible = false;
                    gvRP.Visible = false;
                    btnLogin.Visible = true;
                    btnSearch.Visible = false;
                }
               
                
                

            }

        }

        protected void AddRestaurant_Click(object sender, EventArgs e)
        {
            Session["Id"] = txtId.Text;
            Response.Redirect("addRestaurant.aspx");
        }

        protected void btnMyReviews_Click(object sender, EventArgs e)
        {
            Session["Id"] = txtId.Text;
            Response.Redirect("addReviews.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Id"] = txtId.Text;
            Response.Redirect("search.aspx");
        }

        protected void btnReservation_Click(object sender, EventArgs e)
        {
            Session["Id"] = txtId.Text;
            Response.Redirect("reservation.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}