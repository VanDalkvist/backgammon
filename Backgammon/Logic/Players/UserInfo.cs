namespace Backgammon.Logic.Players
{
	/// <summary>
	/// Class represents information about user.
	/// </summary>
	public class UserInfo
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserInfo"/> class.
		/// </summary>
		/// <param name="name">Name of the player.</param>
		public UserInfo(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Gets name of player.
		/// </summary>
		public string Name { get; private set; }
	}
}