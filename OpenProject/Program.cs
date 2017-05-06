using System;
using System.Collections.Generic;

namespace OpenProject
{
	public class MainClass
	{
		/*
			When at least 2 have been successfully loaded the user can enter more or can now use the compare command
			The compare command will create and then call a Compare object witch will do the main calculation and spit back a string for the main to output
		*/
		public static void Main(string[] args)
		{ 
			Loader timetableLoader = new Loader();
			string timetableName;
			List<TimeTable> providedTimetables = new List<TimeTable>();

			string print = "first";
			for (int i = 0; i < 2; i++)
			{
				Console.WriteLine("Please enter the name of the " + print + " text file: ");
				timetableName = Console.ReadLine();
				// Find the timetable with the name provided by the user
				// Add it to the list of timetables
				providedTimetables.Add(timetableLoader.GetTimeTable(timetableName));
				print = "second";
			}

			//Gives the user the option to mode timetables or continue on to comparing them
			Console.WriteLine("Add the name of another text file or type 'compare' to compare the provided text files: ");
			string addMore = Console.ReadLine().ToLower();

			//Iterates while the user continues to add timetables
			while (addMore != "compare")
			{
				providedTimetables.Add(timetableLoader.GetTimeTable(addMore));
				Console.WriteLine("Add the name of another text file or type 'compare' to compare the provided text files: ");
				addMore = Console.ReadLine().ToLower();
			}

			//Compare all the provided timetables
			Comparer compareTimetables = new Comparer(providedTimetables);
			compareTimetables.Compare();






		}
	}
}
