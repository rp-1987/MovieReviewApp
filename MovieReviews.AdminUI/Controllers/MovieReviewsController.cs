﻿using System;
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
    public class MovieReviewsController : Controller
    {
        private MovieReviewEntities db = new MovieReviewEntities();

        // GET: MovieReviews
        public ActionResult Index()
        {
            var movieReviews = db.MovieReviews.Include(m => m.Critic).Include(m => m.Movy);
            return View(movieReviews.ToList());
        }

        // GET: MovieReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = db.MovieReviews.Find(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            return View(movieReview);
        }

        // GET: MovieReviews/Create
        public ActionResult Create()
        {
            ViewBag.CriticId = new SelectList(db.Critics, "Id", "CriticName");
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName");
            return View();
        }

        // POST: MovieReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieId,CriticId,ReviewSynopsis,IsGood,ReviewRatingNum,ReviewRatingDen,ReviewUrl")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                db.MovieReviews.Add(movieReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriticId = new SelectList(db.Critics, "Id", "CriticName", movieReview.CriticId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName", movieReview.MovieId);
            return View(movieReview);
        }

        // GET: MovieReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = db.MovieReviews.Find(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriticId = new SelectList(db.Critics, "Id", "CriticName", movieReview.CriticId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName", movieReview.MovieId);
            return View(movieReview);
        }

        // POST: MovieReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieId,CriticId,ReviewSynopsis,IsGood,ReviewRatingNum,ReviewRatingDen,ReviewUrl")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriticId = new SelectList(db.Critics, "Id", "CriticName", movieReview.CriticId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName", movieReview.MovieId);
            return View(movieReview);
        }

        // GET: MovieReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = db.MovieReviews.Find(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            return View(movieReview);
        }

        // POST: MovieReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieReview movieReview = db.MovieReviews.Find(id);
            db.MovieReviews.Remove(movieReview);
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
