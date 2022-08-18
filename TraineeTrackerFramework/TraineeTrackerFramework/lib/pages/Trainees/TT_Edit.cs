using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Trainees;

public class TT_Edit
{
    private IWebDriver _seleniumDriver;
    private string _traineesDetailsURL = AppConfigReader.TraineesEditURL;

    #region Properties and Fields
    private int _traineeID => Int32.Parse(_seleniumDriver.Url.Split("?id=")[1]);
    private IWebElement _titleHeader => _seleniumDriver.FindElement(By.CssSelector("h1"));
    private IWebElement _roleHeader => _seleniumDriver.FindElement(By.CssSelector("h4"));
    private IWebElement _firstName => _seleniumDriver.FindElement(By.Id("Trainee_FirstName"));
    private IWebElement _lastName => _seleniumDriver.FindElement(By.Id("Trainee_LastName"));
    private IWebElement _traineeTitle => _seleniumDriver.FindElement(By.Id("Trainee_Title"));
    private IWebElement _emailAddress => _seleniumDriver.FindElement(By.Id("Trainee_Email"));
    private IWebElement _contactNumber => _seleniumDriver.FindElement(By.Id("Trainee_ContactNumber"));
    private IWebElement _permissionRole => _seleniumDriver.FindElement(By.Id("Trainee_PermissionRole"));
    private IWebElement _profileLink => _seleniumDriver.FindElement(By.Id("Trainee_ProfileLink"));
    private IWebElement _saveButton => _seleniumDriver.FindElement(By.ClassName("btn btn-primary"));
    private IWebElement _backToListLink => _seleniumDriver.FindElement(By.XPath($"//a[@href='User/{_traineeID}/Dashboard']"));
    private IWebElement _privacyPolicyLink => _seleniumDriver.FindElement(By.XPath("//a[@href='/Privacy']"));
    #endregion

    public TT_Edit(WebDriver SeleniumDriver) => _seleniumDriver = SeleniumDriver;

    #region Methods
    public int GetID() => _traineeID;
    public string GetURL() => $"{_traineesDetailsURL}?id={_traineeID}";
    public string GetPageTitle() => _seleniumDriver.Title;
    public string GetTitleHeader() => _titleHeader.Text;
    public string GetRole_FromHeader() => _roleHeader.Text;
    public string GetFirstName() => _firstName.Text;
    public string GetLastName() => _lastName.Text;
    public string GetTitle() => _traineeTitle.Text;
    public string GetFullName(bool withTitle) => withTitle == true ? $"{GetTitle()} {GetFirstName()} {GetLastName()}" : $"{GetFirstName()} {GetLastName()}";
    public string GetEmailAddress() => _emailAddress.Text;
    public string GetContactNumber() => _contactNumber.Text;
    public string GetRole_FromBody() => _permissionRole.Text;
    public string GetProfileLink() => _profileLink.Text;
    public void ClickSave() => _saveButton.Click();
    public void ClickBackToList() => _backToListLink.Click();
    public void ClickPrivacyPolicy() => _privacyPolicyLink.Click();

    public void SetFirstName(string name) => _firstName.SendKeys(name);
    public void SetLastName(string name) => _lastName.SendKeys(name);
    public void SetTraineeTitle(string title) => _traineeTitle.SendKeys(title);
    public void SetEmailAddress(string email) => _emailAddress.SendKeys(email);
    public void SetContactNumber(int contactNumber) => _contactNumber.SendKeys(contactNumber.ToString());
    //Not sure if these will work, can be removed if not!
    public void IncrementContactNumber() => _contactNumber.SendKeys(Keys.ArrowUp);
    public void DecrementContactNumber() => _contactNumber.SendKeys(Keys.ArrowDown);
    public void SetPermissionRole(string role) => _permissionRole.SendKeys(role);
    public void SetProfileLink(string link) => _permissionRole.SendKeys(link);
    #endregion
}
