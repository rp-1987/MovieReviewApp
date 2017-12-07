using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviews.Domain.Entities;

namespace MovieReviews.Domain.Repositories
{
    public class CriticsRepository : MovieReviews.Domain.Repositories.ICriticsRepository
    {
        MovieReviewContext context = new MovieReviewContext();

        public IEnumerable<Critic> GetAllCritics()
        {
            return context.Critics.AsEnumerable();            
        }

        
    }
}
