(function () {
    var MovieReviewController = function ($scope, movieService, $log, $routeParams) {
        var getMovies = function (data) {
            $scope.Movies = data;
        };

        var errorDetails = function (data) {
            $scope.ErrorMessage = "Something went wrong";
        };

        

        movieService.movies().then(getMovies, errorDetails);

        $scope.Title = "Movies this week!";
    };

    app.controller("MovieReviewController", ["$scope", "movieService", "$log", "$routeParams", MovieReviewController]);
}());

//This is temp