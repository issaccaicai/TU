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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            String id = txtAcount.Text;
            int chkId;

            string cardNumber = txtCardNumber.Text;
            string name = txtName.Text;
            string street = txtST.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string zipCode = txtZipCode.Text;
            string expMon = txtExpMonth.Text;
            string expYear = txtExpYear.Text;
            string cvv = txtCvv.Text;
            string amount = txtAmount.Text;
            long card_Number;
            int zip_Code;
            int month;
            int year;
            int newCvv;
            decimal ChkAmount;

            ///check card number
            if (id == "")
            {
                lblInva.Text = "*Please enter correct account ID.";
                lblInva.Visible = true;
                return;
            }
            if (!int.TryParse(id, out chkId))
            {
                lblInva.Text = "*Please enter correct account ID.";
                lblInva.Visible = true;
                return;
            }
            ////////////////////////////////////
            ///
            string errorSSg = "";
            if (amount == "")
            {
                lblInva.Text = "*Please enter amount you want to charge.";
                lblInva.Visible = true;
                return;
            }
            if (!decimal.TryParse(amount, out ChkAmount))
            {
                lblInva.Text = "Please enter amount you want to charge.";
                lblInva.Visible = true;
                return;
            }
            if (ChkAmount > 700)
            {
                errorSSg = "Card Declined";
            }
            else
            {
                errorSSg = "Succeeded";
            }

           
            if (int.TryParse(id, out chkId))
            {
                WebRequest newRequest = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/" + chkId);
                newRequest.Headers.Add("apikey", "ELIE3173");
                newRequest.Method = "GET";
                //////////////////////////////////////////////////////////
                WebResponse newResponse = newRequest.GetResponse();
                Stream newDataStream = newResponse.GetResponseStream();
                StreamReader newReader = new StreamReader(newDataStream);
                String myData = newReader.ReadToEnd();
                newReader.Close();
                newResponse.Close();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                CreditCardInfo cardInfo = jss.Deserialize<CreditCardInfo>(myData);

               
                if (cardInfo == null)
                {
                    lblInva.Text = "*No record.";
                    lblInva.Visible = true;
                    return;
                }
                if (cardInfo.Val == false) {
                    errorSSg = "Card Declined";
                }
            }

            if (cardNumber == "")
            {
                lblInva.Text = "*Please Enter credit card number.";
                lblInva.Visible = true;
                return;
            }
            if (!long.TryParse(cardNumber, out card_Number))
            {
                lblInva.Text = "*Please Enter your 16 digital credit card number.";
                lblInva.Visible = true;
                return;
            }
            if (cardNumber.Length != 16)
            {
                lblInva.Text = "*Please Enter 16 digital credit card number.";
                lblInva.Visible = true;
                return;
            }
            //check name
            if (name == "")
            {
                lblInva.Text = "*Please Enter a new credit card holder name.";
                lblInva.Visible = true;
                return;
            }
            if (street == "")
            {
                lblInva.Text = "*Please Enter street name.";
                lblInva.Visible = true;
                return;
            }
            if (city == "")
            {
                lblInva.Text = "*Please Enter city name.";
                lblInva.Visible = true;
                return;
            }

            if (state == "")
            {
                lblInva.Text = "*Please Enter state name.";
                lblInva.Visible = true;
                return;
            }
            //check zipCode
            if (zipCode == "")
            {
                lblInva.Text = "*Please Enter 5 digital zip code.";
                lblInva.Visible = true;
                return;
            }
            if (!int.TryParse(zipCode, out zip_Code))
            {
                lblInva.Text = "*Please Enter 5 digital zip code.";
                lblInva.Visible = true;
                return;
            }
            if (zipCode.Length != 5)
            {
                lblInva.Text = "*Please Enter 5 digital zip code.";
                lblInva.Visible = true;
                return;
            }
            //check expDate
            if (expMon == "")
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            if (!int.TryParse(expMon, out month))
            {
                lblInva.Text = "*Please Enter Enterexparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            if (expMon.Length != 2 || month > 12)
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            if (expYear == "")
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            if (!int.TryParse(expYear, out year))
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            if (expYear.Length != 4)
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            //check cvv
            if (cvv == "")
            {
                lblInva.Text = "*Please Enter 3 digital CVV number.";
                lblInva.Visible = true;
                return;
            }
            if (!int.TryParse(cvv, out newCvv))
            {
                lblInva.Text = "*Please Enter 3 digital CVV number.";
                lblInva.Visible = true;
                return;
            }
            if (cvv.Length != 3)
            {
                lblInva.Text = "*Please Enter 3 digital CVV number.";
                lblInva.Visible = true;
                return;
            }

            lblInva.Text = "OK";
            lblInva.Visible = true;

            DateTime newDate = DateTime.Parse(expMon + "/1/" + expYear);

            PaymentInfo card = new PaymentInfo(chkId, DateTime.Now, ChkAmount, errorSSg);
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonCard = js.Serialize(card);

            /////////////////////////////////////////////////////////////////////
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/Payment/");
            request.Headers.Add("apikey", "ELIE3173");

            request.Method = "POST";
            request.ContentLength = jsonCard.Length;
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonCard);
            writer.Flush();
            writer.Close();

            ///////////////////////////////////////////////////////////////
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            TransactionInfo tranInfo = js.Deserialize<TransactionInfo>(data);

            TransactionInfo[] myTranArr = new TransactionInfo[1];
            myTranArr[0] = tranInfo;
            gvTran.DataSource = myTranArr;
            gvTran.DataBind();

            txtCardNumber.Text = "";
            txtName.Text = "";
            txtST.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtExpMonth.Text = "";
            txtExpYear.Text = "";
            txtCvv.Text = "";
            txtAmount.Text = "";
        }
    }
}