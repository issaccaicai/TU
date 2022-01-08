using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLib
{
    public class CityInfo
    {
        //(state, population, median household income, percentage of owners and renters, 
        //    median home value, median age for both male and female, unemployment rate, crime data)
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public int Population { get; set; }
        public int MedianHouseholdIncome { get; set; }
        public decimal PercentageOfOwners { get; set; }
        public decimal PercentageOfRenters { get; set; }
        public int MedianHomeValue { get; set; }
        public decimal MedianAgeForMale { get; set; }
        public decimal MedianAgeForFemale { get; set; }
        public decimal UnemploymentRate { get; set; }
        public decimal CrimeIndex { get; set; }


        public CityInfo()
        {

        }
        public CityInfo(int cityId, string cityName, string state, int population, int medianHouseholdIncome,
            decimal percentageOfOwners, decimal percentageOfRenters, int medianHomeValue, decimal medianAgeForMale,
            decimal medianAgeForFemale, decimal unemploymentRate, decimal crimeIndex)
        {
            this.CityId = cityId;
            this.CityName = cityName;
            this.State = state;
            this.Population = population;
            this.MedianHouseholdIncome = medianHouseholdIncome;
            this.PercentageOfOwners = percentageOfOwners;
            this.PercentageOfRenters = percentageOfRenters;
            this.MedianHomeValue = medianHomeValue;
            this.MedianAgeForMale = medianAgeForMale;
            this.MedianAgeForFemale = medianAgeForFemale;
            this.UnemploymentRate = unemploymentRate;
            this.CrimeIndex = crimeIndex;


        }
    }


}
