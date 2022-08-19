using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerFramework.lib;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class Courses_IndexStepDefinitions
    {
        TT_Website<ChromeDriver> TT_Website;

        [BeforeScenario]
        public void Setup()
        {
            TT_Website = new TT_Website<ChromeDriver>();
            TT_Website.SeleniumDriver.Manage().Window.Maximize();
        }

        [Given(@"I log in as an Admin")]
        public void GivenILogInAsAnAdmin()
        {
            TT_Website.TT_Account_LoginPage.VisitLoginPage();
            TT_Website.TT_Account_LoginPage.InputUsername("admin");
            TT_Website.TT_Account_LoginPage.InputPassword("password");
            TT_Website.TT_Account_LoginPage.ClickSignIn();
        }

        [Given(@"I log in as a Trainer")]
        public void GivenILogInAsATrainer()
        {
            TT_Website.TT_Account_LoginPage.VisitLoginPage();
            TT_Website.TT_Account_LoginPage.InputUsername("cfrench");
            TT_Website.TT_Account_LoginPage.InputPassword("password");
            TT_Website.TT_Account_LoginPage.ClickSignIn();

            // Sign-in currently causes error, temp workaround
            TT_Website.SeleniumDriver.Navigate().GoToUrl("https://localhost:7234/Admin");
        }

        [When(@"I navigate to the Courses page")]
        public void WhenINavigateToTheCoursesPage()
        {
            TT_Website.SeleniumDriver.FindElement(By.ClassName("course_details_link")).Click();
        }

        [Then(@"I should see a list of all Courses")]
        public void ThenIShouldSeeAListOfAllCourses()
        {
            Assert.That(TT_Website.TT_Courses_DetailsPage.GetCourseName(), Does.Contain("Engineering 113"));
        }

        [AfterScenario]
        public void Teardown()
        {
            TT_Website.SeleniumDriver.Quit();
        }
    }
}
