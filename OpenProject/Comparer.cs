using System;
using System.Collections.Generic;

namespace OpenProject
{
	public class Comparer
	{
		List<TimeTable> _timetables;

		//Compares all timetables and output the times that match
		public string Compare()
		{
			string str = "";
			for (int i = 0; i < _timetables.Count; i++)
			{
				for (int j = 0; j < _timetables.Count ; j++)
				{
					if (((_timetables[i].CheckBlock(i,j) == _timetables[j+1].CheckBlock(i,j))) && ((_timetables[i].CheckBlock(i,j)).Equals(Availability.Y)))
					{
						//FIXME: this will be incorrect if comparing 3 files
						//TODO: proper formatting
						str = str + string.Format("{0},{1} - {2}", i, j, _timetables[i].CheckBlock(i, j).ToString());
					}
				}
			}
			return str;
		}

		public Comparer(List<TimeTable> timetables)
		{
			_timetables = timetables;
		}
	}
}
