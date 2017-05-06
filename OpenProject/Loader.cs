using System;
using System.Collections.Generic;
using System.IO;

namespace OpenProject
{
	public class Loader
	{
		List<string> _content;
		List<string[]> _lines;
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
				using (StreamReader sr = File.OpenText(filename))
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
				System.Environment.Exit(0);
			}
		}

		//Deformats the input from the file to something readable by the program
		private void Deformat()
		{
			//unneccessary chars to be removed from file
			char[] delimiterChars = { ' ', '-', ';' };
			foreach (string s in _content)
			{
				string[] lines = s.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				//creates a new array of strings where [0] = time, [1] = availability for monday
				//can be changed to strings if desired. "NNNNN" would be a time that is unavailable for all days
				_lines.Add(lines);
			}
		}

		//Allocates all data into a TimeTable format
		private void LoadTimeTable()
		{
			//try
			//{
				foreach (string[] stringArray in _lines)
				{
					for (int i = 0; i < stringArray.Length; i++)
					{
						for (int j = 0; i < stringArray.Length - 1; j++)
						{
						//FIXME: the error is showing here.
							_times.ChangeBlock(i, j, (Availability)Enum.Parse(typeof(Availability), stringArray[j + 1]));
						}
					}
				}
			//}
			//catch
			//{
			//	Console.WriteLine("-----------------------------------");
			//	Console.WriteLine("The file is not formatted correctly");
			//	Console.WriteLine("-----------------------------------");
			//}
		}


		public Loader()
		{
			_content = new List<string>();
			_lines = new List<string[]>();
			_times = new TimeTable();
		}
	}
}
