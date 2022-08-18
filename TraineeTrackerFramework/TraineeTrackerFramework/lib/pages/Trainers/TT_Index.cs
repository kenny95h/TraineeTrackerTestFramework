using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Trainers
{
    public class TT_Index
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private IWebElement _trainers_button => _seleniumDriver.FindElement(By.Id("trainers-botton"));
        private IWebElement _courses_botton => _seleniumDriver.FindElement(By.Id("courses-botton"));
        private IWebElement _account_botton => _seleniumDriver.FindElement(By.Id("account-botton"));
        private IWebElement _input_search=> _seleniumDriver.FindElement(By.Id("account-botton"));
        private IWebElement _input_button=> _seleniumDriver.FindElement(By.Id("account-botton"));
        private IWebElement _reset_button=> _seleniumDriver.FindElement(By.Id("account-botton"));
        #endregion

        public TT_Index(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;


        #region Methods
        public void ClickTrainersButton() => _trainers_button.Click();
        public void ClickCoursesButton() => _courses_botton.Click();
        public void ClickAccountButton() => _account_botton.Click();
        public void InputSearchQuery(string query) => _input_search.SendKeys(query);
        public void ClickInputButton() => _input_button.Click();
        public void ClickResetButton() => _reset_button.Click();
        #endregion
    }
}
