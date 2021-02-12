using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillReminder.Services
{
    public interface IDataOfferStore<T>
    {
        Task<bool> AddOfferAsync(T item);
        Task<bool> UpdateOfferAsync(T item);
        Task<bool> DeleteOfferAsync(string id);
        Task<T> GetOfferAsync(string id);
        Task<IEnumerable<T>> GetOfferAsync(bool forceRefresh = false);
       


    }
}
