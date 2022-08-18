using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class Trainees_IndexStepDefinitions
    {
        [When(@"I am redirected to the Trainees page")]
        public void WhenIAmRedirectedToTheTraineesPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see a list of all Trainees")]
        public void ThenIShouldSeeAListOfAllTrainees()
        {
            throw new PendingStepException();
        }
    }
}
