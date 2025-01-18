using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public static class NetManager
    {
        public static string URL = "https://localhost:44399/";
        public static HttpClient httpClinet = new HttpClient();

        public static async Task<T> Get<T>(string path)
        {
            var response = await httpClinet.GetAsync(URL + path);
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static async Task<HttpResponseMessage> Post<T>(string path, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClinet.PostAsync(URL + path, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }
        public static async Task<HttpResponseMessage> Put<T>(string path, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClinet.PostAsync(URL + path, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }
        public static async Task<HttpResponseMessage> Delete(string path)
        {
            var response = await httpClinet.DeleteAsync(URL + path);
            return response;
        }
    }
}
