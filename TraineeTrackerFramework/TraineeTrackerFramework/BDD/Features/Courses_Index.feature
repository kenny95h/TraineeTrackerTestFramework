Feature: Courses_Index

User Journey 4: As an Admin user, I want to have access to a list of all courses, so that I can manage them

@UserJourney4
@HappyPath
Scenario: Admin View All Courses
	Given I log in as an Admin
	When I navigate to the Courses page
	Then I should see a list of all Courses

@UserJourney4
@HappyPath
Scenario: Trainer View All Courses
	Given I log in as a Trainer
	When I navigate to the Courses page
	Then I should see a list of all Courses