using Backgammon.Core.Cells;
using Backgammon.Core.Counters;
using Backgammon.Core.Fields;
using Backgammon.Helper;

namespace Backgammon.Drawing
{
    /// <summary>
	/// Interface represents methods for drawing specific elements.
	/// </summary>
	public interface IDrawer
	{
		/// <summary>
		/// Draw element of type <see cref="ICounter"/>.
		/// </summary>
		void DrawCounter();
		
		/// <summary>
		/// Draw element of type <see cref="ICell"/>.
		/// </summary>
		void DrawCell();
		
		/// <summary>
		/// Draw element of type <see cref="Field"/>.
		/// </summary>
		void DrawField();

		/// <summary>
		/// Draw element of type <see cref="Side"/>
		/// </summary>
		/// <param name="color">The color of side.</param>
		void DrawSide(ColorHelper.ColorCell color);
	}
}