using APITestApp.DataHandling;
using APITestApp.HTTPManager;
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

        public TrackerServices()
        {
            CallManager = new CallManager();
            TrackerResponseDTO = new DTO<Tracker>();
        }

        public async Task MakeRequestAsync(string trainee)
        {
            Json_Response = JObject.Parse(Response);

            TrackerResponseDTO.DeserializeResponse(Response);
        }
        public int GetStatus()
        {
            return (int)CallManager.Response.StatusCode;
        }

    }
}
