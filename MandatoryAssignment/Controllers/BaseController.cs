using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment.Models;

namespace MandatoryAssignment.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly DataContextTable DataContextTable = new DataContextTable();
        protected readonly DataContextView DataContextView = new DataContextView();
    }
}