using System.Configuration;

namespace TraineeTrackerFramework;

public static class AppConfigReader
{
    public static readonly string LoginURL = ConfigurationManager.AppSettings["login_url"];
    public static readonly string IndexURL = ConfigurationManager.AppSettings["index_url"];
    //Needs dll 
}
