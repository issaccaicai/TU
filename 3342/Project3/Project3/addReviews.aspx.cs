using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using restaurantLibrary;

namespace Project3
{
    public partial class addReviews : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["USER"].ToString();
            string id = Session["Id"].ToString();

            if (name == "Visitor")
            {

                lblTest.Text = "USER TYPE: " + name +
                    "<br/>";
            }
            else
            {

                lblTest.Text = "USER TYPE: " + name +
                    "<br/>" + "USER ID: " + id;
            }
            if (!IsPostBack)
            {

                //lblVal.Visible = false;
                lblInfo.Visible = true;
                gvReview.Visible = false;

                myPanel.Visible = false;


                int UserID = Convert.ToInt32(id);

                lblInfo.Text = "All your reviews are located below";
                SqlCommand cmdCourse = new SqlCommand("getReviews");
                cmdCourse.CommandType = CommandType.StoredProcedure;
                //cmdCourse.Parameters.AddWithValue("@reviewerId", UserID);

                DataSet courseDataSet = objDB.GetDataSetUsingCmdObj(cmdCourse);
                gvReview.DataSource = courseDataSet;
                gvReview.DataBind();
                gvReview.Visible = true;




                displayResName s = new displayResName();

                DataSet categoriesDataSet = s.dplResName();
                
                ddlAddName.DataValueField = "restaurantId";
                ddlAddName.DataTextField = "restaurantName";
                ddlAddName.DataSource = categoriesDataSet;
                ddlAddName.DataBind();
            }

            myPanel.Visible = false;
            modifyPanel.Visible = false;
        }
        public void Show()
        {
            lblInfo.Text = "All your reviews are located below";
            SqlCommand cmdCourse = new SqlCommand("getReviews");
            cmdCourse.CommandType = CommandType.StoredProcedure;
            //cmdCourse.Parameters.AddWithValue("@reviewerId", UserID);

            DataSet courseDataSet = objDB.GetDataSetUsingCmdObj(cmdCourse);
            gvReview.DataSource = courseDataSet;
            gvReview.DataBind();
            gvReview.Visible = true;
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {

            myPanel.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string addName = ddlAddName.Text;
            //string description = txtDesc.Text;
            string quality = txtQuality.Text;
            string service = txtService.Text;
            string atmosphere = txtAtmosphere.Text;
            string price = txtPrice.Text;
            string comm = txtComm.Text;

            
            //if (txtDesc.Text == "")
            //{
            //    lblV.Text = "Please enter a restaurant description";
            //}
            if (txtQuality.Text == "")
            {
                lblV.Text = "Please enter a quality number.";
            }
            if (txtService.Text == "")
            {
                lblV.Text = "Please enter a service number.";
            }
            if (txtAtmosphere.Text == "")
            {
                lblV.Text = "Please enter a atmosphere number.";
            }
            if (txtPrice.Text == "")
            {
                lblV.Text = "Please enter a price number";
            }
            if (comm == "")
            {
                lblV.Text = "Please enter a comment";
            }

            int restaurantId = Convert.ToInt32(addName);
            string id = Session["Id"].ToString();
            int reviewerID = Convert.ToInt32(id);

            SqlCommand addReviewCmd = new SqlCommand("addReviews");
            addReviewCmd.CommandType = CommandType.StoredProcedure;

            addReviewCmd.Parameters.AddWithValue("@reviewerId", reviewerID);
            addReviewCmd.Parameters.AddWithValue("@restaurantId", restaurantId);
            addReviewCmd.Parameters.AddWithValue("@quality", Convert.ToInt32(quality));
            addReviewCmd.Parameters.AddWithValue("@service", Convert.ToInt32(service));
            addReviewCmd.Parameters.AddWithValue("@atmosphere", Convert.ToInt32(atmosphere));
            addReviewCmd.Parameters.AddWithValue("@price", Convert.ToInt32(price));
            addReviewCmd.Parameters.AddWithValue("@comments", comm);
            objDB.DoUpdateUsingCmdObj(addReviewCmd);

            Show();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("addReviews.aspx");
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {



            modifyPanel.Visible = true;
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblVa.Text = "";


            for (int row = 0; row < gvReview.Rows.Count; row++)
            {
                CheckBox reviewChk = (CheckBox)gvReview.Rows[row].FindControl("ChkSelect");
                int rowCount = 0;
                if (reviewChk.Checked)
                {
                    lblV.Visible = false;
                    int reviewerID = Convert.ToInt32(gvReview.Rows[row].Cells[1].Text);
                    rowCount = rowCount + 1;
                    if (reviewerID != Convert.ToInt32(Session["Id"].ToString()))
                    {
                        Response.Write("Fail to modify!");
                        lblVa.Text = "Failed, You must delete your own review!";
                        return;
                    }

                    if (rowCount == 1)
                    {
                        int reviewID = Convert.ToInt32(gvReview.Rows[row].Cells[2].Text);
                        SqlCommand modCommand = new SqlCommand("deleteReview");
                        modCommand.CommandType = CommandType.StoredProcedure;
                        modCommand.Parameters.AddWithValue("@reviewId", reviewID);

                        objDB.DoUpdateUsingCmdObj(modCommand);
                        Response.Write("DELETE!");
                        lblVa.Text = "DELETE successful!";
                        gvReview.Visible = true;
                        Show();

                    }
                    else
                    {
                        lblVa.Text = "Please select only one reocrd to edit!";
                        return;
                    }
                }


            }






        }

        protected void ddlAddName_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPanel.Visible = true;
            lblValid.Visible = false;
        }

        protected void btnAddR_Click(object sender, EventArgs e)
        {
            Response.Redirect("addRestaurant.aspx");
        }

        protected void btnMod_Click(object sender, EventArgs e)
        {
            ArrayList arrP = new ArrayList();
            
            string quality = txtQual.Text;
            string service = txtServ.Text;
            string atmosphere = txtAtmo.Text;
            string price = txtPri.Text;
            string comments = txtComments.Text;



            int rowCount = 0;
            for (int row = 0; row < gvReview.Rows.Count; row++)
            {
                CheckBox reviewChk = (CheckBox)gvReview.Rows[row].FindControl("ChkSelect");

                if (reviewChk.Checked)
                {
                    rowCount = rowCount + 1;
                    lblValid.Visible = false;
                    int reviewerID = Convert.ToInt32(gvReview.Rows[row].Cells[1].Text);
                    int reviewID = Convert.ToInt32(gvReview.Rows[row].Cells[2].Text);
                    if (reviewerID != Convert.ToInt32(Session["Id"].ToString()))
                    {
                        Response.Write("Fail to modify!");
                        lblValid.Text = "Failed, You must edit your own review!";
                        lblValid.Visible = true;
                        modifyPanel.Visible = true;
                        return;
                    }
                    arrP.Add(reviewID);
                    

                }

            }
            foreach (int ID in arrP)
            {
                if (rowCount == 1)
                {
                    SqlCommand modCommand = new SqlCommand("modifyReview");
                    modCommand.CommandType = CommandType.StoredProcedure;
                    modCommand.Parameters.AddWithValue("@reviewId", ID);
                    modCommand.Parameters.AddWithValue("@quality", Convert.ToInt32(quality));
                    modCommand.Parameters.AddWithValue("@service", Convert.ToInt32(service));
                    modCommand.Parameters.AddWithValue("@atmosphere", Convert.ToInt32(atmosphere));
                    modCommand.Parameters.AddWithValue("@price", Convert.ToInt32(price));
                    modCommand.Parameters.AddWithValue("@comments", comments);

                    objDB.DoUpdateUsingCmdObj(modCommand);
                    Response.Write("Modified!");
                    lblValid.Text = "Modify successful!";
                    lblValid.Visible = true;
                    gvReview.Visible = true;
                    modifyPanel.Visible = true;
                    Show();
                }


            }
             if (rowCount != 1)
            {
                lblValid.Text = "Please select only one reocrd to edit!";
                lblValid.Visible = true;
                modifyPanel.Visible = true;
                return;
            }
            modifyPanel.Visible = true;
        }

        protected void btnCanc_Click(object sender, EventArgs e)
        {
            Response.Redirect("addReviews.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("search.aspx");
        }

        protected void AddRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect("addRestaurant.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}