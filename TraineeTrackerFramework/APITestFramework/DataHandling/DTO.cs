using Newtonsoft.Json;

namespace APITestApp.DataHandling
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        public ResponseType Response { get; set; }

        public void DeserializeResponse(string response)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(response);
        }
    }
}
