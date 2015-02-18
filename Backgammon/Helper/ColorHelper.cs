namespace Backgammon.Helper
{
	public class ColorHelper
	{
		/// <summary>
		/// Color of counter.
		/// </summary>
		public enum ColorCounter
		{
			White,
			Black,
			Lack
		}

		/// <summary>
		/// Color of counters in cell.
		/// </summary>
		public enum ColorCell
		{
			White = ColorCounter.White,
			Black = ColorCounter.Black,
			Empty
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the color <paramref name="color"/> of cell.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents the color <paramref name="color"/> of cell.
		/// </returns>
		public static string ColorCellToString(ColorCell color)
		{
			return (color == ColorCell.Black) ? GeneralConstants.Black.ToLower() : GeneralConstants.White.ToLower();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the color <paramref name="color"/> of counter.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents the color <paramref name="color"/> of counter.
		/// </returns>
		public static string ColorCounterToString(ColorCounter color)
		{
			return (color == ColorCounter.Black) ? GeneralConstants.Black.ToLower() : GeneralConstants.White.ToLower();
		}
	}
}