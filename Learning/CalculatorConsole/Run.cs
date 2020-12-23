using System;

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
				DisplayList();
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
					DisplayResult(a + b);
				}
				else if (operation == "-")
				{
					DisplayResult(a - b);
				}
				else if (operation == "*")
				{
					DisplayResult(a * b);
				}
				else if (operation == "/")
				{
					if (b != 0)
                    {
						DisplayResult(a / b);
					}
					else
                    {
						Console.WriteLine("Division by Zero!");
					}
					
				}
				else if (operation == "%")
				{
					DisplayResult(a % b);
				}
			}			
		}

		static void DisplayList()
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

		static void DisplayResult(int result)
		{
			Console.WriteLine("result: {0}", result);
			// Console.WriteLine($"result: {result}"); - alternative
		}
	}
}
