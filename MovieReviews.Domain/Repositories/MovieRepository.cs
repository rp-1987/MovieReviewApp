using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MovieReviews.Domain.Entities;

namespace MovieReviews.Domain.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        MovieReviewContext context = new MovieReviewContext();

        public async Task<List<Movy>> GetAllMovies()
        {
            return await context.Movies.ToListAsync();
        }

        public async Task<List<Movy>> GetAllMoviesWithReviews()
        {
            return await context.Movies.Where(x=> x.MovieReviews.Count() > 0).ToListAsync();
        }

        public async Task<Movy> GetMovie(int id)
        {
            return await context.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> AddMovie(Movy movie)
        {
            if (context.Movies.Where(m => m.MovieName == movie.MovieName).Count() == 0)
            {
                context.Movies.Add(movie);
                await context.SaveChangesAsync();
                return "Added Successfully!";
            }
            return "Movie Already exists!";
        }

        public RatingComp GetRating(int movieid)
        {
            RatingComp rating = new RatingComp();
            rating.AverageRatings = CalculateAverageRatings(movieid);
            rating.ReviewPercentage = CalculateReviewPercentage(movieid);
            rating.ReviewCount = context.MovieReviews.Where(x => x.MovieId == movieid).Count();
            return rating;
        }

        private int CalculateReviewPercentage(int movieid)
        {
            decimal denominator = context.MovieReviews.Where(x => x.MovieId == movieid).Count();
            decimal numerator = context.MovieReviews.Where(x => (x.MovieId == movieid) && (x.IsGood)).Count();
            return Convert.ToInt32(numerator / denominator * 100);
        }

        private decimal CalculateAverageRatings(int movieid)
        {
            //decimal denominator = context.MovieReviews.Where(x => x.MovieId == movieid).Select(x => x.ReviewRatingDen).Sum();
            //decimal numerator = context.MovieReviews.Where(x => x.MovieId == movieid).Select(x => x.ReviewRatingNum).Sum();
            decimal averageRating = context.MovieReviews.Where(x => x.MovieId == movieid).Select(x => (x.ReviewRatingNum / x.ReviewRatingDen)).Sum();
            decimal reviewCount = context.MovieReviews.Where(x => x.MovieId == movieid).Count();
            return Math.Round((averageRating / reviewCount) * 10, 1);
        }
    }
}
