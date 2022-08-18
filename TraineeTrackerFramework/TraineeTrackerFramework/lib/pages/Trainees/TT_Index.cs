using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerFramework.lib.pages.Trainees;

public class TT_Index
{
    private IWebDriver _seleniumDriver;
    private string _traineesDetailsURL = AppConfigReader.TraineesDetailsURL;

    #region Properties and Fields
    private IWebElement _spartaLogo => _seleniumDriver.FindElement(By.XPath("//img[@src='/assets/sparta-logo.png']"));
    private IWebElement _pageTitleHeader => _seleniumDriver.FindElement(By.ClassName("h1"));
    private IWebElement _createNewTraineeLink => _seleniumDriver.FindElement(By.XPath("//a[@href='/Trainees/Create']"));
    private IWebElement _searchFilter => _seleniumDriver.FindElement(By.Id("SearchString"));
    private IWebElement _submitFilter => _seleniumDriver.FindElement(By.XPath("//input[@value='Filter']"));
    private IWebElement _resetFilter => _seleniumDriver.FindElement(By.XPath("//input[@value='Reset']"));
    private List<IWebElement> _firstNames => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[0].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _lastNames => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[1].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _traineeTitles => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[2].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _emailAddresses => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[3].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _contactNumbers => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[4].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _permissionRoles => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[5].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _profileLinks => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[6].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _trackers => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[7].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _consultantSkills => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[8].FindElements(By.TagName("td")).ToList();
    private List<IWebElement> _technicalSkills => _seleniumDriver.FindElement(By.ClassName("table")).FindElements(By.TagName("tr")).ToArray()[9].FindElements(By.TagName("td")).ToList();
    private Dictionary<string, Dictionary<string, IWebElement>> trainees;
    #endregion

    public TT_Index(WebDriver SeleniumDriver)
    {
        _seleniumDriver = SeleniumDriver;
        trainees = new Dictionary<string, Dictionary<string, IWebElement>>();

        for (int i = 0; i < _emailAddresses.Count; i++)
        {
            trainees.Add(_emailAddresses[i].Text, new Dictionary<string, IWebElement>()
            {
                {"first_name", _firstNames[i] },
                {"last_name", _lastNames[i] },
                {"contact_number", _contactNumbers[i] },
                {"permission_role", _permissionRoles[i] },
                {"profile_link", _profileLinks[i] },
                {"tracker_edit", _trackers[i].FindElement(By.XPath($"//a[@href='/Trainees/Edit?id={i}']")) },
                {"tracker_details", _trackers[i].FindElement(By.XPath($"//a[@href='/Trainees/Details?id={i}']")) },
                {"tracker_delete", _trackers[i].FindElement(By.XPath($"//a[@href='/Trainees/Delete?id={i}']")) },
                {"consultant_skills", _firstNames[i] },
                {"technical_skills", _firstNames[i] }
            });
        }
    }

    #region Methods
    public void ClickSpartaLogo() => _spartaLogo.Click();
    public void ClickCreateNew() => _createNewTraineeLink.Click();
    public string GetFilterText() => _searchFilter.Text;
    public void SetFilterText(string text) => _searchFilter.SendKeys(text);
    public void ClickSubmitFilter() => _submitFilter.Click();
    public void ClickResetFilter() => _resetFilter.Click();
    #endregion
}
