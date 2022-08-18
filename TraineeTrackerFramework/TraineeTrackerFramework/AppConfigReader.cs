using System.Configuration;

namespace TraineeTrackerFramework;

public static class AppConfigReader
{
    public static readonly string LoginURL = ConfigurationManager.AppSettings["account_login_url"];
    public static readonly string TraineesDeleteURL = ConfigurationManager.AppSettings["trainees_delete_url"];
    public static readonly string TraineesDetailsURL = ConfigurationManager.AppSettings["trainees_details_url"];
}
