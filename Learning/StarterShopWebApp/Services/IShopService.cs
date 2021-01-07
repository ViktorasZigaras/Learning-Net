using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarterShopWebApp.Models;

namespace StarterShopWebApp.Services
{
    public interface IShopService<T> where T : Item
    {
        DbContext Context { get; set; }

        Task<List<T>> GetAllItemsAsync();

        Task<T> GetItemAsync(int id);

        Task AddItemAsync(T t);

        Task UpdateItemAsync(int id, T t);

        Task DeleteItemAsync(int id);
    }
}