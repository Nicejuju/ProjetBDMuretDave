using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetBDMuretDave.Models;

namespace ProjetBDMuretDave.Controllers
{
    public class LieuxController : Controller
    {
        private DBIG3A3Entities db = new DBIG3A3Entities();

        // GET: Lieux
        public ActionResult Index()
        {
            return View(db.Lieux.ToList());
        }

        // GET: Lieux/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return HttpNotFound();
            }
            return View(lieu);
        }

        // GET: Lieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lieux/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLieu,Localite,Type")] Lieu lieu)
        {
            if (ModelState.IsValid)
            {
                db.Lieux.Add(lieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lieu);
        }

        // GET: Lieux/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return HttpNotFound();
            }
            return View(lieu);
        }

        // POST: Lieux/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLieu,Localite,Type")] Lieu lieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lieu);
        }

        // GET: Lieux/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return HttpNotFound();
            }
            return View(lieu);
        }

        // POST: Lieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Lieu lieu = db.Lieux.Find(id);
            db.Lieux.Remove(lieu);
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
