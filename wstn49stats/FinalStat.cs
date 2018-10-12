using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public class FinalStat
	{
		public FinalStat()
		{
			UniqueNumbers = new UniqueNumber();
			Singles = new Single();
			Twos = new Two();
			Threes = new Three();
			Fours = new Four();
		}

		public UniqueNumber UniqueNumbers { get; set; }
		public Single Singles { get; set; }
		public Two Twos { get; set; }
		public Three Threes { get; set; }
		public Four Fours { get; set; }
	}

	public class UniqueNumber
	{
		public float Average { get; set; }
		public int Median { get; set; }
		public int Min { get; set; }
		public int Max {get; set; }
	}

	public class Single
	{
		public float Average { get; set; }
		public int Median { get; set; }
		public int Min { get; set; }
		public int Max {get; set; }
	}

	public class Two
	{
		public float Average { get; set; }
		public int Median { get; set; }
		public int Min { get; set; }
		public int Max {get; set; }
	}

	public class Three
	{
		public float Average { get; set; }
		public int Median { get; set; }
		public int Min { get; set; }
		public int Max {get; set; }
	}

	public class Four
	{
		public float Average { get; set; }
		public int Median { get; set; }
		public int Min { get; set; }
		public int Max {get; set; }
	}
}
