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

        public async Task<Show> GetShowAsync(string id)
        {
            var response = await httpClient.GetAsync($"https://10.0.2.2:7298/api/Show/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Show>(content);
            }

            return null;
        }

        public Task<IEnumerable<Show>> GetShowAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
