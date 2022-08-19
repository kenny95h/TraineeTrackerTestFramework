using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
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
    }
}
