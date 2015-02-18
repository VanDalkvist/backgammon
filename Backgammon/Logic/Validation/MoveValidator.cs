using System;

using Backgammon.Core.Errors;
using Backgammon.Helper;
using Backgammon.Logic.Processing;

namespace Backgammon.Logic.Validation
{
    public class MoveValidator
	{
		private event ValidationHelper Validate;

		public ErrorProvider ErrorProvider { get; private set; }

		public MoveValidator()
		{
			Validate = ValidateDirection;
			//Validate += ValidatePointsOnDice;
			//Validate += ValidateTurn;

			ErrorProvider = new ErrorProvider();
		}

		public bool OnValidate(ValidatedArgs args)
		{
			Validate(args);
			var result = ErrorProvider.Error == string.Empty;
			ErrorProvider.Reset();
			return result;
		}

		private void ValidateDirection(ValidatedArgs args)
		{
			if (args.Counter.Color == ColorHelper.ColorCounter.Black
			    	? args.NewMove.Cell >= args.Counter.InCell
			    	: args.NewMove.Cell <= args.Counter.InCell)
				ErrorProvider.AppendError("You cannot move the counters in the opposite direction.");
		}

		private void ValidatePointsOnDice(ValidatedArgs args)
		{
			var countCells = Math.Abs(args.NewMove.Cell - args.Counter.InCell);
			if (countCells != Dice.Instance.OneDie && countCells != Dice.Instance.TwoDie)
				ErrorProvider.AppendError("Moving the counters is possible only on the number of cells on the dice.");
		}

		private void ValidateTurn(ValidatedArgs args)
		{
			if (args.Counter.Color != (ColorHelper.ColorCounter) PlayBehavior.Instance.Turn)
				ErrorProvider.AppendError("You can move the counters only if your turn.");
		}
	}
}