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
		Stack<string> ReadEntireFileByLine(string path);
	}

	public class FileReader : IFileReader
	{
		public Stack<string> ReadEntireFileByLine(string path)
		{
			var lines = File.ReadLines(path);

			var stack = new Stack<string>();
			foreach (var line in lines)
				stack.Push(line);

			return stack;
		}
	}
}
