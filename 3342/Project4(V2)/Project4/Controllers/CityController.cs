using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using System.Data.SqlClient;
using CityLib;
namespace Project4.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    [Route("api/City")]
    public class CityController : Controller
    {
        ManageCity myCity = new ManageCity();
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        [HttpGet]
        public List<CityInfo> Get()
        {
            return myCity.ShowCityInfo();
        }

        [HttpGet("{cityId}")]
        public CityInfo GetCities(int cityId)
        {
                return myCity.GetCity(cityId);
        }


        //[HttpPost]
        //public void Post([FromBody]CityInfo info)
        //{
        //    myCity.AddCity(info.CityName, info.State, info.Population, info.MedianHouseholdIncome,
        //        info.PercentageOfOwners, info.PercentageOfRenters, info.MedianHomeValue, info.MedianAgeForMale,
        //        info.MedianAgeForFemale, info.UnemploymentRate, info.CrimeIndex);
        //}


        //[HttpPut("{cityId}")]
        //public Boolean Put([FromBody]CityInfo info, int cityId)
        //{
        //    if (info != null)
        //    {
        //        this.objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        this.objCommand.CommandText = "UpdateCity";

        //        objCommand.Parameters.AddWithValue("@CityName", info.CityName);
        //        objCommand.Parameters.AddWithValue("@State", info.State);
        //        objCommand.Parameters.AddWithValue("@Population", info.Population);


        //    }

        //    return (myCity.UpdateCity(cityId, info.CityName, info.State, info.Population, info.MedianHouseholdIncome,
        //        info.PercentageOfOwners, info.PercentageOfRenters, info.MedianHomeValue, info.MedianAgeForMale,
        //        info.MedianAgeForFemale, info.UnemploymentRate, info.CrimeIndex);)
        //}




        [HttpPost()]
        [HttpPost("AddCity")]
        public Boolean AddCustomer([FromBody]CityInfo info)
        {
            if (info != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "AddNewCity";
                objCommand.Parameters.AddWithValue("@CityName", info.CityName);
                objCommand.Parameters.AddWithValue("@State", info.State);
                objCommand.Parameters.AddWithValue("@Population", info.Population);
                objCommand.Parameters.AddWithValue("@MedianHouseholdIncome", info.MedianHouseholdIncome);
                objCommand.Parameters.AddWithValue("@PercentageOfOwners", info.PercentageOfOwners);
                objCommand.Parameters.AddWithValue("@PercentageOfRenters", info.PercentageOfRenters);
                objCommand.Parameters.AddWithValue("@MedianHomeValue", info.MedianHomeValue);
                objCommand.Parameters.AddWithValue("@MedianAgeForMale", info.MedianAgeForMale);
                objCommand.Parameters.AddWithValue("@MedianAgeForFemale", info.MedianAgeForFemale);
                objCommand.Parameters.AddWithValue("@UnemploymentRate", info.UnemploymentRate);
                objCommand.Parameters.AddWithValue("@CrimeIndex", info.CrimeIndex);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);
                if (retVal > 0)
                    return true;
                else
                    return false;
            }

            else
            {
                return false;
            }

        }
        [HttpPut()]
        [HttpPut("UpdateCity")]
        public Boolean UpdateCity([FromBody]CityInfo info)
        {
            if (info != null)
            {
                this.objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                this.objCommand.CommandText = "UpdateCity";
                objCommand.Parameters.AddWithValue("@CityId", info.CityId);
                objCommand.Parameters.AddWithValue("@CityName", info.CityName);
                objCommand.Parameters.AddWithValue("@State", info.State);
                objCommand.Parameters.AddWithValue("@Population", info.Population);
                objCommand.Parameters.AddWithValue("@MedianHouseholdIncome", info.MedianHouseholdIncome);
                objCommand.Parameters.AddWithValue("@PercentageOfOwners", info.PercentageOfOwners);
                objCommand.Parameters.AddWithValue("@PercentageOfRenters", info.PercentageOfRenters);
                objCommand.Parameters.AddWithValue("@MedianHomeValue", info.MedianHomeValue);
                objCommand.Parameters.AddWithValue("@MedianAgeForMale", info.MedianAgeForMale);
                objCommand.Parameters.AddWithValue("@MedianAgeForFemale", info.MedianAgeForFemale);
                objCommand.Parameters.AddWithValue("@UnemploymentRate", info.UnemploymentRate);
                objCommand.Parameters.AddWithValue("@CrimeIndex", info.CrimeIndex);
                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);
                if (retVal > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }






        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: City/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}