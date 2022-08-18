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
		}

		[When(@"I press the Logout button")]
		public void WhenIPressTheLogoutButton()
		{
			TT_Website.TT_Admin_TT_IndexPage.LogOut();
		}

		[Then(@"I should be taken to the Login page")]
		public void ThenIShouldBeTakenToTheLoginPage()
		{
			Assert.That(TT_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.AccountLoginURL));
		}

		[AfterScenario]
		public void DisposeWebDriver()
		{
			TT_Website.SeleniumDriver.Quit();
		}
	}
}
