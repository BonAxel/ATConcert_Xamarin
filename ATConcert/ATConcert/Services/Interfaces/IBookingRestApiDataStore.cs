using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATConcert.Services
{
    public interface IBookingRestApiDataStore<T>
    {
        Task<bool> AddBookingAsync(T item);
        Task<bool> UpdateBookingAsync(T item);
        Task<bool> DeleteBookingAsync(string id);
        Task<T> GetBookingtAsync(string id);
        Task<IEnumerable<T>> GetBookingsAsync(bool forceRefresh = false);
    }
}
