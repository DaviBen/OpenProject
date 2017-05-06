using System;
namespace OpenProject
{
	public class TimeTable
	{
		private Block[,] _times;

		public TimeTable()
		{
			// Rows:    24 hours broken up into 1/2 hour blocks
			// Columns: Monday-Friday
			_times = new Block[48, 5];
			_times.Initialize();
		}

		// Changes the specified block to the specified availability
		public void ChangeBlock(int hour, int day, Availability toChange)
		{
			_times[hour, day].Availability = toChange;
		}

		// Returns the availability of the specified block
		public Availability CheckBlock(int hour, int day)
		{
			return _times[hour, day].Availability;	
		}


	}
}
