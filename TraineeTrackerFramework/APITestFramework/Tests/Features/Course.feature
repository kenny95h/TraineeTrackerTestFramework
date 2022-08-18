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
Scenario: Create Course with a valid endpoint
Given I am an admin
And I have setup a request with "Engineering120,2022-08-18T00:00:00,8,Charlie,Batten,Mr.,cb@spartaglobal.com,Trainer"
When I execute the CREATE Course request
Then I should receive a status code of 201 

@SadPath
Scenario: Create Course without permission
Given I am a trainer
And I have setup a request with "1"
When I execute the CREATE Course request
Then I should receive a status code of 400 

@SadPath
Scenario: Create Course with an invalid endpoint
Given I am an admin
And I have setup a request with ""
When I execute the CREATE Course request
Then I should receive a status code of 400 

@HappyPath
Scenario: Delete course
Given I am an admin
And I have setup a request with "1"
When I execute the the DELETE Course request
Then the course is no longer available in the database
