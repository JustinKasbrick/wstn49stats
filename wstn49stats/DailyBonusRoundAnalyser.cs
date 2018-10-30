using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public class DailyBonusRoundAnalyser : IRoundAnalyser
	{
		public RoundStat GetStatsForRound(Queue<Draw> round, List<int> numbers)
		{
			var stats = new RoundStat();
			
			foreach (var draw in round)
			{
				CollectStats(draw.Num1, numbers, stats);
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
			
			foreach (var draw in round)
			{
				CollectStats(draw.Num1, numbers, stats);
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

			var count = round.Count();
			var counter = 0;
			
			foreach (var draw in round)
			{
				if (counter == count - 1)
					break;

				CollectStats(draw.Num1, numbers, stats);

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

			var count = round.Count();
			var counter = 0;
			
			foreach (var draw in round)
			{
				if (counter != 0)
				{
					CollectStats(draw.Num1, numbers, stats);
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
	}
}
