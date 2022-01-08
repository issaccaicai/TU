using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace CityLib
{
    public class ManageCity
    {
        DBConnect myObj = new DBConnect();

        public List<CityInfo> ShowCityInfo()
        {
            SqlCommand cityInfoCmd = new SqlCommand("getAllCity");
            cityInfoCmd.CommandType = CommandType.StoredProcedure;
            DataSet cityInfoDS = myObj.GetDataSetUsingCmdObj(cityInfoCmd);
            List<CityInfo> cityList = new List<CityInfo>();
            CityInfo listCityInfo;
            foreach (/*int i = 0; i < cityInfoDS.Tables[0].Rows.Count; i++*/DataRow record in cityInfoDS.Tables[0].Rows)
            {
                listCityInfo = new CityInfo();
                listCityInfo.CityId = int.Parse(record["City_Id"].ToString());
                listCityInfo.CityName = record["City_Name"].ToString();
                listCityInfo.State = record["State"].ToString();
                listCityInfo.Population = int.Parse(record["Population"].ToString());
                listCityInfo.MedianHouseholdIncome = int.Parse(record["MedianHouseholdIncome"].ToString());
                listCityInfo.PercentageOfOwners = decimal.Parse(record["PercentageOfOwners"].ToString());
                listCityInfo.PercentageOfRenters = decimal.Parse(record["PercentageOfRenters"].ToString());
                listCityInfo.MedianHomeValue = int.Parse(record["MedianHomeValue"].ToString());
                listCityInfo.MedianAgeForMale = decimal.Parse(record["MedianAgeForMale"].ToString());
                listCityInfo.MedianAgeForFemale = decimal.Parse(record["MedianAgeForFemale"].ToString());
                listCityInfo.UnemploymentRate = decimal.Parse(record["UnemploymentRate"].ToString());
                listCityInfo.CrimeIndex = decimal.Parse(record["CrimeIndex"].ToString());
                cityList.Add(listCityInfo);


                //listCityInfo = new CityInfo(
                //    Convert.ToInt32(myObj.GetField("City_Id", i)),
                //    myObj.GetField("City_Name", i).ToString(),
                //    myObj.GetField("State", i).ToString(),
                //    Convert.ToInt32(myObj.GetField("Population", i)),
                //    Convert.ToInt32(myObj.GetField("MedianHouseholdIncome", i)),
                //    Convert.ToDecimal(myObj.GetField("PercentageOfOwners", i)),
                //    Convert.ToDecimal(myObj.GetField("PercentageOfRenters", i)),
                //    Convert.ToInt32(myObj.GetField("MedianHomeValue", i)),
                //    Convert.ToDecimal(myObj.GetField("MedianAgeForMale", i)),
                //    Convert.ToDecimal(myObj.GetField("MedianAgeForFemale", i)),
                //    Convert.ToDecimal(myObj.GetField("UnemploymentRate", i)),
                //    Convert.ToDecimal(myObj.GetField("CrimeIndex", i)));
                ////listCardInfo.Val = Convert.ToBoolean(myObj.GetField("val", i));
                //cityList.Add(listCityInfo);
            }
            return cityList;
        }

        public void AddCity(string cityName, string state, int population, int medianHouseholdIncome,
            decimal percentageOfOwners, decimal percentageOfRenters, int medianHomeValue, decimal medianAgeForMale,
            decimal medianAgeForFemale, decimal unemploymentRate, decimal crimeIndex)
        {
            SqlCommand addCityCmd = new SqlCommand("AddNewCity");
            addCityCmd.CommandType = CommandType.StoredProcedure;
            addCityCmd.Parameters.AddWithValue("@CityName", cityName);
            addCityCmd.Parameters.AddWithValue("@State", state);
            addCityCmd.Parameters.AddWithValue("@Population", population);
            addCityCmd.Parameters.AddWithValue("@MedianHouseholdIncome", medianHouseholdIncome);
            addCityCmd.Parameters.AddWithValue("@PercentageOfOwners", percentageOfOwners);
            addCityCmd.Parameters.AddWithValue("@PercentageOfRenters", percentageOfRenters);
            addCityCmd.Parameters.AddWithValue("@MedianHomeValue", medianHomeValue);
            addCityCmd.Parameters.AddWithValue("@MedianAgeForMale", medianAgeForMale);
            addCityCmd.Parameters.AddWithValue("@MedianAgeForFemale", medianAgeForFemale);
            addCityCmd.Parameters.AddWithValue("@UnemploymentRate", unemploymentRate);
            addCityCmd.Parameters.AddWithValue("@CrimeInde", crimeIndex);



            myObj.DoUpdateUsingCmdObj(addCityCmd);
        }

        public void UpdateCity(int cityId, string cityName, string state, int population, int medianHouseholdIncome,
            decimal percentageOfOwners, decimal percentageOfRenters, int medianHomeValue, decimal medianAgeForMale,
            decimal medianAgeForFemale, decimal unemploymentRate, decimal crimeIndex) { 

            SqlCommand updateCityInfoCmd = new SqlCommand("UpdateCity");
            updateCityInfoCmd.CommandType = CommandType.StoredProcedure;
            updateCityInfoCmd.Parameters.AddWithValue("@CityId", cityId);
            updateCityInfoCmd.Parameters.AddWithValue("@CityName", cityName);
            updateCityInfoCmd.Parameters.AddWithValue("@State", state);
            updateCityInfoCmd.Parameters.AddWithValue("@Population", population);
            updateCityInfoCmd.Parameters.AddWithValue("@MedianHouseholdIncome", medianHouseholdIncome);
            updateCityInfoCmd.Parameters.AddWithValue("@PercentageOfOwners", percentageOfOwners);
            updateCityInfoCmd.Parameters.AddWithValue("@PercentageOfRenters", percentageOfRenters);
            updateCityInfoCmd.Parameters.AddWithValue("@MedianHomeValue", medianHomeValue);
            updateCityInfoCmd.Parameters.AddWithValue("@MedianAgeForMale", medianAgeForMale);
            updateCityInfoCmd.Parameters.AddWithValue("@MedianAgeForFemale", medianAgeForFemale);
            updateCityInfoCmd.Parameters.AddWithValue("@UnemploymentRate", unemploymentRate);
            updateCityInfoCmd.Parameters.AddWithValue("@CrimeIndex", crimeIndex);


            myObj.DoUpdateUsingCmdObj(updateCityInfoCmd);
        }


        public CityInfo GetCity(int cityId)
        {
            SqlCommand getCity = new SqlCommand("getCityId");
            getCity.CommandType = CommandType.StoredProcedure;
            getCity.Parameters.AddWithValue("@CityId", cityId);
            DataSet cityInfoDS = myObj.GetDataSetUsingCmdObj(getCity);

            if (cityInfoDS.Tables[0].Rows.Count == 1)
            {
                CityInfo listCtInfo = new CityInfo(
                    Convert.ToInt32(myObj.GetField("City_Id", 0)),
                    myObj.GetField("City_Name", 0).ToString(),
                    myObj.GetField("State", 0).ToString(),
                    Convert.ToInt32(myObj.GetField("Population", 0).ToString()),
                    Convert.ToInt32(myObj.GetField("MedianHouseholdIncome", 0).ToString()),
                    Convert.ToDecimal(myObj.GetField("PercentageOfOwners", 0).ToString()),
                    Convert.ToDecimal(myObj.GetField("PercentageOfRenters", 0).ToString()),
                    Convert.ToInt32(myObj.GetField("MedianHomeValue", 0).ToString()),
                    Convert.ToDecimal(myObj.GetField("MedianAgeForMale", 0).ToString()),
                    Convert.ToDecimal(myObj.GetField("MedianAgeForFemale", 0).ToString()),
                    Convert.ToDecimal(myObj.GetField("UnemploymentRate", 0).ToString()),
                    Convert.ToDecimal(myObj.GetField("CrimeIndex", 0).ToString()));
                //listCardInfo.Val = Convert.ToBoolean(myObj.GetField("val", i));
                return listCtInfo;
            }
            return null;
        }
    }

}
