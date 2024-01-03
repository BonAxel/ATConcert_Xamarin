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
    class BookingRestApiDataStore : IBookingRestApiDataStore<Booking>
    {
        public Task<bool> AddBookingAsync(Booking item)
        {
            throw new NotImplementedException();
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
    }
}
