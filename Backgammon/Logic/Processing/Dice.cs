using System.Text;

using Backgammon.Helper;

using NLog;
using Randomize;

namespace Backgammon.Logic.Processing
{
	/// <summary>
	/// Dice for Backgammon game.
	/// </summary>
	public class Dice
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static Dice _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static Dice Instance
		{
			get
			{
				if ( _instance == null )
					_instance = new Dice();

				_logger.Info(_instance);
				return _instance;
			}
		}

		/// <summary>
		/// Gets the number on one die.
		/// </summary>
		public ushort OneDie { get; private set; }

		/// <summary>
		/// Gets the number on two die.
		/// </summary>
		public ushort TwoDie { get; private set; }

		/// <summary>
		/// Gets the count moves for one die.
		/// </summary>
		public GeneralConstants.CountMovesForDie CountMovesForOneDie { get; private set; }

		/// <summary>
		/// Gets the moves for two die.
		/// </summary>
		public GeneralConstants.CountMovesForDie CountMovesForTwoDie { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Dice"/> class.
		/// </summary>
		private Dice()
		{
			Initialize();
			_logger.Info("Dice instance successfully created");
		}

		/// <summary>
		/// <see cref="Dice"/> will be thrown.
		/// </summary>
		public void Throw()
		{
			OneDie = GenerateNumber();
			TwoDie = GenerateNumber();
			DoubleDice();
			_logger.Info("Dice successfully created");
		}

		/// <summary>
		/// Initialize start values for dice.
		/// </summary>
		private void Initialize()
		{
			OneDie = GeneralConstants.Zero;
			TwoDie = GeneralConstants.Zero;
		}

		/// <summary>
		/// Generate number for die on thrown.
		/// </summary>
		/// <returns>
		/// Roll of the dice.
		/// </returns>
		private ushort GenerateNumber()
		{
			return (ushort) Random.Next(1, 7);
		}

		/// <summary>
		/// Setting count of moves for each die.
		/// </summary>
		private void DoubleDice()
		{
			if ( OneDie == TwoDie )
			{
				CountMovesForOneDie = GeneralConstants.CountMovesForDie.Two;
				CountMovesForTwoDie = GeneralConstants.CountMovesForDie.Two;
				_logger.Info("Double on Dice");
			}
			else
			{
				CountMovesForOneDie = GeneralConstants.CountMovesForDie.One;
				CountMovesForTwoDie = GeneralConstants.CountMovesForDie.One;
			}
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			var sb = new StringBuilder();
			
			sb.Append("Dice=");
			sb.AppendFormat("[{0}, {1}]", OneDie, TwoDie);

			return sb.ToString();
		}
	}
}