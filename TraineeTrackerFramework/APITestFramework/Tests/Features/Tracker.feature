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
Given I have setup a request with ""
When I execute the GET Tracker request
Then I should receive all the trackers

@HappyPath
Scenario: Get personal tracker
Given I am a trainee
And I have setup a request with "1/"
When I execute the GET Tracker request
Then I should receive a response equal to ""