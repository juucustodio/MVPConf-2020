using MVPConfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVPConfApp.Services
{
    public class MockDataStore : IDataStore<Palestra>
    {
        readonly List<Palestra> items;

        public MockDataStore()
        {
            items = new List<Palestra>()
            {
                new Palestra { Id = Guid.NewGuid().ToString(), Title = "First item", Description="This is an item description." },
                new Palestra { Id = Guid.NewGuid().ToString(), Title = "Second item", Description="This is an item description." },
                new Palestra { Id = Guid.NewGuid().ToString(), Title = "Third item", Description="This is an item description." },
                new Palestra { Id = Guid.NewGuid().ToString(), Title = "Fourth item", Description="This is an item description." },
                new Palestra { Id = Guid.NewGuid().ToString(), Title = "Fifth item", Description="This is an item description." },
                new Palestra { Id = Guid.NewGuid().ToString(), Title = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Palestra item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Palestra item)
        {
            var oldItem = items.Where((Palestra arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Palestra arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Palestra> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Palestra>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}