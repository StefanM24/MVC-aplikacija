using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class GradController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(int page = 1)
        {
            var model = db.Grad_set.ToList().ToPagedList(page, 5);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradID, NazivGrada, PostanskiBroj")] Grad grad)
        {
            if (ModelState.IsValid)
            {
                db.Grad_set.Add(grad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grad);
        }

        public ActionResult Edit(int id)
        {
            Grad grad = db.Grad_set.Find(id);

            return View(grad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradID, NazivGrada, PostanskiBroj")] Grad grad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grad);
        }

        public ActionResult Delete(int id)
        {
            Grad grad = db.Grad_set.Find(id);

            return View(grad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grad grad = db.Grad_set.Find(id);
            db.Grad_set.Remove(grad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Grad grad = db.Grad_set.Find(id);

            return View(grad);
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