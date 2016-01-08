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
    public class VisiteMedicalesController : Controller
    {
        private DBIG3A3Entities db = new DBIG3A3Entities();

        // GET: VisiteMedicales
        public ActionResult Index()
        {
            var visiteMedicales = db.VisiteMedicales.Include(v => v.Emploi).Include(v => v.Lieu);
            return View(visiteMedicales.ToList());
        }

        

        // GET: VisiteMedicales/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            if (visiteMedicale == null)
            {
                return HttpNotFound();
            }
            return View(visiteMedicale);
        }

        // GET: VisiteMedicales/Create
        public ActionResult Create()
        {
            ViewBag.IdEmploi = new SelectList(db.Personnes, "IdPersonne", "Nom");
            ViewBag.IdLieu = new SelectList(db.Lieux, "IdLieu", "Localite");
            return View();
        }

        // POST: VisiteMedicales/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVisiteMedicale,Date,IdEmploi,IdLieu")] VisiteMedicale visiteMedicale)
        {
            if (ModelState.IsValid)
            {
                db.VisiteMedicales.Add(visiteMedicale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmploi = new SelectList(db.Emplois, "IdEmploi", "TypeEmploi", visiteMedicale.IdEmploi);
            ViewBag.IdLieu = new SelectList(db.Lieux, "IdLieu", "Localite", visiteMedicale.IdLieu);
            return View(visiteMedicale);
        }

        // GET: VisiteMedicales/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            if (visiteMedicale == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmploi = new SelectList(db.Personnes, "IdPersonne", "Nom", visiteMedicale.IdEmploi);
            ViewBag.IdLieu = new SelectList(db.Lieux, "IdLieu", "Localite", visiteMedicale.IdLieu);
            return View(visiteMedicale);
        }

        // POST: VisiteMedicales/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVisiteMedicale,Date,IdEmploi,IdLieu")] VisiteMedicale visiteMedicale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiteMedicale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmploi = new SelectList(db.Emplois, "IdEmploi", "TypeEmploi", visiteMedicale.IdEmploi);
            ViewBag.IdLieu = new SelectList(db.Lieux, "IdLieu", "Localite", visiteMedicale.IdLieu);
            return View(visiteMedicale);
        }

        // GET: VisiteMedicales/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            if (visiteMedicale == null)
            {
                return HttpNotFound();
            }
            return View(visiteMedicale);
        }

        // POST: VisiteMedicales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            db.VisiteMedicales.Remove(visiteMedicale);
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
