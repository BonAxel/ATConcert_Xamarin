using ATConcert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ATConcert.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ATConcert.Services
{
    public class BookingRestApiDataStore : IBookingRestApiDataStore<Booking>
    {
        private static readonly Uri ApiBaseUrl = new Uri("https://77.238.60.113:7298/api/");

        private readonly HttpClient httpClient;

        public BookingRestApiDataStore()
        {
            httpClient = new HttpClient(GetInsecureHandler())
            {
                BaseAddress = ApiBaseUrl
            };

        }

        public Task<bool> DeleteBookingAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingtAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBookingAsync(Booking item)
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

        public async Task<bool> AddBookingAsync(Booking item)
        {
            try
            {
                var jsonItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
                
                var response = await httpClient.PostAsync($"https://10.0.2.2:7298/api/Booking/CreateBooking", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error adding booking. Status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding booking: {ex.Message}");
                return false;
            }
        }
    }
}
