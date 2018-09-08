using MovieReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReviews.Domain.Repositories
{
    public interface IReviewsRepository
    {
        Task<string> AddMovieReview(MovieReview review);
        Task<List<MovieReview>> GetReviewsByMovie(int movieId);
    }
}
