using System.Text;

using Backgammon.Helper;

using NLog;

namespace Backgammon.Logic.Processing
{
	public class PlayBehavior
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static PlayBehavior _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static PlayBehavior Instance
		{
			get
			{
				if ( _instance == null )
					_instance = new PlayBehavior();

				_logger.Info(_instance);
				return _instance;
			}
		}

		public GeneralConstants.TurnIs Turn { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayBehavior"/> class.
		/// </summary>
		private PlayBehavior()
		{
			Turn = GeneralConstants.TurnIs.NotStarted;
			_logger.Info("PlayBehavior instance successfully created.");
		}

		public void Start()
		{
			if (Turn != GeneralConstants.TurnIs.NotStarted)
			{
				_logger.Warn("PlayBehavior already started.");
				return;
			}

			do
			{
				Dice.Instance.Throw();
				if (Dice.Instance.OneDie < Dice.Instance.TwoDie)
					Turn = GeneralConstants.TurnIs.White;
				if (Dice.Instance.OneDie > Dice.Instance.TwoDie)
					Turn = GeneralConstants.TurnIs.Black;
			}
			while (Dice.Instance.OneDie == Dice.Instance.TwoDie);

			_logger.Info("PlayBehavior successfully started.");
		}

		public void Stop()
		{
			if (Turn != GeneralConstants.TurnIs.NotStarted)
			{
				Turn = GeneralConstants.TurnIs.NotStarted;
				_logger.Info("PlayBehavior successfully stopped.");
			}
			else
				_logger.Warn("PlayBehavior already stopped.");
		}

		/// <summary>
		/// Next move.
		/// </summary>
		public void Next()
		{
			_logger.Info("Next move started.");
			if ( MovesNotExist() )
				ChangeTurn();
			Dice.Instance.Throw();
		}

		/// <summary>
		/// Determines whether moves not exist.
		/// </summary>
		/// <returns>
		///  <c>true</c>, if moves not exist for current . Otherwise, <c>false</c>.
		/// </returns>
		private bool MovesNotExist()
		{
			return (Dice.Instance.CountMovesForOneDie == GeneralConstants.CountMovesForDie.Zero
					&& Dice.Instance.CountMovesForTwoDie == GeneralConstants.CountMovesForDie.Zero);
		}

		/// <summary>
		/// Changing turning.
		/// </summary>
		private void ChangeTurn()
		{
			_logger.Info("Changing turn.");
			Turn = (Turn == GeneralConstants.TurnIs.Black) ? GeneralConstants.TurnIs.White : GeneralConstants.TurnIs.Black;
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
			sb.Append("Turn is ");
			sb.Append((Turn == GeneralConstants.TurnIs.Black) ? GeneralConstants.Black : GeneralConstants.White);
			return sb.ToString();
		}
	}
}