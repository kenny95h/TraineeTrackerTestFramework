using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class Trainers_IndexStepDefinitions
    {
        [When(@"I navigate to the Trainers page")]
        public void WhenINavigateToTheTrainersPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see a list of all Trainers")]
        public void ThenIShouldSeeAListOfAllTrainers()
        {
            throw new PendingStepException();
        }
    }
}
