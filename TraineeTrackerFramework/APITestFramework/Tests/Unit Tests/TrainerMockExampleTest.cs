using APITestFramework.Services;
using Moq;
using APITestApp.DataHandling;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class TrainerMockExampleTest
    {
        private TrainerServices _trainerServices;

        /// <summary>
        /// Test methods would have a similar structure to TestAMockTrainer()
        /// 
        /// Test methods would be based on Create, Read, Update, Delete
        /// 
        /// TrainerServices Constructor, or second Constructor needs an interface parameter which will allow for the mockTrainerServices.object
        /// </summary>

        [Test]
        public void TestingAMockTrainer() // Example Mock Test (SetSelectedCustomer Method not implemented in the Trainer Class)
        {
            //Arrange
            var mockTrainerService = new Mock<IResponse>();
            var trainer = new TrainerResponse() { id = 2 };

            // Set up the service so it returns what I want
            //mockTrainerService.Setup(ts => ts.GetTrainerById(2)).Returns(trainer);

            //Act
            //_trainerServices = new TrainerServices(mockTrainerService.Object);

            //_trainerServices.SetSelectedTrainer(trainer);

            //Assert
            //Assert.That(_trainerServices.SelectedTrainer.id, Is.EqualTo(2));
        }
    }
}
