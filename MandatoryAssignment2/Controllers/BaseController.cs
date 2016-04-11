using System;
using System.Diagnostics;
using System.Web.Mvc;
using MandatoryAssignment2.Models;
using MongoDB.Driver;
using SendGrid;

namespace MandatoryAssignment2.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DataContextTable DataContextTable = new DataContextTable();
        protected readonly DataContextView DataContextView = new DataContextView();
        protected static MongoClient Client = new MongoClient();
        protected static IMongoDatabase Db = Client.GetDatabase("DatabaseMandatoryDatabase");

        protected const string Message = "MESSAGE";
        protected const string Notice = "NOTICE";
        protected const string Warning = "WARNING";
        protected const string Error = "ERROR";

        protected void Log(string message, string type)
        {
            Trace.WriteLine(message, type + " - [" + DateTime.Now + "]");
        }
    }
}