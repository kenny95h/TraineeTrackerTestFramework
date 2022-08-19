using System;
using TechTalk.SpecFlow;
using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestApp;  
namespace APITestFramework.Tests.Features;

[Binding, Scope(Feature = "Trainer")]
public class TrainerFeatureStepDefinitions : SharedStepDefinitions
{
    ScenarioContext _scenarioContext;
    private TrainerServices _trainerService;
    private TrainerResponse _trainer;

    

    public TrainerFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._trainerService = new TrainerServices();
        Auth = "";
    }


    [When(@"I execute the CREATE Trainer request")]
    public async Task WhenIExecuteTheCreateTrainerRequest()
    {
        try
        {
            await _trainerService.CreateRequestAsync(Endpoint, Auth);
        }
        catch
        {

        }
    }

    [When(@"I execute the GET Trainer request")]
    public async Task WhenIExecuteTheGetTrainerRequest()
    {
        try
        {
            await _trainerService.MakeRequestAsync(Endpoint, Auth);
            _trainer = _trainerService.TrainerResponseDTO.Response;
        }
        catch
        {

        }
    }

    [When(@"I execute the UPDATE Trainer request")]
    public async Task WhenIExecuteTheUpdateTrainerRequest()
    {
        try
        {
            await _trainerService.UpdateRequestAsync(Endpoint, Auth);
            _trainer = _trainerService.TrainerResponseDTO.Response;
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
            _trainer = _trainerService.TrainerResponseDTO.Response;

            _trainerService.GetTrainersCourses();
            _trainerService.GetTrainersTrainees();
        }
        catch
        {

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
        Assert.That(_trainerService.GetStatus(), Is.EqualTo(expectedStatus));
    }
}
