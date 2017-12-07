using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviews.Domain.Entities;


namespace MovieReviews.Domain.Repositories
{
    public class ReviewsRepository : MovieReviews.Domain.Repositories.IReviewsRepository
    {
        private MovieReviewContext context = new MovieReviewContext();

        public IEnumerable<MovieReview> GetReviewsByMovie(int movieId)
        {
            return context.MovieReviews.Where(x => x.MovieId == movieId).AsEnumerable();
        }

        public string AddMovieReview(MovieReview review)
        {
            if (context.MovieReviews.Where(mr => mr.MovieId == review.MovieId && mr.CriticId == review.CriticId).Count() == 0)
            {
                context.MovieReviews.Add(review);
                context.SaveChanges();
                return "Added Successfully!";
            }
            return "Review Already exists!";
        }
    }
}
