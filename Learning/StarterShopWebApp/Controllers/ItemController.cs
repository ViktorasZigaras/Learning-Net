using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarterShopWebApp.Data;
using StarterShopWebApp.Models;
using StarterShopWebApp.Services;

namespace StarterShopWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Route("[controller]")]
    public abstract class ItemController<T> : ControllerBase where T : Item
    {
        private readonly IShopService<T> _shopService;

        public ItemController(IShopService<T> shopService, ItemContext context)
        {
            _shopService = shopService;
            _shopService.Context = context;
        }

        [HttpGet]
        public async Task<List<T>> GetAllItems()
        {
            return await _shopService.GetAllItemsAsync();
        }

        [HttpGet("{id}")]
        public async Task<T> GetItem(int id)
        {
            return await _shopService.GetItemAsync(id);
        }

        [HttpPost]
        public async Task AddItem(T t)
        {
            await _shopService.AddItemAsync(t);
            // return _shopService.GetItems();
        }

        [HttpPut("{id}")]
        public async Task UpdateItem(int id, T t)
        {
            await _shopService.UpdateItemAsync(id, t);
            // return _shopService.GetItems();
        }

        [HttpDelete("{id}")]
        public async Task DeleteItem(int id)
        {
            await _shopService.DeleteItemAsync(id);
            // return _shopService.GetItems();
        }
    }
}