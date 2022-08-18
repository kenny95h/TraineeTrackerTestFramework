using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Account
{
    public class TT_AccessDenied
    {
        #region properties & fields
        private IWebDriver _seleniumDriver;
        private IWebElement _backBtn => _seleniumDriver.FindElement(By.Id("prev_link"));
        private IWebElement _homeLink => _seleniumDriver.FindElement(By.Id("home_link"));
        #endregion

        public TT_AccessDenied(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region methods
        public void ReturnBack() => _backBtn.Click();
        public void HomePage() => _homeLink.Click();
        public string GetPageTitle() => _seleniumDriver.Title;
        #endregion
    }
}
