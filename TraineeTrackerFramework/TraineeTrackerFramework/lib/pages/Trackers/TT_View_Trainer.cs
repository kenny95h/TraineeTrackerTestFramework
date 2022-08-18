using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Trackers
{
    public class TT_View_Trainer
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private IWebElement _fullName => _seleniumDriver.FindElement(By.Id("trainer-full-name"));
        private IWebElement _email => _seleniumDriver.FindElement(By.Id("trainer-email"));
        private IWebElement _contactNumber=> _seleniumDriver.FindElement(By.Id("trainer-contact-number"));


        #endregion

        public TT_View_Trainer(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public string GetFullName() => _fullName.Text;
        public string GetEmail() => _email.Text;
        public string GetContactNumber() => _contactNumber.Text;
        #endregion

    }
}
