using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerFramework.lib;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class Trainers_IndexStepDefinitions
    {
        TT_Website<ChromeDriver> TT_Website;

        [BeforeScenario]
        public void Setup()
        {
            TT_Website = new TT_Website<ChromeDriver>();
            TT_Website.SeleniumDriver.Manage().Window.Maximize();
        }

        [When(@"I navigate to the Trainers page")]
        public void WhenINavigateToTheTrainersPage()
        {
            TT_Website.SeleniumDriver.FindElement(By.ClassName("trainers_details_link"));
            TT_Website.SeleniumDriver.FindElement(By.Id("prev_link"));
        }

        [Then(@"I should see a list of all Trainers")]
        public void ThenIShouldSeeAListOfAllTrainers()
        {
            Assert.That(TT_Website.SeleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).Count, Is.GreaterThan(0));
            Assert.That(TT_Website.SeleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr"))[0].FindElements(By.TagName("td"))[5].Text, Does.Contain("Trainee"));
        }

        [AfterScenario]
        public void Teardown()
        {
            TT_Website.SeleniumDriver.Quit();
        }
    }
}
