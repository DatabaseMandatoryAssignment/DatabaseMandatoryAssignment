using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;
using MandatoryAssignment2.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MandatoryAssignment2.Controllers
{
    public class MongoDbController : BaseController, IChart
    {
        private readonly MongoDbYearlyViewModel _mongoDbYearlyViewModel = new MongoDbYearlyViewModel();
        private readonly IMongoCollection<MongoDbAmbient> _collection = Db.GetCollection<MongoDbAmbient>("Ambient");
        // POST methods
        [HttpPost]
        public ActionResult LineChart(string stofNavn, string maalested)
        {
            ViewBagItems();

            SetMonths(_mongoDbYearlyViewModel, stofNavn, maalested);
            return View(_mongoDbYearlyViewModel);
        }
        // View methods
        public ActionResult LineChart()
        {
            ViewBagItems();

            SetMonths(_mongoDbYearlyViewModel);
            return View(_mongoDbYearlyViewModel);
        }
        public ActionResult BarChart()
        {
            throw new NotImplementedException();
        }

        public ActionResult DonutChart()
        {
            throw new NotImplementedException();
        }
        // Partial view methods
        public ActionResult _LineChart()
        {
            throw new NotImplementedException();
        }

        public ActionResult _BarChart()
        {
            throw new NotImplementedException();
        }

        public ActionResult _DonutChart()
        {
            throw new NotImplementedException();
        }
        private void ViewBagItems()
        {
            try
            {
                ViewBag.Stof = from s in DataContextTable.Stof select s.StofNavn;
                ViewBag.Maalested = from m in DataContextTable.Maalested select m.Maalested1;
            }
            catch (Exception)
            {
                Log("Could not set ViewBag!", Error);
            }
        }
        private double? GetMonthsAverage(int month, int days, string stofnavn, string maalested)
        {
            try
            {
                if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
                {
                    return (from a in _collection.AsQueryable() where a.DatoMaerke >= new DateTime(2015, month, 01) && a.DatoMaerke <= new DateTime(2015, month, days) select a.Resultat).Average();
                }
                if (string.IsNullOrEmpty(stofnavn))
                {
                    return (from a in _collection.AsQueryable() where a.DatoMaerke >= new DateTime(2015, month, 01) && a.DatoMaerke <= new DateTime(2015, month, days) && a.MaaleSted == maalested select a.Resultat).Average();
                }
                if (string.IsNullOrEmpty(maalested))
                {
                    return (from a in _collection.AsQueryable() where a.DatoMaerke >= new DateTime(2015, month, 01) && a.DatoMaerke <= new DateTime(2015, month, days) && a.Stof == stofnavn select a.Resultat).Average();
                }
                return (from a in _collection.AsQueryable() where a.DatoMaerke >= new DateTime(2015, month, 01) && a.DatoMaerke <= new DateTime(2015, month, days) && a.Stof == stofnavn select a.Resultat).Average();
            }
            catch (Exception)
            {
                Log("Could not calculate average!", Error);
            }
            return null;
        }
        private void SetMonths(MongoDbYearlyViewModel yearlyViewModel, string stofnavn = null, string maalested = null)
        {
            try
            {
                yearlyViewModel.January = GetMonthsAverage(1, 31, stofnavn, maalested);
                yearlyViewModel.February = GetMonthsAverage(2, 28, stofnavn, maalested);
                yearlyViewModel.March = GetMonthsAverage(3, 31, stofnavn, maalested);
                yearlyViewModel.April = GetMonthsAverage(4,30, stofnavn, maalested);
                yearlyViewModel.May = GetMonthsAverage(5, 31, stofnavn, maalested);
                yearlyViewModel.June = GetMonthsAverage(6, 30, stofnavn, maalested);
                yearlyViewModel.July = GetMonthsAverage(7, 31, stofnavn, maalested);
                yearlyViewModel.August = GetMonthsAverage(8, 30, stofnavn, maalested);
                yearlyViewModel.September = GetMonthsAverage(9, 30, stofnavn, maalested);
                yearlyViewModel.October = GetMonthsAverage(10, 31, stofnavn, maalested);
                yearlyViewModel.November = GetMonthsAverage(11, 30, stofnavn, maalested);
                yearlyViewModel.December = GetMonthsAverage(12, 31, stofnavn, maalested);
            }
            catch (Exception)
            {
                Log("Could not set months!", Error);
            }
        }
    }
}