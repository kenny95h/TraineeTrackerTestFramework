Feature: TraineesDetails

A logged-in admin or trainer is able to view details of trainees

@HappyPath
Scenario: 6.1.1 Admin view a trainee details
	Given I am logged in with valid credentials
	And I am on the trainee index page
	When I click Details
	Then I should land on the trainee details page
