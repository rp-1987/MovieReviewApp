using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieReviews.AdminUI;

namespace MovieReviews.AdminUI.Controllers
{
    public class CriticsController : Controller
    {
        private MovieReviewEntities db = new MovieReviewEntities();

        // GET: Critics
        public ActionResult Index()
        {
            return View(db.Critics.ToList());
        }

        // GET: Critics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critic critic = db.Critics.Find(id);
            if (critic == null)
            {
                return HttpNotFound();
            }
            return View(critic);
        }

        // GET: Critics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Critics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CriticName,Publication,IsTopCritic")] Critic critic)
        {
            if (ModelState.IsValid)
            {
                db.Critics.Add(critic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(critic);
        }

        // GET: Critics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critic critic = db.Critics.Find(id);
            if (critic == null)
            {
                return HttpNotFound();
            }
            return View(critic);
        }

        // POST: Critics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CriticName,Publication,IsTopCritic")] Critic critic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(critic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(critic);
        }

        // GET: Critics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critic critic = db.Critics.Find(id);
            if (critic == null)
            {
                return HttpNotFound();
            }
            return View(critic);
        }

        // POST: Critics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Critic critic = db.Critics.Find(id);
            db.Critics.Remove(critic);
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
