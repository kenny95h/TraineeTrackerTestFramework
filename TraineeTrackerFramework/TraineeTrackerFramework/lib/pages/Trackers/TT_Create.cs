using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Trackers
{
    public class TT_Create
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private string _createTrackerURL = AppConfigReader.CreateTrackerURL;
   


        #endregion

        public TT_CreateTrackerPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods

        #endregion
    }
}
