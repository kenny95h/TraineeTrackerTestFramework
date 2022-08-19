using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerFramework.lib;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class TraineesDetailsStepDefinitions
    {
        // public TT_Website<ChromeDriver> TT_Website { get; } = new TT_Website<ChromeDriver>();
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
}
