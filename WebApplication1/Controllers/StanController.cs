using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class StanController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string unetarec)
        {
            var model = db.Stan_set.Where(s => unetarec == null || s.Adresa.Contains(unetarec)).ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.VrstaStanaID = new SelectList(db.VrstaStana_set, "VrstaStanaID", "NazivVrste");
            ViewBag.GradID = new SelectList(db.Grad_set, "GradID", "NazivGrada");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StanID,Kvadratura,Adresa,Sprat,Cena,Vlasnik,Stanje,Uknjizen,Namesten,DodatnaOpremljenost,VrstaStanaID,GradID")] Stan stan)
        {
            if (ModelState.IsValid)
            {
                db.Stan_set.Add(stan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VrstaStanaID = new SelectList(db.VrstaStana_set, "VrstaStanaID", "NazivVrste", stan.VrstaStanaID);
            ViewBag.GradID = new SelectList(db.Grad_set, "GradID", "NazivGrada", stan.GradID);

            return View(stan);
        }

        public ActionResult Edit(int id)
        {
            Stan stan = db.Stan_set.Find(id);

            ViewBag.VrstaStanaID = new SelectList(db.VrstaStana_set, "VrstaStanaID", "NazivVrste", stan.VrstaStanaID);
            ViewBag.GradID = new SelectList(db.Grad_set, "GradID", "NazivGrada", stan.GradID);

            return View(stan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StanID,Kvadratura,Adresa,Sprat,Cena,Vlasnik,Stanje,Uknjizen,Namesten,DodatnaOpremljenost,VrstaStanaID,GradID")] Stan stan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VrstaStanaID = new SelectList(db.VrstaStana_set, "VrstaStanaID", "NazivVrste", stan.VrstaStanaID);
            ViewBag.GradID = new SelectList(db.Grad_set, "GradID", "NazivGrada", stan.GradID);

            return View(stan);
        }

        public ActionResult Delete(int id)
        {
            Stan stan = db.Stan_set.Find(id);

            return View(stan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stan stan = db.Stan_set.Find(id);
            db.Stan_set.Remove(stan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Stan stan = db.Stan_set.Find(id);

            return View(stan);
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