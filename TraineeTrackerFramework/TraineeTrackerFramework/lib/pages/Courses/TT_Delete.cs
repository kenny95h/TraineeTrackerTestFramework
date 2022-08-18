using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Courses
{
    public class TT_CoursesDeletePage
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _coursesDeletePageURL = AppConfigReader.CoursesDeleteURL;
        private IWebElement _courseName => _seleniumDriver.FindElement(By.Id("course_name"));
        private IWebElement _courseStartDate => _seleniumDriver.FindElement(By.Id("coruse_start_date"));
        private IWebElement _courseLengthWeeks => _seleniumDriver.FindElement(By.Id("course_weeks_long"));
        private IWebElement _deleteButton => _seleniumDriver.FindElement(By.Id("delete_button"));
        private IWebElement _previousLink => _seleniumDriver.FindElement(By.Id("prev_link"));
        #endregion

        public TT_CoursesDeletePage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesDeletePageURL);
        public string GetCourseName() => _courseName.Text;
        public string GetCourseStartDate() => _courseStartDate.Text;
        public string GetCourseDurationWeeks() => _courseLengthWeeks.Text;
        public void ClickDeleteButton() => _deleteButton.Click();
        public void ClickPreviousLink() => _previousLink.Click();
        #endregion
    }
}
