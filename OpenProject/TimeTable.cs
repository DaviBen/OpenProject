using System;
namespace OpenProject
{
	public class TimeTable
	{
		private Availability[,] _times;

		public TimeTable()
		{
			// Rows:    24 hours broken up into 1/2 hour blocks
			// Columns: Monday-Friday
			_times = new Availability[48, 7];
			_times.Initialize();
		}

		// Changes the specified block to the specified availability
		public void ChangeBlock(int hour, int day, Availability toChange)
		{
			_times[hour, day] = toChange;
		}

		// Returns the availability of the specified block
		public Availability CheckBlock(int hour, int day)
		{
			return _times[hour, day];
		}


	}
}
