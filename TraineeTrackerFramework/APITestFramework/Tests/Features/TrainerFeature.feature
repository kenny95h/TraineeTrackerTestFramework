Feature: TrainerFeature

Trainer CRUD functionality

@HappyPath
Scenario: Trying to get a Trainer with an valid endpoint
Given I have setup a GET request with an endpoint "1"
When I execute the request
Then I should receive a status code of 200 

@SadPath
Scenario: Trying to get a Trainer with an invalid endpoint
Given I have setup a GET request with an endpoint "roflmao_xD"
When I execute the request
Then I should receive a status code of 400

