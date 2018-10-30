using System;
using System.Collections.Generic;
using System.Linq;

namespace wstn49stats
{
    class Program
    {
        static void Main(string[] args)
        {
	        //GetLast6Rounds();
	        //GetAllTemplatePatterns();
	        //GetLastRoundStats();
	        //Eleminator();

			//DailyGetLast6Rounds();
			DailyGetLastRoundStats();

			DailyBonusGetLastRoundStats();

	        Console.ReadLine();
        }

	    static void GetLastRoundStats()
	    {
		    IFileReader fileReader = new FileReader();
		    var lines = fileReader.ReadNLinesFromFile(8, "w49data.txt");

		    IRoundParser roundParser = new RoundParser();
		    var (numbers, draws) = roundParser.GetNDraws(8, 0, lines, new List<int>());

		    var allPatterns = new List<string>();

		    IRoundAnalyser roundAnalyser = new RoundAnalyser();
		    var stats = roundAnalyser.GetStatsForRound(draws, numbers);
		    var first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);

		    allPatterns.Add(stats.Template);

		    IPrinter printer = new Printer(false);
			
		    printer.PrintRound(draws, numbers);
		    printer.PrintRoundStats(stats);


		    Console.WriteLine();
		    printer.PrintRoundStats(first7Draws);
	    }

		static void DailyGetLastRoundStats()
	    {
		    IFileReader fileReader = new FileReader();
		    var lines = fileReader.ReadNLinesFromFile(10, "dailydata.txt");

		    IRoundParser roundParser = new DailyRoundParser();
		    var (numbers, draws) = roundParser.GetNDraws(10, 0, lines, new List<int>());

		    var allPatterns = new List<string>();

		    IRoundAnalyser roundAnalyser = new DailyRoundAnalyser();
		    var stats = roundAnalyser.GetStatsForRound(draws, numbers);
		    var first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);

		    allPatterns.Add(stats.Template);

		    IPrinter printer = new Printer(true);
			
		    printer.PrintRound(draws, numbers);
		    printer.PrintRoundStats(stats);


		    Console.WriteLine();
		    printer.PrintRoundStats(first7Draws);
	    }

	    static void DailyBonusGetLastRoundStats()
	    {
		    IFileReader fileReader = new FileReader();
		    var lines = fileReader.ReadNLinesFromFile(10, "dailydata.txt");

		    IRoundParser roundParser = new DailyBonusRoundParser();
		    var (numbers, draws) = roundParser.GetNDraws(7, 0, lines, new List<int>());

		    var allPatterns = new List<string>();

		    IRoundAnalyser roundAnalyser = new DailyBonusRoundAnalyser();
		    var stats = roundAnalyser.GetStatsForRound(draws, numbers);
		    var first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);

		    allPatterns.Add(stats.Template);

		    IPrinter printer = new DailyBonusPrinter();
			
		    printer.PrintRound(draws, numbers);
		    printer.PrintRoundStats(stats);


		    Console.WriteLine();
		    printer.PrintRoundStats(first7Draws);
	    }

	    static void GetLast6Rounds()
	    {
		    IFileReader fileReader = new FileReader();
		    var lines = fileReader.ReadNLinesFromFile(7+(8*5), "w49data.txt");

		    IRoundParser roundParser = new RoundParser();
		    var (numbers, draws) = roundParser.GetNDraws(7, 0, lines, new List<int>());

		    IPrinter printer = new Printer(false);
			Console.WriteLine("??-??-??-??-??-??");
		    printer.PrintRound(draws, numbers);
		    Console.WriteLine();

		    for (int i = 0; i < 5; i++)
		    {
			    for (int j = 0; j < 8; j++)
			    {
				    (numbers, draws) = roundParser.GetNDraws(1, 7+((i*8)+j), lines, numbers);
				    printer.PrintSubsiquentRound(draws, numbers);
			    }
			    
				Console.WriteLine();
			    

		    }

		    Console.ReadLine();
	    }

		static void DailyGetLast6Rounds()
	    {
		    IFileReader fileReader = new FileReader();
		    var lines = fileReader.ReadNLinesFromFile(9+(10*5), "dailydata.txt");

		    IRoundParser roundParser = new DailyRoundParser();
		    var (numbers, draws) = roundParser.GetNDraws(9, 0, lines, new List<int>());

		    IPrinter printer = new Printer(true);
			Console.WriteLine("??-??-??-??-??");
		    printer.PrintRound(draws, numbers);
		    Console.WriteLine();

		    for (int i = 0; i < 5; i++)
		    {
			    for (int j = 0; j < 10; j++)
			    {
				    (numbers, draws) = roundParser.GetNDraws(1, 7+((i*8)+j), lines, numbers);
				    printer.PrintSubsiquentRound(draws, numbers);
			    }
			    
				Console.WriteLine();
			    

		    }

		    Console.ReadLine();
	    }

	    static void GetAllTemplatePatterns()
	    {
		    IFileReader fileReader = new FileReader();
		    var lines = fileReader.ReadEntireFileByLineIntoStack("w49data.txt");

		    IRoundParser roundParser = new RoundParser();
		    var (numbers, draws) = roundParser.GetFirstRoundOfNDraws(8, lines);
	        
		    var allPatterns = new List<string>();
			var allUnique = new List<int>();
			var allSingles = new List<int>();
			var allTwos = new List<int>();
			var allThrees = new List<int>();

		    IRoundAnalyser roundAnalyser = new RoundAnalyser();
		    var stats = roundAnalyser.GetStatsForRound(draws, numbers);
		    var first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);

		    allPatterns.Add(stats.Template);
		    allUnique.Add(stats.UniqueNumbers);
		    allSingles.Add(stats.Singles);
		    allTwos.Add(stats.Twos);
		    allThrees.Add(stats.Threes);

		    IPrinter printer = new Printer(false);
			
		    printer.PrintRound(draws, numbers);
		    printer.PrintRoundStats(stats);


		    Console.WriteLine();
		    printer.PrintRoundStats(first7Draws);

		    for (var i = 0; i < 10000; i++)
		    {
			    try
			    {
				    (numbers, draws) = roundParser.GetNextDraw(lines, draws, numbers);
				    stats = roundAnalyser.GetStatsForRound(draws, numbers);
				    allPatterns.Add(stats.Template);
				    allUnique.Add(stats.UniqueNumbers);
				    allSingles.Add(stats.Singles);
				    allTwos.Add(stats.Twos);
				    allThrees.Add(stats.Threes);

				    first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);
				    //printer.PrintRound(draws, numbers);
				    //printer.PrintRoundStats(stats);
				    //Console.WriteLine();
				    //printer.PrintRoundStats(first7Draws);
			    }
			    catch (Exception e)
			    {
				    Console.WriteLine(e);
				    break;
			    }
		        
		    }

			allUnique.Sort();
			var averageUnique = GetAverage(allUnique);
			var medianUnique = GetMedian(allUnique);
			var minUniqu = GetMin(allUnique);
			var maxUniqu = GetMax(allUnique);

			allSingles.Sort();
			var averageSingle = GetAverage(allSingles);
			var medianSingle = GetMedian(allSingles);
			var minSingle = GetMin(allSingles);
			var maxSingle = GetMax(allSingles);

			allTwos.Sort();
			var averageTwos = GetAverage(allTwos);
			var medianTwos = GetMedian(allTwos);
			var minTwos = GetMin(allTwos);
			var maxTwos = GetMax(allTwos);

			allThrees.Sort();
			var averageThrees = GetAverage(allThrees);
			var medianThrees = GetMedian(allThrees);
			var minThrees = GetMin(allThrees);
			var maxThrees = GetMax(allThrees);

			var grps = allPatterns.GroupBy(x => x);

		    using (System.IO.StreamWriter file = 
			    new System.IO.StreamWriter(@"Templates.txt"))
		    {
			    foreach (var grp in grps)
			    {
				    file.WriteLine($"{grp.Key}\t{grp.Count()}");
			    }
		    }
	    }

	    static float GetAverage(List<int> list)
	    {
		    return list.Sum() / list.Count;
	    }

	    static int GetMedian(List<int> sortedList)
	    {
		    var count = sortedList.Count;
		    if (count % 2 == 0)
		    {
			    var skip = count / 2;
			    var num1 = sortedList[skip];
			    var num2 = sortedList[skip+1];
			    if (num1 == num2)
				    return num1;
				return (num1 + num2) /2;
		    }
		    else
		    {
			    int skip = count / 2;
			    return sortedList[skip];
		    }
	    }

	    static int GetMin(List<int> sortedList)
	    {
		    return sortedList.First();
	    }

	    static int GetMax(List<int> sortedList)
	    {
		    return sortedList.Last();
	    }

	    static void Eleminator()
	    {
			// match excty 3 in this list
		    var list = new List<int> {2, 3, 4, 5, 6, 12, 13, 17, 20, 21, 26, 27, 36, 37, 39, 41, 42, 46, 49};
			IFileReader fileReader = new FileReader();

		    var numbers = fileReader.ReadEntireFileByLineIntoStack("numbers.txt");
		    var slimmedDownList = new List<string>();

		    while (numbers.Count > 0)
		    {
			    var num = numbers.Pop();
			    var split = num.Split('\t');
				var draw = new Draw
				{
					Num1 = int.Parse(split[0]),
					Num2 = int.Parse(split[1]),
					Num3 = int.Parse(split[2]),
					Num4 = int.Parse(split[3]),
					Num5 = int.Parse(split[4]),
					Num6 = int.Parse(split[5])
				};

			    var count = 0;
			    if (list.Contains(draw.Num1))
				    count++;
			    if (list.Contains(draw.Num2))
				    count++;
			    if (list.Contains(draw.Num3))
				    count++;
			    if (list.Contains(draw.Num4))
				    count++;
			    if (list.Contains(draw.Num5))
				    count++;
			    if (list.Contains(draw.Num6))
				    count++;


				if(count == 3)
					slimmedDownList.Add(num);
		    }

		    using (System.IO.StreamWriter file = 
			    new System.IO.StreamWriter(@"SlimNum.txt"))
		    {
			    foreach (var n in slimmedDownList)
			    {
				    file.WriteLine(n);
			    }
		    }
	    }
    }
}