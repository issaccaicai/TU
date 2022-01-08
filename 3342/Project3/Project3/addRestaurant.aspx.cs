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
    public partial class addRestaurant : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["USER"].ToString();
            string id = Session["Id"].ToString();

            if (name == "Visitor")
            {

                lblUser.Text = "USER TYPE: " + name +
                    "<br/>";
            }
            else {

                lblUser.Text = "USER TYPE: " + name +
                    "<br/>" + "USER ID: " + id;
            }

            if (!IsPostBack)
            {
                Restaurant Re = new Restaurant();

                DataSet categoriesDataSet = Re.displayRestaurant();
                
                ddlRestaurant.DataValueField = "categoriesId";
                ddlRestaurant.DataTextField = "categoriesName";
                ddlRestaurant.DataSource = categoriesDataSet;
                ddlRestaurant.DataBind();


                Restaurant AllRep = new Restaurant();

                DataSet repDataSet = AllRep.displayAllRep();
                
                ddlAddRep.DataValueField = "representativeId";
                ddlAddRep.DataTextField = "representativeName";
                ddlAddRep.DataSource = repDataSet;
                ddlAddRep.DataBind();

            }
            lblAddInval.Visible = false;
            gvDisplayRestaurant.Visible = false;
        }

        protected void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            string restaurantName = txtName.Text;
            string restaurantDesc = txtDesc.Text;
            string url = txtUrl.Text;

            int id;
            id = int.Parse(ddlRestaurant.SelectedValue);

            if (restaurantName == "")
            {
                lblAddInval.Text = "**Please Enter a restaurant name.**";
                    lblAddInval.Visible = true;
                return;
            }
            else if (restaurantDesc == "")
            {
                lblAddInval.Text = "**Please Enter a restaurant Description.**";
                    lblAddInval.Visible = true;
                return;
            }


            

            
            

            SqlCommand addCommand = new SqlCommand("addRestaurant");
            addCommand.CommandType = CommandType.StoredProcedure;
            
            SqlParameter myPar = new SqlParameter("@categoriesId", SqlDbType.Int);
            myPar.Direction = ParameterDirection.ReturnValue;

            addCommand.Parameters.AddWithValue("@restaurantName", restaurantName);
            addCommand.Parameters.AddWithValue("@restaurantDesc", restaurantDesc);
            addCommand.Parameters.AddWithValue("@categoriesId", id);
            addCommand.Parameters.AddWithValue("@representativeId", ddlAddRep.SelectedItem.Value);
            addCommand.Parameters.AddWithValue("@url", url);



            addCommand.Parameters.Add(myPar);
            objDB.DoUpdateUsingCmdObj(addCommand);
            lblAddInval.Text = "**Restaurant Added**";
            lblAddInval.Visible = true;



         




            SqlCommand cmdRes = new SqlCommand("getRestaurantInfor");
            cmdRes.CommandType = CommandType.StoredProcedure;
            cmdRes.Parameters.AddWithValue("@categoriesId", id);
            DataSet courseDataSet = objDB.GetDataSetUsingCmdObj(cmdRes);
            gvDisplayRestaurant.DataSource = courseDataSet;
            gvDisplayRestaurant.DataBind();
            gvDisplayRestaurant.Visible = true;


            
           



        }

        protected void gvDisplayRestaurant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("search.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}