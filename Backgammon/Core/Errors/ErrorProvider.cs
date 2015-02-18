using System.Text;

namespace Backgammon.Core.Errors
{
    /// <summary>
	/// Class provides errors and warning messages. 
	/// </summary>
	public class ErrorProvider
	{
		/// <summary>
		/// Error string.
		/// </summary>
		private StringBuilder _error;

		/// <summary>
		/// Warning string.
		/// </summary>
		private StringBuilder _warning;

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorProvider"/> class.
		/// </summary>
		public ErrorProvider()
		{
			this.Reset();
		}

		/// <summary>
		/// Resetting all errors and warnings.
		/// </summary>
		public void Reset()
		{
			this._error = new StringBuilder();
			this._warning = new StringBuilder();
		}

		/// <summary>
		/// Gets error string.
		/// </summary>
		public string Error
		{
			get { return this._error.ToString(); }
		}

		/// <summary>
		/// Gets warning string.
		/// </summary>
		public string Warning
		{
			get { return this._warning.ToString(); }
		}

		/// <summary>
		/// Appends error string to all errors.
		/// </summary>
		/// <param name="error">The error.</param>
		public void AppendError(string error)
		{
			this._error.AppendLine(error);
		}

		/// <summary>
		/// Appends warning string to all warnings.
		/// </summary>
		/// <param name="warning">The warning.</param>
		public void AppendWarning(string warning)
		{
			this._warning.AppendLine(warning);
		}
	}
}