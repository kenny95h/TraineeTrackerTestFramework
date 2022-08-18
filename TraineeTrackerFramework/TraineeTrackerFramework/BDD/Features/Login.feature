Feature: Login

As a user, I want to be able to use my credentials, so that I can log in and out of the tracker

@HappyPath
Scenario: Admin Login
	Given I am on the Login page
	And I input valid admin credentials
	When I press the Login button
	Then I should be taken to the Index page

@HappyPath
Scenario: Trainer Login
	Given I am on the Login page
	And I input valid trainer credentials
	When I press the Login button
	Then I should be taken to the Index page

@HappyPath
Scenario: Trainee Login
	Given I am on the Login page
	And I input valid trainee credentials
	When I press the Login button
	Then I should be taken to the Tracker dashboard page

@HappyPath
Scenario: User Logout
	Given I am logged in as any user
	When I press the Logout button
	Then I should be taken to the Login page
