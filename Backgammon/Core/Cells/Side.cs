using System;
using System.Collections.Generic;
using System.Text;

using Backgammon.Core.Counters;
using Backgammon.Drawing;
using Backgammon.Helper;
using NLog;

namespace Backgammon.Core.Cells
{
	/// <summary>
	/// Class represents side of <see cref="ColorHelper.ColorCounter.Black"/> or <see cref="ColorHelper.ColorCounter.White"/> counters.
	/// </summary>
	public class Side : ICell
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// List of counters in cell.
		/// </summary>
		private readonly IList<ICounter> _counters;

		/// <summary>
		/// Initializes a new instance of the <see cref="Side"/> class.
		/// </summary>
		/// <param name="color">
		/// Color of side. <see cref="ColorHelper.ColorCell.Black"/> for <see cref="ColorHelper.ColorCounter.Black"/> and <see cref="ColorHelper.ColorCell.White"/> for <see cref="ColorHelper.ColorCounter.White"/> color of counter.
		/// </param>
		public Side(ColorHelper.ColorCell color)
		{
			_counters = new List<ICounter>();
			Color = color;
			_logger.Info(string.Format("Side for {0} counters created succesfully.", ColorHelper.ColorCellToString(color)));
		}

		/// <summary>
		/// Determines whether the cell is empty.
		/// </summary>
		/// <returns>
		///  <c>true</c>, if the cell is empty; otherwise, <c>false</c>.
		/// </returns>
		public bool IsEmpty()
		{
			return Color == ColorHelper.ColorCell.Empty;
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

			sb.AppendFormat(string.Format("[Count={0}; Color={1}]", Count, Color));
			sb.AppendLine();

			foreach ( var counter in _counters )
				sb.AppendLine("\t" + counter);

			return sb.ToString();
		}

		#region Implementation of ICell

		/// <summary>
		/// Add counter to the side.
		/// </summary>
		/// <param name="counter">The counter.</param>
		/// <returns>
		///  <see cref="GeneralConstants.ExitCode.Success"/>, if counter added successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode Add(ICounter counter)
		{
			try
			{
				if ( Color == ColorHelper.ColorCell.Empty )
					Color = (ColorHelper.ColorCell) counter.Color;

				_counters.Add(counter);
				_logger.Info("Counter added succesfully.");

				return GeneralConstants.ExitCode.Success;
			}
			catch ( Exception e )
			{
				_logger.ErrorException(string.Format("Counter adding failed. [{0}]", counter), e);
				return GeneralConstants.ExitCode.Failed;
			}
		}

		/// <summary>
		/// Remove counter from the side.
		/// </summary>
		/// <returns>
		///  <see cref="GeneralConstants.ExitCode.Success"/>, if counter removed successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode Remove()
		{
			try
			{
				if ( _counters.Count == 0 )
				{
					_logger.Info("Counter cannot removed. The side is empty.");
					return GeneralConstants.ExitCode.Failed;
				}

				_counters.RemoveAt(_counters.Count - 1);
				_logger.Info("Counter removed succesfully.");

				if ( _counters.Count == 0 )
				{
					Color = ColorHelper.ColorCell.Empty;
					_logger.Info("The side is empty.");
				}

				return GeneralConstants.ExitCode.Success;
			}
			catch ( Exception e )
			{
				_logger.ErrorException("Unhandled exception during removing of counter.", e);
				return GeneralConstants.ExitCode.Failed;
			}
		}

		/// <summary>
		/// Returns the last counter.
		/// </summary>
		/// <returns>The last counter.</returns>
		public ICounter Last()
		{
			return Count != 0 ? _counters[Count - 1] : null;
		}

		/// <summary>
		/// Gets count counters in cell.
		/// </summary>
		public ushort Count
		{
			get { return (ushort) _counters.Count; }
		}

		/// <summary>
		/// Gets color counter in cell.
		/// </summary>
		public ColorHelper.ColorCell Color { get; private set; }

		#endregion Implementation of ICell

		#region Implementation of IDrawing

		/// <summary>
		/// Draw the side.
		/// </summary>
		/// <param name="drawer">
		/// Object of type <see cref="IDrawer"/> performs the drawing.
		/// </param>
		public void Draw(IDrawer drawer)
		{
			drawer.DrawSide(Color);
			foreach ( var counter in _counters )
				counter.Draw(drawer);
		}

		#endregion Implementation of IDrawing
	}
}