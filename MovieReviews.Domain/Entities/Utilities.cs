using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviews.Domain.Entities
{
    public class RatingComp
    {
        public int ReviewPercentage { get; set; }
        public decimal AverageRatings { get; set; }
        public int ReviewCount { get; set; }
    }

    
}
