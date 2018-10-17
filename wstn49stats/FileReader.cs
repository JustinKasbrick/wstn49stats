using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wstn49stats
{
	public interface IFileReader
	{
		Stack<string> ReadEntireFileByLineIntoStack(string path);
		List<string> ReadNLinesFromFile(int numLines, string path);
	}

	public class FileReader : IFileReader
	{
		public Stack<string> ReadEntireFileByLineIntoStack(string path)
		{
			var lines = File.ReadLines(path);

			var stack = new Stack<string>();
			foreach (var line in lines)
				stack.Push(line);

			return stack;
		}

		public List<string> ReadNLinesFromFile(int numLines, string path)
		{
			return File.ReadLines(path).Take(numLines).ToList();
		}
	}
}
