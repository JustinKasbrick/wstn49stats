using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public interface IRoundParser
	{
		Tuple<List<int>, Queue<Draw>> GetFirstRoundOfNDraws(int numDraws, Stack<string> lines);
		Tuple<List<int>, Queue<Draw>> GetNextDraw(Stack<string> lines, Queue<Draw> round, List<int> numbers);
		Tuple<List<int>, List<Draw>> GetNDraws(int numDraws, int skip, List<string> lines, List<int> numbers);
	}

	public class RoundParser : IRoundParser
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
			numbers.Remove(draw.Num2);
			numbers.Remove(draw.Num3);
			numbers.Remove(draw.Num4);
			numbers.Remove(draw.Num5);
			numbers.Remove(draw.Num6);

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
					Num1 = int.Parse(parts[2]),
					Num2 = int.Parse(parts[3]),
					Num3 = int.Parse(parts[4]),
					Num4 = int.Parse(parts[5]),
					Num5 = int.Parse(parts[6]),
					Num6 = int.Parse(parts[7]),
				};

				numbers.Add(draw.Num1);
				numbers.Add(draw.Num2);
				numbers.Add(draw.Num3);
				numbers.Add(draw.Num4);
				numbers.Add(draw.Num5);
				numbers.Add(draw.Num6);

				draws.Add(draw);
			}

			return Tuple.Create(numbers, draws);
		}

		private void PopNextAndQueueItUp(Stack<string> lines, Queue<Draw> draws, List<int> numbers)
		{
			var parts = lines.Pop().Split('\t');

			var draw = new Draw
			{
				Num1 = int.Parse(parts[2]),
				Num2 = int.Parse(parts[3]),
				Num3 = int.Parse(parts[4]),
				Num4 = int.Parse(parts[5]),
				Num5 = int.Parse(parts[6]),
				Num6 = int.Parse(parts[7]),
			};

			numbers.Add(draw.Num1);
			numbers.Add(draw.Num2);
			numbers.Add(draw.Num3);
			numbers.Add(draw.Num4);
			numbers.Add(draw.Num5);
			numbers.Add(draw.Num6);

			draws.Enqueue(draw);
		}
	}
}
