using System.Configuration;

namespace TraineeTrackerFramework;

public static class AppConfigReader
{
    public static readonly string AccountLoginURL = ConfigurationManager.AppSettings["account_login_url"];
    public static readonly string AccountAccessDeniedURL = ConfigurationManager.AppSettings["account_accessdenied_url"];
    public static readonly string AdminIndexURL = ConfigurationManager.AppSettings["admin_index_url"];
    public static readonly string CoursesCreateURL = ConfigurationManager.AppSettings["courses_create_url"];
    public static readonly string CoursesDeleteURL = ConfigurationManager.AppSettings["courses_delete_url"];
    public static readonly string CoursesDetailsURL = ConfigurationManager.AppSettings["courses_details_url"];
    public static readonly string CoursesEditURL = ConfigurationManager.AppSettings["courses_edit_url"];
    public static readonly string CoursesIndexURL = ConfigurationManager.AppSettings["courses_index_url"];
    public static readonly string TrackersCreateURL = ConfigurationManager.AppSettings["trackers_create_url"];
    public static readonly string TrackersDeleteURL = ConfigurationManager.AppSettings["trackers_delete_url"];
    public static readonly string TrackersDetailsURL = ConfigurationManager.AppSettings["trackers_details_url"];
    public static readonly string TrackersEditURL = ConfigurationManager.AppSettings["trackers_edit_url"];
    public static readonly string TrackersIndexURL = ConfigurationManager.AppSettings["trackers_index_url"];
    public static readonly string TrackersViewTrainerURL = ConfigurationManager.AppSettings["trackers_view_trainer_url"];
    public static readonly string TraineesCreateURL = ConfigurationManager.AppSettings["trainees_create_url"];
    public static readonly string TraineesDeleteURL = ConfigurationManager.AppSettings["trainees_delete_url"];
    public static readonly string TraineesDetailsURL = ConfigurationManager.AppSettings["trainees_details_url"];
    public static readonly string TraineesEditURL = ConfigurationManager.AppSettings["trainees_edit_url"];
    public static readonly string TraineesIndexURL = ConfigurationManager.AppSettings["trainees_index_url"];
    public static readonly string TrainersIndexURL = ConfigurationManager.AppSettings["trainees_details_url"];
    public static readonly string PrivacyURL = ConfigurationManager.AppSettings["privacy_url"];
    public static readonly string ErrorURL = ConfigurationManager.AppSettings["error_url"];
    public static readonly string IndexURL = ConfigurationManager.AppSettings["index_url"];
}
