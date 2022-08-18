using System;
using TechTalk.SpecFlow;
using APITestApp.DataHandling;
using APITestFramework.Services;
using APITestApp;

namespace APITestFramework.Tests.Features;
[Binding]
public class SharedStepDefinitions
{
    public string Endpoint;
    public string Auth;

    [Given(@"I am an admin")]
    public void GivenIAmAnAdmin()
    {
        Auth = AppConfigReader.AdminAuth;
    }

    [Given(@"I am a trainer")]
    public void GivenIAmATrainer()
    {
        Auth = AppConfigReader.TrainerAuth;
    }

    [Given(@"I am a trainee")]
    public void GivenIAmATrainee()
    {
        Auth = AppConfigReader.TraineeAuth;
    }
    [Given(@"I have setup a request with ""([^""]*)""")]
    public void GivenIHaveSetupARequestWith(string endpoint)
    {
        Endpoint = endpoint;
    }


}
