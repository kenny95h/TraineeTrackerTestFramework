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

## Web Testing


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
</details>

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

# Page Object Models:

## Courses

Below are all public methods that are available for each page under the 'Courses' folder.

### Delete Course Page

```c#
public TT_CoursesDeletePage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesDeletePageURL);
        public string GetCourseName() => _courseName.Text;
        public string GetCourseStartDate() => _courseStartDate.Text;
        public string GetCourseDurationWeeks() => _courseLengthWeeks.Text;
        public void ClickDeleteButton() => _deleteButton.Click();
        public void ClickPreviousLink() => _previousLink.Click();
```

### Course Details Page

```c#
public TT_CoursesDetailsPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesDetailsPageURL);
        public string GetCourseName() => _courseName.Text;
        public string GetCourseStartDate() => _courseStartDate.Text;
        public string GetCourseDurationWeeks() => _courseDurationWeeks.Text;
        public void ClickEditLink() => _editLink.Click();
        public void ClickPreviousLink() => _previousLink.Click();
```

### Course Edit Page

```c#
public TT_CoursesEditPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesEditPageURL);
        public void InputName(string courseName) => _nameInputField.SendKeys(courseName);
        public void InputDate(string courseStartDate) => _dateInputField.SendKeys(courseStartDate);
        public void InputDuration(string courseDurationWeeks) => _weeksLongInputField.SendKeys(courseDurationWeeks);
        public void ClickSubmitButton() => _submitButton.Click();
        public void ClickPreviousLink() => _previousLink.Click();
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
public void VisitTrackerDetailsPage() => _seleniumDriver.Navigate().GoToUrl(_trackerDetailsURL);
        public void ClickEdit() => _editLink.Click();
        public void ClickBackToList() => _backToListLink.Click();
        public void ClickPrivacyPolicy() => _privacyPolicyLink.Click();
        public void ClickSpartaLogo() => _spartaLogo.Click();
        public void ClickTraineeTracker() => _traineeTrackerLink.Click();
        public void ClickMyProfile() => _myProfileButton.Click();
        public void ClickMyTrackers() => _myTrackersButton.Click();
        public void ClickMyTrainer() => _myTrainerButton.Click();
        public void ClickWeek1() => _week1Button.Click();
        public void ClickWeek2() => _week2Button.Click();
        public void ClickWeek3() => _week3Button.Click();
        public void ClickWeek4() => _week4Button.Click();
        public void ClickWeek5() => _week5Button.Click();
        public void ClickWeek6() => _week6Button.Click();
        public void ClickWeek7() => _week7Button.Click();
        public void ClickWeek8() => _week8Button.Click();
        public void ClickLogout() => _logoutButton.Click();
        public string GetPageTitle() => _seleniumDriver.Title;
```

### Edit Tracker Page

```c#
 public void VisitEditTrackerPage() => _seleniumDriver.Navigate().GoToUrl(_editTrackerURL);
        public void InputTechnicalSkill(string technicalSkill) => _technicalSkillField.SendKeys(technicalSkill);
        public void InputConsultantSkill(string consultantSkill) => _consultantSkillField.SendKeys(consultantSkill);
        public void InputStop(string stop) => _stopField.SendKeys(stop);
        public void InputStart(string start) => _startField.SendKeys(start);
        public void InputContinue(string continueText) => _continueField.SendKeys(continueText);
        public void InputComment(string comment) => _commentField.SendKeys(comment);
        public void ClickSave() => _saveButton.Click();
        public void ClickBackToList() => _backToListLink.Click();
        public void ClickPrivacyPolicy() => _privacyPolicyLink.Click();
        public void ClickSpartaLogo() => _spartaLogo.Click();
        public void ClickTraineeTracker() => _traineeTrackerLink.Click();
        public void ClickMyProfile() => _myProfileButton.Click();
        public void ClickMyTrackers() => _myTrackersButton.Click();
        public void ClickMyTrainer() => _myTrainerButton.Click();
        public void ClickWeek1() => _week1Button.Click();
        public void ClickWeek2() => _week2Button.Click();
        public void ClickWeek3() => _week3Button.Click();
        public void ClickWeek4() => _week4Button.Click();
        public void ClickWeek5() => _week5Button.Click();
        public void ClickWeek6() => _week6Button.Click();
        public void ClickWeek7() => _week7Button.Click();
        public void ClickWeek8() => _week8Button.Click();
        public void ClickLogout() => _logoutButton.Click();
        public string GetPageTitle() => _seleniumDriver.Title;
```

### Tracker Index Page

```c#
  public void ClickSpartaLogo() => _spartaLogo.Click();
    public string GetPageTitle() => _seleniumDriver.Title;
    public string GetTitleHeader() => _pageTitleHeader.Text;
    public void ClickCreateNew() => _createNewTraineeLink.Click();
    public string GetFilterText() => _searchFilter.Text;
    public void SetFilterText(string text) => _searchFilter.SendKeys(text);
    public void ClickSubmitFilter() => _submitFilter.Click();
    public void ClickResetFilter() => _resetFilter.Click();
    public string FindEmailByUsername(string id) => _traineeDict.ContainsKey($"{id}@spartaglobal.com") ? $"{id}@spartaglobal.com" : "";
    public string FindDetailByEmail(string email, string requestedDetail) => _traineeDict[email][requestedDetail].Text;
    public void ClickEditByEmail(string email) => _traineeDict[email]["tracker_edit"].Click();
    public void ClickDetailsByEmail(string email) => _traineeDict[email]["tracker_details"].Click();
    public void ClickDeleteByEmail(string email) => _traineeDict[email]["tracker_delete"].Click();
    public void ClickPrivacy() => _privacyPolicyLink.Click();
```





# How to use the frameworks

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



# How to extend the framework





