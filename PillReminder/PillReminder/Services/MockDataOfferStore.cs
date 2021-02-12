using PillReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillReminder.Services
{
    public class MockDataOfferStore : IDataOfferStore<Offer>
    {
        readonly List<Offer> offers;

        public MockDataOfferStore()
        {
            //offers = new List<Offer>()
            //{
            //    new Offer { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
            //    new Offer { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
            //    new Offer { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
            //    new Offer { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
            //    new Offer { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
            //    new Offer { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            //};
        }

        public async Task<bool> AddOfferAsync(Offer offer)
        {
            offers.Add(offer);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateOfferAsync(Offer item)
        {
         //   var oldItem = offers.Where((Offer arg) => arg.Id == item.Id).FirstOrDefault();
            //offers.Remove(oldItem);
            //offers.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteOfferAsync(string id)
        {
            //var oldItem = offers.Where((Offer arg) => arg.Id == id).FirstOrDefault();
            //offers.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Offer> GetOfferAsync(string id)
        {
            //return await Task.FromResult(offers.FirstOrDefault(s => s.Id == id));
            return null;
        }

        public async Task<IEnumerable<Offer>> GetOfferAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(offers);
        }
    }
}