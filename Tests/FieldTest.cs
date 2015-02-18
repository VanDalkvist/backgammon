using System;
using Backgammon.Core.Fields;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
	///This is a test class for FieldTest and is intended
	///to contain all FieldTest Unit Tests
	///</summary>
	[TestFixture]
	public class FieldTest
	{
		/// <summary>
		///A test for ToString
		///</summary>
		[Test]
		public void ToStringTest()
		{
			Console.WriteLine(Field.Instance);
		}
	}
}
