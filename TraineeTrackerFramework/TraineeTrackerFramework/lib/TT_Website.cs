using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TraineeTrackerFramework.lib.driver_config;
using TraineeTrackerFramework.lib.pages.Account;
using TraineeTrackerFramework.lib.pages.Admin;
using TraineeTrackerFramework.lib.pages.Trainees;
using TraineeTrackerFramework.lib.pages.Trainers;

namespace TraineeTrackerFramework.lib;

public class TT_Website<T> where T : IWebDriver, new()
{
    #region Accessible Page Objects and Selenium Driver
    public IWebDriver SeleniumDriver { get; set; }
    public pages.Account.TT_LoginPage TT_Account_LoginPage { get; set; }
    public pages.Account.TT_AccessDenied TT_Account_AccessDeniedPage { get; set; }
    public pages.Admin.TT_Index TT_Admin_TT_IndexPage { get; set; }
    public pages.Courses.TT_Create TT_Courses_CreatePage { get; set; }
    public pages.Courses.TT_CoursesDeletePage TT_Courses_DeletePage { get; set; }
    public pages.Courses.TT_CoursesDetailsPage TT_Courses_DetailsPage { get; set; }
    public pages.Courses.TT_CoursesEditPage TT_Courses_EditPage { get; set; }
    public pages.Courses.TT_CoursesIndexPage TT_Courses_IndexPage { get; set; }
    public pages.Trackers.TT_CreateTrackerPage TT_Trackers_CreatePage { get; set; }
    public pages.Trackers.TT_Delete TT_Trackers_DeletePage { get; set; }
    public pages.Trackers.TT_TrackerDetailsPage TT_Trackers_DetailsPage { get; set; }
    public pages.Trackers.TT_EditTrackerPage TT_Trackers_EditPage { get; set; }
    public pages.Trackers.TT_Index TT_Trackers_IndexPage { get; set; }
    public pages.Trackers.TT_View_Trainer TT_Trackers_ViewTrainerPage { get; set; }
    public pages.Trainees.TT_Create TT_Trainees_CreatePage { get; set; }
    public pages.Trainees.TT_Delete TT_Trainees_DeletePage { get; set; }
    public pages.Trainees.TT_Details TT_Trainees_DetailsPage { get; set; }
    public pages.Trainees.TT_Edit TT_Trainees_EditPage { get; set; } 
    public pages.Trainees.TT_Index TT_Trainees_IndexPage { get; set; }
    public pages.Trainers.TT_Error TT_Trainers_ErrorPage { get; set; }
    public pages.Trainers.TT_Index TT_Trainers_IndexPage { get; set; }

    public pages.TT_Privacy TT_PrivacyPage { get; set; }

    #endregion

    public TT_Website(int pageLoadInsecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
    {
        SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInsecs, implicitWaitInSecs, isHeadless).Driver;
        TT_Account_LoginPage = new pages.Account.TT_LoginPage(SeleniumDriver);
        TT_Account_AccessDeniedPage = new pages.Account.TT_AccessDenied(SeleniumDriver);
        
        TT_Admin_TT_IndexPage = new pages.Admin.TT_Index(SeleniumDriver);
        
        TT_Courses_CreatePage = new pages.Courses.TT_Create(SeleniumDriver);
        TT_Courses_DeletePage = new pages.Courses.TT_CoursesDeletePage(SeleniumDriver);
        TT_Courses_DetailsPage = new pages.Courses.TT_CoursesDetailsPage(SeleniumDriver);
        TT_Courses_EditPage = new pages.Courses.TT_CoursesEditPage(SeleniumDriver);
        TT_Courses_IndexPage = new pages.Courses.TT_CoursesIndexPage(SeleniumDriver);
        
        TT_Trackers_CreatePage = new pages.Trackers.TT_CreateTrackerPage(SeleniumDriver);        
        // TT_Trackers_DeletePage is unnavigable
        TT_Trackers_DetailsPage = new pages.Trackers.TT_TrackerDetailsPage(SeleniumDriver);
        TT_Trackers_EditPage = new pages.Trackers.TT_EditTrackerPage(SeleniumDriver);
        TT_Trackers_IndexPage = new pages.Trackers.TT_Index(SeleniumDriver);
        TT_Trackers_ViewTrainerPage = new pages.Trackers.TT_View_Trainer(SeleniumDriver);
        
        TT_Trainees_CreatePage = new pages.Trainees.TT_Create(SeleniumDriver);
        TT_Trainees_DeletePage = new pages.Trainees.TT_Delete(SeleniumDriver);
        TT_Trainees_DetailsPage = new pages.Trainees.TT_Details(SeleniumDriver);
        TT_Trainees_EditPage = new pages.Trainees.TT_Edit(SeleniumDriver);
        TT_Trainees_IndexPage = new pages.Trainees.TT_Index(SeleniumDriver);
        
        TT_Trainers_ErrorPage = new pages.Trainers.TT_Error(SeleniumDriver);
        TT_Trainers_IndexPage = new pages.Trainers.TT_Index(SeleniumDriver);

        TT_PrivacyPage = new pages.TT_Privacy(SeleniumDriver);
    }
}
