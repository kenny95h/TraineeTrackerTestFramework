Feature: Edit Trainee

Admin and trainer can update trainee details

@HappyPath
Scenario: Editing Trainee as a Admin
	Given I am logged in as a admin
	And when I click on edit button for a trainee
	When I change the trainee details
	Then the details are updated in the database

@HappyPath
Scenario: Editing Trainee as a Trainer
	Given I am logged in as a trainer
	And when I click on edit button for a trainee
	When I change the trainee details
	Then the details are updated in the database