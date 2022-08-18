namespace APITestApp.DataHandling
{
    
    public class Course : IResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public int weeksLong { get; set; }
        public TrainerResponse trainer { get; set; }
        public TraineeResponse[] trainees { get; set; }
    }

    public class TrainerResponse : IResponse
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public object contactNumber { get; set; }
        public string permissionRole { get; set; }
        public object[] trainees { get; set; }
        public Course[] courses { get; set; }
    }

    public class TraineeResponse : IResponse
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public object contactNumber { get; set; }
        public object profileLink { get; set; }
        public Course course { get; set; }
    }

    public class Tracker : IResponse
    {
        public int id { get; set; }
        public int weekNumber { get; set; }
        public string stop { get; set; }
        public string start { get; set; }
        public string _continue { get; set; }
        public string comment { get; set; }
        public int technicalSkill { get; set; }
        public int consultantSkill { get; set; }
        public object trainee { get; set; }
    }
}
