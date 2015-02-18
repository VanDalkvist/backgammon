using System;

using Backgammon.Helper;
using Backgammon.Logic.Algorithms;

namespace Backgammon.Logic.Players
{
	public class Bot : IPlayer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Bot"/> class.
		/// </summary>
		public Bot(ColorHelper.ColorCounter color)
		{
			Type = GeneralConstants.PlayerType.Bot;
			Color = color;
			Info = new UserInfo("Bot");
		}

		#region Implementation of IPlayer

		/// <summary>
		/// Gets type of player.
		/// </summary>
		public GeneralConstants.PlayerType Type { get; private set; }

		/// <summary>
		/// Gets color of counters, which plays the player.
		/// </summary>
		public ColorHelper.ColorCounter Color { get; private set; }

		/// <summary>
		/// Gets information about user.
		/// </summary>
		public UserInfo Info { get; private set; }

		/// <summary>
		/// Move of player.
		/// </summary>
		public void DoMove(IEvaluator evaluator)
		{
			var solution = evaluator.Evaluate();
			//foreach (var move in solution.BestMoves)
			//    Field.Instance.DoMove(move, Color);
			throw new NotImplementedException();
		}

		#endregion
	}
}