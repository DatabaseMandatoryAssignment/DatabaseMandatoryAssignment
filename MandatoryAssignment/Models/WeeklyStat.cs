using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MandatoryAssignment.Models
{
    public class WeeklyStat
    {
        public string MondayDate { get; set; }
        public string TuesdayDate { get; set; }
        public string WednesdayDate { get; set; }
        public string ThursdayDate { get; set; }
        public string FridayDate { get; set; }
        public string SaturdayDate { get; set; }
        public string SundayDate { get; set; }

        public double? Monday { get; set; }
        public double? Tuesday { get; set; }
        public double? Wednesday { get; set; }
        public double? Thursday { get; set; }
        public double? Friday { get; set; }
        public double? Saturday { get; set; }
        public double? Sunday { get; set; }
    }
}