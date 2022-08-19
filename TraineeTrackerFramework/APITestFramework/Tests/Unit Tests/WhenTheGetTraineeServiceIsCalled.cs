using APITestApp;
using APITestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class WhenTheGetTraineeServiceIsCalled
    {
        readonly TraineeServices _traineeServices = new TraineeServices();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _traineeServices.MakeRequestAsync("1", AppConfigReader.AdminAuth);
        }

        [Test]
        public void WhenTheGetTraineeServiceIsCalled_ExpectedTraineeIsReturned()
        {
            Assert.That(_traineeServices.TraineeResponseDTO.Response.firstName, Is.EqualTo("Tuan"));
        }
    }
}
