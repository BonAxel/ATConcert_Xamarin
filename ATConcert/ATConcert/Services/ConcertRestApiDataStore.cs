using ATConcert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ATConcert.Services.Interfaces;
using ATConcert.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ATConcert.Services
{
    public class ConcertRestApiDataStore : IConcertRestApiDataStore<Concert>
    {

        private static readonly Uri ApiBaseUrl = new Uri("https://77.238.60.113:7298/api/");

        private readonly HttpClient httpClient;

        public ConcertRestApiDataStore()
        {
            httpClient = new HttpClient(GetInsecureHandler())
            {
                BaseAddress = ApiBaseUrl
            };
        }


        public Task<bool> AddConcertAsync(Concert item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteConcertAsync(string id)
        {
            throw new NotImplementedException();
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

            var response = await httpClient.GetAsync($"https://10.0.2.2:7298/api/Concert/GetConcerts");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Concert>>(content);
            }

            return null;
        }

        public Task<bool> UpdateConcertAsync(Concert item)
        {
            throw new NotImplementedException();
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }


    }
}
