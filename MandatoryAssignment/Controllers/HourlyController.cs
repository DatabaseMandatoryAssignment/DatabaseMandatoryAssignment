using System;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class HourlyController : BaseController, IChart
    {
        // POST methods

        // View methods
        public ActionResult LineChart()
        {
            return View();
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
    }
}