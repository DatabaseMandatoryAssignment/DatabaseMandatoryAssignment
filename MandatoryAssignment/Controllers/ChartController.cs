using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class ChartController : Controller
    {
        private readonly DataContext _dataContext = new DataContext();
        public ActionResult Index()
        {
            var monthlyStat = new MonthlyStat();

            SetMonths(monthlyStat);
            return View(monthlyStat);
        }
        public ActionResult BarChart()
        {
            var monthlyStat = new MonthlyStat();

            SetMonths(monthlyStat);
            return View(monthlyStat);
        }
        public ActionResult DonutChart()
        {
            var monthlyStat = new MonthlyStat();

            SetMonths(monthlyStat);
            return View(monthlyStat);
        }
        private int GetMonthsCount(int month)
        {
            return (from q in _dataContext.Ambient where q.DatoMaerke.Month == month select q).Count();
        }

        private void SetMonths(MonthlyStat monthlyStat)
        {
            monthlyStat.January = GetMonthsCount(1);
            monthlyStat.February = GetMonthsCount(2);
            monthlyStat.March = GetMonthsCount(3);
            monthlyStat.April = GetMonthsCount(4);
            monthlyStat.May = GetMonthsCount(5);
            monthlyStat.June = GetMonthsCount(6);
            monthlyStat.July = GetMonthsCount(7);
            monthlyStat.August = GetMonthsCount(8);
            monthlyStat.September = GetMonthsCount(9);
            monthlyStat.October = GetMonthsCount(10);
            monthlyStat.November = GetMonthsCount(11);
            monthlyStat.December = GetMonthsCount(12);
        }
    }
}