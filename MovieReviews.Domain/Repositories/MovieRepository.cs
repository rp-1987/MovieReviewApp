using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviews.Domain.Entities;

namespace MovieReviews.Domain.Repositories
{
    public class MovieRepository : MovieReviews.Domain.Repositories.IMovieRepository
    {
        MovieReviewContext context = new MovieReviewContext();

        public IEnumerable<Movy> GetAllMovies()
        {
            return context.Movies.AsEnumerable();
        }

        public IEnumerable<Movy> GetAllMoviesWithReviews()
        {
            return context.Movies.Where(x=> x.MovieReviews.Count() > 0).AsEnumerable();
        }

        public Movy GetMovie(int id)
        {
            return context.Movies.Where(x => x.Id == id).FirstOrDefault();
        }

        public string AddMovie(Movy movie)
        {
            if (context.Movies.Where(m => m.MovieName == movie.MovieName).Count() == 0)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
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
