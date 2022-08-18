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
    private HttpResponseMessage _response;
    private string _endpoint; 
    public TrainerFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._trainerService = new TrainerServices();
    }

    [Given(@"I have setup a GET request with an endpoint ""([^""]*)""")]
    public void GivenIHaveSetupAGETRequestWithAnEndpoint(string endpoint)
    {
        this._endpoint = endpoint;
    }

    [When(@"I execute the request")]
    public async Task WhenIExecuteTheRequest()
    {
        try
        {
            await _trainerService.MakeRequestAsync(_endpoint, AppConfigReader.AdminAuth);
            _trainer = _trainerService.TrainerResponseDTO.Response;
        }
        catch 
        {

        }
    }

    [Then(@"I should receive a status code of (.*)")]
    public void ThenIShouldReceiveAStatusCodeOf(int expectedStatus)
    {
        Assert.That((int)_trainerService.status, Is.EqualTo(expectedStatus));
    }
}
