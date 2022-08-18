Feature: CourseFeature

Course CRUD functionality

@HappyPath
Scenario: Get Course with a valid endpoint
Given I have setup a request with "1"
When I execute the GET Course request
Then I should receive a status code of 200 

@SadPath
Scenario: Get Trainer with an invalid endpoint
Given I have setup a request with "roflmao_xD"
When I execute the GET Course request
Then I should receive a status code of 400
