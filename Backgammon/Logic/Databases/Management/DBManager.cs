using System;
using System.Data;
using System.Data.SQLite;

using Backgammon.Helper;
using Backgammon.Logic.Databases.DBHelper;

using NLog;

namespace Backgammon.Logic.Databases.Management
{
	public class DBManager
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static DBManager _instance;

		/// <summary>
		/// Sqliite connection
		/// </summary>
		private readonly SQLiteConnection _connection;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static DBManager Instance
		{
			get
			{
				if ( _instance == null )
					_instance = new DBManager();

				_logger.Info(_instance);
				return _instance;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DBManager"/> class.
		/// </summary>
		private DBManager()
		{
			try
			{
				_connection = new SQLiteConnection("Data Source=" + DBConstants.NameDB);
				_logger.Info("DataBaseManager instance successfully created.");
			}
			catch (SQLiteException e)
			{
				_logger.ErrorException("Data base cannot be created.", e);
				_logger.Error("DataBaseManager instance creating failed.");
			}
			catch (Exception e)
			{
				_logger.ErrorException("Unhandled exception during creating DataBaseManager instance.", e);
			}
		}

		/// <summary>
		/// Opens DB connection.
		/// </summary>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if connection opened successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode OpenDBConnection()
		{
			try
			{
				_logger.Info("Opening DB connection...");
				_connection.Open();
				_logger.Info("DB connection opened successfully.");
				return GeneralConstants.ExitCode.Success;
			}
			catch ( SQLiteException e )
			{
				_logger.ErrorException("Data base connection cannot be opened.", e);
				return GeneralConstants.ExitCode.Failed;
			}
			catch ( Exception e )
			{
				_logger.ErrorException("Unhandled exception during opening DB connection.", e);
				return GeneralConstants.ExitCode.Failed;
			}
		}

		/// <summary>
		/// Closes DB connection.
		/// </summary>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if connection closed successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode CloseDBConnection()
		{
			try
			{
				if ( _connection != null )
				{
					_logger.Info("Closing DB connection...");
					_connection.Close();
					_logger.Info("DB connection closed successfully.");
				}
				else
				{
					_logger.Error("DB connection doesn't exist.");
					return GeneralConstants.ExitCode.Failed;
				}
				return GeneralConstants.ExitCode.Success;
			}
			catch ( SQLiteException e )
			{
				_logger.ErrorException("Data base connection cannot be closed.", e);
				return GeneralConstants.ExitCode.Failed;
			}
			catch ( Exception e )
			{
				_logger.ErrorException("Unhandled exception during closing DB connection.", e);
				return GeneralConstants.ExitCode.Failed;
			}
		}

		/// <summary>
		/// Executes the insert/update/delete operations.
		/// </summary>
		/// <param name="sqlStatement">The SQL query.</param>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if non query executed successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode ExecuteNonQuery(string sqlStatement)
		{
			var result = GeneralConstants.ExitCode.Success;
			_logger.Info(string.Format("Executing non query: [{0}]...", sqlStatement));

			try
			{
				if ( OpenDBConnection() == GeneralConstants.ExitCode.Success )
				{
					var mycommand = new SQLiteCommand(_connection);
					mycommand.CommandText = sqlStatement;

					if (mycommand.ExecuteNonQuery() > 0)
					{
						_logger.Error("Non query executing failed.");
						result = GeneralConstants.ExitCode.Failed;
					}
					_logger.Info(string.Format("Non query: [{0}] executed successfully.", sqlStatement));
				}
			}
			catch ( Exception e )
			{
				_logger.ErrorException(string.Format("Unhandled exception during executing non query [{0}].", sqlStatement), e);
				result = GeneralConstants.ExitCode.Failed;
			}
			finally
			{
				if ( CloseDBConnection() != GeneralConstants.ExitCode.Success )
					result = GeneralConstants.ExitCode.Failed;
			}

			return result;
		}

		/// <summary>
		/// Gets the data table.
		/// </summary>
		/// <param name="sqlStatement">The SQL select query.</param>
		/// <returns>Table with result.</returns>
		public DataTable ExecuteQuery(string sqlStatement)
		{
			_logger.Info(string.Format("Executing query: [{0}]...", sqlStatement));

			var dataTable = new DataTable();
			SQLiteDataReader reader = null;

			try
			{
				OpenDBConnection();
				var mycommand = new SQLiteCommand(_connection);
				mycommand.CommandText = sqlStatement;
				reader = mycommand.ExecuteReader();
				dataTable.Load(reader);
				_logger.Info(string.Format("Query: [{0}] executed.", sqlStatement));
			}
			catch ( Exception e )
			{
				_logger.ErrorException(string.Format("Unhandled exception during executing query: [{0}].", sqlStatement), e);
			}
			finally
			{
				if (null != reader)
					reader.Close();

				CloseDBConnection();
			}

			return dataTable;
		}
	}
}