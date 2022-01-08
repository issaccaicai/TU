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

namespace APITest
{
    public partial class MerchantStoreDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecordPurchase_Click(object sender, EventArgs e)
        {
            //RegisterSite rpObject = new RegisterSite();

            //rpObject.SiteID = txtSiteId.Text.ToString();
            //rpObject.Description = txtDescription.ToString();
            //rpObject.APIKey = txtAPIkey.Text.ToString();
            //rpObject.Email = txtEmail.Text.ToString();
            //rpObject.ContactInformation = txtContactInformation.Text.ToString();
            //rpObject.APIKey = txtAPIkey.Text.ToString();
            //rpObject.Email = txtEmail.Text.ToString();
            //rpObject.ContactInformation = txtContactInformation.Text.ToString();




            //JavaScriptSerializer js = new JavaScriptSerializer();  //Coverts Object into JSON String
            //String jsRP = js.Serialize(rpObject);

            //try
            //{
            //    WebRequest request = WebRequest.Create("http://localhost:6762/api/service/Merchants/RecordPurchase/");
            //    request.Method = "POST";
            //    request.ContentLength = jsRP.Length;
            //    request.ContentType = "application/json";

            //    StreamWriter writer = new StreamWriter(request.GetRequestStream());
            //    writer.Write(jsRP);
            //    writer.Flush();
            //    writer.Close();

            //    WebResponse response = request.GetResponse();
            //    Stream theDataStream = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(theDataStream);
            //    String data = reader.ReadToEnd();
            //    reader.Close();
            //    response.Close();
            //    if (data == "true")
            //    {
            //        lblValidation.Text = "Successful";
            //        lblValidation.Visible = true;
            //    }
            //    else
            //    {

            //        lblValidation.Text = "A problem occurred while adding to the database. The data wasn't recorded.";
            //        lblValidation.Visible = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblValidation.Text = "Error: " + ex.Message;
            //    lblValidation.Visible = true;
            //}

        }
    }
}