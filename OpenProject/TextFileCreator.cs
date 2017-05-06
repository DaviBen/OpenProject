using System;
using System.IO;

namespace OpenProject
{
	public enum Mode
	{
		Day,
		EarlyBird,
		NightOwl,
		Business
	}

	//This class creates a text file for the planned mode switch 
	//where files are split into 8 hours for easier input
	//still very much incomplete
	public class TextFileCreator
	{
		public Mode _currentMode = Mode.Day;

		DateTime time = new DateTime(0);
		//TimeSpan ts = new TimeSpan(13, 00, 00);

		private void Create(string filename)
		{
			StreamWriter writer = new StreamWriter(filename);
			try
			{
				writer.WriteLine("-------Mo-Tu-We-Th-Fr-Sa-Su;");
				for (int i = 0; i < 16 ; i++)
				{
					string str = string.Format("{0}--{1} -{1} -{1} -{1} -{1} -{1} -{1} ;", time.ToString("HH:mm")
					                           , Availability.N.ToString());
					writer.WriteLine(str);
					time = time + TimeSpan.FromMinutes(30);
				}
			}
			finally
			{
				writer.Close();
			}
		}

		public void Setup()
		{
			//switch(m)
			//{
			//	case (Mode.Day):
			time = new DateTime(0);
			Create("Allday.txt");
			time = time + new TimeSpan(13, 00, 00);
			Create("day.txt");
			time = new DateTime(0);
			time = time + new TimeSpan(09, 00, 00);
			Create("work.txt");
				//	break;
				//case (Mode.EarlyBird):
			time = new DateTime(0);
			time = time + new TimeSpan(05, 00, 00);
			Create("earlybird.txt");
				//	break;
				//case (Mode.NightOwl):
			time = new DateTime(0);
			time = time + new TimeSpan(21, 00, 00);
			Create("nightowl.txt");
				//break;
			//}
		}





		public TextFileCreator()
		{
		}
	}
}
