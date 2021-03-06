﻿using Microsoft.AspNetCore.Mvc;
using StarterShopWebApp.Data;
using StarterShopWebApp.Models;
using StarterShopWebApp.Services;

namespace StarterShopWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitController : ItemController<Fruit>
    {
        public FruitController(IShopService<Fruit> shopService, ItemContext context) : base(shopService, context)
        {
        }
    }
}