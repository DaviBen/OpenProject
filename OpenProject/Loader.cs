using System;
using System.Collections.Generic;
using System.IO;

namespace OpenProject
{
	public class Loader
	{
		List<string> _content;


		public TimeTable GetTimeTable(string filename)
		{

		}

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

		private void Deformat()
		{
			char[] delimiterChars = { ' ', '-', ';' };
			foreach (string s in _content)
			{
				string[] lines = s.Split(delimiterChars);
			}
		}

		private void LoadTimeTable()
		{

		}


		public Loader()
		{
			_content = new List<string>();
		}
	}
}
