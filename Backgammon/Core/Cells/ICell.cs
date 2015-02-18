using Backgammon.Core.Counters;
using Backgammon.Drawing;
using Backgammon.Helper;

namespace Backgammon.Core.Cells
{
	/// <summary>
	/// Interface for cell management.
	/// </summary>
    public interface ICell : IDrawing
    {
		/// <summary>
		/// Add counter to the cell.
		/// </summary>
		/// <param name="counter">The counter.</param>
		/// <returns>
		///  <see cref="GeneralConstants.ExitCode.Success"/>, if counter added successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>
		/// </returns>
		GeneralConstants.ExitCode Add(ICounter counter);

        /// <summary>
        /// Remove counter from the cell.
        /// </summary>
		/// <returns>
		///  <see cref="GeneralConstants.ExitCode.Success"/>, if counter removed successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>
		/// </returns>
        GeneralConstants.ExitCode Remove();

		/// <summary>
		/// Returns the last counter.
		/// </summary>
		/// <returns>The last counter.</returns>
		ICounter Last();

		/// <summary>
		/// Determines whether the cell is empty.
		/// </summary>
		/// <returns>
		///  <c>true</c>, if the cell is empty; otherwise, <c>false</c>.
		/// </returns>
		bool IsEmpty();

		/// <summary>
		/// Gets count counters in cell.
		/// </summary>
		ushort Count { get; }

		/// <summary>
		/// Gets color counter in cell.
		/// </summary>
		ColorHelper.ColorCell Color { get; }
    }
}