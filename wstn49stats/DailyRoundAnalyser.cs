using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public class DailyRoundAnalyser : IRoundAnalyser
	{
		public RoundStat GetStatsForRound(Queue<Draw> round, List<int> numbers)
		{
			var stats = new RoundStat();

			var count = round.Count();
			var counter = 0;

			foreach (var draw in round)
			{
				CollectStats(draw.Num1, numbers, stats);
				CollectStats(draw.Num2, numbers, stats);
				CollectStats(draw.Num3, numbers, stats);
				CollectStats(draw.Num4, numbers, stats);
				CollectStats(draw.Num5, numbers, stats);

				if (counter == count - 1)
					SetTemplate(draw, numbers, stats);

				counter++;
			}

			stats.UniqueNumbers = numbers.GroupBy(x => x).Count();
			stats.Twos = stats.Twos / 2;
			stats.Threes = stats.Threes / 3;
			stats.Fours = stats.Fours / 4;

			return stats;
		}

		public RoundStat GetStatsForRound(List<Draw> round, List<int> numbers)
		{
			var stats = new RoundStat();

			var count = round.Count();
			var counter = 0;

			foreach (var draw in round)
			{
				CollectStats(draw.Num1, numbers, stats);
				CollectStats(draw.Num2, numbers, stats);
				CollectStats(draw.Num3, numbers, stats);
				CollectStats(draw.Num4, numbers, stats);
				CollectStats(draw.Num5, numbers, stats);
				CollectStats(draw.Num6, numbers, stats);

				if (counter == 0)
					SetTemplate(draw, numbers, stats);

				counter++;
			}

			stats.UniqueNumbers = numbers.GroupBy(x => x).Count();
			stats.Twos = stats.Twos / 2;
			stats.Threes = stats.Threes / 3;
			stats.Fours = stats.Fours / 4;

			return stats;
		}

		public RoundStat GetStatsForFirst7Draws(Queue<Draw> round, List<int> numbers)
		{
			var stats = new RoundStat();
			var nums = new List<int>();
			nums.AddRange(numbers);

			var last = round.Last();
			nums.Remove(last.Num1);
			nums.Remove(last.Num2);
			nums.Remove(last.Num3);
			nums.Remove(last.Num4);
			nums.Remove(last.Num5);

			var count = round.Count();
			var counter = 0;
			
			foreach (var draw in round)
			{
				if (counter == count - 1)
					break;

				CollectStats(draw.Num1, numbers, stats);
				CollectStats(draw.Num2, numbers, stats);
				CollectStats(draw.Num3, numbers, stats);
				CollectStats(draw.Num4, numbers, stats);
				CollectStats(draw.Num5, numbers, stats);

				counter++;
			}

			stats.UniqueNumbers = nums.GroupBy(x => x).Count();
			stats.Twos = stats.Twos / 2;
			stats.Threes = stats.Threes / 3;
			stats.Fours = stats.Fours / 4;

			
			return stats;
		}

		public RoundStat GetStatsForFirst7Draws(List<Draw> round, List<int> numbers)
		{
			var stats = new RoundStat();
			var nums = new List<int>();
			nums.AddRange(numbers);

			var first = round.First();
			nums.Remove(first.Num1);
			nums.Remove(first.Num2);
			nums.Remove(first.Num3);
			nums.Remove(first.Num4);
			nums.Remove(first.Num5);

			var count = round.Count();
			var counter = 0;
			
			foreach (var draw in round)
			{
				if (counter != 0)
				{
					CollectStats(draw.Num1, numbers, stats);
					CollectStats(draw.Num2, numbers, stats);
					CollectStats(draw.Num3, numbers, stats);
					CollectStats(draw.Num4, numbers, stats);
					CollectStats(draw.Num5, numbers, stats);
				}

				

				counter++;
			}

			stats.UniqueNumbers = nums.GroupBy(x => x).Count();
			stats.Twos = stats.Twos / 2;
			stats.Threes = stats.Threes / 3;
			stats.Fours = stats.Fours / 4;

			
			return stats;
		}

		private static void CollectStats(int drawNum, List<int> numbers, RoundStat stats)
		{
			var nums = numbers.Count(x => x == drawNum);

			switch (nums)
			{
				case 1:
					stats.Singles++;
					break;
				case 2:
					stats.Twos++;
					break;
				case 3:
					stats.Threes++;
					break;
				default:
					stats.Fours++;
					break;
			}
		}

		private static void SetTemplate(Draw draw, List<int> numbers, RoundStat stats)
		{
			var s1 = GetNumberString(draw.Num1, numbers);
			var s2 = GetNumberString(draw.Num2, numbers);
			var s3 = GetNumberString(draw.Num3, numbers);
			var s4 = GetNumberString(draw.Num4, numbers);
			var s5 = GetNumberString(draw.Num5, numbers);

			stats.Template = $"{s1}-{s2}-{s3}-{s4}-{s5}";
		}

		private static string GetNumberString(int drawNum, List<int> numbers)
		{
			var nums = numbers.Count(x => x == drawNum);

			switch (nums)
			{
				case 1:
					return "001";
				case 2:
					return "002";
				case 3:
					return "003";
				default:
					return "003";
			}
		}
	}
}
