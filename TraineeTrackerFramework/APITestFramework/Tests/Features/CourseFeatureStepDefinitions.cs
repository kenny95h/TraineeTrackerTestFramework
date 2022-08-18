using APITestApp.DataHandling;
using APITestFramework.Services;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace APITestFramework.Tests.Features;

[Binding]
public class CourseFeatureStepDefinitions
{
    ScenarioContext _scenarioContext;
    private TrainerServices _trainerService;
    private TrainerResponse _trainer;
    private string _endpoint;
    private string _auth;
    public CourseFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._trainerService = new TrainerServices();
        this._auth = "";
    }


    [When(@"I execute the GET Course request")]
    public async Task WhenIExecuteTheGETCourseRequest()
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
}
