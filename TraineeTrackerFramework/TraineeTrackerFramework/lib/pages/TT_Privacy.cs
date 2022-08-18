using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages
{
    public class TT_Privacy
    {
        #region properties & fields
        private IWebDriver _seleniumDriver;
        private IWebElement _title => _seleniumDriver.FindElement(By.TagName("h1"));
        private IWebElement _policy => _seleniumDriver.FindElement(By.TagName("p"));
        #endregion

        public TT_Privacy(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region
        public string GetTitle() => _title.Text;
        public string GetPolicy() => _policy.Text;
        public string GetPageTitle() => _seleniumDriver.Title;
        #endregion
    }
}
