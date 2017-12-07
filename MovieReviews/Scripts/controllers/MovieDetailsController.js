(function () {
    var MovieDetailsController = function ($scope, movieService, $log, $routeParams) {
        var movieId = $routeParams.movyId;
        var getMovy = function (data) {
            $scope.Movy = data;
            
        };

       

        var errorDetails = function (data) {
            $scope.ErrorMessage = "Something went wrong";
        };



        movieService.movy(movieId).then(getMovy, errorDetails);
        


        $scope.Title = "Movies this week!";
    };

    app.controller("MovieDetailsController", ["$scope", "movieService", "$log", "$routeParams", MovieDetailsController]);
}());