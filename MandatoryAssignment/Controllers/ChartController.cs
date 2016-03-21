using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class ChartController : Controller
    {
        private readonly DataContextTable _dataContextTable = new DataContextTable();
        private readonly DataContextView _dataContextView = new DataContextView();
        [HttpPost]
        public ActionResult Index(string stofNavn, string maalested)
        {
            var monthlyStat = new MonthlyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(monthlyStat, stofNavn, maalested);

            return View(monthlyStat);
        }
        [HttpPost]
        public ActionResult BarChart(string stofNavn, string maalested)
        {
            var monthlyStat = new MonthlyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(monthlyStat, stofNavn, maalested);

            return View(monthlyStat);
        }
        [HttpPost]
        public ActionResult DonutChart(string stofNavn, string maalested)
        {
            var monthlyStat = new MonthlyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(monthlyStat, stofNavn, maalested);

            return View(monthlyStat);
        }
        public ActionResult Index()
        {
            var monthlyStat = new MonthlyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetMonths(monthlyStat);
            return View(monthlyStat);
        }
        [HttpPost]
        public ActionResult WeeklyIndex(int weekNumber, string stofNavn, string maalested)
        {
            var weeklyStat = new WeeklyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            SetWeeks(weeklyStat, weekNumber, stofNavn, maalested);

            return View(weeklyStat);
        }
        public ActionResult WeeklyIndex()
        {
            var weeklyStat = new WeeklyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            var currentWeek = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            ViewBag.CurrentWeek = currentWeek.ToString();
            SetWeeks(weeklyStat, currentWeek);
            return View(weeklyStat);
        }
        public DateTime GetDateByWeek(int weekNumber, int dayOfWeek)
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
        public ActionResult _LineChart()
        {
            var monthlyStat = new MonthlyStat();


            SetMonths(monthlyStat);
            return PartialView(monthlyStat);
        }
        public ActionResult BarChart()
        {
            var monthlyStat = new MonthlyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;
            
            SetMonths(monthlyStat);
            return View(monthlyStat);
        }
        public ActionResult _BarChart()
        {
            var monthlyStat = new MonthlyStat();

            SetMonths(monthlyStat);
            return PartialView(monthlyStat);
        }
        public ActionResult DonutChart()
        {
            var monthlyStat = new MonthlyStat();

            ViewBag.Stof = from s in _dataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in _dataContextTable.Maalested select s.Maalested1;
            
            SetMonths(monthlyStat);
            return View(monthlyStat);
        }
        public ActionResult _DonutChart()
        {
            var monthlyStat = new MonthlyStat();

            SetMonths(monthlyStat);
            return PartialView(monthlyStat);
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
        private double? GetWeeksCount(DateTime startOfWeek, string stofnavn, string maalested)
        {
            if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
            {
                return (from q in _dataContextView.AmbientView where q.DatoMaerke == startOfWeek select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(stofnavn))
            {
                return (from q in _dataContextView.AmbientView where q.DatoMaerke == startOfWeek && q.Maalested == maalested select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(maalested))
            {
                return (from q in _dataContextView.AmbientView where q.DatoMaerke == startOfWeek && q.StofNavn == stofnavn select q.Resultat).Average() ?? 0;
            }
            return (from q in _dataContextTable.Ambient where q.DatoMaerke == startOfWeek && q.Stof.StofNavn == stofnavn && q.Maalested.Maalested1 == maalested select q.Resultat).Average() ?? 0;
        }

        private void SetMonths(MonthlyStat monthlyStat, string stofnavn = null, string maalested = null)
        {
            monthlyStat.January = GetMonthsCount(1, stofnavn, maalested);
            monthlyStat.February = GetMonthsCount(2, stofnavn, maalested);
            monthlyStat.March = GetMonthsCount(3, stofnavn, maalested);
            monthlyStat.April = GetMonthsCount(4, stofnavn, maalested);
            monthlyStat.May = GetMonthsCount(5, stofnavn, maalested);
            monthlyStat.June = GetMonthsCount(6, stofnavn, maalested);
            monthlyStat.July = GetMonthsCount(7, stofnavn, maalested);
            monthlyStat.August = GetMonthsCount(8, stofnavn, maalested);
            monthlyStat.September = GetMonthsCount(9, stofnavn, maalested);
            monthlyStat.October = GetMonthsCount(10, stofnavn, maalested);
            monthlyStat.November = GetMonthsCount(11, stofnavn, maalested);
            monthlyStat.December = GetMonthsCount(12, stofnavn, maalested);
        }
        private void SetWeeks(WeeklyStat weeklyStat, int weekNumber, string stofnavn = null, string maalested = null)
        {
            weeklyStat.MondayDate = GetDateByWeek(weekNumber, 0).ToString("yyyy-MM-dd");
            weeklyStat.TuesdayDate = GetDateByWeek(weekNumber, 1).ToString("yyyy-MM-dd");
            weeklyStat.WednesdayDate = GetDateByWeek(weekNumber, 2).ToString("yyyy-MM-dd");
            weeklyStat.ThursdayDate = GetDateByWeek(weekNumber, 3).ToString("yyyy-MM-dd");
            weeklyStat.FridayDate = GetDateByWeek(weekNumber, 4).ToString("yyyy-MM-dd");
            weeklyStat.SaturdayDate = GetDateByWeek(weekNumber, 5).ToString("yyyy-MM-dd");
            weeklyStat.SundayDate = GetDateByWeek(weekNumber, 6).ToString("yyyy-MM-dd");

            weeklyStat.Monday = GetWeeksCount(GetDateByWeek(weekNumber, 0), stofnavn, maalested);
            weeklyStat.Tuesday = GetWeeksCount(GetDateByWeek(weekNumber, 1), stofnavn, maalested);
            weeklyStat.Wednesday = GetWeeksCount(GetDateByWeek(weekNumber, 2), stofnavn, maalested);
            weeklyStat.Thursday = GetWeeksCount(GetDateByWeek(weekNumber, 3), stofnavn, maalested);
            weeklyStat.Friday = GetWeeksCount(GetDateByWeek(weekNumber, 4), stofnavn, maalested);
            weeklyStat.Saturday = GetWeeksCount(GetDateByWeek(weekNumber, 5), stofnavn, maalested);
            weeklyStat.Sunday = GetWeeksCount(GetDateByWeek(weekNumber, 6), stofnavn, maalested);
        }
    }
}