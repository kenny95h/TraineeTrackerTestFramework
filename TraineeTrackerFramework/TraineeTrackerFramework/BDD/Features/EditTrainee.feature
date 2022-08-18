Feature: EditTrainee

Gherkin Scripts for editing trainee, two based on priveledge level.

@tag1
Scenario: Admin Edit Trainee
	Given I am logged in as an admin
	And I am on the trainee list
	When I press edit on <trainer>
	Then I should be taken to the edit trainee page

Scenario: Trainer Edit Trainee
	Given I am logged in as a trainer
	And I am on the trainee list
	When I press edit on <trainer>
	Then I should be taken to the edit trainee page


