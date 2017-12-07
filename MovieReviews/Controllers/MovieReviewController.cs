using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviews.Domain.Entities;
using MovieReviews.Domain.Repositories;
using MovieReviews.Models;

namespace MovieReviews.Controllers
{
    public class MovieReviewController : Controller
    {
        // GET: MovieReview
        public ReviewsRepository reviewsRepository;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetReviews(int movieId)
        {
            reviewsRepository = new ReviewsRepository();
            var movieReviews = reviewsRepository.GetReviewsByMovie(movieId);
            return Json(movieReviews, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult AddReview(MovieReview review)
        {
            reviewsRepository = new ReviewsRepository();
            var message = reviewsRepository.AddMovieReview(review);
            return Json(new { Message = message });
        }
    }
}