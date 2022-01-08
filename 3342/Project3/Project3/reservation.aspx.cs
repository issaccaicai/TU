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
    public partial class reservation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["USER"].ToString();
            string id = Session["Id"].ToString();

            if (name == "Visitor")
            {

                lblVal.Text = "USER TYPE: " + name +
                    "<br/>";
            }
            else
            {

                lblVal.Text = "USER TYPE: " + name +
                    "<br/>" + "USER ID: " + id;
            }



            lblVal.Visible = false;
            if (!IsPostBack)
            {
                lblVal.Text = "All the reservations are located below";
                SqlCommand cmdCourse = new SqlCommand("getAllReservations");
                cmdCourse.CommandType = CommandType.StoredProcedure;

                DataSet courseDataSet = objDB.GetDataSetUsingCmdObj(cmdCourse);
                gvDisplayReservation.DataSource = courseDataSet;
                gvDisplayReservation.DataBind();
                gvDisplayReservation.Visible = true;
            }
            modifyPanel.Visible = false;
        }
        public void Show()
        {
            lblVal.Text = "All the reservations are located below";
            SqlCommand cmdCourse = new SqlCommand("getAllReservations");
            cmdCourse.CommandType = CommandType.StoredProcedure;

            DataSet courseDataSet = objDB.GetDataSetUsingCmdObj(cmdCourse);
            gvDisplayReservation.DataSource = courseDataSet;
            gvDisplayReservation.DataBind();
        }

        protected void btnModifyReservation_Click(object sender, EventArgs e)
        {
            lblVal.Text = "";
            modifyPanel.Visible = true;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string date = (txtDate.Text).ToString();
            string time = Request["ddlTime"];
            string size = txtSize.Text;

            if (name == "")
            {
                lblVal.Text = "*Please Enter a name.";
                lblVal.Visible = true;
                return;
            }
            if (date == "")
            {
                lblVal.Text = "*Please Enter a date.";
                lblVal.Visible = true;
                return;
            }
            if (time == "")
            {
                lblVal.Text = "*Please Enter a time.";
                lblVal.Visible = true;
                return;
            }
            if (size == "")
            {
                lblVal.Text = "*Please Enter a size.";
                lblVal.Visible = true;
                return;
            }


            int rowCount = 0;
            for (int row = 0; row < gvDisplayReservation.Rows.Count; row++)
            {
                CheckBox reviewChk = (CheckBox)gvDisplayReservation.Rows[row].FindControl("ChkSelect");

                if (reviewChk.Checked)
                {
                    lblVal.Visible = false;
                    int restaurantID = Convert.ToInt32(gvDisplayReservation.Rows[row].Cells[2].Text);
                    int reprID = Convert.ToInt32(gvDisplayReservation.Rows[row].Cells[8].Text);
                    rowCount = rowCount + 1;
                    if (reprID != Convert.ToInt32(Session["Id"].ToString()))
                    {
                        Response.Write("Fail to modify!");
                        lblVal.Text = "Failed, You must edit your own review!";
                        modifyPanel.Visible = true;
                        return;
                    }
                    
                    if (rowCount == 1)
                    {
                        SqlCommand modCommand = new SqlCommand("modifyReservation");
                        modCommand.CommandType = CommandType.StoredProcedure;
                        modCommand.Parameters.AddWithValue("@reservationName", name);
                        modCommand.Parameters.AddWithValue("@reservationTime", time);
                        modCommand.Parameters.AddWithValue("@reservationSize", Convert.ToInt32(size));
                        modCommand.Parameters.AddWithValue("@reservationDate", date);
                        modCommand.Parameters.AddWithValue("@representativeId", reprID);
                        modCommand.Parameters.AddWithValue("@restaurantId", restaurantID);
                        objDB.DoUpdateUsingCmdObj(modCommand);
                        Response.Write("Modified!");
                        lblVal.Text = "Modify successful!";
                        gvDisplayReservation.Visible = true;
                        modifyPanel.Visible = true;
                        Show();
                    }

                    else
                    {
                        lblVal.Text = "Please select only one reocrd to edit!";
                        return;
                    }
                }


            }


            
        }

        protected void btnDeleteReservation_Click(object sender, EventArgs e)
        {

            lblVal.Text = "";


            for (int row = 0; row < gvDisplayReservation.Rows.Count; row++)
            {
                CheckBox reviewChk = (CheckBox)gvDisplayReservation.Rows[row].FindControl("ChkSelect");
                int rowCount = 0;
                if (reviewChk.Checked)
                {
                    lblVal.Visible = false;
                    int reprID = Convert.ToInt32(gvDisplayReservation.Rows[row].Cells[8].Text);

                    rowCount = rowCount + 1;
                    if (reprID != Convert.ToInt32(Session["Id"].ToString()))
                    {
                        Response.Write("Fail to modify!");
                        lblVal.Text = "Failed, You must delete your own review!";
                        return;
                    }

                    if (rowCount == 1)
                    {
                        int reservID = Convert.ToInt32(gvDisplayReservation.Rows[row].Cells[1].Text);
                        SqlCommand modCommand = new SqlCommand("deleteReservation");
                        modCommand.CommandType = CommandType.StoredProcedure;
                        modCommand.Parameters.AddWithValue("@reservationId", reservID);

                        objDB.DoUpdateUsingCmdObj(modCommand);
                        Response.Write("DELETE!");
                        lblVal.Text = "DELETE successful!";
                        gvDisplayReservation.Visible = true;
                        Show();

                    }
                    else
                    {
                        lblVal.Text = "Please select only one reocrd to edit!";
                        return;
                    }
                }


            }






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