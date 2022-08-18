Feature: EditTrainer

The page for editing trainer details.

@EditForename
Scenario: EditTrainersFirstName
	Given I am logged in as admin
	And I am on the index page
	When I click edit trainer link
	And I edit the trainers first name
	Then The trainer's first name should be successfully updated

@EditLastname
Scenario: EditTrainersLastName
	Given I am logged in as admin
	And I am on the index page
	When I click edit trainer link
	And I edit the trainers last name
	Then The trainer's last name should be successfully updated

@EditTitle
Scenario: EditTrainersTitle
	Given I am logged in as admin
	And I am on the index page
	When I click edit trainer link
	And I edit the trainers title
	Then The trainer's title should be successfully updated

@EditEmail
Scenario: EditTrainersEmail
	Given I am logged in as admin
	And I am on the index page
	When I click edit trainer link
	And I edit the trainers email
	Then The trainer's email should be successfully updated

@EditContactNo
Scenario: EditTrainersContactNo
	Given I am logged in as admin
	And I am on the index page
	When I click edit trainer link
	And I edit the trainers contact number
	Then The trainer's contact number should be successfully updated

@EditContactNo
Scenario: EditTrainersPermissions
	Given I am logged in as an admin
	And I am on the index page
	When I click edit trainer link
	And I edit the trainers permission level
	Then The trainer's permission role should be successfully updated
