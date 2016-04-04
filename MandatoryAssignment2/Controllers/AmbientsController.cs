using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MandatoryAssignment2.Models;

namespace MandatoryAssignment2.Controllers
{
    [Authorize]
    public class AmbientsController : Controller
    {
        private DataContextTable db = new DataContextTable();

        // GET: Ambients
        public async Task<ActionResult> Index()
        {
            var ambient = db.Ambient.Include(a => a.Enhed).Include(a => a.Maalested).Include(a => a.Opstilling).Include(a => a.Stof).Include(a => a.Udstyr);
            return View(await ambient.Take(10000).ToListAsync());
        }

        // GET: Ambients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambient ambient = await db.Ambient.FindAsync(id);
            if (ambient == null)
            {
                return HttpNotFound();
            }
            return View(ambient);
        }

        // GET: Ambients/Create
        public ActionResult Create()
        {
            ViewBag.EnhedId = new SelectList(db.Enhed, "EnhedId", "EnhedNavn");
            ViewBag.MaaleStedId = new SelectList(db.Maalested, "MaalestedId", "Maalested1");
            ViewBag.OpstillingId = new SelectList(db.Opstilling, "OpstillingId", "OpstillingNavn");
            ViewBag.StofId = new SelectList(db.Stof, "StofId", "StofNavn");
            ViewBag.UdstyrId = new SelectList(db.Udstyr, "UdstyrId", "UdstyrNavn");
            return View();
        }

        // POST: Ambients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AmbientId,MaaleStedId,DatoMaerke,OpstillingId,StofId,Resultat,EnhedId,UdstyrId,Easting32,Northing32")] Ambient ambient)
        {
            if (ModelState.IsValid)
            {
                db.Ambient.Add(ambient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EnhedId = new SelectList(db.Enhed, "EnhedId", "EnhedNavn", ambient.EnhedId);
            ViewBag.MaaleStedId = new SelectList(db.Maalested, "MaalestedId", "Maalested1", ambient.MaaleStedId);
            ViewBag.OpstillingId = new SelectList(db.Opstilling, "OpstillingId", "OpstillingNavn", ambient.OpstillingId);
            ViewBag.StofId = new SelectList(db.Stof, "StofId", "StofNavn", ambient.StofId);
            ViewBag.UdstyrId = new SelectList(db.Udstyr, "UdstyrId", "UdstyrNavn", ambient.UdstyrId);
            return View(ambient);
        }

        // GET: Ambients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambient ambient = await db.Ambient.FindAsync(id);
            if (ambient == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnhedId = new SelectList(db.Enhed, "EnhedId", "EnhedNavn", ambient.EnhedId);
            ViewBag.MaaleStedId = new SelectList(db.Maalested, "MaalestedId", "Maalested1", ambient.MaaleStedId);
            ViewBag.OpstillingId = new SelectList(db.Opstilling, "OpstillingId", "OpstillingNavn", ambient.OpstillingId);
            ViewBag.StofId = new SelectList(db.Stof, "StofId", "StofNavn", ambient.StofId);
            ViewBag.UdstyrId = new SelectList(db.Udstyr, "UdstyrId", "UdstyrNavn", ambient.UdstyrId);
            return View(ambient);
        }

        // POST: Ambients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AmbientId,MaaleStedId,DatoMaerke,OpstillingId,StofId,Resultat,EnhedId,UdstyrId,Easting32,Northing32")] Ambient ambient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EnhedId = new SelectList(db.Enhed, "EnhedId", "EnhedNavn", ambient.EnhedId);
            ViewBag.MaaleStedId = new SelectList(db.Maalested, "MaalestedId", "Maalested1", ambient.MaaleStedId);
            ViewBag.OpstillingId = new SelectList(db.Opstilling, "OpstillingId", "OpstillingNavn", ambient.OpstillingId);
            ViewBag.StofId = new SelectList(db.Stof, "StofId", "StofNavn", ambient.StofId);
            ViewBag.UdstyrId = new SelectList(db.Udstyr, "UdstyrId", "UdstyrNavn", ambient.UdstyrId);
            return View(ambient);
        }

        // GET: Ambients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambient ambient = await db.Ambient.FindAsync(id);
            if (ambient == null)
            {
                return HttpNotFound();
            }
            return View(ambient);
        }

        // POST: Ambients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ambient ambient = await db.Ambient.FindAsync(id);
            db.Ambient.Remove(ambient);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
