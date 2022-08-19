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
        this._trackerService = new TrackerServices(null);
        Auth = "";
    }

    [When(@"I execute the GET Tracker request")]
    public async Task WhenIExecuteTheGETTrackerRequest()
    {
        try
        {
            await _trackerService.MakeRequestAsync(Endpoint, Auth);
            _tracker = _trackerService.TrackerResponseDTO.Response;
            ResponseContent = _trackerService.Response;
        }
        catch
        {

        }
    }
    [When(@"I execute the UPDATE Tracker request")]
    public async Task WhenIExecuteTheUPDATETrackerRequest()
    {
        try
        {
            await _trackerService.UpdateRequestAsync(Endpoint, Auth);
            _tracker = _trackerService.TrackerResponseDTO.Response;
            ResponseContent = _trackerService.Response;
        }
        catch
        {

        }
    }
    [When(@"I execute the CREATE Tracker request")]
    public async Task WhenIExecuteTheCreateTrackerRequest()
    {
        try
        {
            await _trackerService.CreateRequestAsync(Endpoint, Auth);
            _tracker = _trackerService.TrackerResponseDTO.Response;
            ResponseContent = _trackerService.Response;
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

    [Then(@"I should receive all the trackers")]
    public void ThenIShouldReceiveAllTheTrackers()
    {
        Assert.That(_trackerService.Response, Does.Contain("{\"id\":1,\"weekNumber\":1,\"stop\":\"Enter comment here\",\"start\":\"Enter comment here\",\"continue\":\"Enter comment here\",\"comment\":\"Enter comment here\",\"technicalSkill\":1,\"consultantSkill\":1,\"trainee\":null},{\"id\":2,\"weekNumber\":2,\"stop\":\"Enter comment here\",\"start\":\"Enter comment here\",\"continue\":\"Enter comment here\",\"comment\":\"Enter comment here\",\"technicalSkill\":1,\"consultantSkill\":1,\"trainee\":null},{\"id\":3,\"weekNumber\":3,\"stop\":\"Enter comment here\",\"start\":\"Enter comment here\",\"continue\":\"Enter comment here\",\"comment\":\"Enter comment here\",\"technicalSkill\":1,\"consultantSkill\":1,\"trainee\":null},"));
        Assert.That(_trackerService.Response, Does.Contain("{\"id\":88,\"weekNumber\":8,\"stop\":\"Enter comment here\",\"start\":\"Enter comment here\",\"continue\":\"Enter comment here\",\"comment\":\"Enter comment here\",\"technicalSkill\":1,\"consultantSkill\":1,\"trainee\":null}"));
    }

}
