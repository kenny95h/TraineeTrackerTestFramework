using System;
using TechTalk.SpecFlow;
using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestApp;
namespace APITestFramework.Tests.Features;

[Binding, Scope(Feature = "Trainee")]
public class TraineeFeatureStepDefinitions : SharedStepDefinitions
{
    ScenarioContext _scenarioContext;
    private TraineeServices _traineeService;
    private TrainerServices _trainerService;
    private TraineeResponse _trainee;
    private Exception _exception;

    public TraineeFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._traineeService = new TraineeServices();
        this._trainerService = new TrainerServices();
        Auth = "";
    }

    [When(@"I execute the GET Trainee request")]
    public async Task WhenIExecuteTheGetTraineeRequest()
    {
        try
        {
            await _traineeService.MakeRequestAsync(Endpoint, Auth);
        }
        catch
        {

        }
    }

    [When(@"I request to read all trainees")]
    public async Task WhenIRequestToReadAllTrainees() // See all trainees on my course
    {
        try
        {
            await _trainerService.MakeRequestAsync(Endpoint, Auth);

            _trainerService.GetTrainersCourses();
            _trainerService.GetTrainersTrainees();
        }
        catch
        {

        }
    }

    [When(@"I execute the DELETE trainee request")]
    public async Task WhenIExecuteTheDELETETraineeRequest()
    {
        try
        {
            await _traineeService.DeleteRequestAsync(Endpoint, Auth);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"I am displayed with all trainee details for my courses")]
    public void ThenIAmDisplayedWithAllTraineeDetailsForMyCourses() // Assert that all trainees from a list are on the course
    {
        Assert.That(_trainerService.GetCorrectTrainee());
    }

    [Then(@"I should receive a status code of (.*)")]
    public void ThenIShouldReceiveAStatusCodeOf(int expectedStatus)
    {
        Assert.That(_traineeService.GetStatus(), Is.EqualTo(expectedStatus));
    }
}
