Feature: ViewTrainersDetails

A short summary of the feature

@HappyPath
Scenario: View Trainer Details
	Given I am logged in as an admin
	And I am on the index page
	When I click on detials link
	Then I land on the trianers detials page
