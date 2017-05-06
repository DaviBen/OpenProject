using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace OpenProject
{
	[TestFixture()]
	public class LoaderTest
	{
		[Test()]
		public void ReadMethod_Test()
		{
			Assert.Fail();
		}

		[Test()]
		public void Deformat_Test()
		{
			string str = "03:00--N -N -N -N -N -Y-N ;";
			char[] delimiterChars = { ' ', '-', ';' };
			string[] lines = str.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

			StringAssert.AreEqualIgnoringCase("03:00NNNNNYN", string.Join("", lines));

		}

		[Test()]
		public void LoadTimeTable_Test()
		{
			char[] delimiterChars = { ' ', '-', ';' };
			string str = "01:00--N -N -N -N -N -Y-N ;";
			string[] lines = str.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
			string str2 = "02:00--N -N -N -N -N -Y-N ;";
			string[] lines2 = str2.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
			string str3 = "03:00--N -N -N -N -N -Y-N ;";
			string[] lines3 = str3.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);


			TimeTable _times = new TimeTable();
			List<string[]> _lines = new List<string[]>();

			_lines.Add(lines);
			_lines.Add(lines2);
			_lines.Add(lines3);

			foreach (string[] stringArray in _lines)
			{
				for (int i = 0; i < stringArray.Length; i++)
				{
					for (int j = 0; i < stringArray.Length - 1; j++)
					{
						_times.ChangeBlock(i, j, (Availability)Enum.Parse(typeof(Availability), stringArray[j + 1]));
					}
				}
			}


			StringAssert.AreEqualIgnoringCase("05:00NNNNNYN", string.Join("", lines));

		}
	}
}