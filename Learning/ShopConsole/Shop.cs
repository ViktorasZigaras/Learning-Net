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

		public void run()
		{
			string command;
			// string[] parameters;
			
			initList();
			while (true)
			{
				displayMenu();
				command = Console.ReadLine();
				if (command == "Exit")
				{
					break;
				} 
				else if (command == "List")
				{
					displayList();
				}
				// parameters = command.Split(" ");
			}
		}

/*
1. "List" išspausdina informacija, ką galima nusipirkti parduotuvėje ir kokios kainos. išpirktų produktų neturėtų rodyti.
2. "Buy Candy 20" - turėtų nupirkti visus egzistuojančius toks item egzistuoja parduotuvėje ir yra toks kiekis. Jei ne, turėtų parodyti atitinkamą žinutę.
3. "Add Cup 30" - turėtų papildyti parduotuvę su atitinkamu produktu ir kiekiu. Tai turętų atsivaizduoti ir "List" komandoje. 
3a. Jei tokiu produktų jau yra, papildyti.

-> Sukurti Vartotojo klasę, kuri laikytų pinigų balancą.

4. "Show Balance" parodyti kiek pinigų liko.
5. Modifikuoti Buy komandą, kuri neleistų nusipirkti, jei neužtenka pinigų. 
6. "Topup 30": papildytų sąskaitą.
*/

		// switch/if?
		// use Lists
		// randomise goods
		// use statics?

		private void initList()
        {
            foreach (var book in books)
            {
				itemList.Add(new Book{ Title = book, Quantity = rand.Next(1, 5), Price = rand.Next(10, 50) });
			}

			foreach (var candy in candies)
			{
				itemList.Add(new Candy { Title = candy, Quantity = rand.Next(10, 50), Price = rand.Next(1, 5) });
			}

			foreach (var cup in cups)
			{
				itemList.Add(new Cup { Title = cup, Quantity = rand.Next(2, 8), Price = rand.Next(3, 18) });
			}
		}

		private void displayMenu()
		{
			Console.WriteLine("");
			Console.WriteLine("========================================");
			Console.WriteLine("Please enter command, options are:");
			Console.WriteLine("List");
			Console.WriteLine("Exit");
			Console.WriteLine("========================================");
			Console.WriteLine("");
		}

		private void displayList()
		{
			Console.WriteLine("");
			Console.WriteLine("========================================");
			Console.WriteLine("Items for sale");
			Console.WriteLine("========================================");
			foreach (var item in itemList)
			{
				Console.WriteLine($"{item} - {item.Title} x {item.Quantity} ({item.Price})");
			}
			Console.WriteLine("========================================");
			Console.WriteLine("");
		}
	}
}

			/*int a, b;
			, operation;
				a = Int32.Parse(parameters[0]);
				b = Int32.Parse(parameters[2]);
				operation = parameters[1];
			}*/

