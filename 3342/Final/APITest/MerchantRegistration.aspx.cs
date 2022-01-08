using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TestLib;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace APITest
{
    public partial class MerchantRegistration : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {


            if (txtSellerSite.Text == "" && txtUrl.Text == "" && txtEmail.Text == "" && txtPassword.Text == "" && txtPhone.Text == "" && txtAddress.Text == "" &&
                    txtCity.Text == "" && ddlState.SelectedValue == "" && txtZipCode.Text == "" && txtQ1.Text == "" && txtQ2.Text == "" && txtQ3.Text == "" && ddlQ1.SelectedValue == "" &&
                    ddlQ2.SelectedValue == "" && ddlQ3.SelectedValue == "")
            {
                lblVal.Text = "Please fill out all infomration";
            }
            else
            {
                try
                {
                    url = url + "Register/Merchant/";
                    Merchant merchant = new Merchant();

                    merchant.sellerSite = txtSellerSite.Text;
                    merchant.url = txtUrl.Text;
                    merchant.email = txtEmail.Text;
                    merchant.password = txtPassword.Text;
                    merchant.phone = txtPhone.Text;
                    merchant.description = txtDescription.Text;
                    merchant.address = txtAddress.Text;
                    merchant.city = txtCity.Text;
                    merchant.state = ddlState.SelectedValue;
                    merchant.zip = txtZipCode.Text;
                    merchant.q1 = txtQ1.Text;
                    merchant.q2 = txtQ2.Text;
                    merchant.q3 = txtQ3.Text;
                    merchant.ques1 = ddlQ1.SelectedValue;
                    merchant.ques2 = ddlQ2.SelectedValue;
                    merchant.ques3 = ddlQ3.SelectedValue;

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonMerchant = js.Serialize(merchant);

                    WebRequest request = WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentLength = jsonMerchant.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonMerchant);
                    writer.Flush();
                    writer.Close();

                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(theDataStream);
                    String data = streamReader.ReadToEnd();
                    streamReader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        lblVal.Visible = true;
                        lblVal.Text = "Successfully registered a merchant!";

                    }
                    else
                    {
                        lblVal.Visible = true;
                        lblVal.Text = "An error occurred! The username is already exists!";

                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}