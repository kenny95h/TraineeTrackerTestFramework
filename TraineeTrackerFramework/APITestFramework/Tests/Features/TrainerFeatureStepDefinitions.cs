using System;
using TechTalk.SpecFlow;
using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestApp;  
namespace APITestFramework.Tests.Features;

[Binding]
public class TrainerFeatureStepDefinitions
{
    ScenarioContext _scenarioContext;
    private TrainerServices _trainerService;
    private TrainerResponse _trainer;
    private string _endpoint;
    private string _auth;
    public TrainerFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._trainerService = new TrainerServices();
        this._auth = "";
    }

    [Given(@"I am an admin")]
    public void GivenIAmAnAdmin()
    {
        this._auth = AppConfigReader.AdminAuth;
    }

    [Given(@"I have setup a request with ""([^""]*)""")]
    public void GivenIHaveSetupARequestWith(string endpoint)
    {
        this._endpoint = endpoint;
    }

    [When(@"I execute the CREATE Trainer request")]
    public async Task WhenIExecuteTheCreateTrainerRequest()
    {
        try
        {
            await _trainerService.CreateRequestAsync(_endpoint, _auth);
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
            await _trainerService.MakeRequestAsync(_endpoint, _auth);
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
            await _trainerService.UpdateRequestAsync(_endpoint, _auth);
            _trainer = _trainerService.TrainerResponseDTO.Response;
        }
        catch
        {

        }
    }

    [Then(@"I should receive a status code of (.*)")]
    public void ThenIShouldReceiveAStatusCodeOf(int expectedStatus)
    {
        Assert.That(_trainerService.GetStatus(), Is.EqualTo(expectedStatus));
    }
}
