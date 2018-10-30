using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public class DailyBonusPrinter : IPrinter
	{
		public void PrintRoundStats(RoundStat stats)
		{
			Console.WriteLine($"Template: {stats.Template}");
			Console.WriteLine($"Unique: {stats.UniqueNumbers} [4 to 5]");
			Console.WriteLine($"Singles: {stats.Singles} [3]");
			Console.WriteLine($"Twos: {stats.Twos} [1]");
			Console.WriteLine($"Threes: {stats.Threes+stats.Fours} [1]");

			Console.WriteLine();
		}

		public void PrintRound(Queue<Draw> draws, List<int> numbers)
		{
			foreach (var draw in draws)
			{
				SetConsoleColour(draw.Num1, numbers);
				Console.Write($"{draw.Num1}");
				
				Console.WriteLine();
			}

			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void PrintRound(List<Draw> draws, List<int> numbers)
		{
			foreach (var draw in draws)
			{
				SetConsoleColour(draw.Num1, numbers);
				Console.Write($"{draw.Num1}");
				
				Console.WriteLine();
			}

			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void PrintSubsiquentRound(List<Draw> draws, List<int> numbers)
		{
			foreach (var draw in draws)
			{
				SetConsoleColourForSusiqentRounds(draw.Num1, numbers);
				Console.Write($"{draw.Num1}");
				
				Console.WriteLine();

			}

			Console.ForegroundColor = ConsoleColor.Gray;
		}

		private static void SetConsoleColour(int drawNumber, List<int> numbers)
		{
			//if (drawNumber > 1)
			//{
			// Console.ForegroundColor = numbers.Contains(number) 
			//  ? ConsoleColor.Gray 
			//  : ConsoleColor.Red;
			//}

			var nums = numbers.Count(x => x == drawNumber);
			if (nums == 1)
				Console.ForegroundColor = ConsoleColor.Green;
			else if (nums == 2)
				Console.ForegroundColor = ConsoleColor.Blue;
			else
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
		}

		private static void SetConsoleColourForSusiqentRounds(int drawNumber, List<int> numbers)
		{
			var nums = numbers.Count(x => x == drawNumber);
			if (nums == 1)
				Console.ForegroundColor = ConsoleColor.Red;
			else
				Console.ForegroundColor = ConsoleColor.Gray;
		}
	}
}
