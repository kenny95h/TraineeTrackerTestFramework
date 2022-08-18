using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Courses
{
    public class TT_Create
    {
        #region regions & properties
        private IWebDriver _seleniumDriver;
        private IWebElement _prevLink => _seleniumDriver.FindElement(By.Id("prev_link"));
        #endregion

        public TT_Create(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region methods

        #endregion
    }
}
