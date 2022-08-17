using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TraineeTrackerFramework.lib.driver_config;
using TraineeTrackerFramework.lib.pages.Account;

namespace TraineeTrackerFramework.lib;

public class TT_Website
{
    public class AP_Website<T> where T : IWebDriver, new()
    {
        #region Accessible age Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }
        public TT_LoginPage TT_LoginPage { get; set; }
        #endregion

        public AP_Website(int pageLoadInsecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInsecs, implicitWaitInSecs, isHeadless).Driver;
            TT_LoginPage = new TT_LoginPage(SeleniumDriver);
        }
    }
}
