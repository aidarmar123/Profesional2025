using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoatOfRussiaMobileApp.Service
{
    public static class NetManager
    {
        public static string URl = "http://localhost:62367/";
        public static HttpClient httpClient = new HttpClient();
        public static async Task<T> Get<T>(string path)
        {
            var response = await httpClient.GetAsync(URl +path);
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static async Task<HttpResponseMessage> Put<T>(T data, string path)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PutAsync(URl + path, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }
    }
}
