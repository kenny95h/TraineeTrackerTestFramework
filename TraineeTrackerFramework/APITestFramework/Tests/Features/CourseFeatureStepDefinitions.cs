using System;
using TechTalk.SpecFlow;
using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestApp;
namespace APITestFramework.Tests.Features;

[Binding, Scope(Feature = "Course")]
public class CourseFeatureStepDefinitions : SharedStepDefinitions
{
    ScenarioContext _scenarioContext;
    private CourseServices _courseService;
    private Course _course;
    public CourseFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._courseService = new CourseServices(null);
        Auth = "";
    }


    [When(@"I execute the GET Course request")]
    public async Task WhenIExecuteTheGetCourseRequest()
    {
        try
        {
            await _courseService.MakeRequestAsync(Endpoint);
            _course = _courseService.CourseResponseDTO.Response;
        }
        catch
        {

        }
    }

    [Then(@"I should receive a status code of (.*)")]
    public void ThenIShouldReceiveAStatusCodeOf(int expectedStatus)
    {
        Assert.That(_courseService.GetStatus(), Is.EqualTo(expectedStatus));
    }

    [When(@"I execute the the DELETE Course request")]
    public void WhenIExecuteTheTheDeleteCourseRequest()
    {
        throw new PendingStepException();
        //Waiting for course service to be finished
    }

    [Then(@"the course is no longer available in the database")]
    public void ThenTheCourseIsNoLongerAvailableInTheDatabase()
    {
        Assert.That(() => _courseService.MakeRequestAsync(Endpoint), Throws.Exception);
    }

}
