using APITestApp.DataHandling;
using APITestFramework.Interface;
using APITestFramework.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APITestFramework.Tests
{
    public class TrackerMockTests
    {
        private TrackerServices _trackerServices;

        [Test]
        [Category("Valid Course")]
        public void TestingAMockTracker()
        {
            //Arrange
            var mockTrainerService = new Mock<IService>();
            var tracker = new Tracker() { id = 2 };

            // Set up the service so it returns what I want
            mockTrainerService.Setup(ts => ts.GetTrackerByID(2)).Returns(tracker);

            //Act
            _trackerServices = new TrackerServices(mockTrainerService.Object);

            _trackerServices.SetSelectedTracker(tracker);

            //Assert
            Assert.That(_trackerServices.SelectedTracker.id, Is.EqualTo(2));
        }
    }
}
