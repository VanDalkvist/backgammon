using Backgammon.Helper;
using Backgammon.Logic.Algorithms;

namespace Backgammon.Logic.Players
{
	/// <summary>
	/// Interface for player managament.
	/// </summary>
	public interface IPlayer
	{
		/// <summary>
		/// Gets type of player.
		/// </summary>
		GeneralConstants.PlayerType Type { get; }

		/// <summary>
		/// Gets color of counters, which plays the player.
		/// </summary>
		ColorHelper.ColorCounter Color { get; }

		/// <summary>
		/// Gets information about user.
		/// </summary>
		UserInfo Info { get; }

		/// <summary>
		/// Move of player.
		/// </summary>
		/// <param name="evaluator">
		/// Object of type <see cref="IEvaluator"/> performs the evaluation.
		/// </param>
		void DoMove(IEvaluator evaluator);
	}
}