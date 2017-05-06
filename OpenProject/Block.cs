using System;
namespace OpenProject
{
	public class Block
	{
		private Availability _availability;

		public Block()
		{
		}

		public Availability Availability
		{
			get { return _availability; }
			set { _availability = value; }
		}
	}
}
