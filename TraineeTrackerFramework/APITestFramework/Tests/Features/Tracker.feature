Feature: Tracker

Tracker CRUD functionality

@HappyPath
Scenario: Get Tracker with a valid endpoint
Given I have setup a request with "1"
When I execute the GET Tracker request
Then I should receive a status code of 200 

@SadPath
Scenario: Get Tracker with an invalid endpoint
Given I have setup a request with "wrong"
When I execute the GET Tracker request
Then I should receive a status code of 400


@HappyPath
Scenario: Get all Trackers
Given I am an admin
Given I have setup a request with ""
When I execute the GET Tracker request
Then I should receive a status code of 200
And I should receive all the trackers

@SadPath
Scenario: Get all Trackers without permission
Given I am a trainee
Given I have setup a request with ""
When I execute the GET Tracker request
Then I should receive a status code of 403

@HappyPath
Scenario: Get personal tracker
Given I am a trainee
And I have setup a request with "1"
When I execute the GET Tracker request
Then I should receive a status code of 200
And I should receive a response containing "id"

@HappyPath
Scenario: Create tracker
Given I am an admin
And I have setup a request with "1,comment,1,1,David,Joyce,Mr.,DJ@SpartaGlobal.com,Trainee"
When I execute the CREATE Tracker request
Then I should receive a status code of 201

@HappyPath
Scenario: Update tracker
Given I am a trainer
And I have setup a request with "89,1,Added some more comments,1,1,David,Joyce,Mr.,DJ@SpartaGlobal.com,Trainee"
When I execute the UPDATE Tracker request
Then I should receive a status code of 200
