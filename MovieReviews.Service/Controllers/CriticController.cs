using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReviews.Domain;
using System.Web.Http.Cors;

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*","*","*")]
    public class CriticController : ApiController
    {

        public IHttpActionResult GetCritics()
        {
            try
            {
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var allCritics = adaptor.criticsRepository.GetAllCritics();
                var criticsSelectList = from c in allCritics.AsEnumerable()
                                        select new
                                        {
                                            CriticId = c.Id,
                                            CriticName = c.CriticName
                                        };
                return Ok(criticsSelectList);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }
    }
}
