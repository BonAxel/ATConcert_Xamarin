using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATConcert.Services.Interfaces
{
    interface IShowRestApiDataStore<T>
    {

        Task<T> GetConcertAsync(string id);
        Task<IEnumerable<T>> GetConcertsAsync(bool forceRefresh = false);
    }
}
