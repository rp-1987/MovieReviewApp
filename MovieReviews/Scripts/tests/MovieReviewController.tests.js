describe('Testing Movie Review Controller', function () {
    var $controller;
    var movieReviewService;

    beforeEach(function () {
        module('reviewApp');
        inject(function (_$controller_, _movieService_) {
            $controller = _$controller_;
            movieReviewService = _movieService_;
        });

        
    });

    it('Should Say "Movies this week!"', function () {
        var $scope = {},
            $log = {},
            $routeParams = {};
        var controller = $controller('MovieReviewController', { $scope: $scope, movieService: movieReviewService, $log: $log, $routeParams: $routeParams });
        expect($scope.Title).toEqual("Movies this week!");
    });
});