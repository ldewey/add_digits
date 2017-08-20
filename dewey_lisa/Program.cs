using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace addDigits
{
	class Program
	{

		static void Main()
		{
			bool invalidInput = false;
			string xStr = "", yStr = "";
			int x = 0, y = 0;
			int dummy = 0;
			bool error = false;
			do
			{
				if (error)
				{   Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Error! The integers must have the same number of digits.");
					Console.ResetColor();
				}

				do
				{
					if (invalidInput)
						Console.WriteLine("Invalid input!");
					invalidInput = false;

					Console.WriteLine("Enter a number up to 10 digits in length.");
					
					xStr = Console.ReadLine();
					if (!Int32.TryParse(xStr, out dummy))
					{
						error = true;
						invalidInput = true;
					};

				} while (invalidInput);
				do
				{
					if (invalidInput)
					{
						Console.WriteLine("Invalid input!");
					}

					invalidInput = false;

					Console.WriteLine("Enter another number with the same number of digits as the first number: ");
					try
					{
						yStr = Console.ReadLine();
					}
					catch (Exception)
					{
						invalidInput = true;
					}
				} while (invalidInput);
				error = true;
			} while (xStr.Length != yStr.Length);

			error = false;
			int lastSum = -1;
			string[] xList = xStr.Select(xSel => xSel.ToString()).ToArray();
			string[] yList = yStr.Select(ySel => ySel.ToString()).ToArray();

			int? firstElement = null;

			for (int i = 0; i < xStr.ToString().Length; i++)
			{

				if (firstElement == null)
				{
					firstElement = sum(Int32.Parse(xList[i]), Int32.Parse(yList[i]));
				}
				else
				{
					int sumOfSame = sum(Int32.Parse(xList[i]), Int32.Parse(yList[i]));
					if (sumOfSame != firstElement)
					{
						error = true;
						break;
					}
				}





				//var sum = (int32.parse(xstr) % 10 + int32.parse(ystr) % 10);
				//if (lastsum != sum && lastsum != -1)
				//{
				//	error = true;
				//	break;
				//}
				//x /= 10;
				//y /= 10;

				//lastsum = sum;
			}
			Console.WriteLine((!error).ToString());
			Console.ReadLine();
		}

		static int sum(int val1, int val2)
		{
			return val1 + val2;
		}
	}
}