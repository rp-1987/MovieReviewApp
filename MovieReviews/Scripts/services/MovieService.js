(function () {
    var movieService = function ($http) {
        var movies = function () {
            return $http.post(baseUrl + "Home/GetMovies")
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        var movy = function (movieId) {
            return $http.post(baseUrl + "Home/GetMovy?Id=" + movieId)
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        var addMovie = function (movieObj) {
            return $http({
                method: 'POST',
                url: baseUrl + 'Movie/AddMovie',
                data: movieObj
            }).then(function (serviceResponse) {
                return serviceResponse.data;
            });
        };

        var addReview = function (reviewObj) {
            return $http({
                method: 'POST',
                url: baseUrl + 'MovieReview/AddReview',
                data: reviewObj
            }).then(function (serviceResponse) {
                return serviceResponse.data;
            });            
        };
        

        var getMovieList = function () {
            return $http.post(baseUrl + "Movie/GetAllMovies")
                        .then(function (serviceResponse) {
                            return serviceResponse.data;
                        });
        };

        var getCriticsList = function () {
            return $http.post(baseUrl + "Critic/GetAllCritics")
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