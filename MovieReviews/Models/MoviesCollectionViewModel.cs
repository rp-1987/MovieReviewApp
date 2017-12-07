using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviews.Domain.Entities;
using MovieReviews.Domain.Repositories;

namespace MovieReviews.Models
{
    public class MoviesCollectionViewModel
    {
        public IEnumerable<MovyViewModel> Movies { get; set;}
    }
}