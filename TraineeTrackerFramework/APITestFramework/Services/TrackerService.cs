using APITestApp.DataHandling;
using APITestApp.HTTPManager;
using APITestFramework.Interface;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestFramework.Services
{
    public class TrackerServices
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<Tracker> TrackerResponseDTO { get; set; }
        public string Response { get; set; }

        public Tracker SelectedTracker { get; set; }

        public int status;

        public TrackerServices(IService tracker)
        {
            CallManager = new CallManager();
            TrackerResponseDTO = new DTO<Tracker>();
        }

        public async Task MakeRequestAsync(string tracker, string auth)
        {
            Response = await CallManager.MakeRequestAsync(auth, Resource.Trackers, tracker, Method.Get);

            Json_Response = JObject.Parse(Response);

            TrackerResponseDTO.DeserializeResponse(Response);
        }

        public async Task CreateRequestAsync(string tracker, string auth)
        {
            Response = await CallManager.MakeRequestAsync(auth, Resource.Trackers, tracker, Method.Post);

            Json_Response = JObject.Parse(Response);

            TrackerResponseDTO.DeserializeResponse(Response);
        }

        public async Task UpdateRequestAsync(string tracker, string auth)
        {
            Response = await CallManager.MakeRequestAsync(auth, Resource.Trackers, tracker, Method.Put);

            //Response only returns true/false - Cannot convert

            //Json_Response = JObject.Parse(Response);

            //TrackerResponseDTO.DeserializeResponse(Response);
        }
        public int GetStatus()
        {
            return (int)CallManager.Response.StatusCode;
        }

        public void SetSelectedTracker(Tracker selectedTracker)
        {
            SelectedTracker = selectedTracker;
        }
    }
}
