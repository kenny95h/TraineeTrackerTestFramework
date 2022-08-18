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
        IWebDriver _seleniumDriver;
        IWebElement _homeLink => _seleniumDriver.FindElement(By.Id("home_link"));
        IWebElement _prevLink => _seleniumDriver.FindElement(By.Id("prev_link"));
        #endregion

        public TT_AccessDenied(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region methods
        public void ReturnHome() => _homeLink.Click();
        public void StepBack() => _prevLink.Click();
        public string GetPageTitle() => _seleniumDriver.Title;
        #endregion
    }
}
