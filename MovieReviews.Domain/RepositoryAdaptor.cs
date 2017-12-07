using MovieReviews.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviews.Domain
{
    public class RepositoryAdaptor
    {
        public ICriticsRepository criticsRepository;
        public IMovieRepository movieRepository;
        public IReviewsRepository reviewsRepository;

        public RepositoryAdaptor()
        {
            criticsRepository = new CriticsRepository();
            movieRepository = new MovieRepository();
            reviewsRepository = new ReviewsRepository();
        }


    }
}
