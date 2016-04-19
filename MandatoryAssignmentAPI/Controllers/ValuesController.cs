using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MandatoryAssignmentAPI.Models;

namespace MandatoryAssignmentAPI.Controllers
{
    [AllowAnonymous]
    public class ValuesController : ApiController
    {
        protected readonly DataContextTable DataContextTable = new DataContextTable();
        protected readonly DataContextView DataContextView = new DataContextView();


        [HttpGet]
        public List<string> MaalestedList()
        {
            return (from m in DataContextTable.Maalested select m.Maalested1).ToList();
        }

        [HttpGet]
        public List<string> StofList()
        {
            return (from s in DataContextTable.Stof select s.StofNavn).ToList();
        }
        [HttpGet]
        public double? GetMonthsAverage(int month, string stofnavn = null, string maalested = null)
        {

            if (string.IsNullOrEmpty(stofnavn) && string.IsNullOrEmpty(maalested))
            {
                return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month select a.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(stofnavn))
            {
                return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month && a.Maalested == maalested select a.Resultat).Average() ?? 0;
            }
            if (string.IsNullOrEmpty(maalested))
            {
                return (from a in DataContextView.AmbientView where a.DatoMaerke.Month == month && a.StofNavn == stofnavn select a.Resultat).Average() ?? 0;
            }
            return (from a in DataContextTable.Ambient where a.DatoMaerke.Month == month && a.Stof.StofNavn == stofnavn && a.Maalested.Maalested1 == maalested select a.Resultat).Average() ?? 0;
        }
        
    }
}
