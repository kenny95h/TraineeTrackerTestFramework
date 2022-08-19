using APITestApp;
using APITestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class WhenTheCourseServiceIsCalled_WithAValidCourseToDelete
    {
        readonly CourseServices _courseServices = new CourseServices();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _courseServices.DeleteRequestAsync("6", AppConfigReader.AdminAuth);
        }

        [Test]
        public void StatusCode_Is204()
        {
            Assert.That(_courseServices.GetStatus, Is.EqualTo(204));
        }
    }
}
