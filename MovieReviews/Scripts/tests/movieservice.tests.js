describe('Testing Movie Service', function () {
    var movieService, httpBackend;
    

    beforeEach(function () {
        //load module
        module('reviewApp');

        inject(function ($httpBackend, _movieService_) {
            movieService = _movieService_;
            httpBackend = $httpBackend;
        });
    });

    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

    //Check if Service is not null

    it('Check if Service exists', function () {
        expect(movieService).not.toBeNull();
    });

    it('Verify Service Call for GetMovies', function () {
        var returnData = {};

        httpBackend.expectPOST("http://localhost:2423/Home/GetMovies").respond(returnData);

        var returnedPromise = movieService.movies();

        var result;
        returnedPromise.then(function (response) {
            result = response;
        });

        httpBackend.flush();

        expect(result).toEqual(returnData);
    });


    it('GetMovies Should return HTTP 200', function () {
        var returnedPromise = movieService.movies();
        var mockResponse = [{ "MovyId": 1, "MovyName": "Pink", "ReleaseDate": "16-09-2016 12.00.00 AM", "Rating": "UA", "Director": "Aniruddha Roy Chowdhury", "Studio": "NH Studios", "Synopsis": "A lawyer with wild mood swings helps three women sue the men who attacked them.", "RatingComp": { "ReviewPercentage": 100, "AverageRatings": 8.5, "ReviewCount": 4 }, "Reviews": null }, { "MovyId": 2, "MovyName": "Baar Baar Dekho", "ReleaseDate": "09-09-2016 12.00.00 AM", "Rating": "U", "Director": "Nitya Mehra", "Studio": "Dharma Productions", "Synopsis": null, "RatingComp": { "ReviewPercentage": 40, "AverageRatings": 4.6, "ReviewCount": 5 }, "Reviews": null }, { "MovyId": 3, "MovyName": "Freaky Ali", "ReleaseDate": "16-09-2016 12.00.00 AM", "Rating": "UA", "Director": "Sohail Khan", "Studio": "Salman Khan Productions", "Synopsis": null, "RatingComp": { "ReviewPercentage": 33, "AverageRatings": 5.2, "ReviewCount": 6 }, "Reviews": null }, { "MovyId": 4, "MovyName": "Banjo", "ReleaseDate": "23-09-2016 12.00.00 AM", "Rating": "UA", "Director": "Ravi Jadhav", "Studio": "Nishka Lulla", "Synopsis": null, "RatingComp": { "ReviewPercentage": 40, "AverageRatings": 4.6, "ReviewCount": 5 }, "Reviews": null }, { "MovyId": 5, "MovyName": "M.S.Dhoni - The Untold Story", "ReleaseDate": "30-09-2016 12.00.00 AM", "Rating": "UA", "Director": "Neeraj Pandey", "Studio": "Rhiti Sports", "Synopsis": "Coaches, mentors and friends inspire young M.S. Dhoni (Sushant Singh Rajput) to become a master cricketer and captain of Team India.", "RatingComp": { "ReviewPercentage": 75, "AverageRatings": 6.3, "ReviewCount": 8 }, "Reviews": null }, { "MovyId": 6, "MovyName": "Ae Dil Hai Mushkil", "ReleaseDate": "28-10-2016 12.00.00 AM", "Rating": "UA", "Director": "Karan Johar", "Studio": "Dharma Productions", "Synopsis": "Love Story", "RatingComp": { "ReviewPercentage": 56, "AverageRatings": 5.5, "ReviewCount": 9 }, "Reviews": null }, { "MovyId": 7, "MovyName": "Drishyam", "ReleaseDate": "02-08-2015 12.00.00 AM", "Rating": "U", "Director": "Nishikant Kamath", "Studio": "Viacom 18", "Synopsis": "A school drop-out but intelligent man, Vijay runs a successful business and loves his family. When a dark incident threatens to ruin his family, he desperately tries to protect them at all costs.", "RatingComp": { "ReviewPercentage": 78, "AverageRatings": 7.1, "ReviewCount": 9 }, "Reviews": null }, { "MovyId": 8, "MovyName": "Shivaay", "ReleaseDate": "28-10-2016 12.00.00 AM", "Rating": "U", "Director": "Ajay Devgan", "Studio": "Ajay Devan", "Synopsis": "To protect his family, a stable and innocent Himalayan mountaineer transforms into a mean destroyer when he needs to.", "RatingComp": { "ReviewPercentage": 33, "AverageRatings": 4.5, "ReviewCount": 6 }, "Reviews": null }, { "MovyId": 11, "MovyName": "Dear Zindagi", "ReleaseDate": "25-11-2016 12.00.00 AM", "Rating": "UA", "Director": "Gauri Shinde", "Studio": "Dharma Productions, Red Chillies Entertainment, Hope Productions", "Synopsis": "An unconventional thinker (Shah Rukh Khan) helps a budding cinematographer (Alia Bhatt) gain a new perspective on life.", "RatingComp": { "ReviewPercentage": 67, "AverageRatings": 5.8, "ReviewCount": 9 }, "Reviews": null }, { "MovyId": 14, "MovyName": "Befikre", "ReleaseDate": "09-12-2016 12.00.00 AM", "Rating": "A", "Director": "Aditya Chopra", "Studio": "Yash Raj Films", "Synopsis": "NA", "RatingComp": { "ReviewPercentage": 33, "AverageRatings": 4.3, "ReviewCount": 6 }, "Reviews": null }, { "MovyId": 15, "MovyName": "Kahani 2", "ReleaseDate": "02-12-2016 12.00.00 AM", "Rating": "UA", "Director": "Sujoy Ghosh", "Studio": "Studio 18", "Synopsis": "Sequel To Kahani", "RatingComp": { "ReviewPercentage": 88, "AverageRatings": 5.9, "ReviewCount": 8 }, "Reviews": null }, { "MovyId": 16, "MovyName": "Dangal", "ReleaseDate": "23-12-2016 12.00.00 AM", "Rating": "UA", "Director": "Nitesh Tiwari", "Studio": "Aamir Khan Productions", "Synopsis": "It stars Aamir Khan as Mahavir Singh Phogat, who taught wrestling to his daughters Geeta Phogat and Babita Kumari. The former is India\u0027s first female wrestler to win at the 2010 Commonwealth Games, where she won the gold medal (55 kg). Her sister Babita Kumari won the silver (51 kg). \"Dangal\" is the Hindi term for \"a wrestling competition\".", "RatingComp": { "ReviewPercentage": 100, "AverageRatings": 8.0, "ReviewCount": 12 }, "Reviews": null }, { "MovyId": 17, "MovyName": "Rock On 2", "ReleaseDate": "11-11-2016 12.00.00 AM", "Rating": "UA", "Director": "Shujaat Saudagar", "Studio": "Excel Entertainment", "Synopsis": "Rock On 2 is a 2016 Indian rock musical drama film directed by Shujaat Saudagar, produced by Farhan Akhtar and Ritesh Sidhwani, and with music by Shankar-Ehsaan-Loy.", "RatingComp": { "ReviewPercentage": 14, "AverageRatings": 4.7, "ReviewCount": 7 }, "Reviews": null }, { "MovyId": 18, "MovyName": "Ti Sadhya Kay Karte", "ReleaseDate": "13-01-2017 12.00.00 AM", "Rating": "U", "Director": "Satish Rajwade", "Studio": "Zee Studios", "Synopsis": "Romance", "RatingComp": { "ReviewPercentage": 100, "AverageRatings": 7.0, "ReviewCount": 4 }, "Reviews": null }, { "MovyId": 19, "MovyName": "Raees", "ReleaseDate": "27-01-2017 12.00.00 AM", "Rating": "UA", "Director": "Rahul Dholakia", "Studio": "Excel Entertainment", "Synopsis": "A determined police officer (Nawazuddin Siddiqui) threatens to destroy a crime lord\u0027s (Shah Rukh Khan) powerful empire in Gujarat, India.", "RatingComp": { "ReviewPercentage": 58, "AverageRatings": 5.8, "ReviewCount": 12 }, "Reviews": null }];

        httpBackend
            .when('POST', "http://localhost:2423/Home/GetMovies")
            .respond(200, mockResponse)

        var result;
        returnedPromise.then(function (response) {
            result = response;
        });

        httpBackend.flush();

        expect(result).toEqual(mockResponse);
    });

});