using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Admin
{
    public class TT_Index
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _indexPageURL = AppConfigReader.IndexURL;

        private IWebElement _trainees_collapse => _seleniumDriver.FindElement(By.Id("trainees_collapse"));
        private IWebElement _trainers_collapse => _seleniumDriver.FindElement(By.Id("trainers_collapse"));
        private IWebElement _courses_collapse => _seleniumDriver.FindElement(By.Id("courses_collapse"));
        private IWebElement _account_collapse => _seleniumDriver.FindElement(By.Id("account_collapse"));
        private IWebElement _logout_button => _seleniumDriver.FindElement(By.Id("logout_button"));
        #endregion

        public TT_Index(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        #endregion
    }
}
