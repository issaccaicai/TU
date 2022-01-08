using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

using CityLib;

namespace Project4W
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVal.Text = "";
            lblVal.Visible = false;
            btnAddCity.Visible = true;
            btnDisplay.Visible = true;
            btnUpdate.Visible = false;
            btnCanncel.Visible = false;

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {

            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/Project4WS/api/City/");
            WebRequest request = WebRequest.Create("http://localhost:2101/api/City/");
            WebResponse response = request.GetResponse();

            //request.Method = "GET";

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            string data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            
            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<CityInfo> cityList = js.Deserialize<List<CityInfo>>(data);
            //CityInfo[] cityList = js.Deserialize<CityInfo[]>(data);

            gvCity.DataSource = cityList;
            gvCity.DataBind();

            gvCity.Visible = true;

        }

        protected void btnAddCity_Click(object sender, EventArgs e)
        {
            //Display(0, "POST");

            string cityName = txtCityName.Text;
            string state = txtState.Text;
            string population = txtPopulation.Text;
            string medianHouseholdIncome = txtMedianHouseholdIncome.Text;
            string percentageOfOwners = txtPercentageOfOwners.Text;
            string percentageOfRenters = txtPercentageOfRenters.Text;
            string medianHomeValue = txtMedianHomeValue.Text;
            string medianAgeForMale = txtMedianAgeForMale.Text;
            string medianAgeForFemale = txtMedianAgeForFemale.Text;
            string unemploymentRate = txtUnemploymentRate.Text;
            string crimeIndex = txtCrimeIndex.Text;


            if (cityName == "")
            {
                lblVal.Text = "*Please Enter a City Name.";
                lblVal.Visible = true;
                return;
            }

            else if (state == "")
            {
                lblVal.Text = "*Please Enter a State.";
                lblVal.Visible = true;
                return;
            }

            else if (population == "")
            {
                lblVal.Text = "*Please Enter a Population.";
                lblVal.Visible = true;
                return;
            }
            else if (medianHouseholdIncome == "")
            {
                lblVal.Text = "*Please Enter a Median Household Income.";
                lblVal.Visible = true;
                return;
            }
            else if (percentageOfOwners == "")
            {
                lblVal.Text = "*Please Enter a Percentage Of Owners.";
                lblVal.Visible = true;
                return;
            }
            else if (percentageOfRenters == "")
            {
                lblVal.Text = "*Please Enter a Percentage Of Renters.";
                lblVal.Visible = true;
                return;
            }
            else if (medianHomeValue == "")
            {
                lblVal.Text = "*Please Enter a Median Home Value.";
                lblVal.Visible = true;
                return;
            }
            else if (medianAgeForMale == "")
            {
                lblVal.Text = "*Please Enter a Median Age For Male.";
                lblVal.Visible = true;
                return;
            }
            else if (medianAgeForFemale == "")
            {
                lblVal.Text = "*Please Enter a Median Age For Female.";
                lblVal.Visible = true;
                return;
            }
            else if (unemploymentRate == "")
            {
                lblVal.Text = "*Please Enter an Unemployment Rate.";
                lblVal.Visible = true;
                return;
            }
            else if (crimeIndex == "")
            {
                lblVal.Text = "*Please Enter a Crime Index.";
                lblVal.Visible = true;
                return;
            }


            else
            {


                CityInfo city = new CityInfo();

                city.CityName = txtCityName.Text;
                city.State = txtState.Text;
                city.Population = Convert.ToInt32(txtPopulation.Text);
                city.MedianHouseholdIncome = Convert.ToInt32(txtMedianHouseholdIncome.Text);
                city.PercentageOfOwners = Convert.ToDecimal(txtPercentageOfOwners.Text);
                city.PercentageOfRenters = Convert.ToDecimal(txtPercentageOfRenters.Text);
                city.MedianHomeValue = Convert.ToInt32(txtMedianHomeValue.Text);
                city.MedianAgeForMale = Convert.ToDecimal(txtMedianAgeForMale.Text);
                city.MedianAgeForFemale = Convert.ToDecimal(txtMedianAgeForFemale.Text);
                city.UnemploymentRate = Convert.ToDecimal(txtUnemploymentRate.Text);
                city.CrimeIndex = Convert.ToDecimal(txtCrimeIndex.Text);

                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonCity = js.Serialize(city);
                try

                {


                    /////////////////////////////////////////////////////////////////////
                    //string myUrl = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/Project4WS/api/City/";
                    string myUrl = "http://localhost:2101/api/City/" + "AddCity/";

                    //if (cityId != 0)
                    //{
                    //    myUrl += "/" + cityId;
                    //}
                    WebRequest request = WebRequest.Create(myUrl);

                    request.Method = "POST";
                    request.ContentLength = jsonCity.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonCity);
                    writer.Flush();
                    writer.Close();

                    WebResponse response = request.GetResponse();

                    Stream theDataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(theDataStream);

                    string data = reader.ReadToEnd();

                    reader.Close();

                    response.Close();

                    if (data == "true")
                    {

                        lblVal.Text = "**Successful.";
                        lblVal.Visible = true;
                    }


                    else
                    {

                        lblVal.Text = "A problem occurred while adding the customer to the database. The data wasn't recorded.";
                    }

                }
                catch (Exception ex)

                {

                    lblVal.Text = "Error: " + ex.Message;

                }
            }




            gvCity.Visible = false;
            //lblVal.Text = "**City information has been updated!";
            //lblVal.Visible = true;

            txtCityName.Text = "";
            txtState.Text = "";
            txtPopulation.Text = "";
            txtMedianHouseholdIncome.Text = "";
            txtPercentageOfOwners.Text = "";
            txtPercentageOfRenters.Text = "";
            txtMedianHomeValue.Text = "";
            txtMedianAgeForMale.Text = "";
            txtMedianAgeForFemale.Text = "";
            txtUnemploymentRate.Text = "";
            txtCrimeIndex.Text = "";


        }

        public void Display(int cityId, string method)
        {
            string cityName = txtCityName.Text;
            string state = txtState.Text;
            string population = txtPopulation.Text;
            string medianHouseholdIncome = txtMedianHouseholdIncome.Text;
            string percentageOfOwners = txtPercentageOfOwners.Text;
            string percentageOfRenters = txtPercentageOfRenters.Text;
            string medianHomeValue = txtMedianHomeValue.Text;
            string medianAgeForMale = txtMedianAgeForMale.Text;
            string medianAgeForFemale = txtMedianAgeForFemale.Text;
            string unemploymentRate = txtUnemploymentRate.Text;
            string crimeIndex = txtCrimeIndex.Text;
            


            if (cityName == "")
            {
                lblVal.Text = "*Please Enter a City Name.";
                lblVal.Visible = true;
                return;
            }

            else if (state == "")
            {
                lblVal.Text = "*Please Enter a State.";
                lblVal.Visible = true;
                return;
            }

            else if (population == "")
            {
                lblVal.Text = "*Please Enter a Population.";
                lblVal.Visible = true;
                return;
            }
            else if (medianHouseholdIncome == "")
            {
                lblVal.Text = "*Please Enter a Median Household Income.";
                lblVal.Visible = true;
                return;
            }
            else if (percentageOfOwners == "")
            {
                lblVal.Text = "*Please Enter a Percentage Of Owners.";
                lblVal.Visible = true;
                return;
            }
            else if (percentageOfRenters == "")
            {
                lblVal.Text = "*Please Enter a Percentage Of Renters.";
                lblVal.Visible = true;
                return;
            }
            else if (medianHomeValue == "")
            {
                lblVal.Text = "*Please Enter a Median Home Value.";
                lblVal.Visible = true;
                return;
            }
            else if (medianAgeForMale == "")
            {
                lblVal.Text = "*Please Enter a Median Age For Male.";
                lblVal.Visible = true;
                return;
            }
            else if (medianAgeForFemale == "")
            {
                lblVal.Text = "*Please Enter a Median Age For Female.";
                lblVal.Visible = true;
                return;
            }
            else if (unemploymentRate == "")
            {
                lblVal.Text = "*Please Enter an Unemployment Rate.";
                lblVal.Visible = true;
                return;
            }
            else if (crimeIndex == "")
            {
                lblVal.Text = "*Please Enter a Crime Index.";
                lblVal.Visible = true;
                return;
            }
            else
            {
                try

                {

                    CityInfo city = new CityInfo(cityId, cityName, state, Convert.ToInt32(population), Convert.ToInt32(medianHouseholdIncome),
            Convert.ToDecimal(percentageOfOwners), Convert.ToDecimal(percentageOfRenters), Convert.ToInt32(medianHomeValue), Convert.ToDecimal(medianAgeForMale),
            Convert.ToDecimal(medianAgeForFemale), Convert.ToDecimal(unemploymentRate), Convert.ToDecimal(crimeIndex));

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonCity = js.Serialize(city);

                    /////////////////////////////////////////////////////////////////////
                    string myUrl = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/Project4WS/api/City/";
                    //string myUrl = "http://localhost:2101/api/City/";

                    if (cityId != 0)
                    {
                        myUrl += "/" + cityId;
                    }
                    WebRequest request = WebRequest.Create(myUrl);

                    request.Method = method;
                    request.ContentLength = jsonCity.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonCity);
                    writer.Flush();
                    writer.Close();

                    lblVal.Text = "**Successful.";
                    lblVal.Visible = true;
                }
                catch (Exception ex)

                {

                    lblVal.Text = "Error: " + ex.Message;

                }
            }



        }




        protected void btnUpdateChange_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnCanncel.Visible = true;
            btnAddCity.Visible = false;
            btnDisplay.Visible = false;



            Button button = (Button)sender;
            int index = int.Parse(button.CommandArgument);
            int id = Convert.ToInt32(gvCity.Rows[index].Cells[0].Text);
            lblID.Text = id.ToString();
            //lblID.Visible = true;

            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/Project4WS/api/City/" + id);
            //WebRequest request = WebRequest.Create("http://localhost:2101/api/City/" + id);

            //request.Method = "GET";
            //Post add
            //    put update;

            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            string data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            CityInfo city = js.Deserialize<CityInfo>(data);

            txtCityName.Text = city.CityName;
            txtState.Text = city.State;
            txtPopulation.Text = city.Population.ToString();
            txtMedianHouseholdIncome.Text = city.MedianHouseholdIncome.ToString();
            txtPercentageOfOwners.Text = city.PercentageOfOwners.ToString();
            txtPercentageOfRenters.Text = city.PercentageOfRenters.ToString();
            txtMedianHomeValue.Text = city.MedianHomeValue.ToString();
            txtMedianAgeForMale.Text = city.MedianAgeForMale.ToString();
            txtMedianAgeForFemale.Text = city.MedianAgeForFemale.ToString();
            txtUnemploymentRate.Text = city.UnemploymentRate.ToString();
            txtCrimeIndex.Text = city.CrimeIndex.ToString();
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //string cityId = lblID.Text;

            //Display(int.Parse(cityId), "PUT");
            //gvCity.Visible = false;
            //lblVal.Text = "**City information has been updated!";
            //lblVal.Visible = true;

            string cityId = lblID.Text;

            string cityName = txtCityName.Text;
            string state = txtState.Text;
            string population = txtPopulation.Text;
            string medianHouseholdIncome = txtMedianHouseholdIncome.Text;
            string percentageOfOwners = txtPercentageOfOwners.Text;
            string percentageOfRenters = txtPercentageOfRenters.Text;
            string medianHomeValue = txtMedianHomeValue.Text;
            string medianAgeForMale = txtMedianAgeForMale.Text;
            string medianAgeForFemale = txtMedianAgeForFemale.Text;
            string unemploymentRate = txtUnemploymentRate.Text;
            string crimeIndex = txtCrimeIndex.Text;


            if (cityName == "")
            {
                lblVal.Text = "*Please Enter a City Name.";
                lblVal.Visible = true;
                return;
            }

            else if (state == "")
            {
                lblVal.Text = "*Please Enter a State.";
                lblVal.Visible = true;
                return;
            }

            else if (population == "")
            {
                lblVal.Text = "*Please Enter a Population.";
                lblVal.Visible = true;
                return;
            }
            else if (medianHouseholdIncome == "")
            {
                lblVal.Text = "*Please Enter a Median Household Income.";
                lblVal.Visible = true;
                return;
            }
            else if (percentageOfOwners == "")
            {
                lblVal.Text = "*Please Enter a Percentage Of Owners.";
                lblVal.Visible = true;
                return;
            }
            else if (percentageOfRenters == "")
            {
                lblVal.Text = "*Please Enter a Percentage Of Renters.";
                lblVal.Visible = true;
                return;
            }
            else if (medianHomeValue == "")
            {
                lblVal.Text = "*Please Enter a Median Home Value.";
                lblVal.Visible = true;
                return;
            }
            else if (medianAgeForMale == "")
            {
                lblVal.Text = "*Please Enter a Median Age For Male.";
                lblVal.Visible = true;
                return;
            }
            else if (medianAgeForFemale == "")
            {
                lblVal.Text = "*Please Enter a Median Age For Female.";
                lblVal.Visible = true;
                return;
            }
            else if (unemploymentRate == "")
            {
                lblVal.Text = "*Please Enter an Unemployment Rate.";
                lblVal.Visible = true;
                return;
            }
            else if (crimeIndex == "")
            {
                lblVal.Text = "*Please Enter a Crime Index.";
                lblVal.Visible = true;
                return;
            }

            //        CityInfo city = new CityInfo(Convert.ToInt32(cityId), cityName, state, Convert.ToInt32(population), Convert.ToInt32(medianHouseholdIncome),
            //Convert.ToDecimal(percentageOfOwners), Convert.ToDecimal(percentageOfRenters), Convert.ToInt32(medianHomeValue), Convert.ToDecimal(medianAgeForMale),
            //Convert.ToDecimal(medianAgeForFemale), Convert.ToDecimal(unemploymentRate), Convert.ToDecimal(crimeIndex));
            else
            {
                CityInfo city = new CityInfo();

                city.CityId = Convert.ToInt32(lblID.Text);

                city.CityName = txtCityName.Text;
                city.State = txtState.Text;
                city.Population = Convert.ToInt32(txtPopulation.Text);
                city.MedianHouseholdIncome = Convert.ToInt32(txtMedianHouseholdIncome.Text);
                city.PercentageOfOwners = Convert.ToDecimal(txtPercentageOfOwners.Text);
                city.PercentageOfRenters = Convert.ToDecimal(txtPercentageOfRenters.Text);
                city.MedianHomeValue = Convert.ToInt32(txtMedianHomeValue.Text);
                city.MedianAgeForMale = Convert.ToDecimal(txtMedianAgeForMale.Text);
                city.MedianAgeForFemale = Convert.ToDecimal(txtMedianAgeForFemale.Text);
                city.UnemploymentRate = Convert.ToDecimal(txtUnemploymentRate.Text);
                city.CrimeIndex = Convert.ToDecimal(txtCrimeIndex.Text);


                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonCity = js.Serialize(city);
                try

                {
                    /////////////////////////////////////////////////////////////////////
                    //string myUrl = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug11448/Project4WS/api/City/";
                    string myUrl = "http://localhost:2101/api/City/" + "UpdateCity/";

                    //if (cityId != 0)
                    //{
                    //    myUrl += "/" + cityId;
                    //}
                    WebRequest request = WebRequest.Create(myUrl);

                    request.Method = "PUT";
                    request.ContentLength = jsonCity.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonCity);
                    writer.Flush();
                    writer.Close();

                    WebResponse response = request.GetResponse();

                    Stream theDataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(theDataStream);

                    string data = reader.ReadToEnd();

                    reader.Close();

                    response.Close();

                    if (data == "true")
                    {

                        lblVal.Text = "**Successful.";
                        lblVal.Visible = true;
                    }


                    else
                    {

                        lblVal.Text = "A problem occurred while adding the customer to the database. The data wasn't recorded.";
                    }

                }
                catch (Exception ex)

                {

                    lblVal.Text = "Error: " + ex.Message;

                }



            }

            gvCity.Visible = false;


            txtCityName.Text = "";
            txtState.Text = "";
            txtPopulation.Text = "";
            txtMedianHouseholdIncome.Text = "";
            txtPercentageOfOwners.Text = "";
            txtPercentageOfRenters.Text = "";
            txtMedianHomeValue.Text = "";
            txtMedianAgeForMale.Text = "";
            txtMedianAgeForFemale.Text = "";
            txtUnemploymentRate.Text = "";
            txtCrimeIndex.Text = "";
        }

        protected void btnCanncel_Click(object sender, EventArgs e)
        {
            btnAddCity.Visible = true;
            btnDisplay.Visible = true;
            btnUpdate.Visible = false;
            btnCanncel.Visible = false;

            txtCityName.Text = "";
            txtState.Text = "";
            txtPopulation.Text = "";
            txtMedianHouseholdIncome.Text = "";
            txtPercentageOfOwners.Text = "";
            txtPercentageOfRenters.Text = "";
            txtMedianHomeValue.Text = "";
            txtMedianAgeForMale.Text = "";
            txtMedianAgeForFemale.Text = "";
            txtUnemploymentRate.Text = "";
            txtCrimeIndex.Text = "";
            

        }

        protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}