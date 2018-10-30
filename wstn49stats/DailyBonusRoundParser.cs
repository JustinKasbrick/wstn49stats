using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public class DailyBonusRoundParser : IRoundParser
	{
		public Tuple<List<int>, Queue<Draw>> GetFirstRoundOfNDraws(int numDraws, Stack<string> lines)
		{
			var numbers = new List<int>();
			var draws = new Queue<Draw>();

			for (var i = 0; i < numDraws; i++)
			{
				PopNextAndQueueItUp(lines, draws, numbers);
			}

			return Tuple.Create(numbers, draws);
		}

		public Tuple<List<int>, Queue<Draw>> GetNextDraw(Stack<string> lines, Queue<Draw> round, List<int> numbers)
		{
			var draw = round.Dequeue();
			numbers.Remove(draw.Num1);

			PopNextAndQueueItUp(lines, round, numbers);

			return Tuple.Create(numbers, round);
		}

		public Tuple<List<int>, List<Draw>> GetNDraws(int numDraws, int skip, List<string> lines, List<int> numbers)
		{
			var draws = new List<Draw>();
			for (var i = skip; i < numDraws+skip; i++)
			{
				var parts = lines[i].Split('\t');

				var draw = new Draw
				{
					Num1 = int.Parse(parts[7])
				};

				numbers.Add(draw.Num1);

				draws.Add(draw);
			}

			return Tuple.Create(numbers, draws);
		}

		private void PopNextAndQueueItUp(Stack<string> lines, Queue<Draw> draws, List<int> numbers)
		{
			var parts = lines.Pop().Split('\t');

			var draw = new Draw
			{
				Num1 = int.Parse(parts[7])
			};

			numbers.Add(draw.Num1);

			draws.Enqueue(draw);
		}
	}
}
