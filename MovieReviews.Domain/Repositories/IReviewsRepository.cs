using System;
namespace MovieReviews.Domain.Repositories
{
    public interface IReviewsRepository
    {
        string AddMovieReview(MovieReviews.Domain.Entities.MovieReview review);
        System.Collections.Generic.IEnumerable<MovieReviews.Domain.Entities.MovieReview> GetReviewsByMovie(int movieId);
    }
}
