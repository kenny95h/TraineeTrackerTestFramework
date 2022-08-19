Feature: Trainee

Trainee CRUD functionality

@HappyPath
Scenario: Get Tracker with a valid endpoint
Given I have setup a request with "1"
When I execute the GET Trainee request
Then I should receive a status code of 200 

@SadPath
Scenario: Get Tracker with an invalid endpoint
Given I have setup a request with "wrongy"
When I execute the GET Trainee request
Then I should receive a status code of 400

#@HappyPath
#Scenario: See all trainees as an Admin
#Given I am an admin
#When I request to read all trainees
#Then I am dispalyed with all trainee details