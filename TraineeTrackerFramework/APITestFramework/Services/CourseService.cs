using APITestApp.DataHandling;
using APITestApp.HTTPManager;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestFramework.Services
{
    public class CourseServices
    {
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<Course> CourseResponseDTO { get; set; }
        public string Response { get; set; }

        public int status;

        public CourseServices()
        {
            CallManager = new CallManager();
            CourseResponseDTO = new DTO<Course>();
        }

        public async Task MakeRequestAsync(string trainee)
        {
            Json_Response = JObject.Parse(Response);

            CourseResponseDTO.DeserializeResponse(Response);
        }
        public int GetStatus()
        {
            return (int)CallManager.Response.StatusCode;
        }

    }
}
