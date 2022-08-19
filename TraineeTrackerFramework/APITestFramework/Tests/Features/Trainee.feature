Feature: Trainee

Trainee CRUD functionality

@HappyPath
Scenario: Get Trainee with a valid endpoint
Given I have setup a request with "1"
When I execute the GET Trainee request
Then I should receive a status code of 200 

@SadPath
Scenario: Get Trainee with an invalid endpoint
Given I have setup a request with "wrongy"
When I execute the GET Trainee request
Then I should receive a status code of 400

@HappyPath
Scenario: See all trainees on my courses as a Trainer
Given I am a trainer
When I request to read all trainees
Then I am displayed with all trainee details for my courses

@HappyPath
Scenario: Delete a trainee as a trainer
Given I am a trainer
And I have setup a request with "10"
When I execute the DELETE trainee request
Then I should receive a status code of 204