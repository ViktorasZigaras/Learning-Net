using System;
using System.Collections.Generic;
using ShopConsole.Items;

namespace ShopConsole
{
    class Shop
    {
		private readonly string[] books = { "Fantasy", "Scifi", "Romance" };
		private readonly string[] candies = { "Sweet", "Bitter", "Gum", "Floss" };
		private readonly string[] cups = { "Large", "Small" };
		private readonly Random rand = new Random();
		private readonly List<Item> itemList = new List<Item>();
		private User user;

		public void Run()
		{
			string command, itemClass, title;
			string[] parameters;
			int quantity;
			user = new User { Balance = rand.Next(100, 500) };
			InitList();
			while (true)
			{
				DisplayMenu();
				command = Console.ReadLine();
				if (command == "Exit")
				{
					break;
				} 
				else if (command == "List")
				{
					DisplayList();
				}
				else if (command == "Balance")
				{
					DisplayBalance();
				}
				else
                {
					// a potential to split to more methods if needed
					parameters = command.Split(" ");
					command = parameters[0];
					if (command == "Increase")
					{
						user.Balance += Int32.Parse(parameters[1]);
					}
					itemClass = parameters[1];
					title = parameters[2];
					quantity = Int32.Parse(parameters[3]);
					if (command == "Buy")
					{
						foreach (Item item in itemList)
						{
							if (item.ToString() == itemClass && item.Title == title)
							{
								if (item.Quantity - quantity < 0)
								{
									Console.WriteLine("Not enough merchandise");
								}
								else
								{
									if (user.Balance - (quantity * item.Price) < 0)
									{
										Console.WriteLine("Not enough balance");
									}
									else
									{
										user.Balance -= quantity * item.Price;
										item.Quantity -= quantity;
									}
								}
								break;
							}
						}
					}
					else if (command == "Add")
					{
						foreach (Item item in itemList)
						{
							if (item.ToString() == itemClass && item.Title == title)
							{
								item.Quantity += quantity;
								break;
							}
						}
					}
				}
			}
		}

		// Add: don't create brand new objects just yet

		private void DisplayBalance()
        {
			Console.WriteLine($"User Balance is: {user.Balance}");
		}

		private void InitList()
        {
            foreach (string book in books)
            {
				itemList.Add(new Book{ Title = book, Quantity = rand.Next(1, 5), Price = rand.Next(10, 50) });
			}
			foreach (string candy in candies)
			{
				itemList.Add(new Candy { Title = candy, Quantity = rand.Next(10, 50), Price = rand.Next(1, 5) });
			}
			foreach (string cup in cups)
			{
				itemList.Add(new Cup { Title = cup, Quantity = rand.Next(2, 8), Price = rand.Next(3, 18) });
			}
		}

		private void DisplayMenu()
		{
			Console.WriteLine("");
			Console.WriteLine("========================================");
			Console.WriteLine("Please enter command, options are:");
			Console.WriteLine("List");
			Console.WriteLine("Buy Item Title Quantity");
			Console.WriteLine("Add Item Title Quantity");
			Console.WriteLine("Balance");
			Console.WriteLine("Increase Amount");
			Console.WriteLine("Exit");
			Console.WriteLine("========================================");
			Console.WriteLine("");
		}

		private void DisplayList()
		{
			Console.WriteLine("");
			Console.WriteLine("========================================");
			Console.WriteLine("Items for sale");
			Console.WriteLine("========================================");
			foreach (var item in itemList)
			{
				if (item.Quantity > 0)
                {
					Console.WriteLine($"{item} - {item.Title} x {item.Quantity} ({item.Price})");
                }
			}
			Console.WriteLine("========================================");
			Console.WriteLine("");
		}
	}
}
