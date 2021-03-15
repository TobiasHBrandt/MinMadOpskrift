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
    public class OpskriftController : Controller
    {
        private MinMadOpskriftEntities db = new MinMadOpskriftEntities();

        // GET: Opskrift
        public ActionResult Index()
        {
            var opskrift = db.Opskrift.Include(o => o.Bruger);
            return View(opskrift.ToList());
        }

        // GET: Opskrift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opskrift opskrift = db.Opskrift.Find(id);
            if (opskrift == null)
            {
                return HttpNotFound();
            }
            return View(opskrift);
        }

        // GET: Opskrift/Create
        public ActionResult Create()
        {
            ViewBag.OpskriftID = new SelectList(db.Bruger, "ID", "Brugernavn");
            return View();
        }

        // POST: Opskrift/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OpskriftID,Title,Beskrivelse,Ingredienser")] Opskrift opskrift)
        {
            if (ModelState.IsValid)
            {
                db.Opskrift.Add(opskrift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OpskriftID = new SelectList(db.Bruger, "ID", "Brugernavn", opskrift.OpskriftID);
            return View(opskrift);
        }

        // GET: Opskrift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opskrift opskrift = db.Opskrift.Find(id);
            if (opskrift == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpskriftID = new SelectList(db.Bruger, "ID", "Brugernavn", opskrift.OpskriftID);
            return View(opskrift);
        }

        // POST: Opskrift/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OpskriftID,Title,Beskrivelse,Ingredienser")] Opskrift opskrift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opskrift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpskriftID = new SelectList(db.Bruger, "ID", "Brugernavn", opskrift.OpskriftID);
            return View(opskrift);
        }

        // GET: Opskrift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opskrift opskrift = db.Opskrift.Find(id);
            if (opskrift == null)
            {
                return HttpNotFound();
            }
            return View(opskrift);
        }

        // POST: Opskrift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opskrift opskrift = db.Opskrift.Find(id);
            db.Opskrift.Remove(opskrift);
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
