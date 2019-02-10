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
    [EnableCors("*","*","*")]
    public class CriticController : ApiController
    {
        private ICriticsRepository repo;
        
        public CriticController(ICriticsRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IHttpActionResult> GetCritics()
        {
            try
            {                
                var allCritics = await repo.GetAllCritics();
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
