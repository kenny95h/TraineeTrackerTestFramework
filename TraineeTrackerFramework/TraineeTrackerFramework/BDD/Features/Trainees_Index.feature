Feature: Trainees_Index

User Journey 2: As an Admin user, I want to have access to a list of added trainees, so that I can manage them

@UserJourney2
@HappyPath
Scenario: Admin View All Trainees
	Given I log in as an Admin
	When I am redirected to the Trainees page
	Then I should see a list of all Trainees

@UserJourney2
@HappyPath
Scenario: Trainer View All Trainees
	Given I log in as a Trainer
	When I am redirected to the Trainees page
	Then I should see a list of all Trainees