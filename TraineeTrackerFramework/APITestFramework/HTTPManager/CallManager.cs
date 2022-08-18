using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.HTTPManager
{
    public class CallManager
    {
        private readonly RestClient _client;

        private RestRequest _request;
        public RestResponse Response { get; set; }

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.baseUrl);

            _request = new RestRequest();
            _request.AddHeader("Content-Type", "application/json");
        }

        public async Task<(string, int)> MakeRequestAsync(string auth, Resource resource, string code, Method method)
        {
            _request.AddHeader("Authorization", auth);
            switch (resource)
            {
                case Resource.Trainers:
                    if(method == Method.Post)
                    {
                        string[] trainer = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}";
                        _request.AddJsonBody(new { firstname = trainer[0], lastname= trainer[1], title = trainer[2], email = trainer[3], permissionrole = trainer[4] });
                    }
                    else if(method == Method.Put)
                    {
                        string[] updateTrainer = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{updateTrainer[0]}";
                        _request.AddJsonBody(new { id = updateTrainer[0], firstname = updateTrainer[1], lastname = updateTrainer[2], title = updateTrainer[3], email = updateTrainer[4], permissionrole = updateTrainer[5] });
                    }
                    else
                    {
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{code}";
                    }

                    _request.Method = method;

                    Response = await _client.ExecuteAsync(_request);

                    return (Response.Content, (int)Response.StatusCode);

                case Resource.GetTracker:
                    if (method == Method.Post)
                    {
                        string[] updateTracker = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{updateTracker[0]}";
                        _request.AddJsonBody(new
                        {
                            stop = updateTracker[0],
                            start = updateTracker[1],
                            _continue = updateTracker[2],
                            comment = updateTracker[3],
                            technicalSkill = updateTracker[4],
                            consultantSkill = updateTracker[5],
                            trainee = updateTracker[6]
                        });
                    }
                    else if (method == Method.Put)
                    {
                        string[] updateTracker = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{updateTracker[0]}";
                        _request.AddJsonBody(new { 
                            id = updateTracker[0], 
                            stop = updateTracker[1],
                            start = updateTracker[2],
                            _continue = updateTracker[3],
                            comment = updateTracker[4],
                            technicalSkill = updateTracker[5],
                            consultantSkill = updateTracker[6],
                            trainee = updateTracker[7]
                        });
                    }
                    else
                    {
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{code}";
                    }

                    _request.Method = method;

                    Response = await _client.ExecuteAsync(_request);

                    return (Response.Content, (int)Response.StatusCode);

                default:
                    throw new ArgumentException();

            }
        }
    }
}
