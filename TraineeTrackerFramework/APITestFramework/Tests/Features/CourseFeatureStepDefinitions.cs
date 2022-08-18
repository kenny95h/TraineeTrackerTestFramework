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
    private Exception _exception;
    public CourseFeatureStepDefinitions(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        this._courseService = new CourseServices();
        Auth = "";
    }


    [When(@"I execute the the DELETE Course request")]
    public async Task WhenIExecuteTheTheDELETECourseRequest()
    {
        try
        {
            await _courseService.DeleteRequestAsync(Endpoint, Auth);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [When(@"I execute the CREATE Course request")]
    public async Task WhenIExecuteTheCREATECourseRequest()
    {
        try
        {
            await _courseService.CreateRequestAsync(Endpoint, Auth);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }


    [Then(@"the name of the course ""([^""]*)"" is available in the database")]
    public void ThenTheNameOfTheCourseIsAvailableInTheDatabase(string courseName)
    {
        Assert.That(_courseService.CourseResponseDTO.Response.name, Is.EqualTo(courseName));
    }

    [Then(@"I am returned a status code (.*)")]
    public void ThenIAmReturnedAnErrorStatusCode(int status)
    {
        Assert.That(_courseService.GetStatus, Is.EqualTo(status));
    }

    [Then(@"I am returned an exception")]
    public void ThenIAmReturnedAnException()
    {
        Assert.That(_exception.ToString(), Does.Contain("exception").IgnoreCase);
    }


}
