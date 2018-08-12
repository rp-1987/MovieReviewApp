Feature: LandingPage
	In order to view reviews of latest movies
	as a user
	I want a list of latest movie reviews

@mytag
Scenario: Get All Movies
	Given I have reached login page	
	When I check all the movies
	Then I should view all the movies
