using Backgammon.Core.Counters;
using Backgammon.Helper;

namespace Backgammon.Logic.Validation
{
	public class ValidatedArgs
	{
		public CounterCellPair NewMove { get; private set; }
		public ICounter Counter { get; private set; }

		public ValidatedArgs(CounterCellPair newMove, ICounter counter)
		{
			NewMove = newMove;
			Counter = counter;
		}
	}
}