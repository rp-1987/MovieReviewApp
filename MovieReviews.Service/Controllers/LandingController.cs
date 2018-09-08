using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReviews.Domain;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LandingController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var movies = await adaptor.movieRepository.GetAllMoviesWithReviews();
                

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
                                    RatingComp = adaptor.movieRepository.GetRating(m.Id)
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
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var movy = await adaptor.movieRepository.GetMovie(id);
                var reviews = await adaptor.reviewsRepository.GetReviewsByMovie(id);
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
                                  RatingComp = adaptor.movieRepository.GetRating(movy.Id)
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
