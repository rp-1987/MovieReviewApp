using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviews.Domain.Entities;


namespace MovieReviews.Domain.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private MovieReviewContext context = new MovieReviewContext();

        public async Task<List<MovieReview>> GetReviewsByMovie(int movieId)
        {
            return await context.MovieReviews.Where(x => x.MovieId == movieId).ToListAsync();
        }

        public async Task<string> AddMovieReview(MovieReview review)
        {
            if (await context.MovieReviews.Where(mr => mr.MovieId == review.MovieId && mr.CriticId == review.CriticId).CountAsync() == 0)
            {
                context.MovieReviews.Add(review);
                await context.SaveChangesAsync();
                return "Added Successfully!";
            }
            return "Review Already exists!";
        }
    }
}
