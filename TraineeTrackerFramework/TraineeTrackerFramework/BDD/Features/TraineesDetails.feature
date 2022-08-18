Feature: TraineesDetails

A logged-in admin or trainer is able to view details of trainees

@HappyPath
Scenario: 6.1.1 Admin view a trainee details
	Given I am logged in as an admin on the trainee list page
	When I click Details
	Then I should land on the trainee details page
