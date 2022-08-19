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

        private List<Course> trainersCourseList = new List<Course>();
        private List<TraineeResponse> traineesList = new List<TraineeResponse>();

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

        public void GetTrainersCourses()
        {
            foreach (Course course in TrainerResponseDTO.Response.courses)
            {
                trainersCourseList.Add(course);
            }
        }
            
        public void GetTrainersTrainees()
        {
            foreach (TraineeResponse trainee in TrainerResponseDTO.Response.trainees)
            {
                traineesList.Add(trainee);
            }
        }

        public bool GetCorrectTrainee()
        {
            for (int i = 0; i < trainersCourseList.Count; i++)
            {
                if (trainersCourseList[i].trainees[i] == traineesList[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
