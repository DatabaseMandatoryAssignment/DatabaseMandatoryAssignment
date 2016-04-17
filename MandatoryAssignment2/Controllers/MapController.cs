using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment2.Models;

namespace MandatoryAssignment2.Controllers
{
    public class MapController : BaseController
    {
        public ActionResult Index()
        {
            List<double?> number = new List<double?>();
            try
            {
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "H.C. Andersen Boulevard, Skur" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Jagtvej, Skur" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Anholt, Radar stationen" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Føllesbjerg" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Odense Gade,Skur 5, Odense Albanigade" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Århus gade (3)" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "H.C.Ørsted Inst." select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Odense Tag (2)" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Aalborg Tag ny" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Ulborg" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Risø" select q.Resultat).Average() ?? 0);
                number.Add((from q in DataContextView.AmbientView where q.Maalested == "Aarhus Botanisk" select q.Resultat).Average() ?? 0);
            }
            catch (Exception)
            {
                Log("Could not calculate average!", Error);
            }

            return View(number);
        }
    }
}