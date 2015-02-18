using System;
using System.Data;
using System.Data.SQLite;
using System.Text;

using Backgammon.Helper;
using Backgammon.Logic.Databases.DBHelper;
using Backgammon.Logic.Players;

using NLog;

namespace Backgammon.Logic.Databases.Management
{
	public class UserManager
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Adds the user to database.
		/// </summary>
		/// <param name="userName">The user name.</param>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if user added successully; 
		/// Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode AddUser(string userName)
		{
			try
			{
				_logger.Info("Adding user...");
				_logger.Info(string.Format("Adding user: {0} ...", userName));

				var sqlQuery = new StringBuilder();
				sqlQuery.AppendFormat("INSERT INTO {0} VALUES(", DBConstants.UsersTable);
				sqlQuery.AppendFormat("'{0}'", userName);
				sqlQuery.Append(");");

				if ( DBManager.Instance.ExecuteNonQuery(sqlQuery.ToString()) == GeneralConstants.ExitCode.Success )
				{
					_logger.Info("User added successfully.");
					return GeneralConstants.ExitCode.Success;
				}
				return GeneralConstants.ExitCode.Failed;
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
		/// Deletes the user from database.
		/// </summary>
		/// <param name="userName">The user</param>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if user deleted successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode DeleteUser(string userName)
		{
			GeneralConstants.ExitCode result;

			try
			{
				_logger.Info(string.Format("Deleting user: {0}...", userName));

				var sql = new StringBuilder();
				sql.AppendFormat("DELETE FROM {0} WHERE {1}='{2}';", DBConstants.UsersTable, DBConstants.ColumnUserName, userName);

				result = DBManager.Instance.ExecuteNonQuery(sql.ToString());
			}
			catch ( Exception e )
			{
				_logger.ErrorException(string.Format("Unhandled exception during deleting user {0}.", userName), e);
				result = GeneralConstants.ExitCode.Failed;
			}

			return result;
		}

		/// <summary>
		/// Gets list of all users.
		/// </summary>
		/// <returns>
		/// Table of users.
		/// </returns>
		public DataTable GetAllUsers()
		{
			DataTable table = null;
			try
			{
				_logger.Info("Getting list of all users...");

				const string sql = "SELECT * FROM " + DBConstants.UsersTable + ";";
				table = DBManager.Instance.ExecuteQuery(sql);
			}
			catch ( Exception e )
			{
				_logger.ErrorException(string.Format("Unhandled exception during getting all users."), e);
			}
			return table;
		}

		///<summary>
		/// Updates the player in database.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, 
		/// if player updated successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode UpdateUser(IPlayer player)
		{
			GeneralConstants.ExitCode result;

			try
			{
				_logger.Info(string.Format("Updating user in database: {0}", player));

				var sql = new StringBuilder();
				sql.AppendFormat("UPDATE {0} SET ", DBConstants.NameDB);

				// template:
				// sql.AppendFormat(" {0}='{1}'", DBConstants.ColumnLogin, session.Login);

				result = DBManager.Instance.ExecuteNonQuery(sql.ToString());
			}
			catch ( Exception e )
			{
				_logger.ErrorException(string.Format("Unhandled exception during updating user {0}.", player.Info.Name), e);
				result = GeneralConstants.ExitCode.Failed;
			}

			return result;
		}

		///<summary>
		/// Delete all entries about users in database.
		/// </summary>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if deleted all users successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode DeleteAllUsers()
		{
			_logger.Info("Deleting all entries in database...");

			var users = GetAllUsers();
			foreach ( DataRow user in users.Rows )
				if ( DeleteUser((string) user[DBConstants.ColumnUserName]) == GeneralConstants.ExitCode.Failed )
				{
					_logger.Error("Deleting all entries in database failed.");
					return GeneralConstants.ExitCode.Failed;
				}

			_logger.Error("All entries in database deleted successfully.");
			return GeneralConstants.ExitCode.Success;
		}
	}
}