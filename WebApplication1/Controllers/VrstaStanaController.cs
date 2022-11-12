using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VrstaStanaController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string unetarec)
        {
            var model = db.VrstaStana_set.Where(s => unetarec == null || s.NazivVrste.Contains(unetarec)).ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VrstaStanaID, NazivVrste")] VrstaStana vrstastana)
        {
            if (ModelState.IsValid)
            {
                db.VrstaStana_set.Add(vrstastana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrstastana);
        }

        public ActionResult Edit(int id)
        {
            VrstaStana vrstastana = db.VrstaStana_set.Find(id);

            return View(vrstastana);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VrstaStanaID, NazivVrste")] VrstaStana vrstastana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrstastana).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrstastana);
        }

        public ActionResult Delete(int id)
        {
            VrstaStana vrstastana = db.VrstaStana_set.Find(id);

            return View(vrstastana);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VrstaStana vrstastana = db.VrstaStana_set.Find(id);
            db.VrstaStana_set.Remove(vrstastana);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            VrstaStana vrstastana = db.VrstaStana_set.Find(id);
            return View(vrstastana);
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