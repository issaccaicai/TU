using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestLib;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Data;
namespace APITest
{
    public partial class APITest : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVal.Visible = false;
            lblValidation.Visible = false;


        }

        protected void btnDepartments_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/GetDepartments/");
            //WebRequest request = WebRequest.Create("http://localhost:6762/api/service/Merchants/GetDepartments/");
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            //InsertCreditCardClass CreditInfo = js.Deserialize<InsertCreditCardClass>(data);

            Department[] departmentInfo = js.Deserialize<Department[]>(data);
            gvDepartments.DataSource = departmentInfo;
            gvDepartments.DataBind();
            gvDepartments.Visible = true;
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/GetProductCatalog/" + txtFindDepartment.Text);
            //WebRequest request = WebRequest.Create("http://localhost:6762/api/service/Merchants/GetProductCatalog/" + txtFindDepartment.Text);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            //InsertCreditCardClass CreditInfo = js.Deserialize<InsertCreditCardClass>(data);

            Product[] departmentInfo = js.Deserialize<Product[]>(data);
            gvProducts.DataSource = departmentInfo;
            gvProducts.DataBind();
            gvProducts.Visible = true;

        }

        protected void btnRegisterSite_Click(object sender, EventArgs e)
        {
            RegisterSite rsObject = new RegisterSite();

            rsObject.SiteID = txtSiteId.Text.ToString();
            rsObject.Description = txtDescription.Text;
            rsObject.APIKey = txtAPIkey.Text.ToString();
            rsObject.Email = txtEmail.Text.ToString();
            rsObject.ContactInformation = txtContactInformation.Text.ToString();

            JavaScriptSerializer js = new JavaScriptSerializer();  //Coverts Object into JSON String
            String jsRS = js.Serialize(rsObject);

            try
            {


                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/RegisterSite/");
               // WebRequest request = WebRequest.Create("http://localhost:6762/api/service/Merchants/RegisterSite/");
                request.Method = "POST";
                request.ContentLength = jsRS.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsRS);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                if (data == "true")
                {
                    lblVal.Text = "Successful";
                    lblVal.Visible = true;

                }
                else
                {

                    lblVal.Text = "A problem occurred while adding to the database. The data wasn't recorded.";
                    lblVal.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblVal.Text = "Error: " + ex.Message;
                lblVal.Visible = true;
            }
            txtSiteId.Text = "";
            txtDescription.Text = "";
            txtAPIkey.Text = "";
            txtEmail.Text = "";
            txtContactInformation.Text = "";
        }

        protected void btnRecordPurchase_Click(object sender, EventArgs e)
        {
            RecordPurchase rpObject = new RecordPurchase();

            rpObject.ProductNumber = txtProductNumber.Text;
            rpObject.Quantity = Convert.ToInt32(txtQuantity.Text);
            rpObject.SiteID = txtSiteIDrp.Text;
            rpObject.APIKey = txtAPIKeyrp.Text;

            rpObject.CustomerId = txtCustomerId.Text;
            //rpObject.CustomerName = txtCustomerName.Text;
            //rpObject.CustomerEmail = txtCustomerEmail.Text;
            //rpObject.CustomerPhone = txtCustomerPhone.Text;
            

            JavaScriptSerializer js = new JavaScriptSerializer();  //Coverts Object into JSON String
            String jsRP = js.Serialize(rpObject);

            try
            {

                WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/TermProjectWS/api/service/Merchants/RecordPurchase/");
                // WebRequest request = WebRequest.Create("http://localhost:6762/api/service/Merchants/RecordPurchase/");
                request.Method = "POST";
                request.ContentLength = jsRP.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsRP);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                if (data == "true")
                {
                    lblValidation.Text = "Successful";
                    lblValidation.Visible = true;

                    
                }
                else
                {

                    lblValidation.Text = "A problem occurred while adding to the database. The data wasn't recorded.";
                    lblValidation.Visible = true;
                }



            }
            catch (Exception ex)
            {
                lblValidation.Text = "Error: " + ex.Message;
                lblValidation.Visible = true;
            }
            txtProductNumber.Text = "";
            txtQuantity.Text = "";
            txtSiteIDrp.Text = "";
            txtAPIKeyrp.Text = "";

            txtCustomerId.Text = "";
            //txtCustomerName.Text = "";
            //txtCustomerEmail.Text = "";
            //txtCustomerPhone.Text = "";

        }
    }
}