(function () {
    var MovieCrudController = function ($scope, movieService, $log) {
        $scope.Message = "";
        $scope.AlertClass = "alert alert-info";
        $scope.ShowAlert = false;
        var addSuccess = function (data) {
            $scope.Message = data.Message;
            $scope.AlertClass = "alert alert-success";
            
        };

        var errorDetails = function (data) {
            $scope.Message = "There was some error while adding";
            $scope.AlertClass = "alert alert-danger";
        };
      
        

        $scope.Add = function () {
            $scope.ShowAlert = true;
            if (validateMovie($scope.movie)) {
                movieService.addMovie($scope.movie).then(addSuccess, errorDetails);
            }
            
        };

        var validateMovie = function (movieObj) {
            var chk = true;

            if (movieObj != null) {
                if (movieObj.MovieName == null || movieObj.MovieName.length == 0) {
                    $scope.Message += "Please Add movie name \n";
                    chk = false;
                }
                if (movieObj.ReleaseDate == null || movieObj.ReleaseDate.length == 0) {
                    $scope.Message += "Please Release Date \n";
                    chk = false;
                }
                if (movieObj.Rating == null || movieObj.Rating.length == 0) {
                    $scope.Message += "Please give CBFC rating \n";
                    chk = false;
                }
                if (movieObj.Director == null || movieObj.Director.length == 0) {
                    $scope.Message += "Please Add Director Name \n";
                    chk = false;
                }
                if (movieObj.Studio == null || movieObj.Studio.length == 0) {
                    $scope.Message += "Please Add Studio name \n";
                    chk = false;
                }
                if (movieObj.Synopsis == null || movieObj.Synopsis.length == 0) {
                    $scope.Message += "Please Add Synopsis for the movie \n";
                    chk = false;
                }
            }
            else {
                $scope.Message += "Please Add movie details \n";
                chk = false;
            }
            
            
            if (chk) {
                $scope.Message = "";
            }
           
            return chk;

        }
    };

    app.controller("MovieCrudController", ["$scope", "movieService", "$log", MovieCrudController]);
}());