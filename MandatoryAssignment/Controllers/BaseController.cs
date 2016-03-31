using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public class BaseController : Controller
    {
        protected const string Message = "MESSAGE";
        protected const string Notice = "NOTICE";
        protected const string Warning = "WARNING";
        protected const string Error = "ERROR";

        protected readonly DataContextTable DataContextTable = new DataContextTable();
        protected readonly DataContextView DataContextView = new DataContextView();

        protected void Log(string message, string type)
        {
            Trace.WriteLine(message, type + " - [" + DateTime.Now + "]");
        }
    }
}