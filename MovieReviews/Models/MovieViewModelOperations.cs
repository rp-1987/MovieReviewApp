using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviews.Domain.Entities;

namespace MovieReviews.Models
{
    public static class MovieViewModelOperations
    {
        public static MovyViewModel TransformMovy(Movy movy)
        {
            if (movy != null)
            {
                return new MovyViewModel
                {
                    MovyId = movy.Id,
                    MovyName = movy.MovieName,
                    ReleaseDate = movy.ReleaseDate.ToString(),
                    Rating = movy.Rating,
                    Director = movy.Director,
                    Studio = movy.Studio,
                    Synopsis = movy.Synopsis
                    //MoviePosters = movy.MoviePosters,
                    //MovieReviews = movy.MovieReviews
                };
            }
            else
            {
                return null;
            }
        }

        public static IEnumerable<ReviewViewModel> TransformReviews(IEnumerable<MovieReview> reviews)
        {
            if (reviews != null && reviews.Count() > 0)
            {
                var reviewsVm = from r in reviews
                                select new ReviewViewModel
                                {
                                    CriticName = r.Critic.CriticName,
                                    Publication = r.Critic.Publication,
                                    ReviewUrl = r.ReviewUrl,
                                    ReviewRating = r.ReviewRatingNum.ToString() + "/" + r.ReviewRatingDen.ToString(),
                                    IsFavorable = r.IsGood,
                                    Synopsis = r.ReviewSynopsis
                                };
                return reviewsVm;
            }
            return null;
        }


        public static IEnumerable<MovyViewModel> TransformMovies(IEnumerable<Movy> movies)
        {
            if (movies != null && movies.Count() > 0)
            {
                var moviesVm = from m in movies
                               select new MovyViewModel
                               {
                                   MovyId = m.Id,
                                   MovyName = m.MovieName,
                                   ReleaseDate = m.ReleaseDate.ToString(),
                                   Rating = m.Rating,
                                   Director = m.Director,
                                   Studio = m.Studio,
                                   Synopsis = m.Synopsis
                                   //MoviePosters = m.MoviePosters,
                                   //MovieReviews = m.MovieReviews
                               };
                return moviesVm;
            }
            else
            {
                return null;
            }
        }
    }
}