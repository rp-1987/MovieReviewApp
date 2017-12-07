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
    public class CriticController : Controller
    {

        CriticsRepository repository;
        // GET: Critic
        [HttpPost]
        public ActionResult GetAllCritics()
        {
            repository = new CriticsRepository();
            var allCritics = repository.GetAllCritics();
            var criticsSelectList = from c in allCritics.AsEnumerable()
                                    select new CriticsSelectListViewModel
                                    {
                                        CriticId = c.Id,
                                        CriticName = c.CriticName
                                    };
            return Json(criticsSelectList);
        }


    }
}