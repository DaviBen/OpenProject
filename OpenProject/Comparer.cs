using System;
using System.Collections.Generic;

namespace OpenProject
{
	public class Comparer
	{
		List<TimeTable> _timetables;
		List<int[]> _yes;
		List<int[]> _maybe;
		List<string> _compare;

		//Compares all timetables and output the times that match
		public string Compare()
		{
			string output;
			for (int k = 0; k < _timetables.Count - 1; k++)
			{
				for (int i = 0; i < 48; i++)
				{
					for (int j = 0; j < 7; j++)
					{
						//FIXME: Wrong if more than 2
						//fix repeating values when more than 2
						if (((_timetables[k].CheckBlock(i, j) == _timetables[k + 1].CheckBlock(i, j)))
							&& (((_timetables[k].CheckBlock(i, j)).Equals(Availability.Y))
								|| ((_timetables[k].CheckBlock(i, j)).Equals(Availability.M))))
						{
							if (((_timetables[k].CheckBlock(i, j)).Equals(Availability.Y)))
							{
								// intArray[0] is Time
								// intArray[1] is Day
								// intArray[2] is Availability
								int[] intArray = new int[3];
								intArray[0] = i;
								intArray[1] = j;
								intArray[2] = (int)_timetables[k].CheckBlock(i, j);
								_yes.Add(intArray);
							}
							if (((_timetables[k].CheckBlock(i, j)).Equals(Availability.M)))
							{
								// intArray[0] is Time
								// intArray[1] is Day
								// intArray[2] is Availability
								int[] intArray = new int[3];
								intArray[0] = i;
								intArray[1] = j;
								intArray[2] = (int)_timetables[i].CheckBlock(i, j);
								_maybe.Add(intArray);
							}
						}
					}
				}
			}

			output = "Here are the list of days available for Y\n";
			output = output + Format(_yes) + "\n";
			output = output + "Here are the list of days available for M\n";
			output = output + Format(_maybe);
			return output;
		}

		//Format data to a readable format for the user.
		private string Format(List<int[]> intArrays)
		{
			foreach (int[] intArray in intArrays)
			{
				string str;
				DateTime time = new DateTime(0);
				for (int i = 0; i < intArray[0]; i++)
					time = time + TimeSpan.FromMinutes(30);
				str = time.ToString("HH:mm");
				string day = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)intArray[1]);
				str = str + " " + day + " " + ((Availability)intArray[2]).ToString();
				_compare.Add(str);
			}
			return string.Join("\n", _compare);
		}

		public Comparer(List<TimeTable> timetables)
		{
			_timetables = timetables;
			_yes = new List<int[]>();
			_maybe = new List<int[]>();
			_compare = new List<string>();
		}

		/* Alternative way to get days
		private enum Days
		{
			Monday,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday,
			Sunday
		}
		((Days)intArray[1]).ToString(); */
	}
}
