using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TraineeTrackerFramework.lib.driver_config;

public class SeleniumDriverConfig<T> where T : IWebDriver, new()
{
    public IWebDriver Driver { get; set; }

    public SeleniumDriverConfig(int pageLoadSecs, int implicitWaitSecs, bool isHeadless)
    {
        Driver = new T();
        DriverSetUp(pageLoadSecs, implicitWaitSecs, isHeadless);
    }

    private void DriverSetUp(int pageLoadSecs, int implicitWaitSecs, bool isHeadless)
    {
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadSecs);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitSecs);
        if (isHeadless) SetHeadless();
    }

    private void SetHeadless()
    {
        if (Driver is ChromeDriver)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            Driver.Dispose();
            Driver = new ChromeDriver(options);
        }
        else if (Driver is FirefoxDriver)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            Driver.Dispose();
            Driver = new FirefoxDriver(options);
        }
        else
        {
            throw new ArgumentException("Browser not supported by framework");
        }
    }
}
