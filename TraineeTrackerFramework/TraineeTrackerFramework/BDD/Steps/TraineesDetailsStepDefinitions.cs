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
        public TT_Website<ChromeDriver> TT_Website { get; } = new TT_Website<ChromeDriver>();

        [Given(@"I am logged in as an admin on the trainee list page")]
        public void GivenIAmLoggedInAsAnAdmin()
        {
            TT_Website.TT_Account_LoginPage.VisitLoginPage();
            TT_Website.TT_Account_LoginPage.InputUsername("admin");
            TT_Website.TT_Account_LoginPage.InputPassword("password");
            TT_Website.TT_Account_LoginPage.ClickSignIn();
        }

        [When(@"I click Details")]
        public void WhenIClickDetails()
        {
            TT_Website.TT_Admin_TT_IndexPage.EditTraineeLnk();
        }

        [Then(@"I should land on the trainee details page")]
        public void ThenIShouldLandOnTheTraineeDetailsPage()
        {
            Assert.That(TT_Website.SeleniumDriver.Url, Is.EqualTo(""));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            TT_Website.SeleniumDriver.Quit();
        }
    }
}
