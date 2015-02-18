namespace Backgammon.Helper
{
    /// <summary>
    /// Constants.
    /// </summary>
    public class GeneralConstants
    {
		public const ushort Zero = 0;

        /// <summary>
		/// Turn is <see cref="White"/>, <see cref="Black"/>. <see cref="NotStarted"/>, if game not started.
        /// </summary>
        public enum TurnIs
        {
            White = ColorHelper.ColorCounter.White,
			Black = ColorHelper.ColorCounter.Black,
			NotStarted
        }

		/// <summary>
		/// Mark for counter.
		/// </summary>
		public enum Mark
		{
			Marked,
			NonMarked
		}

		/// <summary>
		/// Count of moves.
		/// </summary>
		/// <remarks>
		///  <see cref="Zero"/>, if moves no more; <see cref="One"/>, if one move exists; <see cref="Two"/>, if two moves exists. (only on double at the dice).
		/// </remarks>
		public enum CountMovesForDie
		{
			Zero = 0,
			One = 1,
			Two = 2
		}

    	public enum PlayerType
    	{
			Bot,
			Real,
			Remote
		}

		public enum ExitCode
		{
			Success,
			Failed
		}

		public const int ErrorCode = -1;

    	public const ushort CountCounters = 15;
		public const ushort CountCells = 24;

    	public const ushort StartIndexOfWhiteCounters = 0;
		public const ushort StartIndexOfBlackCounters = 15;

    	public const string Black = "Black";
		public const string White = "White";

    	public const string Bot = "Bot";
    }
}