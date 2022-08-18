using OpenQA.Selenium;
namespace TraineeTrackerFramework.lib.pages.Trackers
{
    public class TT_Index
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private IWebElement _quote => _seleniumDriver.FindElement(By.ClassName("mt-4"));
        #endregion
        public TT_Index(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;




    }
}