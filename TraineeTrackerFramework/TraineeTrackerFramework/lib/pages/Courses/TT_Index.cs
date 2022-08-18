using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Courses
{
    public class TT_CoursesIndexPage
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _coursesIndexPageURL = AppConfigReader.CoursesIndexURL;
        private IWebElement _createLink => _seleniumDriver.FindElement(By.Id("create_link"));
        #endregion

        public TT_CoursesIndexPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesIndexPageURL);
        public void ClickCreate() => _createLink.Click();
        #endregion
    }
}
