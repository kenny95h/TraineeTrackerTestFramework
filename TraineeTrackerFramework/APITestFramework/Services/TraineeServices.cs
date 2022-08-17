using APITestApp.DataHandling;
using APITestApp.HTTPManager;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestFramework.Services
{
    public class TraineeServices
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<TraineeResponse> TraineeResponseDTO { get; set; }
        public string Response { get; set; }

        public int status;

        public TraineeServices()
        {
            CallManager = new CallManager();
            TraineeResponseDTO = new DTO<TraineeResponse>();
        }

        public async Task MakeRequestAsync(string trainee)
        {
            //(TraineeResponse, status) = await CallManager.MakeRequestAsync(Resource.GetTrainee, trainee, Method.Post); // Will not work. MakeRequestAsync needs uncommenting

            Json_Response = JObject.Parse(Response);

            TraineeResponseDTO.DeserializeResponse(Response);
        }
    }
}
