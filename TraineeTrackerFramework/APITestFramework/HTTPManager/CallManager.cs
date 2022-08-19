using RestSharp;

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

        public async Task<string> MakeRequestAsync(string auth, Resource resource, string code, Method method)
        {
            _request.AddHeader("Authorization", auth);
            switch (resource)
            {
                case Resource.Trainers:
                    if (method == Method.Post)
                    {
                        string[] trainer = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}";
                        _request.AddJsonBody(new { firstname = trainer[0], lastname = trainer[1], title = trainer[2], email = trainer[3], permissionrole = trainer[4] });
                    }
                    else if (method == Method.Put)
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

                    return Response.Content;

                case Resource.Trackers:

                    if (method == Method.Post)
                    {
                        string[] updateTracker = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}";
                        _request.AddJsonBody(new
                        {
                            WeekNumber = updateTracker[0],
                            comment = updateTracker[1],
                            technicalSkill = updateTracker[2],
                            consultantSkill = updateTracker[3],
                            trainee = new
                            {
                                firstname = updateTracker[4],
                                lastname = updateTracker[5],
                                title = updateTracker[6],
                                email = updateTracker[7],
                                permissionrole = updateTracker[8]
                            }
                        });
                    }
                    else if (method == Method.Put)
                    {
                        string[] updateTracker = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{updateTracker[0]}";
                        _request.AddJsonBody(new
                        {
                            WeekNumber = updateTracker[1],
                            comment = updateTracker[2],
                            technicalSkill = updateTracker[3],
                            consultantSkill = updateTracker[4],
                            trainee = new
                            {
                                firstname = updateTracker[5],
                                lastname = updateTracker[6],
                                title = updateTracker[7],
                                email = updateTracker[8],
                                permissionrole = updateTracker[9]
                            }
                        });
                    }
                    else
                    {
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{code}";
                    }

                    _request.Method = method;

                    Response = await _client.ExecuteAsync(_request);

                    return Response.Content;

                case Resource.Trainees:
                    if (method == Method.Get)
                    {
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{code}";
                    }
                    else if (method == Method.Delete)
                    {
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{code}";
                    }
                    _request.Method = method;
                    Response = await _client.ExecuteAsync(_request);
                    return Response.Content;

                case Resource.Courses:
                    if (method == Method.Post)
                    {
                        string[] course = code.Split(','); ;
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}";
                        _request.AddJsonBody(new { name = course[0], startdate = course[1], weekslong = course[2], trainer = new { firstname = course[3], lastname = course[4], title = course[5], email = course[6], permissionrole = course[7] } });
                    }
                    else
                    {
                        _request.Resource = $"{AppConfigReader.baseUrl}{resource}/{code}";
                    }
                    _request.Method = method;

                    Response = await _client.ExecuteAsync(_request);

                    return Response.Content;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
