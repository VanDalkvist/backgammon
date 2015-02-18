using System.Collections.Generic;
using Backgammon.Helper;

namespace Backgammon.Logic.Algorithms.Solutions
{
	// XML: to add xml-comments

	public interface ISolution
	{
		IList<CounterCellPair> BestMoves { get; }
	}
}