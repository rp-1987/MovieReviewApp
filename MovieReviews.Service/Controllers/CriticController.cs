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
    [EnableCors("*","*","*")]
    public class CriticController : ApiController
    {

        public async Task<IHttpActionResult> GetCritics()
        {
            try
            {
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var allCritics = await adaptor.criticsRepository.GetAllCritics();
                var criticsSelectList = from c in allCritics
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
