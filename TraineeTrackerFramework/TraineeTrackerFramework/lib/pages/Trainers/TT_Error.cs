using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Trainers
{
    public class TT_Error
    {
        #region properties & fields
        private IWebDriver _seleniumDriver;
        private IWebElement _errorH1 => _seleniumDriver.FindElement(By.TagName("h1"));
        private IWebElement _errorH2 => _seleniumDriver.FindElement(By.TagName("h2"));
        private IWebElement _devMode => _seleniumDriver.FindElement(By.TagName("h3"));
        #endregion

        public TT_Error(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region methods
        public string GetErrorTitle() => _errorH1.Text;
        public string GetErrorText() => _errorH2.Text;
        public string GetDevMode() => _devMode.Text;
        public string PageTitle() => _seleniumDriver.Title;
        #endregion
    }
}
