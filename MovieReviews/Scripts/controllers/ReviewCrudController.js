(function () {
    var ReviewCrudController = function ($scope, movieService, $log) {
        $scope.Message = "";
        $scope.AlertClass = "alert alert-info alert-dismissible";
        $scope.ShowAlert = false;
        

        var addSuccess = function (data) {
            $scope.Message = data.Message;
            $scope.AlertClass = "alert alert-success alert-dismissible";
            $scope.review = null;

        };

        var bindMovies = function (data) {
            $scope.Movies = data;
        }

        var bindCritics = function (data) {
            $scope.Critics = data;
        }

        $scope.Add = function () {
            
            $scope.ShowAlert = true;
            if (validateObject($scope.review)) {
                movieService.addReview($scope.review).then(addSuccess, handleError);
                
            }
        };

        var handleError = function (data) {
            $scope.Message = "Something went wrong";
        };

        var validateObject = function (reviewObj) {
            reviewObj.ReviewRatingDen = 5;
            var chk = true;
            if (reviewObj != null) {
                if (reviewObj.MovieId == null || reviewObj.MovieId.length == 0) {
                    $scope.Message += "Please Select Movie \n";
                    chk = false;
                }
                if (reviewObj.CriticId == null || reviewObj.CriticId.length == 0) {
                    $scope.Message += "Please Select Critic\n";
                    chk = false;
                }
                if (reviewObj.ReviewSynopsis == null || reviewObj.ReviewSynopsis.length == 0) {
                    $scope.Message += "Please give Synopsis \n";
                    chk = false;
                }
                if (reviewObj.ReviewRatingNum == null || reviewObj.ReviewRatingNum.length == 0) {
                    $scope.Message += "Please give Ratings \n";
                    chk = false;
                }
                if (reviewObj.IsGood == null) {
                    $scope.review.IsGood = false;
                }
                
            }
            else {
                $scope.Message += "Please Add Review details \n";
                chk = false;
            }
            return chk;
        }

        movieService.getMovieList().then(bindMovies, handleError);
        movieService.getCriticsList().then(bindCritics, handleError);
    };

    app.controller("ReviewCrudController", ["$scope", "movieService", "$log", ReviewCrudController]);
}());