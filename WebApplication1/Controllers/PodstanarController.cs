using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Users ="stefan@gmail.com")]
    public class PodstanarController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            var model = db.Podstanar_set.OrderBy(s => s.Prezime).ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PodstanarID, Ime, Prezime, JMBG, BrojTelefona")] Podstanar podstanar)
        {
            if(ModelState.IsValid)
            {
                db.Podstanar_set.Add(podstanar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podstanar);
        }

        public ActionResult Edit(int id)
        {
            Podstanar podstanar = db.Podstanar_set.Find(id);

            return View(podstanar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PodstanarID, Ime, Prezime, JMBG, BrojTelefona")] Podstanar podstanar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podstanar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podstanar);
        }

        public ActionResult Delete(int id)
        {
            Podstanar podstanar = db.Podstanar_set.Find(id);

            return View(podstanar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Podstanar podstanar = db.Podstanar_set.Find(id);
            db.Podstanar_set.Remove(podstanar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Podstanar podstanar = db.Podstanar_set.Find(id);

            return View(podstanar);
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