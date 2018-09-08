using MovieReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReviews.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<string> AddMovie(Movy movie);
        Task<List<Movy>> GetAllMovies();
        Task<List<Movy>> GetAllMoviesWithReviews();
        Task<Movy> GetMovie(int id);
        RatingComp GetRating(int movieid);
    }
}
