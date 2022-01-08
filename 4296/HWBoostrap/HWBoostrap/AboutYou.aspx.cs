using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HWBoostrap
{
    public partial class AboutYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblValidation.Visible = false;
        }
        protected void ValidateDate(object source, ServerValidateEventArgs args)
        {
            if (DateTime.TryParse(txtBirthday.Text, out DateTime dt))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtZip.Text = "";
                txtComments.Text = "";
                txtEmail.Text = "";
                txtPhoneNumber.Text = "";
                txtBirthday.Text = "";
                
            }
            lblValidation.Text = "Successful";
            lblValidation.Visible = true;
        }
    }
}