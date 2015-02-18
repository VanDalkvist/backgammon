using Backgammon.Drawing;
using Backgammon.Helper;

namespace Backgammon.Core.Counters
{
	/// <summary>
	/// Interface for cell management.
	/// </summary>
    public interface ICounter : IDrawing
	{
		/// <summary>
		/// Identificator of counter.
		/// </summary>
		int Id { get; }

		/// <summary>
		/// Number of cell.
		/// </summary>
		int InCell { get; }

		/// <summary>
		/// Gets value, shown whether counter is marked.
		/// </summary>
        GeneralConstants.Mark IsMarked { get; }

		/// <summary>
		/// Gets color of counter.
		/// </summary>
        ColorHelper.ColorCounter Color { get; }
    }
}