//var baseUrl = "http://localhost:2423/";
var baseUrl = "http://localhost:52934/api/";
var app = angular.module("reviewApp", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "Main/Default.html",
            controller: "MovieReviewController"
        })
        .when("/Movie/:movyId", {
            templateUrl: "Main/MovieDetails.html",
            controller: "MovieDetailsController"
        })
        .when("/AddMovie", {
            templateUrl: "Main/AddMovie.html",
            controller: "MovieCrudController"
        })
        .when("/AddReview", {
            templateUrl: "Main/AddReview.html",
            controller: "ReviewCrudController"
        })
    .otherwise({ redirectTo: "/" })
});