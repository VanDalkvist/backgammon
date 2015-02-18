using Backgammon.Helper;

namespace Backgammon.Logic.Verification
{
	public class VerificatedArgs
	{
		public GeneralConstants.TurnIs Turn { get; private set; }

		public VerificatedArgs(GeneralConstants.TurnIs turn)
		{
			Turn = turn;
		}
	}
}