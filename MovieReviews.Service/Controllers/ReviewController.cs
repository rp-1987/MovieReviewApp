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
    public class ReviewController : ApiController
    {
        //public IHttpActionResult Get(int id)
        //{
        //    try
        //    {
        //        RepositoryAdaptor adaptor = new RepositoryAdaptor();
        //        var movieReviews = adaptor.reviewsRepository.GetReviewsByMovie(id);
        //        return Ok(movieReviews);
        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }
        //}

        public IHttpActionResult Post(Object obj)
        {
            try
            {
                var jsonString = obj.ToString();
                MovieReview review = JsonConvert.DeserializeObject<MovieReview>(jsonString); 
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var message = adaptor.reviewsRepository.AddMovieReview(review);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
