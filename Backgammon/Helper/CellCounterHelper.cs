using System.Collections.Generic;
using System.Text;

namespace Backgammon.Helper
{
	/// <summary>
	/// Class represents wrapper of <see cref="KeyValuePair{TKey,TValue}"/>.
	/// </summary>
	public class CounterCellPair
	{
		/// <summary>
		/// <see cref="KeyValuePair{TKey,TValue}"/> object.
		/// </summary>
		private KeyValuePair<ushort, ushort> _cellCounterPair;

		/// <summary>
		/// The counter id, played the role of key.
		/// </summary>
		public ushort Counter
		{
			get { return _cellCounterPair.Key; }
		}

		/// <summary>
		/// The cell id, played the role of value.
		/// </summary>
		public ushort Cell
		{
			get { return _cellCounterPair.Value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CounterCellPair"/> class.
		/// </summary>
		public CounterCellPair(ushort counter, ushort cell)
		{
			_cellCounterPair = new KeyValuePair<ushort, ushort>(counter, cell);
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
			sb.AppendFormat("[Counter={0}, Cell={1}]", Counter, Cell);
			return sb.ToString();
		}
	}
}