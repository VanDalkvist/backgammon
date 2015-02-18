using Backgammon.Core.Counters;

namespace Backgammon.Drawing
{
	public class DrawingCounterArgs : IDrawingArgs
	{
        public Counter Counter { get; private set; }

	    public DrawingCounterArgs(Counter counter)
		{
	        Counter = counter;
			Draw += DoDraw;
		}

		private void DoDraw(IGeneralDrawer drawer)
		{
			drawer.Draw();
		}

		#region Implementation of IDrawingArgs

		public event Painting Draw;

		#endregion
	}
}