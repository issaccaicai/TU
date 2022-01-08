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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInva.Visible = false;
            lblInva.Text = "";
            btnCreateNewCard.Visible = true;
            btnShow.Visible = true;
            btnUpdate.Visible = false;
            btnCanncel.Visible = false;
            
        }

        protected void btnCreateNewCard_Click(object sender, EventArgs e)
        {
            Mymethod(0, "POST", true);
        }

        public void Mymethod(int accountId, string method, bool val)
        {
            string cardNumber = txtCardNumber.Text;
            string name = txtName.Text;
            string street = txtST.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string zipCode = txtZipCode.Text;
            string expMon = txtExpMonth.Text;
            string expYear = txtExpYear.Text;
            string cvv = txtCvv.Text;
            long card_Number;
            int zip_Code;
            int month;
            int year;
            int newCvv;

            ///check card number
            if (cardNumber == "")
            {
                lblInva.Text = "*Please Enter credit card number.";
                lblInva.Visible = true;
                return;
            }
            else if (!long.TryParse(cardNumber, out card_Number))
            {
                lblInva.Text = "*Please Enter your 16 digital credit card number.";
                lblInva.Visible = true;
                return;
            }
            else if (cardNumber.Length != 16)
            {
                lblInva.Text = "*Please Enter 16 digital credit card number.";
                lblInva.Visible = true;
                return;
            }
            //check name
            else if (name == "")
            {
                lblInva.Text = "*Please Enter a new credit card holder name.";
                lblInva.Visible = true;
                return;
            }
            else if (street == "")
            {
                lblInva.Text = "*Please Enter street name.";
                lblInva.Visible = true;
                return;
            }
            else if (city == "")
            {
                lblInva.Text = "*Please Enter city name.";
                lblInva.Visible = true;
                return;
            }

            else if (state == "")
            {
                lblInva.Text = "*Please Enter state name.";
                lblInva.Visible = true;
                return;
            }
            //check zipCode
            else if (zipCode == "")
            {
                lblInva.Text = "*Please Enter 5 digital zip code.";
                lblInva.Visible = true;
                return;
            }
            else if (!int.TryParse(zipCode, out zip_Code))
            {
                lblInva.Text = "*Please Enter 5 digital zip code.";
                lblInva.Visible = true;
                return;
            }
            else if (zipCode.Length != 5)
            {
                lblInva.Text = "*Please Enter 5 digital zip code.";
                lblInva.Visible = true;
                return;
            }
            //check expDate
            else if (expMon == "")
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            else if (!int.TryParse(expMon, out month))
            {
                lblInva.Text = "*Please Enter Enterexparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            else if (expMon.Length != 2 || month > 12)
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            else if (expYear == "")
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            else if (!int.TryParse(expYear, out year))
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            else if (expYear.Length != 4)
            {
                lblInva.Text = "*Please Enter exparation date of your credit card.";
                lblInva.Visible = true;
                return;
            }
            //check cvv
            else if (cvv == "")
            {
                lblInva.Text = "*Please Enter 3 digital CVV number.";
                lblInva.Visible = true;
                return;
            }
            else if (!int.TryParse(cvv, out newCvv))
            {
                lblInva.Text = "*Please Enter 3 digital CVV number.";
                lblInva.Visible = true;
                return;
            }
            else if (cvv.Length != 3)
            {
                lblInva.Text = "*Please Enter 3 digital CVV number.";
                lblInva.Visible = true;
                return;
            }
            else
            {
                lblInva.Text = "OK";
                lblInva.Visible = true;

                DateTime newDate = DateTime.Parse(expMon + "/1/" + expYear);
               
                CreditCardInfo card = new CreditCardInfo(accountId, cardNumber, name, street, city, state, zipCode, newDate, cvv);
                card.Val = val;
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonCard = js.Serialize(card);

                /////////////////////////////////////////////////////////////////////
                string myUrl = "http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/";
                if (accountId != 0) {
                    myUrl += "/" + accountId;
                }
                WebRequest request = WebRequest.Create(myUrl);
                request.Headers.Add("apikey", "ELIE3173");

                request.Method = method;
                request.ContentLength = jsonCard.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonCard);
                writer.Flush();
                writer.Close();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/");
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
            List<CreditCardInfo> cardInfo = js.Deserialize<List<CreditCardInfo>>(data);
            gvCard.DataSource = cardInfo;
            gvCard.DataBind();
            gvCard.Visible = true;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnCanncel.Visible = true;
            btnCreateNewCard.Visible = false;
            btnShow.Visible = false;


            Button button = (Button)sender;
            int index = int.Parse(button.CommandArgument);
            int id = Convert.ToInt32(gvCard.Rows[index].Cells[0].Text);
            lblID.Text = id.ToString();

            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/" + id);
            request.Headers.Add("apikey", "ELIE3173");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            CreditCardInfo card = js.Deserialize<CreditCardInfo>(data);

            txtCardNumber.Text = card.CardNumber.ToString();
            txtName.Text = card.CardHolderName;
            txtST.Text = card.CardAddr;
            txtCity.Text = card.CardCity;
            txtState.Text = card.CardState;
            txtZipCode.Text = card.CardZipCode;
            txtExpMonth.Text = card.CardExpDate.Month.ToString("00");
            txtExpYear.Text = card.CardExpDate.Year.ToString("00");
            txtCvv.Text = card.CardCvv;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string acctId = lblID.Text;
            Mymethod(int.Parse(acctId), "PUT", true);
            gvCard.Visible = false;
            lblInva.Text = "*Card infomation have been updated.";
            lblInva.Visible = true;
            txtCardNumber.Text = "";
            txtName.Text = "";
            txtST.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtExpMonth.Text = "";
            txtExpYear.Text = "";
            txtCvv.Text = "";
        }

        protected void gvCard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.CommandArgument);
            int id = Convert.ToInt32(gvCard.Rows[index].Cells[0].Text);
            Action(id, "PUT", false);
            }

        public void Action(int accountId, string method, bool val)
        {
            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/" + accountId);
            request.Headers.Add("apikey", "ELIE3173");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            CreditCardInfo card = js.Deserialize<CreditCardInfo>(data);

            card.Val = val;
            String jsonCard = js.Serialize(card);

            /////////////////////////////////////////////////////////////////////
            string myUrl = "http://cis-iis2.temple.edu/Fall2018/CIS3342_tug96043/Project4WS/api/CreditCard/";
            if (accountId != 0)
            {
                myUrl += "/" + accountId;
            }
            request = WebRequest.Create(myUrl);
            request.Headers.Add("apikey", "ELIE3173");

            request.Method = method;
            request.ContentLength = jsonCard.Length;
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonCard);
            writer.Flush();
            writer.Close();
            lblInva.Text = "*Card Have been Deactivated.";
            lblInva.Visible = true;
            gvCard.Visible = false;
        }

        protected void btnCanncel_Click(object sender, EventArgs e)
        {
            btnCreateNewCard.Visible = true;
            btnShow.Visible = true;
            btnUpdate.Visible = false;
            btnCanncel.Visible = false;
            txtCardNumber.Text = "";
            txtName.Text = "";
            txtST.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtExpMonth.Text = "";
            txtExpYear.Text = "";
            txtCvv.Text = "";
        }
    }
}
