using System;

namespace ShopConsole
{
    class User
    {
        public User(Random rand)
        {
            Balance = rand.Next(100, 500);
        }
        public int Balance { get; set; }
    }
}
