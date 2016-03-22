using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class YearlyController : Controller
    {
        private readonly DataContextTable _dataContextTable = new DataContextTable();
        private readonly DataContextView _dataContextView = new DataContextView();
        [HttpPost]
        public ActionResult LineChart(string stofNavn, string maalested)
        {
            var yearlyViewModel = new YearlyViewModel();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(yearlyViewModel, stofNavn, maalested);

            return View(yearlyViewModel);
        }
        [HttpPost]
        public ActionResult BarChart(string stofNavn, string maalested)
        {
            var yearlyViewModel = new YearlyViewModel();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(yearlyViewModel, stofNavn, maalested);

            return View(yearlyViewModel);
        }
        [HttpPost]
        public ActionResult DonutChart(string stofNavn, string maalested)
        {
            var yearlyViewModel = new YearlyViewModel();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(yearlyViewModel, stofNavn, maalested);

            return View(yearlyViewModel);
        }
        public ActionResult LineChart()
        {
            var yearlyViewModel = new YearlyViewModel();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(yearlyViewModel);
            return View(yearlyViewModel);
        }
        
        public ActionResult _LineChart()
        {
            var yearlyViewModel = new YearlyViewModel();

            SetMonths(yearlyViewModel);
            return PartialView(yearlyViewModel);
        }
        public ActionResult BarChart()
        {
            var yearlyViewModel = new YearlyViewModel();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;
            
            SetMonths(yearlyViewModel);
            return View(yearlyViewModel);
        }
        public ActionResult _BarChart()
        {
            var yearlyViewModel = new YearlyViewModel();

            SetMonths(yearlyViewModel);
            return PartialView(yearlyViewModel);
        }
        public ActionResult DonutChart()
        {
            var yearlyViewModel = new YearlyViewModel();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;
            
            SetMonths(yearlyViewModel);
            return View(yearlyViewModel);
        }
        public ActionResult _DonutChart()
        {
            var yearlyViewModel = new YearlyViewModel();

            SetMonths(yearlyViewModel);
            return PartialView(yearlyViewModel);
        }
        private double? GetMonthsCount(int month, string stofnavn, string maalested)
        {
            if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
            {
                return (from q in _dataContextView.AmbientView where q.DatoMaerke.Month == month select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(stofnavn))
            {
                return (from q in _dataContextView.AmbientView where q.DatoMaerke.Month == month && q.Maalested == maalested select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(maalested))
            {
                return (from q in _dataContextView.AmbientView where q.DatoMaerke.Month == month && q.StofNavn == stofnavn select q.Resultat).Average() ?? 0;
            }
            return (from q in _dataContextTable.Ambient where q.DatoMaerke.Month == month && q.Stof.StofNavn == stofnavn && q.Maalested.Maalested1 == maalested select q.Resultat).Average() ?? 0;
        }

        private void SetMonths(YearlyViewModel yearlyViewModel, string stofnavn = null, string maalested = null)
        {
            yearlyViewModel.January = GetMonthsCount(1, stofnavn, maalested);
            yearlyViewModel.February = GetMonthsCount(2, stofnavn, maalested);
            yearlyViewModel.March = GetMonthsCount(3, stofnavn, maalested);
            yearlyViewModel.April = GetMonthsCount(4, stofnavn, maalested);
            yearlyViewModel.May = GetMonthsCount(5, stofnavn, maalested);
            yearlyViewModel.June = GetMonthsCount(6, stofnavn, maalested);
            yearlyViewModel.July = GetMonthsCount(7, stofnavn, maalested);
            yearlyViewModel.August = GetMonthsCount(8, stofnavn, maalested);
            yearlyViewModel.September = GetMonthsCount(9, stofnavn, maalested);
            yearlyViewModel.October = GetMonthsCount(10, stofnavn, maalested);
            yearlyViewModel.November = GetMonthsCount(11, stofnavn, maalested);
            yearlyViewModel.December = GetMonthsCount(12, stofnavn, maalested);
        }
    }
}