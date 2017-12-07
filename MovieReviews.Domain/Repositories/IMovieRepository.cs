using System;
namespace MovieReviews.Domain.Repositories
{
    public interface IMovieRepository
    {
        string AddMovie(MovieReviews.Domain.Entities.Movy movie);
        System.Collections.Generic.IEnumerable<MovieReviews.Domain.Entities.Movy> GetAllMovies();
        System.Collections.Generic.IEnumerable<MovieReviews.Domain.Entities.Movy> GetAllMoviesWithReviews();
        MovieReviews.Domain.Entities.Movy GetMovie(int id);
        MovieReviews.Domain.Entities.RatingComp GetRating(int movieid);
    }
}
