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
    public partial class search : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["USER"].ToString();

            btnReview.Visible = false;
            if (name == "Visitor")
            {

                lblTest.Text = "USER TYPE: " + name +
                    "<br/>";
                btnReview.Visible = false;
                btnManageReservation.Visible = false;
                btnAddRes.Visible = false;
            }
            else
            {
                string id = Session["Id"].ToString();

                lblTest.Text = "USER TYPE: " + name +
                    "<br/>" + "USER ID: " + id;
                if (name == "Reviewer")
                {
                    btnManageReservation.Visible = false;
                }
                if (name == "Representative")
                {
                    btnReview.Visible = false;
                }

            }

            if (!IsPostBack)
            {
                Search s = new Search();

                DataSet categoriesDataSet = s.displaySearch();
                lbSelect.DataValueField = "categoriesId";
                lbSelect.DataTextField = "categoriesName";
                lbSelect.DataSource = categoriesDataSet;
                lbSelect.DataBind();
            }

            

        }
        
        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //int id;
            //id = int.Parse(lbSelect.SelectedValue);

            //SqlCommand cmdDisplay = new SqlCommand("selectRestaurant");
            //cmdDisplay.CommandType = CommandType.StoredProcedure;

            //SqlParameter inputParameter = new SqlParameter("@CategoriesID", id);
            //inputParameter.Direction = ParameterDirection.Input;
            //inputParameter.SqlDbType = SqlDbType.Int;
            //cmdDisplay.Parameters.Add(inputParameter);
            //gvDisplayRes.DataSource = objDB.GetDataSetUsingCmdObj(cmdDisplay);
            //gvDisplayRes.DataBind();
            
        }
        public void showCategories(int selectedId)
        {
            //int categories= Convert.ToInt32(ddlCategories.SelectedValue);

            //SqlCommand cmdCategories = new SqlCommand("selectRestaurant");
            //cmdCategories.CommandType = CommandType.StoredProcedure;
            //cmdCategories.Parameters.AddWithValue("@CategoriesID", cmdCategories );
           // DataSet categoriesDataSet = objDB.GetDataSetUsingCmdObj(cmdCategories);

            //ddlCategories.DataValueField = "categoriesId";
            //ddlCategories.DataTextField = "categoresName";
            //ddlCategories.DataSource = categoriesDataSet;
            //ddlCategories.DataBind();
            //int departmentID = Convert.ToInt32(ddlCategories.SelectedValue);
            //.DataSource = courseDataSet;
            // .DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddReservation_Click(object sender, EventArgs e)
        {
            string Date = (txtDate.Text).ToString();
            string size = txtSize.Text;
            string time = Request["ddlTime"];
            string name = txtName.Text;

            for (int row = 0; row < gvDisplayRes.Rows.Count; row++)
            {
                CheckBox reviewChk = (CheckBox)gvDisplayRes.Rows[row].FindControl("ChkSelect");
                int rowCount = 0;
                if (reviewChk.Checked)
                {
                    lblVali.Visible = false;
                    int representativeId = Convert.ToInt32(gvDisplayRes.Rows[row].Cells[6].Text);
                    int restaurantId = Convert.ToInt32(gvDisplayRes.Rows[row].Cells[1].Text);
                    rowCount = rowCount + 1;

                    if (rowCount == 1)
                    {
                        SqlCommand modCommand = new SqlCommand("makeReservation");
                        modCommand.CommandType = CommandType.StoredProcedure;
                        modCommand.Parameters.AddWithValue("@reservationName", name);
                        modCommand.Parameters.AddWithValue("@reservationTime", time);
                        modCommand.Parameters.AddWithValue("@reservationSize", Convert.ToInt32(size));
                        modCommand.Parameters.AddWithValue("@reservationDate", Date);
                        modCommand.Parameters.AddWithValue("@restaurantId", restaurantId);
                        modCommand.Parameters.AddWithValue("@representativeId", representativeId);

                        objDB.DoUpdateUsingCmdObj(modCommand);
                        Response.Write("succeed!");
                        lblVali.Text = "Reservation made!";
                        gvDisplayRes.Visible = true;

                    }
                    else
                    {
                        lblVali.Text = "Please select only one restaurant to make reservation!";
                        lblVali.Visible = true;
                        return;
                    }
                }


            }

        }

        protected void lbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DS = new DataSet();

            foreach (ListItem listitem in lbSelect.Items)
            {
               if (listitem.Selected)
                {
                    string name = listitem.Text;
                    txtName.Text = name;

                    SqlCommand cmdDisplay = new SqlCommand("selectAllRestaurant");
                    cmdDisplay.CommandType = CommandType.StoredProcedure;

                    SqlParameter inputParameter = new SqlParameter("@categoriesName", name);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    cmdDisplay.Parameters.Add(inputParameter);
                    var DS2 = objDB.GetDataSetUsingCmdObj(cmdDisplay);

                    DS.Merge(DS2);

                    gvDisplayRes.DataSource = DS;
                    gvDisplayRes.DataBind();
                } 
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnAddRes_Click(object sender, EventArgs e)
        {
            Response.Redirect("addRestaurant.aspx");
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("addReviews.aspx");
        }

        protected void btnManageReservation_Click(object sender, EventArgs e)
        {

        }
    }
}