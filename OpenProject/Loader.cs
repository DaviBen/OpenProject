using System;
using System.Collections.Generic;
using System.IO;

namespace OpenProject
{
	public class Loader
	{
		List<string> _content;
		private TimeTable _times;

		//Returns the finished TimeTable from filename
		public TimeTable GetTimeTable(string filename)
		{
			Read(filename);
			Deformat();
			LoadTimeTable();
			return _times;

		}

		//Reads in the file from the filename
		private void Read(string filename)
		{
			try
			{
				using (StreamReader sr = new StreamReader(filename))
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						_content.Add(line);
					}
				}
			}
			catch
			{
				Console.WriteLine("-------------------------------------");
				Console.WriteLine("The program cannot find the text file");
				Console.WriteLine("-------------------------------------");
			}
		}

		//Deformats the input from the file to something readable by the program
		private void Deformat()
		{
			List<string> _lines = new List<string>();
			//unneccessary chars to be removed from file
			string[] delimiterString = { " ", "-", ";",
				"Mo", "Tu", "We", "Th", "Fr", "Sa", "Su",
				"0", "1", "2","3","4","5","6","7","8","9",":"};
			foreach (string s in _content)
			{
				string[] lines = s.Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);
				string linesStr = string.Join("", lines);
				linesStr = linesStr.ToUpper();
				_lines.Add(linesStr);
			}
			_content.Clear();
			_content.AddRange(_lines);
			_content.RemoveAll(string.IsNullOrEmpty);
		}

		//Allocates all data into a TimeTable format
		private void LoadTimeTable()
		{
			try
			{
				for (int i = 0; i < _content.Count; i++)
				{
					for (int j = 0; j < _content[1].Length; j++)
					{
						_times.ChangeBlock(i, j, 
						                   (Availability)Enum.Parse(typeof(Availability), _content[i][j].ToString()));
					}
				}
			}
			catch
			{
				Console.WriteLine("-----------------------------------");
				Console.WriteLine("The file is not formatted correctly");
				Console.WriteLine("-----------------------------------");
				System.Environment.Exit(0);
			}
		}


		public Loader()
		{
			_content = new List<string>();
			_times = new TimeTable();
		}
	}
}
