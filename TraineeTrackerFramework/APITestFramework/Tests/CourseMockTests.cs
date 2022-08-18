using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestFramework.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APITestFramework.Tests
{
    public class CourseMockTests
    {
        private CourseServices _courseServices;

        [Test]
        [Category("Valid Course")]
        public void TestingAMockCourse()
        {
            //Arrange
            var mockTrainerService = new Mock<IService>();
            var course = new Course() { id = 2 };

            // Set up the service so it returns what I want
            mockTrainerService.Setup(ts => ts.GetCourseByID(2)).Returns(course);

            //Act
            _courseServices = new CourseServices(mockTrainerService.Object);

            _courseServices.SetSelectedCourse(course);

            //Assert
            Assert.That(_courseServices.SelectedCourse.id, Is.EqualTo(2));
        }
    }
}
