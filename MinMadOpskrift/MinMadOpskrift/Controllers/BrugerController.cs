using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MinMadOpskrift;

namespace MinMadOpskrift.Controllers
{
    [Route("api/Bruger")]
    public class BrugerController : Controller
    {
        private MinMadOpskriftEntities db = new MinMadOpskriftEntities();

        // GET: Bruger
        public ActionResult Index()
        {
            return View(db.Bruger.ToList());
        }

        // GET: Bruger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return HttpNotFound();
            }
            return View(bruger);
        }

        // GET: Bruger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bruger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Brugernavn,Password,Alder,Email")] Bruger bruger)
        {
            if (ModelState.IsValid)
            {
                db.Bruger.Add(bruger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bruger);
        }

        // GET: Bruger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return HttpNotFound();
            }
            return View(bruger);
        }

        // POST: Bruger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brugernavn,Password,Alder,Email")] Bruger bruger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bruger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bruger);
        }

        // GET: Bruger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return HttpNotFound();
            }
            return View(bruger);
        }

        // POST: Bruger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bruger bruger = db.Bruger.Find(id);
            db.Bruger.Remove(bruger);
            db.SaveChanges();
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
