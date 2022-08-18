using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestFramework.Interface;
using Moq;

namespace APITestFramework.Tests
{
    public class CourseMockTests
    {
        private CourseServices _courseServices;
        private Mock<IService> mockTrainerService = new Mock<IService>();

        [Test]
        [Category("Valid Course")]
        public void TestingAMockCourse()
        {
            //Arrange
            var course = new Course() { id = 2, name = "Engineering 120", startDate = new DateTime(2022, 09, 14), 
                                        trainer = new TrainerResponse() { id = 2, firstName = "Nish"}, 
                                        trainees = new TraineeResponse[2] { new TraineeResponse() { firstName = "Tom"}, new TraineeResponse() { firstName = "David"} }, 
                                        weeksLong = 8};

            // Set up the service so it returns what I want
            mockTrainerService.Setup(ts => ts.GetCourseByID(2)).Returns(course);

            //Act
            _courseServices = new CourseServices(mockTrainerService.Object);
            _courseServices.SetSelectedCourse(course);

            //Assert
            Assert.That(_courseServices.SelectedCourse.id, Is.EqualTo(2));
            Assert.That(_courseServices.SelectedCourse.name, Is.EqualTo("Engineering 120"));
            Assert.That(_courseServices.SelectedCourse.startDate, Is.EqualTo(new DateTime(2022, 09, 14)));
            Assert.That(_courseServices.SelectedCourse.trainer.firstName, Is.EqualTo("Nish"));
            Assert.That(_courseServices.SelectedCourse.trainees[0].firstName, Is.EqualTo("Tom"));
            Assert.That(_courseServices.SelectedCourse.trainees[1].firstName, Is.EqualTo("David"));
            Assert.That(_courseServices.SelectedCourse.weeksLong, Is.EqualTo(8));
        }
    }
}
