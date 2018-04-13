using System;
using System.Collections.Generic;
namespace MovieReviews.Domain.Repositories
{
    public interface ICriticsRepository
    {
        IEnumerable<MovieReviews.Domain.Entities.Critic> GetAllCritics();
    }
}
