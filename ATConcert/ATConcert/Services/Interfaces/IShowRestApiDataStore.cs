using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATConcert.Services.Interfaces
{
    interface IShowRestApiDataStore<T>
    {

        Task<T> GetShowAsync(string id);
        Task<IEnumerable<T>> GetShowAsync(bool forceRefresh = false);
    }
}
