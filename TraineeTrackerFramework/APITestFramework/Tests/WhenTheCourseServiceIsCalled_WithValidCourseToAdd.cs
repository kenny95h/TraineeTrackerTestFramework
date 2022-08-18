using APITestApp;
using APITestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class WhenTheCourseServiceIsCalled_WithValidCourseToAdd
    {
        readonly CourseServices _courseServices = new CourseServices();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _courseServices.CreateRequestAsync("Engineering120,2022-08-18T00:00:00,8,Charlie,Batten,Mr.,cb@spartaglobal.com,Trainer", AppConfigReader.AdminAuth);
        }

        [Test]
        public void NameOfCourse_IsEngineering120()
        {
            Assert.That(_courseServices.CourseResponseDTO.Response.name, Is.EqualTo("Engineering120"));
        }
    }
}
