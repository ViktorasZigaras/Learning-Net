﻿using System;

namespace Learning
{
	class Run
	{
		/*
		 * Notes: this is oversimplified console calculator that uses command format displayed below to perform one operation at the time, no memorisation
		 * Int is used instead of float, try catch could be used in zero division check
		 */
		static void Main(string[] args)
		{
			int a, b;
			string command, operation;
			string[] parameters;
			while (true)
            {
				displayList();
				command = Console.ReadLine();
				if (command == "exit")
				{
					break;
				}
				parameters = command.Split(" ");
				a = Int32.Parse(parameters[0]);
				b = Int32.Parse(parameters[2]);
				operation = parameters[1];

				if (operation == "+")
                {
					displayResult(a + b);
				}
				else if (operation == "-")
				{
					displayResult(a - b);
				}
				else if (operation == "*")
				{
					displayResult(a * b);
				}
				else if (operation == "/")
				{
					if (b != 0)
                    {
						displayResult(a / b);
					}
					else
                    {
						Console.WriteLine("Division by Zero!");
					}
					
				}
				else if (operation == "%")
				{
					displayResult(a % b);
				}
			}			
		}

		static void displayList()
        {
			Console.WriteLine("");
			Console.WriteLine("========================================");
			Console.WriteLine("Please enter command, options are:");
			Console.WriteLine("A + B");
			Console.WriteLine("A - B");
			Console.WriteLine("A * B");
			Console.WriteLine("A / B");
			Console.WriteLine("A % B");
			Console.WriteLine("exit");
			Console.WriteLine("========================================");
			Console.WriteLine("");
		}

		static void displayResult(int result)
		{
			Console.WriteLine("result: {0}", result);
			// Console.WriteLine($"result: {result}"); - alternative
		}
	}
}
