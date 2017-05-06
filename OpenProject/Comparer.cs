using System;
using System.Collections.Generic;

namespace OpenProject
{
	public class Comparer
	{
		List<TimeTable> _timetables;

		public string Compare()
		{
			string str = null;
			for (int i = 0; i < _timetables.Count; i++)
			{
				for (int j = 0; j < _timetables.Count - 1 ; j++)
				{
					if (_timetables[i].CheckBlock(i,j) == _timetables[j+1].CheckBlock(i,j))
					{
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
