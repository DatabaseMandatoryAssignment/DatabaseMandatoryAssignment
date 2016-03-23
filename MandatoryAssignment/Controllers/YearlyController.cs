using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class YearlyController : BaseController, IChart
    {
        private readonly YearlyViewModel _yearlyViewModel = new YearlyViewModel();
        // POST methods
        [HttpPost]
        public ActionResult LineChart(string stofNavn, string maalested)
        {
            ViewBagItems();

            SetMonths(_yearlyViewModel, stofNavn, maalested);
            return View(_yearlyViewModel);
        }
        [HttpPost]
        public ActionResult BarChart(string stofNavn, string maalested)
        {
            ViewBagItems();

            SetMonths(_yearlyViewModel, stofNavn, maalested);
            return View(_yearlyViewModel);
        }
        [HttpPost]
        public ActionResult DonutChart(string stofNavn, string maalested)
        {
            ViewBagItems();

            SetMonths(_yearlyViewModel, stofNavn, maalested);
            return View(_yearlyViewModel);
        }
        // View methods
        public ActionResult LineChart()
        {
            ViewBagItems();

            SetMonths(_yearlyViewModel);
            return View(_yearlyViewModel);
        }
        public ActionResult BarChart()
        {
            ViewBagItems();

            SetMonths(_yearlyViewModel);
            return View(_yearlyViewModel);
        }
        public ActionResult DonutChart()
        {
            ViewBagItems();

            SetMonths(_yearlyViewModel);
            return View(_yearlyViewModel);
        }
        // Partial view methods
        public ActionResult _LineChart()
        {
            SetMonths(_yearlyViewModel);
            return PartialView(_yearlyViewModel);
        }

        public ActionResult _BarChart()
        {
            SetMonths(_yearlyViewModel);
            return PartialView(_yearlyViewModel);
        }

        public ActionResult _DonutChart()
        {
            SetMonths(_yearlyViewModel);
            return PartialView(_yearlyViewModel);
        }
        private void ViewBagItems()
        {
            ViewBag.Stof = from s in DataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in DataContextTable.Maalested select s.Maalested1;
        }
        private double? GetMonthsCount(int month, string stofnavn, string maalested)
        {
            if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
            {
                return (from q in DataContextView.AmbientView where q.DatoMaerke.Month == month select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(stofnavn))
            {
                return (from q in DataContextView.AmbientView where q.DatoMaerke.Month == month && q.Maalested == maalested select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(maalested))
            {
                return (from q in DataContextView.AmbientView where q.DatoMaerke.Month == month && q.StofNavn == stofnavn select q.Resultat).Average() ?? 0;
            }
            return (from q in DataContextTable.Ambient where q.DatoMaerke.Month == month && q.Stof.StofNavn == stofnavn && q.Maalested.Maalested1 == maalested select q.Resultat).Average() ?? 0;
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