using APITestApp.DataHandling;
using APITestApp.HTTPManager;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Services
{
    public class TrainerServices
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<TrainerResponse> TrainerResponseDTO { get; set; }
        public string Response { get; set; }

        public int status;

        public TrainerServices()
        {
            CallManager = new CallManager();
            TrainerResponseDTO = new DTO<TrainerResponse>();
        }

        public async Task MakeRequestAsync(string trainer, string auth)
        {
            Response = await CallManager.MakeRequestAsync(auth, Resource.Trainers, trainer, Method.Get);

            Json_Response = JObject.Parse(Response);

            TrainerResponseDTO.DeserializeResponse(Response);
        }

        public async Task CreateRequestAsync(string trainer, string auth)
        {
            Response = await CallManager.MakeRequestAsync(auth, Resource.Trainers, trainer, Method.Post); 

            Json_Response = JObject.Parse(Response);

            TrainerResponseDTO.DeserializeResponse(Response);
        }

        public async Task UpdateRequestAsync(string trainer, string auth)
        {
            Response= await CallManager.MakeRequestAsync(auth, Resource.Trainers, trainer, Method.Put);

            //Response only returns true/false - Cannot convert

            //Json_Response = JObject.Parse(Response);

            //TrainerResponseDTO.DeserializeResponse(Response);
        }

        public int GetStatus()
        {
            return (int)CallManager.Response.StatusCode;
        }
    }
}
