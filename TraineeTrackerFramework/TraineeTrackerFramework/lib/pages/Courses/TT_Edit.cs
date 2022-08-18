using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Courses
{
    public class TT_CoursesEditPage
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _coursesEditPageURL = AppConfigReader.CoursesEditURL;

        private IWebElement _nameInputField => _seleniumDriver.FindElement(By.Id("name_input"));
        private IWebElement _dateInputField => _seleniumDriver.FindElement(By.Id("start_date_input"));
        private IWebElement _weeksLongInputField => _seleniumDriver.FindElement(By.Id("weeks_long_input"));
        private IWebElement _submitButton => _seleniumDriver.FindElement(By.Id("submit_button"));
        private IWebElement _previousLink => _seleniumDriver.FindElement(By.Id("prev_link"));
        #endregion

        public TT_CoursesEditPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesEditPageURL);
        public void InputName(string courseName) => _nameInputField.SendKeys(courseName);
        public void InputDate(string courseStartDate) => _dateInputField.SendKeys(courseStartDate);
        public void InputDuration(string courseDurationWeeks) => _weeksLongInputField.SendKeys(courseDurationWeeks);
        public void ClickSubmitButton() => _submitButton.Click();
        public void ClickPreviousLink() => _previousLink.Click();
        #endregion
    }
}
