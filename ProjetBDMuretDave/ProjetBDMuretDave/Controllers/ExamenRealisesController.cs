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
    public class ExamenRealisesController : Controller
    {
        private DBIG3A3Entities db = new DBIG3A3Entities();

        // GET: ExamenRealises
        public ActionResult Index()
        {
            var examenRealises = db.ExamenRealises.Include(e => e.TypeExaman).Include(e => e.VisiteMedicale);
            return View(examenRealises.ToList());
        }

        //Retourner les examens d'une visite médicale
        public ActionResult IndexExamen(decimal idVisite)
        {
            List<ExamenRealise> listExamen = (from m in db.ExamenRealises
                                              where m.IdVisiteMedicale == idVisite
                                              select m).ToList();
            return View(listExamen);
        }

        // GET: ExamenRealises/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenRealise examenRealise = db.ExamenRealises.Find(id);
            if (examenRealise == null)
            {
                return HttpNotFound();
            }
            return View(examenRealise);
        }

        // GET: ExamenRealises/Create
        public ActionResult Create(decimal idVisite)
        {
            ViewBag.IdTypeExamen = new SelectList(db.TypeExamen, "IdTypeExamen", "Libelle");
            //Pour que la dropdownList ne contienne que l'id de la visite pour laquelle on ajoute un examen
            ViewBag.IdVisiteMedicale = new SelectList(from v in db.VisiteMedicales where v.IdVisiteMedicale==idVisite select v.IdVisiteMedicale);
            //ViewBag.IdVisiteMedicale = new SelectList(db.VisiteMedicales, "IdVisiteMedicale", "IdVisiteMedicale");
            return View();
        }

        // POST: ExamenRealises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idExamenReal,Libelle,IdTypeExamen,IdVisiteMedicale,Resultat,Duree")] ExamenRealise examenRealise)
        {
            if (ModelState.IsValid)
            {
                db.ExamenRealises.Add(examenRealise);
                db.SaveChanges();
                return RedirectToAction("IndexExamen", new { idVisite = examenRealise.IdVisiteMedicale });
            }

            ViewBag.IdTypeExamen = new SelectList(db.TypeExamen, "IdTypeExamen", "Libelle", examenRealise.IdTypeExamen);
            ViewBag.IdVisiteMedicale = new SelectList(db.VisiteMedicales, "IdVisiteMedicale", "IdVisiteMedicale", examenRealise.IdVisiteMedicale);
            return View(examenRealise);
        }

        // GET: ExamenRealises/Edit/5
        public ActionResult Edit(decimal id,decimal idVisite)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenRealise examenRealise = db.ExamenRealises.Find(id);
            if (examenRealise == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTypeExamen = new SelectList(db.TypeExamen, "IdTypeExamen", "Libelle", examenRealise.IdTypeExamen);
            //ViewBag.IdVisiteMedicale = new SelectList(db.VisiteMedicales, "IdVisiteMedicale", "IdVisiteMedicale", examenRealise.IdVisiteMedicale);
            ViewBag.IdVisiteMedicale = new SelectList(from v in db.VisiteMedicales where v.IdVisiteMedicale == idVisite select v.IdVisiteMedicale);
            return View(examenRealise);
        }

        // POST: ExamenRealises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExamenReal,Libelle,IdTypeExamen,IdVisiteMedicale,Resultat,Duree")] ExamenRealise examenRealise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenRealise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexExamen" ,new { idVisite = examenRealise.IdVisiteMedicale });
            }
            ViewBag.IdTypeExamen = new SelectList(db.TypeExamen, "IdTypeExamen", "Libelle", examenRealise.IdTypeExamen);
            ViewBag.IdVisiteMedicale = new SelectList(db.VisiteMedicales, "IdVisiteMedicale", "IdVisiteMedicale", examenRealise.IdVisiteMedicale);
            return View(examenRealise);
        }

        // GET: ExamenRealises/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenRealise examenRealise = db.ExamenRealises.Find(id);
            if (examenRealise == null)
            {
                return HttpNotFound();
            }
            return View(examenRealise);
        }

        // POST: ExamenRealises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ExamenRealise examenRealise = db.ExamenRealises.Find(id);
            db.ExamenRealises.Remove(examenRealise);
            db.SaveChanges();
            return RedirectToAction("IndexExamen", new { idVisite = examenRealise.IdVisiteMedicale });
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
