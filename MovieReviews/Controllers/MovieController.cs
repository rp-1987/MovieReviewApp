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
    public class MovieController : Controller
    {
        // GET: Movie

        public MovieRepository movieRepository;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movy movie)
        {
            movieRepository = new MovieRepository();
            string Message = movieRepository.AddMovie(movie);
            return Json(new { Message = Message });
        }

        [HttpPost]
        public ActionResult GetAllMovies()
        {
            movieRepository = new MovieRepository();
            var allMovies = movieRepository.GetAllMovies();
            var movieList = from m in allMovies.AsEnumerable()
                            select new MoviesSelectListViewModel
                            {
                                MovieId = m.Id,
                                MovieName = m.MovieName
                            };
            return Json(movieList);
        }
    }
}