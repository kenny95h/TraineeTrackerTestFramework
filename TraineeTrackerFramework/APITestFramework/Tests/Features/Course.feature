Feature: Course

Course CRUD functionality

@HappyPath
Scenario: Get Course with a valid endpoint
Given I have setup a request with "1"
When I execute the GET Course request
Then I should receive a status code of 200 

@SadPath
Scenario: Get Course with an invalid endpoint
Given I have setup a request with "cheesegromit"
When I execute the GET Course request
Then I should receive a status code of 400

@HappyPath
Scenario: Delete course
Given I am an admin
And I have setup a request with "1"
When I execute the the DELETE Course request
Then the course is no longer available in the database
