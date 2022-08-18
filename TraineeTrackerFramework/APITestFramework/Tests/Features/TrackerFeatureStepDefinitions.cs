using System;
using TechTalk.SpecFlow;
using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestApp;
namespace APITestFramework.Tests.Features;

[Binding, Scope(Feature = "Tracker")]
public class TrackerFeatureStepDefinitions : SharedStepDefinitions
{
    ScenarioContext _scenarioContext;
    private TrackerServices _trackerService;
    private Tracker _tracker;

    public TrackerFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        //this._trackerService = new TrackerServices();
        Auth = "";
    }

    [When(@"I execute the GET Tracker request")]
    public async Task WhenIExecuteTheGETTrackerRequest()
    {
        try
        {
            //await _trackerService.MakeRequestAsync(Endpoint);
            _tracker = _trackerService.TrackerResponseDTO.Response;
        }
        catch
        {

        }
    }

    [Then(@"I should receive a status code of (.*)")]
    public void ThenIShouldReceiveAStatusCodeOf(int expectedStatus)
    {
        Assert.That(_trackerService.GetStatus(), Is.EqualTo(expectedStatus));
    }
}
