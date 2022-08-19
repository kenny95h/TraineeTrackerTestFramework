using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TraineeTrackerFramework.lib;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class Trainees_IndexStepDefinitions
    {
        TT_Website<ChromeDriver> TT_Website;

        [BeforeScenario]
        public void Setup()
        {
            TT_Website = new TT_Website<ChromeDriver>();
        }

        [When(@"I am redirected to the Trainees page")]
        public void WhenIAmRedirectedToTheTraineesPage()
        {
            TT_Website.SeleniumDriver.FindElement(By.Id("trainee-table")).FindElements(By.ClassName("trainees_details_link"))[0].Click();
            TT_Website.SeleniumDriver.FindElement(By.Id("prev_link")).Click();
        }

        [Then(@"I should see a list of all Trainees")]
        public void ThenIShouldSeeAListOfAllTrainees()
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
