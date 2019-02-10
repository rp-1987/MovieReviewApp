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
using MovieReviews.Domain.Repositories;

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReviewController : ApiController
    {
        private IReviewsRepository reviewsRepository;

        public ReviewController(IReviewsRepository reviewsRepo)
        {
            reviewsRepository = reviewsRepo;
        }

        public async Task<IHttpActionResult> Post(Object obj)
        {
            try
            {
                var jsonString = obj.ToString();
                MovieReview review = JsonConvert.DeserializeObject<MovieReview>(jsonString);                
                var message = await reviewsRepository.AddMovieReview(review);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
