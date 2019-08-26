using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats.NewThought
{
    public static class CountAllNumbers
    {
        public static void Count()
        {

            IFileReader fileReader = new FileReader();
            var lines = fileReader.ReadEntireFileByLineIntoStack("../../../Data/w49data.txt");

            var rankings = new List<string>();
            var counter = new int[50];
            while (lines.Count > 0)
            {
                var line = lines.Pop();

                var parts = line.Split('\t');

                var draw = new Draw
                {
                    Num1 = int.Parse(parts[2]),
                    Num2 = int.Parse(parts[3]),
                    Num3 = int.Parse(parts[4]),
                    Num4 = int.Parse(parts[5]),
                    Num5 = int.Parse(parts[6]),
                    Num6 = int.Parse(parts[7]),
                };

                var rankDic = new Dictionary<int, Number>();
                for (var i = 1; i < counter.Length; i++)
                {
                    var num = i;
                    var count = counter[i];

                    rankDic.Add(num, new Number{Value = num, Count = count});
                }

                var ordered = rankDic.OrderByDescending(x => x.Value);

                var groups = rankDic.GroupBy(x => x.Value.Count).OrderByDescending(x => x.Key);

                var rank = 1;
                foreach (var group in groups)
                {
                    foreach (var keyValuePair in group)
                    {
                        keyValuePair.Value.Rank = rank;
                    }

                    rank++;
                }


                var numList = new List<int>
                {
                    rankDic.Single(x => x.Key == draw.Num1).Value.Rank,
                    rankDic.Single(x => x.Key == draw.Num2).Value.Rank,
                    rankDic.Single(x => x.Key == draw.Num3).Value.Rank,
                    rankDic.Single(x => x.Key == draw.Num4).Value.Rank,
                    rankDic.Single(x => x.Key == draw.Num5).Value.Rank,
                    rankDic.Single(x => x.Key == draw.Num6).Value.Rank
                };

                var sortedNumList = numList.OrderByDescending(x => x);
                

                var stringBuilder = new StringBuilder();
                foreach (var i in sortedNumList )
                {
                    stringBuilder.Append($"{i}-");
                }
                var s = stringBuilder.ToString();
                rankings.Add(s);

                /*
                Console.Write($"{draw.Num1}-r{rankDic.Single(x => x.Key == draw.Num1).Value.Rank}  ");
                Console.Write($"{draw.Num2}-r{rankDic.Single(x => x.Key == draw.Num2).Value.Rank}  ");
                Console.Write($"{draw.Num3}-r{rankDic.Single(x => x.Key == draw.Num3).Value.Rank}  ");
                Console.Write($"{draw.Num4}-r{rankDic.Single(x => x.Key == draw.Num4).Value.Rank}  ");
                Console.Write($"{draw.Num5}-r{rankDic.Single(x => x.Key == draw.Num5).Value.Rank}  ");
                Console.WriteLine($"{draw.Num6}-r{rankDic.Single(x => x.Key == draw.Num6).Value.Rank}");
                */


                counter[draw.Num1]++;
                counter[draw.Num2]++;
                counter[draw.Num3]++;
                counter[draw.Num4]++;
                counter[draw.Num5]++;
                counter[draw.Num6]++;
            }

            /*
            foreach (var ranking in rankings)
            {
                Console.WriteLine(ranking);
            }
            */
            var rankGroup = rankings.GroupBy(x => x);
            foreach (var group in rankGroup)
            {
                if(group.Count() > 1)
                    Console.WriteLine($"{group.Key} ({group.Count()})"); 
            }
            Console.WriteLine(rankGroup.Count());

        }

        public class Number
        {
            public int Value { get; set; }
            public int Count { get; set; }
            public int Rank { get; set; }
        }
    }
}
