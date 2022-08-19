# What we were testing

This project developed a framework for testing the Trainee Tracker app built by Sparta's C# Engineering 113 team. Two aspects of the app were subjected to testing - the web front-end GUI and the API that formed part of the server backend. 

After an initial assessment and meeting with stakeholders involved with building the app, it was decided to do some [*exploratory testing](https://www.atlassian.com/continuous-delivery/software-testing/exploratory-testing) to discover what existing functionality was, in order to have some basis to test against. Since we had access to the codebase, **white-box testing** was also done. 

# Tools used

Some of the tools that were used in the testing were:

- Visual Studio

- Postman

- Selenium IDE & WebDriver

- SpecFlow

  =============================================

# The Features and API end points under test

## API  Testing

### (Deduced) CRUD Functionality

This functionality was deduced from conversations with stakeholders, exploratory testing, etc.

#### Trainee

- Read Own Tracker
- Read Own Profile
- Update Tracker
- Update Own Profile

#### Trainer

- Update Trainee Profile Comments
- Read Trainee
- Read Own Profile
- Update Own Profile
- Create Trainee for Own Course
- Delete Trainee from Own Course

#### Admin

- Ability to access, update, create and delete everything

The base endpoint used was https://localhost:7234 endpoint, with a server running locally. This would give access to the login screen

From here the further endpoints that could be defined were:

| Endpoint       | Example                               | Function                           |
| -------------- | ------------------------------------- | ---------------------------------- |
| /Trainers      | https://localhost:7234/api/Trainers/  | to return all trainers             |
| /Trainers/<id> | https://localhost:7234/api/Trainers/2 | to access a specific trainer       |
| /Courses       | https://localhost:7234/api/Courses/   | to access all courses              |
| /Courses/<id>  | https://localhost:7234/api/Courses/2  | to access a specific course by id  |
| /Trainees      | https://localhost:7234/api/Trainees/  | to access all trainees             |
| /Trainees/<id> | https://localhost:7234/api/Trainees/  | to access a specific trainee by id |





# How to use the frameworks

# Collaborators 

# Defects found (raise as issues in GitHub Project board)

# How to extend the framework





