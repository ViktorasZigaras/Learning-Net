using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarterShopWebApp.Models;

namespace StarterShopWebApp.Services
{
    public class ShopService<T> : IShopService<T> where T : Item
    {
        public DbContext Context { get; set; }

        public async Task<List<T>> GetAllItemsAsync()
        {
            return await Context.Set<T>().ToListAsync();
            // return Fruits;
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
            // return Fruits.Where(item => item.Id == id).First();
        }

        public async Task AddItemAsync(T t)
        {
            Context.Set<T>().Add(t);
            await Context.SaveChangesAsync();
            // Fruits.Add(item);
        }

        public async Task UpdateItemAsync(int id, T t)
        {
            var item = await GetItemAsync(id);
            item.Name = t.Name;
            await Context.SaveChangesAsync();
            // Item targetItem = Fruits.FirstOrDefault(target => target.Id == item.Id);
            // if (targetItem != null) targetItem.Name = item.Name;
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await GetItemAsync(id);
            Context.Set<T>().Remove(item);
            await Context.SaveChangesAsync();
            // Fruits.Remove(Fruits.Where(item => item.Id == id).First());
        }
    }
}