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
And I have setup a request with "1,1,stoppy,staaaarty,continue working,nocomment,100,4000,null"
When I execute the CREATE Tracker request
Then I should receive a status code of 200

@HappyPath
Scenario: Update tracker
Given I am a trainer
And I have setup a request with "1,1,stoppy,starty,continue working,nocomment,100,4000,null"
When I execute the UPDATE Tracker request
Then I should receive a status code of 200
