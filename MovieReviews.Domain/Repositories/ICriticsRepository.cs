using System;
namespace MovieReviews.Domain.Repositories
{
    public interface ICriticsRepository
    {
        System.Collections.Generic.IEnumerable<MovieReviews.Domain.Entities.Critic> GetAllCritics();
    }
}
