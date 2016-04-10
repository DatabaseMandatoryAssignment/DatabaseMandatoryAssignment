using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment2.Controllers
{
    public class WeeklyController : BaseController, IChart
    {
        private readonly WeeklyViewModel _weeklyViewModel = new WeeklyViewModel();
        // POST methods
        [HttpPost]
        public ActionResult LineChart(int weekNumber, string stofNavn, string maalested)
        {
            ViewBagItems();

            SetWeeks(_weeklyViewModel, weekNumber, stofNavn, maalested);
            return View(_weeklyViewModel);
        }
        [HttpPost]
        public ActionResult BarChart(int weekNumber, string stofNavn, string maalested)
        {
            ViewBagItems();

            SetWeeks(_weeklyViewModel, weekNumber, stofNavn, maalested);
            return View(_weeklyViewModel);
        }
        [HttpPost]
        public ActionResult DonutChart(int weekNumber, string stofNavn, string maalested)
        {
            ViewBagItems();

            SetWeeks(_weeklyViewModel, weekNumber, stofNavn, maalested);
            return View(_weeklyViewModel);
        }
        // View methods
        public ActionResult LineChart()
        {
            ViewBagItems();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();
            SetWeeks(_weeklyViewModel, currentWeek);

            return View(_weeklyViewModel);
        }

        public ActionResult BarChart()
        {
            ViewBagItems();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();
            SetWeeks(_weeklyViewModel, currentWeek);

            return View(_weeklyViewModel);
        }

        public ActionResult DonutChart()
        {
            ViewBagItems();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();
            SetWeeks(_weeklyViewModel, currentWeek);

            return View(_weeklyViewModel);
        }

        // Partial view methods
        public ActionResult _LineChart()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();

            SetWeeks(_weeklyViewModel, currentWeek);
            return PartialView(_weeklyViewModel);
        }

        public ActionResult _BarChart()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();

            SetWeeks(_weeklyViewModel, currentWeek);
            return PartialView(_weeklyViewModel);
        }

        public ActionResult _DonutChart()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();

            SetWeeks(_weeklyViewModel, currentWeek);
            return PartialView(_weeklyViewModel);
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
        private DateTime GetDateByWeek(int weekNumber, int dayOfWeek)
        {
            DateTime jan1 = new DateTime(2015, 1, 1);
            int daysOffset = DayOfWeek.Tuesday - jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);

            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(jan1, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekNumber;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            var result = firstMonday.AddDays(weekNum * 7 + dayOfWeek - 1);
            return result;
        }
        private double? GetWeeksAverage(DateTime startOfWeek, string stofnavn, string maalested)
        {
            try
            {

                if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
                {
                    return (from a in DataContextView.AmbientView where a.DatoMaerke == startOfWeek select a.Resultat).Average() ?? 0;
                }
                if (string.IsNullOrEmpty(stofnavn))
                {
                    return (from a in DataContextView.AmbientView where a.DatoMaerke == startOfWeek && a.Maalested == maalested select a.Resultat).Average() ?? 0;
                }
                if (string.IsNullOrEmpty(maalested))
                {
                    return (from a in DataContextView.AmbientView where a.DatoMaerke == startOfWeek && a.StofNavn == stofnavn select a.Resultat).Average() ?? 0;
                }
                return (from a in DataContextTable.Ambient where a.DatoMaerke == startOfWeek && a.Stof.StofNavn == stofnavn && a.Maalested.Maalested1 == maalested select a.Resultat).Average() ?? 0;
            }
            catch (Exception)
            {
                Log("Could not calculate average!", Error);
            }
            return null;
        }
        private void SetWeeks(WeeklyViewModel weeklyViewModel, int weekNumber, string stofnavn = null, string maalested = null)
        {
            try
            {
                weeklyViewModel.MondayDate = GetDateByWeek(weekNumber, 0).ToString("yyyy-MM-dd");
                weeklyViewModel.TuesdayDate = GetDateByWeek(weekNumber, 1).ToString("yyyy-MM-dd");
                weeklyViewModel.WednesdayDate = GetDateByWeek(weekNumber, 2).ToString("yyyy-MM-dd");
                weeklyViewModel.ThursdayDate = GetDateByWeek(weekNumber, 3).ToString("yyyy-MM-dd");
                weeklyViewModel.FridayDate = GetDateByWeek(weekNumber, 4).ToString("yyyy-MM-dd");
                weeklyViewModel.SaturdayDate = GetDateByWeek(weekNumber, 5).ToString("yyyy-MM-dd");
                weeklyViewModel.SundayDate = GetDateByWeek(weekNumber, 6).ToString("yyyy-MM-dd");

                weeklyViewModel.Monday = GetWeeksAverage(GetDateByWeek(weekNumber, 0), stofnavn, maalested);
                weeklyViewModel.Tuesday = GetWeeksAverage(GetDateByWeek(weekNumber, 1), stofnavn, maalested);
                weeklyViewModel.Wednesday = GetWeeksAverage(GetDateByWeek(weekNumber, 2), stofnavn, maalested);
                weeklyViewModel.Thursday = GetWeeksAverage(GetDateByWeek(weekNumber, 3), stofnavn, maalested);
                weeklyViewModel.Friday = GetWeeksAverage(GetDateByWeek(weekNumber, 4), stofnavn, maalested);
                weeklyViewModel.Saturday = GetWeeksAverage(GetDateByWeek(weekNumber, 5), stofnavn, maalested);
                weeklyViewModel.Sunday = GetWeeksAverage(GetDateByWeek(weekNumber, 6), stofnavn, maalested);
            }
            catch (Exception)
            {
                Log("Could not set weeks!", Error);
            }
        }
    }
}