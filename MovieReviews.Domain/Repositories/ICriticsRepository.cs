using MovieReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReviews.Domain.Repositories
{
    public interface ICriticsRepository
    {
        Task<List<Critic>> GetAllCritics();
    }
}
