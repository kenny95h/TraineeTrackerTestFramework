Feature: TrainerFeature

Trainer CRUD functionality

@HappyPath
Scenario: Get Trainer with a valid endpoint
Given I have setup a request with "1"
When I execute the GET Trainer request
Then I should receive a status code of 200 

@SadPath
Scenario: Get Trainer with an invalid endpoint
Given I have setup a request with "roflmao_xD"
When I execute the GET Trainer request
Then I should receive a status code of 400

@HappyPath
Scenario: Create Trainer
Given I am an admin
And I have setup a request with "Thomas,Wolstencroft,Mr.,twolse@spartaglobal.com,Trainer"
When I execute the CREATE Trainer request
Then I should receive a status code of 201

@HappyPath
Scenario: Update Trainer
Given I am an admin
And I have setup a request with "7,Tommy,Wolstencroft,Mr.,twolse@spartaglobal.com,Trainer"
When I execute the UPDATE Trainer request
Then I should receive a status code of 200

@SadPath
Scenario: Update Trainer that doesn't exist
Given I am an admin
And I have setup a request with "9999wow,Tommy,Wolstencroft,Mr.,twolse@spartaglobal.com,Trainer"
When I execute the UPDATE Trainer request
Then I should receive a status code of 400


