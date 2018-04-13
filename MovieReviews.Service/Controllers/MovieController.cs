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

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MovieController : ApiController
    {
        public IHttpActionResult Post(Object obj)
        {
            try
            {
                var jsonString = obj.ToString();
                Movy movie = JsonConvert.DeserializeObject<Movy>(jsonString);
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var message = adaptor.movieRepository.AddMovie(movie);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        public IHttpActionResult Get()
        {
            try
            {
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var allMovies = adaptor.movieRepository.GetAllMovies();
                var movieList = from m in allMovies.AsEnumerable()
                                select new
                                {
                                    MovieId = m.Id,
                                    MovieName = m.MovieName
                                };
                return Ok(movieList);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
