using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Assignment2.Model;
using Newtonsoft.Json;

namespace Assignment2.Model
{
    public class NetworkingManager
    {
        private string url = "https://api.openweathermap.org/data/2.5/weather?q=Etobicoke&appid=67cd38d57255aecdca14e4517ab17841";
        private HttpClient client = new HttpClient();

        public async Task<WeatherModel> GetWeather()
        {
            var resp = await client.GetAsync(url);
            if(resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new WeatherModel();
            }
            else
            {
                var stringResp = await resp.Content.ReadAsStringAsync();
                //var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResp);
                //var arr = dic.ElementAt(0).Value;

                return JsonConvert.DeserializeObject<WeatherModel>(stringResp);
            }
        }

        public NetworkingManager()
        {
        }
    }
}
