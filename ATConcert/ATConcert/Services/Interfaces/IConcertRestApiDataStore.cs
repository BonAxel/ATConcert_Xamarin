using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATConcert.Services.Interfaces
{
    public interface IConcertRestApiDataStore<T>
    {
        Task<bool> AddConcertAsync(T item);
        Task<bool> UpdateConcertAsync(T item);
        Task<bool> DeleteConcertAsync(string id);
        Task<T> GetConcertAsync(string id);
        Task<IEnumerable<T>> GetConcertsAsync(bool forceRefresh = false);

    }
}
