using Backgammon.Core.Cells;
using Backgammon.Core.Counters;
using Backgammon.Helper;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    ///This is a test class for CellTest and is intended
    ///to contain all CellTest Unit Tests
    ///</summary>
    [TestFixture]
    public class CellTest
    {
        private ICell _cell;
        private ICounter _blackCounter;

    	/// <summary>
        /// Initialize for test
        /// </summary>
        [TestFixtureSetUp]
        public void CreateCell()
        {
            _cell = new Cell();
			_blackCounter = new Counter(16, 2, ColorHelper.ColorCounter.Black);
			new Counter(3, 2, ColorHelper.ColorCounter.Black);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [Test]
        public void AddTest()
        {
			var result = _cell.Add(_blackCounter);
			Assert.IsTrue(result == GeneralConstants.ExitCode.Success);

			result = _cell.Add(_blackCounter);
			Assert.IsTrue(result == GeneralConstants.ExitCode.Success);
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [Test]
        public void RemoveTest()
        {
			var result = _cell.Add(_blackCounter);
			Assert.IsTrue(result == GeneralConstants.ExitCode.Success);

            result = _cell.Remove();
            Assert.IsTrue(result == GeneralConstants.ExitCode.Success);
        }
    }
}