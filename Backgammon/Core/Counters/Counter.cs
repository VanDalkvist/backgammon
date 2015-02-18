using System.Text;

using Backgammon.Drawing;
using Backgammon.Helper;

namespace Backgammon.Core.Counters
{
	/// <summary>
	/// Counter.
	/// </summary>
    public class Counter : ICounter
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Counter"/> class.
		/// </summary>
		/// <param name="id">Identificator of counter.</param>
		/// <param name="numberCell">Number of cell.</param>
		/// <param name="color">Color of counter.</param>
		public Counter(int id, int numberCell, ColorHelper.ColorCounter color)
		{
			Id = id;
			InCell = numberCell;
			Color = color;
            IsMarked = GeneralConstants.Mark.NonMarked;
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
			sb.AppendFormat("[id={0}; InCell={1}; Color={2}; IsMarked={3}]", Id, InCell, Color, IsMarked);
			return sb.ToString();
		}

		#region Implementation of ICounter

		/// <summary>
		/// Identificator of counter.
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// Number of cell.
		/// </summary>
		public int InCell { get; private set; }

		/// <summary>
		/// Gets value, shown whether counter is marked.
		/// </summary>
		public GeneralConstants.Mark IsMarked { get; private set; }

		/// <summary>
		/// Gets or sets color of counter.
		/// </summary>
		public ColorHelper.ColorCounter Color { get; private set; }

		#endregion Implementation of ICounter

        #region Implementation of IDrawing

        /// <summary>
        /// Draw the counter.
        /// </summary>
        /// <param name="drawer">
        /// Object of type <see cref="IDrawer"/> performs the drawing.
        /// </param>
        public void Draw(IDrawer drawer)
        {
            drawer.DrawCounter();
        }

        #endregion Implementation of IDrawing
	}
}