using ATConcert.Models;
using ATConcert.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ATConcert.Services
{
    public class ShowRestApiDataStore : IShowRestApiDataStore<Show>
    {

        private static readonly Uri ApiBaseUrl = new Uri("https://77.238.60.113:7298/api/");

        private readonly HttpClient httpClient;


        public ShowRestApiDataStore()
        {
            httpClient = new HttpClient(GetInsecureHandler())
            {
                BaseAddress = ApiBaseUrl
            };
        }

        public async Task<Show> GetConcertAsync(string id)
        {
            var response = await httpClient.GetAsync($"{ApiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Show>(content);
            }

            return null;
        }


        public async Task<IEnumerable<Show>> GetConcertsAsync(bool forceRefresh = false)
        {

            var response = await httpClient.GetAsync($"https://10.0.2.2:7298/api/Concert/GetConcerts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Show>>(content);
            }

            return null;
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
