using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using MyCreditCard;

namespace Project4
{
    public partial class transaction_record : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInva.Visible = false;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            String id = txtAcount.Text;
            int chkId;

            if (id == "")
            {
                lblInva.Text = "*Please enter correct account ID.";
                lblInva.Visible = true;
                return;
            }
            else if (!int.TryParse(id, out chkId))
            {
                lblInva.Text = "*Please enter correct account ID.";
                lblInva.Visible = true;
                return;
            }

            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/transaction/" + chkId);
            request.Headers.Add("apikey", "ELIE3173");
            request.Method = "GET";
            //////////////////////////////////////////////////////////
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<TransactionInfo> cardInfo = js.Deserialize<List<TransactionInfo>>(data);
            
            if (cardInfo.Count == 0) {
                lblInva.Text = "*No credit card records.";
                lblInva.Visible = true;
                gvAllTran.Visible = false;
                return;
            }
            gvAllTran.DataSource = cardInfo;
            gvAllTran.DataBind();
            gvAllTran.Visible = true;
        }
    }
}