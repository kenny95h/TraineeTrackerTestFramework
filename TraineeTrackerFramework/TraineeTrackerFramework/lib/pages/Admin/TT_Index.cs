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
        #region Properties & Fields
        private IWebDriver _seleniumDriver;
        private string _indexPageURL = AppConfigReader.IndexURL;

        private IWebElement _trainees_collapse => _seleniumDriver.FindElement(By.Id("trainees_collapse"));
        private IWebElement _trainers_collapse => _seleniumDriver.FindElement(By.Id("trainers_collapse"));
        private IWebElement _courses_collapse => _seleniumDriver.FindElement(By.Id("courses_collapse"));
        private IWebElement _account_collapse => _seleniumDriver.FindElement(By.Id("account_collapse"));
        private IWebElement _logout_button => _seleniumDriver.FindElement(By.Id("logout_button"));
        private IWebElement _editTrainee => _seleniumDriver.FindElement(By.ClassName("trainees_edit_link"));
        private IWebElement _viewDetailTrainee => _seleniumDriver.FindElement(By.ClassName("trainees_details_link"));
        private IWebElement _deleteTrainee => _seleniumDriver.FindElement(By.ClassName("trainees_delete_link"));
        private IWebElement _editTrainer => _seleniumDriver.FindElement(By.ClassName("trainers_edit_link"));
        private IWebElement _viewDetailTrainer => _seleniumDriver.FindElement(By.ClassName("trainers_details_link"));
        private IWebElement _deleteTrainer => _seleniumDriver.FindElement(By.ClassName("trainers_delete_link"));
        private IWebElement _editCourse => _seleniumDriver.FindElement(By.ClassName("course_edit_link"));
        private IWebElement _viewDetailCourse => _seleniumDriver.FindElement(By.ClassName("course_details_link"));
        private IWebElement _deleteCourse => _seleniumDriver.FindElement(By.ClassName("course_delete_link"));
        #endregion

        public TT_Index(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Methods
        public void CollapseTrainees() => _trainees_collapse.Click();
        public void CollapseTrainers() => _trainers_collapse.Click();
        public void CollapseCourses() => _courses_collapse.Click();
        public void CollapseAccounts() => _account_collapse.Click();
        public void LogOut() => _logout_button.Click();
        // all the courses
        public void EditTraineeLnk() => _editTrainee.Click();
        public void EditTrainerLnk() => _editTrainer.Click();
        public void EditCourseLnk() => _editCourse.Click();
        public void ViewTraineeLnk() => _viewDetailTrainee.Click();
        public void ViewTrainerLnk() => _viewDetailTrainer.Click();
        public void ViewCourseLnk() => _viewDetailCourse.Click();
        public void DeleteTraineeLnk() => _deleteTrainee.Click();
        public void DeleteTrainerLnk() => _deleteTrainer.Click();
        public void DeleteCourseLnk() => _deleteCourse.Click();
        #endregion
    }
}
