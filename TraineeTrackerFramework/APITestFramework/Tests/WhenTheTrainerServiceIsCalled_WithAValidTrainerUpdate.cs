using APITestApp;
using APITestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class WhenTheTrainerServiceIsCalled_WithAValidTrainerUpdate
    {
        readonly TrainerServices _trainerServices = new TrainerServices();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _trainerServices.UpdateRequestAsync("7,Tom,Wolstencroft,Mr.,twolse@spartaglobal.com,Trainer", AppConfigReader.AdminAuth);
        }

        [Test]
        public void StatusCode_Is200()
        {
            Assert.That(_trainerServices.status, Is.EqualTo(200));
        }

        [Test]
        public void Update_IsTrue()
        {
            Assert.That(_trainerServices.Response, Is.EqualTo("true"));
        }
    }
}
