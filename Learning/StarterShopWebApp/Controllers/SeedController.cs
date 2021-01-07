using Microsoft.AspNetCore.Mvc;
using StarterShopWebApp.Data;
using StarterShopWebApp.Models;
using StarterShopWebApp.Services;

namespace StarterShopWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ItemController<Fruit>
    {
        public SeedController(IShopService<Fruit> shopService, ItemContext context) : base(shopService, context)
        {
        }
    }
}