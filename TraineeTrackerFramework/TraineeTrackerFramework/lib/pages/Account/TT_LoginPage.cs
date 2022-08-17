using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Account;

public class TT_LoginPage
{
    #region Properties and Fields
    private IWebDriver _seleniumDriver;
    private string _loginPageURL = AppConfigReader.LoginURL;
    private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("Credential_UserName"));
    private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("Credential_Password"));
    private IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("submit-button"));
    private IWebElement _usernameAlert => _seleniumDriver.FindElement(By.Id("username_error_msg"));
    private IWebElement _passwordAlert => _seleniumDriver.FindElement(By.Id("password_error_msg"));
    private IWebElement _spartaLogo => _seleniumDriver.FindElement(By.Id("!!!!!!!!!!FILL ME IN!!!!!!!!!!!"));
    private IWebElement _privacyPolicyLink => _seleniumDriver.FindElement(By.Id("!!!!!!!!!!FILL ME IN!!!!!!!!!!!"));
    #endregion

    public TT_LoginPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

    #region Methods
    public void VisitLoginPage() => _seleniumDriver.Navigate().GoToUrl(_loginPageURL);
    public void InputUsername(string username) => _usernameField.SendKeys(username);
    public void InputPassword(string password) => _passwordField.SendKeys(password);
    public void ClickSignIn() => _loginButton.Click();
    public string GetUsernameAlertText() => _usernameAlert.Text;
    public string GetPasswordAlertText() => _passwordAlert.Text;
    public void ClickSpartaLogo() => _spartaLogo.Click();
    public void ClickPrivacyPolicy() => _privacyPolicyLink.Click();
    public string GetPageTitle() => _seleniumDriver.Title;
    #endregion
}
