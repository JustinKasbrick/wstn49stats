using System;
using System.Collections.Generic;
using System.Linq;

namespace wstn49stats
{
    class Program
    {
        static void Main(string[] args)
        {
	        IFileReader fileReader = new FileReader();
	        var lines = fileReader.ReadEntireFileByLine("w49data.txt");

	        IRoundParser roundParser = new RoundParser();
	        var (numbers, draws) = roundParser.GetFirstRoundOfNDraws(8, lines);

			IRoundAnalyser roundAnalyser = new RoundAnalyser();
	        var stats = roundAnalyser.GetStatsForRound(draws, numbers);
	        var first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);

			IPrinter printer = new Printer();
			
			printer.PrintRound(draws, numbers);
	        printer.PrintRoundStats(stats);


			Console.WriteLine();
	        printer.PrintRoundStats(first7Draws);

	        for (var i = 0; i < 8; i++)
	        {
		        (numbers, draws) = roundParser.GetNextDraw(lines, draws, numbers);
		        stats = roundAnalyser.GetStatsForRound(draws, numbers);
		        first7Draws = roundAnalyser.GetStatsForFirst7Draws(draws, numbers);
		        printer.PrintRound(draws, numbers);
		        printer.PrintRoundStats(stats);
		        Console.WriteLine();
		        printer.PrintRoundStats(first7Draws);
	        }
	        

	        Console.ReadLine();
        }

    }
}