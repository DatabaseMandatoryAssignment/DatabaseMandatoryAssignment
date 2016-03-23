using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MandatoryAssignment.Models
{
    interface IChart
    {
        ActionResult LineChart();
        ActionResult BarChart();
        ActionResult DonutChart();
        ActionResult _LineChart();
        ActionResult _BarChart();
        ActionResult _DonutChart();
    }
}
