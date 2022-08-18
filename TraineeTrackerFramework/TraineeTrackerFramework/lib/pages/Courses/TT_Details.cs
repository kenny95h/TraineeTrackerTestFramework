using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Courses
{
    public class TT_CoursesDetailsPage
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _coursesDetailsPageURL = AppConfigReader.CoursesDetailsURL;
        private IWebElement _courseName => _seleniumDriver.FindElement(By.Id("course_name"));
        private IWebElement _courseStartDate => _seleniumDriver.FindElement(By.Id("coruse_start_date"));
        private IWebElement _courseDurationWeeks => _seleniumDriver.FindElement(By.Id("course_weeks_long"));
        private IWebElement _editLink => _seleniumDriver.FindElement(By.Id("edit_link"));
        private IWebElement _previousLink => _seleniumDriver.FindElement(By.Id("prev_link"));
        #endregion

        public TT_CoursesDetailsPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void VisitPage() => _seleniumDriver.Navigate().GoToUrl(_coursesDetailsPageURL);
        public string GetCourseName() => _courseName.Text;
        public string GetCourseStartDate() => _courseStartDate.Text;
        public string GetCourseDurationWeeks() => _courseDurationWeeks.Text;
        public void ClickEditLink() => _editLink.Click();
        public void ClickPreviousLink() => _previousLink.Click();
        #endregion

    }
}
