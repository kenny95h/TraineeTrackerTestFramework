using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Trackers
{
    public class TT_View_Trainer
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private IWebElement _fullName => _seleniumDriver.FindElement(By.ClassName("col-sm-9"));
        private IWebElement _email => _seleniumDriver.FindElement(By.TagName("col-sm-9"));


        #endregion

        public TT_View_Trainer(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void GetFullName() => _fullName.Displayed.ToString();
        public void GetEmail() => _email.Displayed.ToString();
        #endregion

    }
}
