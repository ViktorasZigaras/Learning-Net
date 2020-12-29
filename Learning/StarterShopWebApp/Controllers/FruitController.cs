using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterShopWebApp.Models;
using StarterShopWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarterShopWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : Controller
    {
        private readonly ShopService _shopService;
        public FruitController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public List<Item> GetItems()
        {
            return _shopService.GetItems();
        }

        [HttpGet("{id}")]
        public Item GetItem(int id)
        {
            return _shopService.GetItem(id);
        }

        [HttpPost]
        public List<Item> AddItem(Fruit item)
        {
            _shopService.AddItem(item);
            return _shopService.GetItems();
        }

        [HttpPut]
        public List<Item> UpdateItem(Fruit item)
        {
            _shopService.UpdateItem(item);
            return _shopService.GetItems();
        }

        [HttpDelete("{id}")]
        public List<Item> DeleteItem(int id)
        {
            _shopService.DeleteItem(id);
            return _shopService.GetItems();
        }
    }
}

// https://stackoverflow.com/questions/20009031/how-to-use-asp-net-mvc-generic-controller-to-populate-right-model
