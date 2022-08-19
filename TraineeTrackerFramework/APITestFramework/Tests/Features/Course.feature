Feature: Course

Course CRUD functionality

@HappyPath
Scenario: Delete course
Given I am an admin
And I have setup a request with "3"
When I execute the the DELETE Course request
Then I am returned a status code 204

@HappyPath
Scenario: Create course
Given I am an admin
And I have setup a request with "Engineering121,2022-08-18T00:00:00,8,Charlie,Batten,Mr.,cb@spartaglobal.com,Trainer"
When I execute the CREATE Course request
Then the name of the course "Engineering121" is available in the database

@SadPath
Scenario: Create course as trainer
Given I am a trainer
And I have setup a request with "Engineering121,2022-08-18T00:00:00,8,Charlie,Batten,Mr.,cb@spartaglobal.com,Trainer"
When I execute the CREATE Course request
Then I am returned a status code 403


@SadPath
Scenario: Create course as admin with empty field
Given I am an admin
And I have setup a request with "2022-08-18T00:00:00,8,Charlie,Batten,Mr.,cb@spartaglobal.com,Trainer"
When I execute the CREATE Course request
Then I am returned an exception

@SadPath
Scenario: Delete course that does not exist
Given I am an admin
And I have setup a request with "10"
When I execute the the DELETE Course request
Then I am returned a status code 404