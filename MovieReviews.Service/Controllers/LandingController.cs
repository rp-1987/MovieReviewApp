using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReviews.Domain;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using MovieReviews.Domain.Repositories;

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LandingController : ApiController
    {
        private IMovieRepository movieRepository;
        private IReviewsRepository reviewRepository;

        public LandingController(IMovieRepository movieRepo, IReviewsRepository reviewRepo)
        {
            movieRepository = movieRepo;
            reviewRepository = reviewRepo;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {                
                var movies = await movieRepository.GetAllMoviesWithReviews();
                

                var moviesDto = from m in movies
                                select new
                                {
                                    MovyId = m.Id,
                                    MovyName = m.MovieName,
                                    ReleaseDate = m.ReleaseDate.ToString(),
                                    Rating = m.Rating,
                                    Director = m.Director,
                                    Studio = m.Studio,
                                    Synopsis = m.Synopsis,
                                    RatingComp = movieRepository.GetRating(m.Id)
                                };
                return Ok(moviesDto);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {                
                var movy = await movieRepository.GetMovie(id);
                var reviews = await reviewRepository.GetReviewsByMovie(id);
                var reviewsDto = (from r in reviews
                                  select new
                                  {
                                      CriticName = r.Critic.CriticName,
                                      Publication = r.Critic.Publication,
                                      ReviewUrl = r.ReviewUrl,
                                      ReviewRating = r.ReviewRatingNum.ToString() + "/" + r.ReviewRatingDen.ToString(),
                                      IsFavorable = r.IsGood,
                                      Synopsis = r.ReviewSynopsis
                                  }).ToList();
                var movyDto = 
                              new
                              {
                                  MovyId = movy.Id,
                                  MovyName = movy.MovieName,
                                  ReleaseDate = movy.ReleaseDate.ToString(),
                                  Rating = movy.Rating,
                                  Director = movy.Director,
                                  Studio = movy.Studio,
                                  Synopsis = movy.Synopsis,
                                  Reviews = reviewsDto,
                                  RatingComp = movieRepository.GetRating(movy.Id)
                              };
                return Ok(movyDto);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
