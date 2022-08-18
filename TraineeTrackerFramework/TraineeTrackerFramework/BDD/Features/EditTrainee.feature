Feature: EditTrainee

Gherkin Scripts for editing trainee, two based on priveledge level.

@tag1
Scenario: Admin Edit Trainee
	Given I am logged in as an admin
	And I am on the index page
	When I press edit link
	Then I should be taken to the edit trainee page

Scenario: Trainer Edit Trainee
	Given I am logged in as a trainer
	And I am on the index page
	When I press edit link
	Then I should be taken to the edit trainee page


