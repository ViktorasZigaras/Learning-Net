using StarterShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarterShopWebApp.Services
{
    public class ShopService
    {
        private List<Item> Fruits = new List<Item>();

        public ShopService()
        {
            Fruits.Add(new Fruit { Name = "Apple", Id = 1 });
            Fruits.Add(new Fruit { Name = "Orange", Id = 2 });
            Fruits.Add(new Fruit { Name = "Fig", Id = 3 });
            Fruits.Add(new Fruit { Name = "Banana", Id = 4 });
        }

        public List<Item> GetItems()
        {
            return Fruits;
        }

        public Item GetItem(int id)
        {
            return Fruits.Where(item => item.Id == id).First();
        }

        public void AddItem(Item item)
        {
            Fruits.Add(item);
        }

        public void UpdateItem(Item item)
        {
            Item targetItem = Fruits.FirstOrDefault(target => target.Id == item.Id);
            if (targetItem != null) targetItem.Name = item.Name;
        }

        internal void DeleteItem(int id)
        {
            Fruits.Remove(Fruits.Where(item => item.Id == id).First());
        }
    }
}

// fruits, veggies, seeds + generics
