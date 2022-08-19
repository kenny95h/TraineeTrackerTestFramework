using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TraineeTrackerFramework.BDD.Steps
{
    [Binding]
    public class TraineesDetailsStepDefinitions
    {
        [Given(@"I am logged in with valid credentials")]
        public void GivenIAmLoggedInAsAnAdmin()
        {
            throw new PendingStepException();
        }

        [Given(@"I am on the trainee index page")]
        public void GivenIAmOnTheTraineeListPage()
        {
            throw new PendingStepException();
        }

        [When(@"I click Details")]
        public void WhenIClickDetails()
        {
            throw new PendingStepException();

        }

        [Then(@"I should land on the trainee details page")]
        public void ThenIShouldLandOnTheTraineeDetailsPage()
        {
            throw new PendingStepException();

        }
    }
}
