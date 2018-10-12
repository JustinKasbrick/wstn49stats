using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public interface IPrinter
	{
		void PrintRoundStats(RoundStat stats);
		void PrintRound(Queue<Draw> draws, List<int> numbers);
	}

	public class Printer : IPrinter
	{
		public void PrintRoundStats(RoundStat stats)
		{
			Console.WriteLine($"Template: {stats.Template}");
			Console.WriteLine($"Unique: {stats.UniqueNumbers} [32 to 33]");
			Console.WriteLine($"Singles: {stats.Singles} [21 to 22]");
			Console.WriteLine($"Twos: {stats.Twos} [7]");
			Console.WriteLine($"Threes: {stats.Threes+stats.Fours} [2 to 3]");

			Console.WriteLine();
		}

		public void PrintRound(Queue<Draw> draws, List<int> numbers)
		{
			foreach (var draw in draws)
			{
				SetConsoleColour(draw.Num1, numbers);
				Console.Write($"{draw.Num1}-");
				SetConsoleColour(draw.Num2, numbers);
				Console.Write($"{draw.Num2}-");
				SetConsoleColour(draw.Num3, numbers);
				Console.Write($"{draw.Num3}-");
				SetConsoleColour(draw.Num4, numbers);
				Console.Write($"{draw.Num4}-");
				SetConsoleColour(draw.Num5, numbers);
				Console.Write($"{draw.Num5}-");
				SetConsoleColour(draw.Num6, numbers);
				Console.Write($"{draw.Num6}");
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
	}
}
