using OpenQA.Selenium;

namespace TraineeTrackerFramework.lib.pages.Trainees
{
    public class TT_Create
    {
        #region Properties and Fields
        private IWebDriver _seleniumDriver;
        private IWebElement _firstName=> _seleniumDriver.FindElement(By.Id("first_name_input"));
        private IWebElement _lastName=> _seleniumDriver.FindElement(By.Id("last_name_input"));
        private IWebElement _title => _seleniumDriver.FindElement(By.Id("title_input"));
        private IWebElement _email => _seleniumDriver.FindElement(By.Id("email_input"));
        private IWebElement _contactNumber => _seleniumDriver.FindElement(By.Id("contact_number_input"));
        private IWebElement _permissionRole => _seleniumDriver.FindElement(By.Id("permission_role_input"));
        private IWebElement _profileLink=> _seleniumDriver.FindElement(By.Id("profile_link_input"));
        private IWebElement _submitButton => _seleniumDriver.FindElement(By.Id("submit_button"));
        private IWebElement _prev_page => _seleniumDriver.FindElement(By.Id("prev_page"));

        #endregion
        public TT_Create(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        #region Method
        public void EnterFirstName(string firstName) => _firstName.SendKeys(firstName);
        public void EnterLastName(string lastName) => _lastName.SendKeys(lastName);
        public void EnterTitle(string title) => _title.SendKeys(title);
        public void EnterEmail(string email) => _email.SendKeys(email);
        public void EnterContactNumber(string contactNumber) => _contactNumber.SendKeys(contactNumber);
        public void EnterPermissionRole(string permissionRole) => _permissionRole.SendKeys(permissionRole);
        public void EnterProfileLink(string profileLink) => _profileLink.SendKeys(profileLink);
        public void ClickSubmitButton() => _submitButton.Click();
        public void ClickPrevButton() => _prev_page.Click();

        #endregion



    }
}
