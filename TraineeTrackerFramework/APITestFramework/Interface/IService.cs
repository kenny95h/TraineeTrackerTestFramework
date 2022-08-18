using APITestApp.DataHandling;

namespace APITestFramework.Interface
{
    public interface IService
    {
        public Course GetCourseByID(int courseId);
        public Tracker GetTrackerByID(int trackerId);
    }
}
