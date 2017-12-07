(function () {
    var testController = function ($scope) {
        

        $scope.Title = "Movies this week!";
    };

    app.controller("testController", ["$scope", testController]);
}());