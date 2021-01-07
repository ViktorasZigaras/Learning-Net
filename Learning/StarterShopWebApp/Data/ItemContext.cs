using Microsoft.EntityFrameworkCore;
using StarterShopWebApp.Models;

namespace StarterShopWebApp.Data
{
    public class ItemContext : DbContext
    {
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Seed> Seeds { get; set; }
        public DbSet<Veggy> Veggies { get; set; }

        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
        }

        // Seeding the initial data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>().HasData(new Fruit[]
            {
                new Fruit {Id = 1, Name = "Bad Apple"},
                new Fruit {Id = 2, Name = "Good Pear"},
                new Fruit {Id = 3, Name = "Chaotic Orange"},
            });

            modelBuilder.Entity<Seed>().HasData(new Seed[]
            {
                new Seed {Id = 1, Name = "Life Seed"},
                new Seed {Id = 2, Name = "Death Seed"},
                new Seed {Id = 3, Name = "Destiny Seed"},
            });

            modelBuilder.Entity<Veggy>().HasData(new Veggy[]
            {
                new Veggy {Id = 1, Name = "Fat Carrot"},
                new Veggy {Id = 2, Name = "Red Beet"},
                new Veggy {Id = 3, Name = "Stinky Onion"},
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}