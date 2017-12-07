using MovieReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviews.Domain.Repositories.SQLRepository
{
    public class CriticSQLRepository: ICriticsRepository
    {
        public IEnumerable<Entities.Critic> GetAllCritics()
        {
            using (var context = new MovieReviewContext())
            {
                List<Entities.Critic> critics = context.Critics.SqlQuery("usp_GetAllCritics").ToList();
                return critics.AsEnumerable();
            }
        }
    }
}
