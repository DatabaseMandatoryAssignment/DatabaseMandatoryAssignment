﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
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
            throw new NotImplementedException();
        }

        public ActionResult DonutChart()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ActionResult _DonutChart()
        {
            throw new NotImplementedException();
        }
        private void ViewBagItems()
        {
            ViewBag.Stof = from s in DataContextTable.Stof select s.StofNavn;
            ViewBag.Maalested = from s in DataContextTable.Maalested select s.Maalested1;
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
        private double? GetWeeksCount(DateTime startOfWeek, string stofnavn, string maalested)
        {
            if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
            {
                return (from q in DataContextView.AmbientView where q.DatoMaerke == startOfWeek select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(stofnavn))
            {
                return (from q in DataContextView.AmbientView where q.DatoMaerke == startOfWeek && q.Maalested == maalested select q.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(maalested))
            {
                return (from q in DataContextView.AmbientView where q.DatoMaerke == startOfWeek && q.StofNavn == stofnavn select q.Resultat).Average() ?? 0;
            }
            return (from q in DataContextTable.Ambient where q.DatoMaerke == startOfWeek && q.Stof.StofNavn == stofnavn && q.Maalested.Maalested1 == maalested select q.Resultat).Average() ?? 0;
        }
        private void SetWeeks(WeeklyViewModel weeklyViewModel, int weekNumber, string stofnavn = null, string maalested = null)
        {
            weeklyViewModel.MondayDate = GetDateByWeek(weekNumber, 0).ToString("yyyy-MM-dd");
            weeklyViewModel.TuesdayDate = GetDateByWeek(weekNumber, 1).ToString("yyyy-MM-dd");
            weeklyViewModel.WednesdayDate = GetDateByWeek(weekNumber, 2).ToString("yyyy-MM-dd");
            weeklyViewModel.ThursdayDate = GetDateByWeek(weekNumber, 3).ToString("yyyy-MM-dd");
            weeklyViewModel.FridayDate = GetDateByWeek(weekNumber, 4).ToString("yyyy-MM-dd");
            weeklyViewModel.SaturdayDate = GetDateByWeek(weekNumber, 5).ToString("yyyy-MM-dd");
            weeklyViewModel.SundayDate = GetDateByWeek(weekNumber, 6).ToString("yyyy-MM-dd");

            weeklyViewModel.Monday = GetWeeksCount(GetDateByWeek(weekNumber, 0), stofnavn, maalested);
            weeklyViewModel.Tuesday = GetWeeksCount(GetDateByWeek(weekNumber, 1), stofnavn, maalested);
            weeklyViewModel.Wednesday = GetWeeksCount(GetDateByWeek(weekNumber, 2), stofnavn, maalested);
            weeklyViewModel.Thursday = GetWeeksCount(GetDateByWeek(weekNumber, 3), stofnavn, maalested);
            weeklyViewModel.Friday = GetWeeksCount(GetDateByWeek(weekNumber, 4), stofnavn, maalested);
            weeklyViewModel.Saturday = GetWeeksCount(GetDateByWeek(weekNumber, 5), stofnavn, maalested);
            weeklyViewModel.Sunday = GetWeeksCount(GetDateByWeek(weekNumber, 6), stofnavn, maalested);
        }
    }
}