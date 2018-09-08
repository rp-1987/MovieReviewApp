using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviews.Domain.Entities;

namespace MovieReviews.Domain.Repositories
{
    public class CriticsRepository : ICriticsRepository
    {
        MovieReviewContext context = new MovieReviewContext();

        

        public async Task<List<Critic>> GetAllCritics()
        {
            return await context.Critics.ToListAsync();
        }


    }
}
