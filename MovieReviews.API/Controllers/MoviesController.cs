using MovieReviews.API.Models;
using MovieReviews.Domain;
using MovieReviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieReviews.API.Controllers
{
    public class MoviesController : ApiController
    {
        //public IEnumerable<MovieViewModel> GetMovies()
        //{
        //    RepositoryAdaptor repositoryAdaptor = new RepositoryAdaptor();
        //    var movies = repositoryAdaptor.movieRepository.GetAllMovies();
        //    var result = from m in movies
        //                 select new MovieViewModel
        //                 {
        //                     MovyId = m.Id,
        //                     MovyName = m.MovieName,
        //                     ReleaseDate = m.ReleaseDate,
        //                     Rating = m.Rating,
        //                     Studio = m.Studio,
        //                     Synopsis = m.Synopsis
        //                 };

        //    return result;
            
        //}
    }
}
