using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviews.Domain.Repositories.SQLRepository
{
    public class MoviesSQLRepository: IMovieRepository
    {
        public string AddMovie(Entities.Movy movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Movy> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Movy> GetAllMoviesWithReviews()
        {
            throw new NotImplementedException();
        }

        public Entities.Movy GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Entities.RatingComp GetRating(int movieid)
        {
            throw new NotImplementedException();
        }
    }
}
