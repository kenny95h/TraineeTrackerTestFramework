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
        private IWebElement _nameInput => _seleniumDriver.FindElement(By.Id("name_input"));
        private IWebElement _startDateInput => _seleniumDriver.FindElement(By.Id("start_date_input"));
        private IWebElement _weeksLongInput => _seleniumDriver.FindElement(By.Id("weeks_long_input"));
        private IWebElement _submitBtn => _seleniumDriver.FindElement(By.Id("submit_button"));
        #endregion

        public TT_Create(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region methods
        public void GoBack() => _prevLink.Click();
        public void NameInput(string courseName) => _nameInput.SendKeys(courseName);
        public void StartDateInput(string date) => _startDateInput.SendKeys(date);
        public void WeeksLongInput(string weekLength) => _weeksLongInput.SendKeys(weekLength);
        public void Submit() => _submitBtn.Click();
        #endregion
    }
}
