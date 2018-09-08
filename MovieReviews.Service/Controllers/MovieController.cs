using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReviews.Domain;
using MovieReviews.Domain.Entities;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MovieController : ApiController
    {
        public async Task<IHttpActionResult> Post(Object obj)
        {
            try
            {
                var jsonString = obj.ToString();
                Movy movie = JsonConvert.DeserializeObject<Movy>(jsonString);
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var message = await adaptor.movieRepository.AddMovie(movie);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var allMovies = await adaptor.movieRepository.GetAllMovies();
                
                var movieList = allMovies
                                          .OrderByDescending(x => x.ReleaseDate)
                                          .Select(movie => new { MovieId = movie.Id, MovieName = movie.MovieName });
                return Ok(movieList);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
