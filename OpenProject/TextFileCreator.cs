using System;
using System.IO;

namespace OpenProject
{
	public enum Mode
	{
		Day,
		EarlyBird,
		NightOwl,
	}

	public class TextFileCreator
	{
		public Mode _currentMode = Mode.Day;

		int time = 0;

		public void Create(string filename)
		{
			StreamWriter writer = new StreamWriter(filename);
			for (int i = 0; i < 16; i++)
			{
				string str = string.Format("{0} {1}", time.ToString("D4"), Availability.No);
				writer.WriteLine(str);
				time = time + 30;
				if (time == 2400)
					time = 0;
			}
		}

		//if (_currentMode == Mode.Day)
		//{
		//					time = 1300;
		//		Create("day.txt");
		//	break;
		//		case "EarlyBird":
		//		time = 500;
		//		Create("earlybird.txt");
		//	break;
		//		case "NightOwl":
		//		time = 2100:
		//		Create("nightowl.txt");
		//	break;
		//}
		//}


		public TextFileCreator()
		{
		}
	}
}
