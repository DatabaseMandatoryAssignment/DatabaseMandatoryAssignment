using System;
using System.Linq;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment2.Controllers
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
        private double? GetMonthsAverage(int month, string stofnavn, string maalested)
        {
            try
            {
                if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
                {
                    return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month select a.Resultat).Average() ?? 0;
                }
                if (string.IsNullOrEmpty(stofnavn))
                {
                    return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month && a.Maalested == maalested select a.Resultat).Average() ?? 0;
                }
                if (string.IsNullOrEmpty(maalested))
                {
                    return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month && a.StofNavn == stofnavn select a.Resultat).Average() ?? 0;
                }
                return (from a in DataContextTable.Ambient where a.DatoMaerke.Month == month && a.Stof.StofNavn == stofnavn && a.Maalested.Maalested1 == maalested select a.Resultat).Average() ?? 0;
            }
            catch (Exception)
            {
                Log("Could not calculate average!", Error);
                return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month select a.Resultat).Average() ?? 0;
            }
        }
        private void SetMonths(YearlyViewModel yearlyViewModel, string stofnavn = null, string maalested = null)
        {
            try
            {
                yearlyViewModel.January = GetMonthsAverage(1, stofnavn, maalested);
                yearlyViewModel.February = GetMonthsAverage(2, stofnavn, maalested);
                yearlyViewModel.March = GetMonthsAverage(3, stofnavn, maalested);
                yearlyViewModel.April = GetMonthsAverage(4, stofnavn, maalested);
                yearlyViewModel.May = GetMonthsAverage(5, stofnavn, maalested);
                yearlyViewModel.June = GetMonthsAverage(6, stofnavn, maalested);
                yearlyViewModel.July = GetMonthsAverage(7, stofnavn, maalested);
                yearlyViewModel.August = GetMonthsAverage(8, stofnavn, maalested);
                yearlyViewModel.September = GetMonthsAverage(9, stofnavn, maalested);
                yearlyViewModel.October = GetMonthsAverage(10, stofnavn, maalested);
                yearlyViewModel.November = GetMonthsAverage(11, stofnavn, maalested);
                yearlyViewModel.December = GetMonthsAverage(12, stofnavn, maalested);
            }
            catch (Exception)
            {
                Log("Could not set months!", Error);
            }
        }
    }
}