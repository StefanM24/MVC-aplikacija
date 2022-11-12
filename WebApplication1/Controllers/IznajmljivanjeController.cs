using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    [Authorize(Users = "stefan@gmail.com")]//lozinka:Stefke1*
    public class IznajmljivanjeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            var model = db.Iznajmljivanje_set.OrderBy(s => s.DatumPocetka).ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            var upit = (from p in db.Podstanar_set
                        select new { p.PodstanarID, Ime = p.Ime + " " + p.Prezime.ToString() }).ToList();

            ViewBag.StanID = new SelectList(db.Stan_set, "StanID", "Adresa");
            ViewBag.PodstanarID = new SelectList(upit, "PodstanarID", "Ime");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IznajmljivanjeID, DatumPocetka,StanID,PodstanarID")] Iznajmljivanje iznajmljivanje)
        {
            if (ModelState.IsValid)
            {
                db.Iznajmljivanje_set.Add(iznajmljivanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StanID = new SelectList(db.Stan_set, "StanID", "Adresa", iznajmljivanje.StanID);
            ViewBag.PodstanarID = new SelectList(db.Podstanar_set, "PodstanarID", "Ime", iznajmljivanje.PodstanarID);

            return View(iznajmljivanje);
        }

        public ActionResult Edit(int id)
        {
            var upit = (from p in db.Podstanar_set
                        select new { p.PodstanarID, Ime = p.Ime + " " + p.Prezime.ToString() }).ToList();

            Iznajmljivanje iznajmljivanje = db.Iznajmljivanje_set.Find(id);

            ViewBag.StanID = new SelectList(db.Stan_set, "StanID", "Adresa", iznajmljivanje.StanID);
            ViewBag.PodstanarID = new SelectList(upit, "PodstanarID", "Ime", iznajmljivanje.PodstanarID);

            return View(iznajmljivanje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IznajmljivanjeID, DatumPocetka,StanID,PodstanarID")] Iznajmljivanje iznajmljivanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iznajmljivanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StanID = new SelectList(db.Stan_set, "StanID", "Adresa", iznajmljivanje.StanID);
            ViewBag.PodstanarID = new SelectList(db.Podstanar_set, "PodstanarID", "Ime", iznajmljivanje.PodstanarID);

            return View(iznajmljivanje);
        }

        public ActionResult Delete(int id)
        {
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanje_set.Find(id);

            return View(iznajmljivanje);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanje_set.Find(id);
            db.Iznajmljivanje_set.Remove(iznajmljivanje);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanje_set.Find(id);

            return View(iznajmljivanje);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}