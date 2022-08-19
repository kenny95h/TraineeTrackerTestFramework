# Introduction

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
| /Courses/<id>  | https://localhost:7234/api/Courses/1  | to access a specific course by id  |
| /Trainees      | https://localhost:7234/api/Trainees/  | to access all trainees             |
| /Trainees/<id> | https://localhost:7234/api/Trainees/4 | to access a specific trainee by id |
| /Trackers/     | https://localhost:7234/api/Trackers   | to access all trackers             |
| /Trackers/<id> | https://localhost:7234/api/Trackers/3 | to access a specific id            |

## Web Testing

![Postman](https://raw.githubusercontent.com/kenny95h/TraineeTrackerTestFramework/dev/images/postman-api.jpg)
=======
### Login Page

#### Features
```c#
Feature: Login

As a user, I want to be able to use my credentials, so that I can log in and out of the tracker

@HappyPath
Scenario: Admin Login
	Given I am on the Login page
	And I input valid admin credentials
	When I press the Login button
	Then I should be taken to the Index page

@HappyPath
Scenario: Trainer Login
	Given I am on the Login page
	And I input valid trainer credentials
	When I press the Login button
	Then I should be taken to the Index page

@HappyPath
Scenario: Trainee Login
	Given I am on the Login page
	And I input valid trainee credentials
	When I press the Login button
	Then I should be taken to the Tracker dashboard page

@HappyPath
Scenario: User Logout
	Given I am logged in as any user
	When I press the Logout button
	Then I should be taken to the Login page
```
#### Tests

<details>
    <summary>Step Definitions</summary>


```c#
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerFramework.lib;

namespace TraineeTrackerFramework.BDD.Steps
{
	[Binding]
	public class LoginStepDefinitions
	{
		public TT_Website<ChromeDriver> TT_Website { get; } = new TT_Website<ChromeDriver>();
		//private Credentials _credentials;

		[Given(@"I am on the Login page")]
		public void GivenIOnTheLoginPage()
		{
			//TT_Website.TT_Account_LoginPage.VisitLoginPage();
			TT_Website.SeleniumDriver.Navigate().GoToUrl(AppConfigReader.AccountLoginURL);
		}

		[Given(@"I input valid admin credentials")]
		public void GivenIInputValidAdminCredentials()
		{
			TT_Website.TT_Account_LoginPage.InputUsername("admin");
			TT_Website.TT_Account_LoginPage.InputPassword("password");
		}

		[When(@"I press the Login button")]
		public void WhenIPressTheLoginButton()
		{
			TT_Website.TT_Account_LoginPage.ClickSignIn();
		}

		[Then(@"I should be taken to the Index page")]
		public void ThenIShouldBeTakenToTheIndexPage()
		{
			Assert.That(TT_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.AdminIndexURL));
		}

		[Given(@"I input valid trainer credentials")]
		public void GivenIInputValidTrainerCredentials()
		{
			TT_Website.TT_Account_LoginPage.InputUsername("cfrench");
			TT_Website.TT_Account_LoginPage.InputPassword("password");
		}

		[Given(@"I input valid trainee credentials")]
		public void GivenIInputValidTraineeCredentials()
		{
			TT_Website.TT_Account_LoginPage.InputUsername("pbellaby");
			TT_Website.TT_Account_LoginPage.InputPassword("password");
		}

		[Then(@"I should be taken to the Tracker dashboard page")]
		public void ThenIShouldBeTakenToTheTrackerDashboardPage()
		{
			Assert.That(TT_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.TrackersIndexURL));
		}

		[Given(@"I am logged in as any user")]
		public void GivenIAmLoggedInAsAnyUser()
		{
			GivenIOnTheLoginPage();
			GivenIInputValidAdminCredentials();
			WhenIPressTheLoginButton();
		}

		[When(@"I press the Logout button")]
		public void WhenIPressTheLogoutButton()
		{
			TT_Website.TT_Admin_TT_IndexPage.LogOut();
		}

		[Then(@"I should be taken to the Login page")]
		public void ThenIShouldBeTakenToTheLoginPage()
		{
			Assert.That(TT_Website.SeleniumDriver.Url, Does.Contain(AppConfigReader.AccountLoginURL));
		}

		[AfterScenario]
		public void DisposeWebDriver()
		{
			TT_Website.SeleniumDriver.Quit();
		}
	}
}

```
</details>

#### Outcome

Trainer login test fails, this has been documented in the 'Defects' section below. Other tests pass.

### View Details Page


#### Featues

```c#


Feature: ViewTrainersDetails

A short summary of the feature

@HappyPath
Scenario: View Trainer Details Page
Given I am logged in as an admin
And I am on the index page
When I click on detials link
Then I land on the trianers detials page
      
```
<details>
  <summary>Step Definitions</summary>

  ```c#
    public class ViewTrainersDetailsStepDefinitions
      {
        public LoginStepDefinitions _loginStepDefinitions = new LoginStepDefinitions();


        [Given(@"I am logged in as an admin")]
        public void GivenIAmLoggedInAsAnAdmin()
        {
            _loginStepDefinitions.TT_Website.SeleniumDriver.Manage().Window.Maximize();
            _loginStepDefinitions.GivenIAmLoggedInAsAnyUser();
        }

        [Given(@"I am on the index page")]
        public void GivenIAmOnTheIndexPage()
        {
            _loginStepDefinitions.TT_Website.SeleniumDriver.Navigate().GoToUrl(AppConfigReader.AdminIndexURL);
        }

        [When(@"I click on detials link")]
        public void WhenIClickOnDetialsLink()
        {
            _loginStepDefinitions.TT_Website.TT_Admin_TT_IndexPage.ViewTraineeLnk();
        }

        [Then(@"I land on the trianers detials page")]
        public void ThenILandOnTheTrianersDetialsPage()
        {
            Assert.That(_loginStepDefinitions.TT_Website.SeleniumDriver.Url, Is.EqualTo("https://localhost:7234/Trainees/Details?id=1"));

        }

        [Then(@"I should see all the infomration on the trainer")]
        public void ThenIShouldSeeAllTheInfomrationOnTheTrainer()
        {
            throw new PendingStepException();
        }

    }
  ```
</details>

#### Outcome

All tests pass


### Index Page (View Trainees Details)

#### Features (from `TraineesDetails.feature`)

```
@HappyPath
Scenario: 6.1.1 Admin view a trainee details
	Given I am logged in as an admin on the trainee list page
	When I click Details
	Then I should land on the trainee details page

@HappyPath
Scenario: 6.1.2 Trainer view a trainee details
	Given I am logged in as a trainer on the trainee list page
	When I click Details
	Then I should land on the trainee details page
```

#### Tests

<details>
  <summary>Step Definitions</summary>

  ```csharp
    public class TraineesDetailsStepDefinitions
      {
        public LoginStepDefinitions _loginStepDefs = new LoginStepDefinitions();

        [Given(@"I am logged in as an admin on the trainee list page")]
        public void GivenIAmLoggedInAsAnAdmin()
        {
            _loginStepDefs.GivenIOnTheLoginPage();
            _loginStepDefs.GivenIInputValidAdminCredentials();
            _loginStepDefs.WhenIPressTheLoginButton();
        }

        [Given(@"I am logged in as a trainer on the trainee list page")]
        public void GivenIAmLoggedInAsATrainerOnTheTraineeListPage()
        {
            _loginStepDefs.GivenIOnTheLoginPage();
            _loginStepDefs.GivenIInputValidTrainerCredentials();
            _loginStepDefs.WhenIPressTheLoginButton();
            _loginStepDefs.TT_Website.SeleniumDriver.Navigate().GoToUrl("https://localhost:7234/Trainers/Index");
        }


        [When(@"I click Details")]
        public void WhenIClickDetails()
        {
            _loginStepDefs.TT_Website.SeleniumDriver.Manage().Window.Maximize();
            _loginStepDefs.TT_Website.TT_Trainers_IndexPage.ClickTraineeDetails();
        }

        [Then(@"I should land on the trainee details page")]
        public void ThenIShouldLandOnTheTraineeDetailsPage()
        {
            Assert.That(_loginStepDefs.TT_Website.SeleniumDriver.Url, Does.Contain("https://localhost:7234/Trainees/Details?id="));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _loginStepDefs.TT_Website.SeleniumDriver.Quit();
        }
    }
  ```
</details>

#### Outcomes

WEB 6.1.1 Admin view a trainee details :heavy_check_mark:

WEB 6.1.2 Trainer view a trainees details :heavy_check_mark:

All tests pass. :white_check_mark:


### Edit Trainee

```c#
Feature: Edit Trainee

Admin and trainer can update trainee details

@HappyPath
Scenario: Editing Trainee as a Admin
	Given I am logged in as a admin
	And when I click on edit button for a trainee
	When I change the trainee details
	Then the details are updated in the database

@HappyPath
Scenario: Editing Trainee as a Trainer
	Given I am logged in as a trainer
	And when I click on edit button for a trainee
	When I change the trainee details
	Then the details are updated in the database
```

# Page Object Models:

## Courses

Below are all public methods that are available for each page under the 'Courses' folder.

### Delete Course Page

```c#
public TT_CoursesDeletePage(IWebDriver seleniumDriver)
        public void VisitPage()
        public string GetCourseName()
        public string GetCourseStartDate()
        public string GetCourseDurationWeeks()
        public void ClickDeleteButton()
        public void ClickPreviousLink()
```

### Course Details Page

```c#
public TT_CoursesDetailsPage(IWebDriver seleniumDriver)
        public void VisitPage()
        public string GetCourseName()
        public string GetCourseStartDate()
        public string GetCourseDurationWeeks()
        public void ClickEditLink()
        public void ClickPreviousLink()
```

### Course Edit Page

```c#
public TT_CoursesEditPage(IWebDriver seleniumDriver)
        public void VisitPage()
        public void InputName(string courseName)
        public void InputDate(string courseStartDate)
        public void InputDuration(string courseDurationWeeks)
        public void ClickSubmitButton() => _submitButton.Click()
        public void ClickPreviousLink() => _previousLink.Click()
```

## Trackers

Below are all public methods that are available for each page under the 'Trackers' folder.

Some pages are not shown as they were inaccessible during the testing phases  of the project, these have been documented in the 'Defects' section.

### Create Tracker Page

```c#
Unavailable
```

### Delete Tracker Page

```c#
Unavailable
```

### Tracker Details Page

```c#
		public void VisitTrackerDetailsPage()
        public void ClickEdit() 
        public void ClickBackToList()
        public void ClickPrivacyPolicy() 
        public void ClickSpartaLogo() 
        public void ClickTraineeTracker()
        public void ClickMyProfile() 
        public void ClickMyTrackers()
        public void ClickMyTrainer() 
        public void ClickWeek1() 
        public void ClickWeek2()
        public void ClickWeek3() 
        public void ClickWeek4() 
        public void ClickWeek5() 
        public void ClickWeek6()
        public void ClickWeek7()
        public void ClickWeek8() 
        public void ClickLogout() 
        public string GetPageTitle() 
```

### Edit Tracker Page

```c#
 public void VisitEditTrackerPage() 
        public void InputTechnicalSkill(string technicalSkill) 
        public void InputConsultantSkill(string consultantSkill) 
        public void InputStop(string stop) 
        public void InputStart(string start)
        public void InputContinue(string continueText) 
        public void InputComment(string comment) 
        public void ClickSave() 
        public void ClickBackToList() 
        public void ClickPrivacyPolicy() 
        public void ClickSpartaLogo() 
        public void ClickTraineeTracker() 
        public void ClickMyProfile() 
        public void ClickMyTrackers()
        public void ClickMyTrainer() 
        public void ClickWeek1() 
        public void ClickWeek2() 
        public void ClickWeek3()
        public void ClickWeek4() 
        public void ClickWeek5()
        public void ClickWeek6() 
        public void ClickWeek7() 
        public void ClickWeek8()
        public void ClickLogout() 
        public string GetPageTitle() 
```

### Tracker Index Page

```c#
  public void ClickSpartaLogo() 
    public string GetPageTitle() 
    public string GetTitleHeader()
    public void ClickCreateNew() 
    public string GetFilterText() 
    public void SetFilterText(string text)
    public void ClickSubmitFilter() 
    public void ClickResetFilter() 
    public string FindEmailByUsername(string id) 
    public string FindDetailByEmail(string email, string requestedDetail) 
    public void ClickEditByEmail(string email) 
    public void ClickDetailsByEmail(string email) 
    public void ClickDeleteByEmail(string email) 
    public void ClickPrivacy() 
```

### View Trainer Page

```c#
    public string GetFullName() => _fullName.Text;
    public string GetEmail() => _email.Text;
    public string GetContactNumber() => _contactNumber.Text;
```

## Trainee

### Create Trainee Page
```c#
    public void EnterFirstName(string firstName) => _firstName.SendKeys(firstName);
    public void EnterLastName(string lastName) => _lastName.SendKeys(lastName);
    public void EnterTitle(string title) => _title.SendKeys(title);
    public void EnterEmail(string email) => _email.SendKeys(email);
    public void EnterContactNumber(string contactNumber) => _contactNumber.SendKeys(contactNumber);
    public void EnterPermissionRole(string permissionRole) => _permissionRole.SendKeys(permissionRole);
    public void EnterProfileLink(string profileLink) => _profileLink.SendKeys(profileLink);
    public void ClickSubmitButton() => _submitButton.Click();
    public void ClickPrevButton() => _prev_page.Click();
```

## Trainer

### Index Page
```c#
    public void ClickTrainersButton() => _trainers_button.Click();
    public void ClickCoursesButton() => _courses_botton.Click();
    public void ClickAccountButton() => _account_botton.Click();
    public void InputSearchQuery(string query) => _input_search.SendKeys(query);
    public void ClickInputButton() => _input_button.Click();
    public void ClickResetButton() => _reset_button.Click();
```

# How to use the frameworks

## API

- Data Handling

- DTO - Data Transfer Object

- HTTPManager

  

![TestExplorer](https://raw.githubusercontent.com/kenny95h/TraineeTrackerTestFramework/dev/images/run-api-framework.jpg)

# Collaborators 

# Defects found (raise as issues in GitHub Project board)

#### Login page defects

During exploration of the Login page the following defects has been identified:

- Trainer is unable to login due to being redirected to a 'Access denied page'.

Below is a defect report as well as a test summary report for the mentioned defect and a screenshot of what the defect would look like to a user.

**Summary of Defect:**
The user should be able to Login using trainer credentials but is unable to
**Expected Result:**
After entering trainer credentials, the user should be taken to Trainer Index page
**Actual Result:**
After entering trainer credentials, the user is met with an access denied page
**Defect Description: (Hint: Steps to Reproduce)**
Trainer login details
username: cfrench
password: password
Press Login
**Further Comment:**
No further comment

```c#
Message: 
  Expected string length 28 but was 65. Strings differ at index 24.
  Expected: "...s://localhost:7234/Admin"
  But was:  "...s://localhost:7234/Account/AccessDenied?ReturnUrl=%2FTrainees"
  ----------------------------------^
```
![Access Denied](https://user-images.githubusercontent.com/108397810/185591567-3b721f55-f5c4-4db1-bb8c-c4c4558557bb.PNG)

#### Trainee Creation Defects
During exploration of the index trainee page the following defects has been identified:
 - The create button is not working.

Defect report:
Summary of Defect:
The admin should be able to create new trainees by clicking the "Create New" button but that button is not working.

Expected Result:
Clicking the "Create New" takes me to a page where the admin can create a new trainee.

Actual Result:
The "Create New" button is not working so it does not take me to the page where the admin can create new trainees.

Defect Description: (Hint: Steps to Reproduce)
Trainer login details
username: admin
password: password
Click Login
Click Details for existing a trainee
Click Back to List
Try to Click the "Create New" button
Further Comment:
No further comment

#### Viewing Trainer Defects
During exploration of the Index page the following defects has been identified:
 - Trainer detail cannot be viewed.

Defect report:

Summary of Defect:
The admin should be able to view details of the trainers but the error message is received.

Expected Result:
Clicking the "Details" button for a trainer takes me to a page where the admin can view the trainer's details.

Actual Result:
Clicking the "Details" button for a trainer takes me to an error page (An unhandled exception occurred while processing the request).

Defect Description: (Hint: Steps to Reproduce)
Trainer login details
username: admin
password: password
Click Login
Click Details for existing a trainer (cfrench)

Further Comment:
No further comment

# How to extend the framework







