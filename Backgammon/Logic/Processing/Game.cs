using Backgammon.Helper;

using NLog;

namespace Backgammon.Logic.Processing
{
	public class Game
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static Game _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static Game Instance
		{
			get
			{
				if ( _instance == null )
					_instance = new Game();

				_logger.Info(_instance);
				return _instance;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Game"/> class.
		/// </summary>
		private Game()
		{
			_logger.Info("Game instance successfully created.");
		}

		/// <summary>
		/// Starting game.
		/// </summary>
		public void Start(GeneralConstants.PlayerType playerType1, GeneralConstants.PlayerType playerType2)
		{
			PlayBehavior.Instance.Start();
			_logger.Info("Game started successfully.");
		}

		/// <summary>
		/// Stopping game.
		/// </summary>
		public void Stop()
		{
			PlayBehavior.Instance.Stop();
			_logger.Info("Game stopped successfully.");
		}

		// Reminder:

		// TODO: to create Save function for serialization state of game
		// TODO: to create Load function for deserialization state of game
		// TODO: to override ToString method
	}
}