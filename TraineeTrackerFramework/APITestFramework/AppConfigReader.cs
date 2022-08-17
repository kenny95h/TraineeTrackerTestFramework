using System.Configuration;

namespace APITestApp
{
    public static class AppConfigReader
    {
        public static readonly string baseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string adminUrl = ConfigurationManager.AppSettings["admin_url"];
        public static readonly string loginUrl = ConfigurationManager.AppSettings["login_url"];
        public static readonly string accessdeniedUrl = ConfigurationManager.AppSettings["accessdenied_url"];
        public static readonly string coursesUrl = ConfigurationManager.AppSettings["courses_url"];
        public static readonly string trackersUrl = ConfigurationManager.AppSettings["trackers_url"];
        public static readonly string traineesUrl = ConfigurationManager.AppSettings["trainees_url"];
        public static readonly string trainersUrl = ConfigurationManager.AppSettings["trainers_url"];
        public static readonly string createUrl = ConfigurationManager.AppSettings["create_url"];
        public static readonly string editUrl = ConfigurationManager.AppSettings["edit_url"];
        public static readonly string detailsUrl = ConfigurationManager.AppSettings["details_url"];
        public static readonly string deleteUrl = ConfigurationManager.AppSettings["delete_url"];
        public static readonly string privacyUrl = ConfigurationManager.AppSettings["privacy_url"];
        //Authorisation types
        public static readonly string AdminAuth = ConfigurationManager.AppSettings["admin_auth"];
        public static readonly string TrainerAuth = ConfigurationManager.AppSettings["trainer_auth"];
        public static readonly string TraineeAuth = ConfigurationManager.AppSettings["trainee_auth"];
    }
}
