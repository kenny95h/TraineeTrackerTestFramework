using APITestFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Tests
{
    public class WhenTheDeleteTraineeServiceIsCalled
    {
        readonly TraineeServices _traineeServices = new TraineeServices();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            //await _traineeServices.MakeRequestAsync()
        }
    }
}
