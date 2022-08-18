using APITestApp.DataHandling;
using APITestApp.HTTPManager;
using APITestFramework.Interface;
using Castle.Core.Resource;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITestFramework.Services
{
    public class CourseServices
    {
        private readonly IService _service;

        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<Course> CourseResponseDTO { get; set; }

        public Course SelectedCourse { get; set; }

        public string Response { get; set; }

        public int status;

        public CourseServices(IService service)
        {
            CallManager = new CallManager();
            CourseResponseDTO = new DTO<Course>();

            _service = service;
        }

        public void SetSelectedCourse(Course selectedCourse)
        {
            SelectedCourse = selectedCourse;
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
