using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviews.Domain.Entities;
using MovieReviews.Domain.Repositories;

namespace MovieReviews.Models
{
    public class MovyViewModel
    {
        public int MovyId { get; set; }

        public string MovyName { get; set; }

        public string ReleaseDate { get; set; }
        
        public string Rating { get; set; }
        
        public string Director { get; set; }
        
        public string Studio { get; set; }
        
        public string Synopsis { get; set; }

        public RatingComp RatingComp { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}