using APITestApp;
using APITestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class TrainerTests
    {
        readonly TrainerServices _trainerServices = new TrainerServices();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _trainerServices.MakeRequestAsync("5",AppConfigReader.AdminAuth);
        }

        [Test]
        public void NameOfTrainer_IsAllIWant()
        {
            Assert.That(_trainerServices.TrainerResponseDTO.Response.firstName, Is.EqualTo("Cathy"));
        }
    }
}
