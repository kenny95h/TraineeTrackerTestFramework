using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Trainees;

public class TT_Details
{
    private IWebDriver _seleniumDriver;
    private string _traineesDetailsURL = AppConfigReader.TraineesDetailsURL;
    
    #region Properties and Fields
    private int _traineeID => Int32.Parse(_seleniumDriver.Url.Split("?id=")[1]);
    private IWebElement _titleHeader => _seleniumDriver.FindElement(By.CssSelector("h1"));
    private IWebElement _roleHeader => _seleniumDriver.FindElement(By.CssSelector("h4"));
    private IWebElement _firstName => _seleniumDriver.FindElement(By.XPath("//dt[text()='First Name']/following-sibling::dd"));
    private IWebElement _lastName => _seleniumDriver.FindElement(By.XPath("//dt[text()='Last Name']/following-sibling::dd"));
    private IWebElement _traineeTitle => _seleniumDriver.FindElement(By.XPath("//dt[text()='Title']/following-sibling::dd"));
    private IWebElement _emailAddress => _seleniumDriver.FindElement(By.XPath("//dt[text()='Email']/following-sibling::dd"));
    private IWebElement _contactNumber => _seleniumDriver.FindElement(By.XPath("//dt[text()='Contact Number']/following-sibling::dd"));
    private IWebElement _permissionRole => _seleniumDriver.FindElement(By.XPath("//dt[text()='Permission Role']/following-sibling::dd"));
    private IWebElement _profileLink => _seleniumDriver.FindElement(By.XPath("//dt[text()='Profile Link']/following-sibling::dd"));
    private IWebElement _editLink => _seleniumDriver.FindElement(By.XPath($"//a[@href='/Trainees/Edit?id={_traineeID}']"));
    private IWebElement _backToListLink => _seleniumDriver.FindElement(By.XPath("//a[@href='/Trainees']"));
    private IWebElement _privacyPolicyLink => _seleniumDriver.FindElement(By.XPath("//a[@href='/Privacy']"));
    #endregion

    public TT_Details(IWebDriver SeleniumDriver) => _seleniumDriver = SeleniumDriver;

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
    public void ClickEdit() => _editLink.Click();
    public void ClickBackToList() => _backToListLink.Click();
    public void ClickPrivacyPolicy() => _privacyPolicyLink.Click();
    #endregion
}
