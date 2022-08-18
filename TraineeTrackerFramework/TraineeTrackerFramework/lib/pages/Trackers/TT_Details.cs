using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Trackers
{
    public class TT_TrackerDetailsPage
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _trackerDetailsURL = AppConfigReader.TrackerDetailsURL;
        private IWebElement _editLink => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _backToListLink => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _privacyPolicyLink => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _spartaLogo => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _traineeTrackerLink => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _myProfileButton => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _myTrackersButton => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _myTrainerButton => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week1Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week2Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week3Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week4Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week5Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week6Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week7Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _week8Button => _seleniumDriver.FindElement(By.Id(""));
        private IWebElement _logoutButton => _seleniumDriver.FindElement(By.Id("logout_button"));
        #endregion

        public TT_TrackerDetailsPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
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
        #endregion

    }
}
