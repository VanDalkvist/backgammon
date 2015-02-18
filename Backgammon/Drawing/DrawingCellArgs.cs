using Backgammon.Core.Cells;

namespace Backgammon.Drawing
{
	public class DrawingCellArgs : IDrawingArgs
	{
		public ICell Cell { get; private set; }

		public DrawingCellArgs(ICell cell)
		{
			Cell = cell;
		}

		#region Implementation of IDrawingArgs

		public event Painting Draw;

		#endregion
	}
}