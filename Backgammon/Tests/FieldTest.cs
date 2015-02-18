using System;
using Backgammon.Core.Counters;
using Backgammon.Core.Fields;
using Backgammon.Helper;
using NUnit.Framework;

namespace Backgammon.Tests
{
	/// <summary>
	///This is a test class for FieldTest and is intended to contain all FieldTest Unit Tests.
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

		/// <summary>
		///A test for DoMove
		///</summary>
		[Test]
		public void DoMoveTest()
		{
			Assert.IsTrue(
				Field.Instance.DoMove(
					new CounterCellPair(19, 4),
					new Counter(19, 5, ColorHelper.ColorCounter.Black))
				== GeneralConstants.ExitCode.Success);

			Assert.IsTrue(
				Field.Instance.DoMove(
					new CounterCellPair(18, 4),
					new Counter(18, 5, ColorHelper.ColorCounter.Black))
				== GeneralConstants.ExitCode.Success);

			ICounter counter = new Counter(1, 0, ColorHelper.ColorCounter.White);
			var newMove = new CounterCellPair(1, 4);

			Assert.IsTrue(Field.Instance.DoMove(newMove, counter) == GeneralConstants.ExitCode.Failed);

			Assert.IsTrue(
				Field.Instance.DoMove(
					new CounterCellPair(18, 3),
					new Counter(18, 4, ColorHelper.ColorCounter.Black))
				== GeneralConstants.ExitCode.Success);

			Assert.IsTrue(
				Field.Instance.DoMove(
					new CounterCellPair(18, 7),
					new Counter(18, 4, ColorHelper.ColorCounter.Black))
				== GeneralConstants.ExitCode.Failed);

			Assert.IsTrue(
				Field.Instance.DoMove(
					new CounterCellPair(1, 2),
					new Counter(1, 4, ColorHelper.ColorCounter.White))
				== GeneralConstants.ExitCode.Failed);

			Assert.IsTrue(Field.Instance.DoMove(newMove, counter) == GeneralConstants.ExitCode.Success);

			Console.WriteLine(Field.Instance);
		}
	}
}
