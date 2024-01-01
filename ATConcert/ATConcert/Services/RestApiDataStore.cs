using ATConcert.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ATConcert.Services
{
    public class RestApiDataStore : IRestApiDataStore<Concert>
    {
        //OBS. Const = Används för ett värde som inte ska modifieras under kod. SMORT! 
        private const string ApiBaseUrl = "https://localhost:7298/api/";

        private readonly HttpClient httpClient;

        public RestApiDataStore()
        {
            httpClient = new HttpClient();
        }
        public async Task<bool> AddConcertAsync(Concert concert)
        {
            var response = await httpClient.PostAsync(ApiBaseUrl, new StringContent(JsonConvert.SerializeObject(concert), Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateConcertAsync(Concert concert)
        {
            var response = await httpClient.PutAsync($"{ApiBaseUrl}/{concert.ConcertId}", new StringContent(JsonConvert.SerializeObject(concert), Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteConcertAsync(string id)
        {
            var response = await httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Concert> GetConcertAsync(string id)
        {
            var response = await httpClient.GetAsync($"{ApiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Concert>(content);
            }

            return null;
        }

        public async Task<IEnumerable<Concert>> GetConcertsAsync(bool forceRefresh = false)
        {
            var response = await httpClient.GetAsync($"https://localhost:7298/api/Concert/GetConcerts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Concert>>(content);
            }

            return null;
        }
    }
}
