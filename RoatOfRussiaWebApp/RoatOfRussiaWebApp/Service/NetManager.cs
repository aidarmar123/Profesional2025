
using Newtonsoft.Json;

namespace RoatOfRussiaWebApp.Service
{
    public static class NetManager
    {
        public static string URL = "http://localhost:62367/";
        public static HttpClient httpClient = new HttpClient();

        public static async Task<T> Get<T>(string path)
        {
            var response = await httpClient.GetAsync(URL+path);
            var content = await response.Content.ReadAsStringAsync();
            var data =  JsonConvert.DeserializeObject<T>(content);
            return data;
        }
       
    }
}
