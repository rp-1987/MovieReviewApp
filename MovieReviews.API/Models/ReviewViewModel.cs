using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviews.API.Models
{
    public class ReviewViewModel
    {
        public string CriticName { get; set; }
        public string Publication { get; set; }
        public string ReviewUrl { get; set; }
        public string ReviewRating { get; set; }
        public bool IsFavorable { get; set; }
        public string Synopsis { get; set; }
    }
}