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
    private TraineeResponse _trainee;

    public TraineeFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._traineeService = new TraineeServices();
        Auth = "";
    }

    [When(@"I execute the GET Trainee request")]
    public async Task WhenIExecuteTheGetTraineeRequest()
    {
        try
        {
            await _traineeService.MakeRequestAsync(Endpoint, Auth);
            _trainee = _traineeService.TraineeResponseDTO.Response;
        }
        catch
        {

        }
    }

    [Then(@"I should receive a status code of (.*)")]
    public void ThenIShouldReceiveAStatusCodeOf(int expectedStatus)
    {
        Assert.That(_traineeService.GetStatus(), Is.EqualTo(expectedStatus));
    }
}
