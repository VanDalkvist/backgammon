using Backgammon.Logic.Algorithms.Solutions;

namespace Backgammon.Logic.Algorithms
{
	public interface IEvaluator
	{
		ISolution Evaluate();
	}
}