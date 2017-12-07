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
    public class HomeController : Controller
    {
        // GET: Home

        public MovieRepository movieRepository;
        public ReviewsRepository reviewRepository;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMovy(int Id)
        {
            movieRepository = new MovieRepository();
            reviewRepository = new ReviewsRepository();
            Movy movy = movieRepository.GetMovie(Id);
            var reviews = reviewRepository.GetReviewsByMovie(Id);
            MovyViewModel movyVm = MovieViewModelOperations.TransformMovy(movy);
            movyVm.Reviews = MovieViewModelOperations.TransformReviews(reviews);
            movyVm.RatingComp = movieRepository.GetRating(Id);
            return Json(movyVm, JsonRequestBehavior.DenyGet);                        
        }

        [HttpPost]
        public ActionResult GetMovies()
        {
            movieRepository = new MovieRepository();
            IEnumerable<Movy> movies = movieRepository.GetAllMoviesWithReviews();
            //var moviesTemp = movieRepository.GetAllMoviesTest();
            IEnumerable<MovyViewModel> moviesVm = MovieViewModelOperations.TransformMovies(movies);
            var moviesList = moviesVm.ToList();
            foreach (var m in moviesList)
            {
                m.RatingComp = movieRepository.GetRating(m.MovyId);
            }

            return Json(moviesList, JsonRequestBehavior.DenyGet);
        }

        public ActionResult TestRunner()
        {
            return View();
        }


    }
}