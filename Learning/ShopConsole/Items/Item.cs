using System;
using System.Collections.Generic;
using System.Text;

namespace ShopConsole.Items
{
    abstract class Item
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
