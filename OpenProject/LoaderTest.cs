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
			//string str = "03:00--N -N -N -N -N -Y-N ;";
			string str = "-------Mo - Tu - We - Th - Fr - Sa - Su;";
			string[] delimiterString = { " ", "-", ";",
				"Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
			string[] lines = str.Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);

			StringAssert.AreEqualIgnoringCase("", string.Join("", lines));
		}

		[Test()]
		public void Deformat_Test2()
		{
			string str = "03:00--N -N -N -N -N -Y-N ;";
			//string str = "-------Mo - Tu - We - Th - Fr - Sa - Su;";
			string[] delimiterString = { " ", "-", ";",
				"Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
			string[] lines = str.Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);

			StringAssert.AreEqualIgnoringCase("03:00NNNNNYN", string.Join("", lines));
		}
	}
}