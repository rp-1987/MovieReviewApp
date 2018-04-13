(function () {
    var movieService = function ($http) {
        var movies = function () {
            return $http.get(baseUrl + "Landing")
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        var movy = function (movieId) {
            return $http.get(baseUrl + "landing/" + movieId)
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        var addMovie = function (movieObj) {
            return $http({
                method: 'POST',
                url: baseUrl + 'movie',
                data: movieObj
            }).then(function (serviceResponse) {
                return serviceResponse.data;
            });
        };

        var addReview = function (reviewObj) {
            return $http({
                method: 'POST',
                url: baseUrl + 'review',
                data: reviewObj
            }).then(function (serviceResponse) {
                return serviceResponse.data;
            });            
        };
        

        var getMovieList = function () {
            return $http.get(baseUrl + "movie")
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        var getCriticsList = function () {
            return $http.get(baseUrl + "critic")
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        return {
            movies: movies,
            movy: movy,
            addMovie: addMovie,
            getMovieList: getMovieList,
            getCriticsList: getCriticsList,
            addReview: addReview
        };
    };
    var module = angular.module("reviewApp");
    module.factory("movieService", ["$http", movieService]);
}());