using System.Collections.Generic;
using System.Text;

using Backgammon.Core.Cells;
using Backgammon.Core.Counters;
using Backgammon.Drawing;
using Backgammon.Helper;
using Backgammon.Logic.Validation;

using NLog;

namespace Backgammon.Core.Fields
{
	/// <summary>
	/// Field for Backgammon game.
	/// </summary>
	public class Field : IDrawing
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static Field _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static Field Instance
		{
			get
			{
				if ( _instance == null )
					_instance = new Field();

				_logger.Info(_instance);
				return _instance;
			}
		}

		/// <summary>
		/// List of cells.
		/// </summary>
		private IList<ICell> _cells;

		/// <summary>
		/// Side for ejected white counters.
		/// </summary>
		private Side _whiteSide;

		/// <summary>
		/// Side for ejected black counters.
		/// </summary>
		private Side _blackSide;

		/// <summary>
		/// Validator of field.
		/// </summary>
		private MoveValidator _validator;

		/// <summary>
		/// Initializes a new instance of the <see cref="Field"/> class.
		/// </summary>
		private Field()
		{
			Initialize();
			_logger.Info(string.Format("Field instance successfully created:\n {0}", ToString()));
		}

		/// <summary>
		/// Reset start position of the field.
		/// </summary>
		public void Reset()
		{
			_logger.Info("Reset field instance.");
			Initialize();
		}

		/// <summary>
		/// Initialize start position.
		/// </summary>
		private void Initialize()
		{
			ushort countWhiteCounters = 0;
			ushort countBlackCounters = 0;

			_cells = new List<ICell>();

			_validator = new MoveValidator();

			for ( ushort i = 0; i < GeneralConstants.CountCells; i++ )
			{
				_cells.Add(new Cell());
				switch ( i )
				{
				case 0:
					SetCurrentCell(ref countWhiteCounters, i, 2, ColorHelper.ColorCounter.White);
					break;
				case 5:
					SetCurrentCell(ref countBlackCounters, i, 5, ColorHelper.ColorCounter.Black);
					break;
				case 7:
					SetCurrentCell(ref countBlackCounters, i, 3, ColorHelper.ColorCounter.Black);
					break;
				case 11:
					SetCurrentCell(ref countWhiteCounters, i, 5, ColorHelper.ColorCounter.White);
					break;
				case 12:
					SetCurrentCell(ref countBlackCounters, i, 5, ColorHelper.ColorCounter.Black);
					break;
				case 16:
					SetCurrentCell(ref countWhiteCounters, i, 3, ColorHelper.ColorCounter.White);
					break;
				case 18:
					SetCurrentCell(ref countWhiteCounters, i, 5, ColorHelper.ColorCounter.White);
					break;
				case 23:
					SetCurrentCell(ref countBlackCounters, i, 2, ColorHelper.ColorCounter.Black);
					break;
				}
			}

			_whiteSide = new Side(ColorHelper.ColorCell.White);
			_blackSide = new Side(ColorHelper.ColorCell.Black);
		}

		/// <summary>
		/// Sets the cell with number <paramref name="numberCell"/>.
		/// </summary>
		/// <param name="countCounters">Count of counters, when established on this field.</param>
		/// <param name="numberCell">The number of the cell.</param>
		/// <param name="countCountersInCell">Start count of counters in cell.</param>
		/// <param name="color">The color counters in cell.</param>
		private void SetCurrentCell(ref ushort countCounters, ushort numberCell,
			ushort countCountersInCell, ColorHelper.ColorCounter color)
		{
			var oldCount = countCounters;
			countCounters += countCountersInCell;

			var step = (ushort) (color == ColorHelper.ColorCounter.White ? 0 : GeneralConstants.CountCounters);
			var j = (ushort) (oldCount + step);
			var count = (ushort) (countCounters + step);

			for ( ; j < count; j++ )
				_cells[numberCell].Add(new Counter(j, numberCell, color));
		}

		/// <summary>
		/// Do the move.
		/// </summary>
		/// <param name="newMove">The move.</param>
		/// <param name="counter">Moved counter.</param>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if counter moved successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode DoMove(CounterCellPair newMove, ICounter counter)
		{
			if ( !_validator.OnValidate(new ValidatedArgs(newMove, counter)) )
				return GeneralConstants.ExitCode.Failed;

			if ( !_cells[newMove.Cell].IsEmpty() )
			{
				var colorsAreEqual = _cells[newMove.Cell].Color == (ColorHelper.ColorCell) counter.Color;
				if ( _cells[newMove.Cell].Count == 1 )
				{
					if ( !colorsAreEqual )
					{
						var movedCounterOnSide = _cells[newMove.Cell].Last();
						if ( _cells[newMove.Cell].Color == ColorHelper.ColorCell.Black )
							_blackSide.Add(new Counter(movedCounterOnSide.Id, -1, movedCounterOnSide.Color));
						else
							_whiteSide.Add(new Counter(movedCounterOnSide.Id, -1, movedCounterOnSide.Color));

						_cells[newMove.Cell].Remove();
					}
				}
				else if ( !colorsAreEqual )
					return GeneralConstants.ExitCode.Failed;
			}

			_cells[counter.InCell].Remove();
			_cells[newMove.Cell].Add(new Counter(counter.Id, newMove.Cell, counter.Color));

			return GeneralConstants.ExitCode.Success;
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

			for ( var i = 0; i < GeneralConstants.CountCells; i++ )
				sb.Append(string.Format("Cell[{0}]: {1}", i, _cells[i]));

			sb.Append(string.Format("White side: {0}", _whiteSide));
			sb.Append(string.Format("Black side: {0}", _blackSide));

			return sb.ToString();
		}

		#region Implementation of IDrawing

		/// <summary>
		/// Draw the field.
		/// </summary>
		/// <param name="drawer">
		/// Object of type <see cref="IDrawer"/> performs the drawing.
		/// </param>
		public void Draw(IDrawer drawer)
		{
			drawer.DrawField();
			foreach ( var cell in _cells )
				cell.Draw(drawer);
		}

		#endregion Implementation of IDrawing
	}
}