Feature: Trainers_Index

User Journey 3: As a user, I want to have access to a list of trainers, so that I can manage them

@UserJourney3
@HappyPath
Scenario: Admin View All Trainers
	Given I log in as an Admin
	When I navigate to the Trainers page
	Then I should see a list of all Trainers

@UserJourney3
@HappyPath
Scenario: Trainer View All Trainers
	Given I log in as a Trainer
	When I navigate to the Trainers page
	Then I should see a list of all Trainers