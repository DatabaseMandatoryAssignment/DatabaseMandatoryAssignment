using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class HourlyController : BaseController, IChart
    {
        private readonly HourlyViewModel _hourlyViewModel = new HourlyViewModel();
        // POST methods
        [HttpPost]
        public ActionResult LineChart(string date, string stofNavn, string maalested)
        {
            ViewBagItems();

            SetHours(_hourlyViewModel, date, stofNavn, maalested);
            return View(_hourlyViewModel);
        }
        [HttpPost]
        public ActionResult BarChart(string date, string stofNavn, string maalested)
        {
            ViewBagItems();

            SetHours(_hourlyViewModel, date, stofNavn, maalested);
            return View(_hourlyViewModel);
        }
        [HttpPost]
        public ActionResult DonutChart(string date, string stofNavn, string maalested)
        {
            ViewBagItems();

            SetHours(_hourlyViewModel, date, stofNavn, maalested);
            return View(_hourlyViewModel);
        }
        // View methods
        public ActionResult LineChart()
        {
            ViewBagItems();
            ViewBag.Date = DateTime.Now.ToString("2015-MM-dd");

            SetHours(_hourlyViewModel, ViewBag.Date);
            return View(_hourlyViewModel);
        }

        public ActionResult BarChart()
        {
            ViewBagItems();
            ViewBag.Date = DateTime.Now.ToString("2015-MM-dd");

            SetHours(_hourlyViewModel, ViewBag.Date);
            return View(_hourlyViewModel);
        }

        public ActionResult DonutChart()
        {
            ViewBagItems();
            ViewBag.Date = DateTime.Now.ToString("2015-MM-dd");

            SetHours(_hourlyViewModel, ViewBag.Date);
            return View(_hourlyViewModel);
        }

        // Partial view methods
        public ActionResult _LineChart()
        {
            ViewBag.Date = DateTime.Now.ToString("2015-MM-dd");

            SetHours(_hourlyViewModel, ViewBag.Date);
            return PartialView(_hourlyViewModel);
        }

        public ActionResult _BarChart()
        {
            ViewBag.Date = DateTime.Now.ToString("2015-MM-dd");

            SetHours(_hourlyViewModel, ViewBag.Date);
            return PartialView(_hourlyViewModel);
        }

        public ActionResult _DonutChart()
        {
            ViewBag.Date = DateTime.Now.ToString("2015-MM-dd");

            SetHours(_hourlyViewModel, ViewBag.Date);
            return PartialView(_hourlyViewModel);
        }

        private double? GetHourAverage(string date, string hour, string stofnavn, string maalested)
        {
            var date1 = Convert.ToDateTime(date + " " + hour + ":00:00");
            var date2 = Convert.ToDateTime(date + " " + hour + ":59:59");

            if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
            {
                return (from a in DataContextView.AmbientView where a.DatoMaerke >= date1 && a.DatoMaerke < date2 select a.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(stofnavn))
            {
                return (from a in DataContextView.AmbientView where a.DatoMaerke >= date1 && a.DatoMaerke < date2 && a.Maalested == maalested select a.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(maalested))
            {
                return (from a in DataContextView.AmbientView where a.DatoMaerke >= date1 && a.DatoMaerke < date2 && a.StofNavn == stofnavn select a.Resultat).Average() ?? 0;
            }
            return (from a in DataContextView.AmbientView where a.DatoMaerke >= date1 && a.DatoMaerke < date2 && a.Maalested == maalested && a.StofNavn == stofnavn select a.Resultat).Average() ?? 0;
        }

        private void SetHours(HourlyViewModel hourlyViewModel, string date, string stofnavn = null, string maalested = null)
        {
            hourlyViewModel.Hour00 = GetHourAverage(date, " 0", stofnavn, maalested);
            hourlyViewModel.Hour01 = GetHourAverage(date, " 1", stofnavn, maalested);
            hourlyViewModel.Hour02 = GetHourAverage(date, " 2", stofnavn, maalested);
            hourlyViewModel.Hour03 = GetHourAverage(date, " 3", stofnavn, maalested);
            hourlyViewModel.Hour04 = GetHourAverage(date, " 4", stofnavn, maalested);
            hourlyViewModel.Hour05 = GetHourAverage(date, " 5", stofnavn, maalested);
            hourlyViewModel.Hour06 = GetHourAverage(date, " 6", stofnavn, maalested);
            hourlyViewModel.Hour07 = GetHourAverage(date, " 7", stofnavn, maalested);
            hourlyViewModel.Hour08 = GetHourAverage(date, " 8", stofnavn, maalested);
            hourlyViewModel.Hour09 = GetHourAverage(date, " 9", stofnavn, maalested);
            hourlyViewModel.Hour10 = GetHourAverage(date, " 10", stofnavn, maalested);
            hourlyViewModel.Hour11 = GetHourAverage(date, " 11", stofnavn, maalested);
            hourlyViewModel.Hour12 = GetHourAverage(date, " 12", stofnavn, maalested);
            hourlyViewModel.Hour13 = GetHourAverage(date, " 13", stofnavn, maalested);
            hourlyViewModel.Hour14 = GetHourAverage(date, " 14", stofnavn, maalested);
            hourlyViewModel.Hour15 = GetHourAverage(date, " 15", stofnavn, maalested);
            hourlyViewModel.Hour16 = GetHourAverage(date, " 16", stofnavn, maalested);
            hourlyViewModel.Hour17 = GetHourAverage(date, " 17", stofnavn, maalested);
            hourlyViewModel.Hour18 = GetHourAverage(date, " 18", stofnavn, maalested);
            hourlyViewModel.Hour19 = GetHourAverage(date, " 19", stofnavn, maalested);
            hourlyViewModel.Hour20 = GetHourAverage(date, " 20", stofnavn, maalested);
            hourlyViewModel.Hour21 = GetHourAverage(date, " 21", stofnavn, maalested);
            hourlyViewModel.Hour22 = GetHourAverage(date, " 22", stofnavn, maalested);
            hourlyViewModel.Hour23 = GetHourAverage(date, " 23", stofnavn, maalested);
        }
        private void ViewBagItems()
        {
            ViewBag.Stof = from s in DataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in DataContextTable.Maalested select s.Maalested1;
        }
    }
}