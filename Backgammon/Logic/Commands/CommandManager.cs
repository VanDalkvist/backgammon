using System;
using System.Collections.Generic;

using Backgammon.Helper;

using NLog;

namespace Backgammon.Logic.Commands
{
    public class CommandManager
	{
		/// <summary>
		/// Logger instance.
		/// </summary>
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// List of registered commands.
		/// </summary>
		private readonly IList<ICommand> _commands;

		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static CommandManager _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public static CommandManager Instance
		{
			get
			{
				if ( _instance == null )
					_instance = new CommandManager();

				_logger.Info(_instance);
				return _instance;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandManager"/> class.
		/// </summary>
		private CommandManager()
		{
			this._commands = new List<ICommand>();
			_logger.Info("CommandManager instance created succsessfully");
		}

		/// <summary>
		/// Registry to <see cref="CommandManager"/> new command <paramref name="command"/>.
		/// </summary>
		/// <param name="command">The command.</param>
		public void Registry(ICommand command)
		{
			Instance._commands.Add(command);
			_logger.Info("Command registried succsessfully");
		}

		/// <summary>
		/// Registry to <see cref="CommandManager"/> list of new commands <paramref name="commands"/>.
		/// </summary>
		/// <param name="commands">The list of commands.</param>
		public void Registry(params ICommand[] commands)
		{
			foreach ( var command in commands )
				Instance._commands.Add(command);

			_logger.Info("All commands registried succsessfully");
		}

		/// <summary>
		/// Unregistry from <see cref="CommandManager"/> command.
		/// </summary>
		/// <returns>
		/// <see cref="GeneralConstants.ExitCode.Success"/>, if command unregistered successully; Otherwise, <see cref="GeneralConstants.ExitCode.Failed"/>.
		/// </returns>
		public GeneralConstants.ExitCode Unregistry()
		{
			try
			{
				Instance._commands.RemoveAt(Instance._commands.Count - 1);
				_logger.Info("Command unregistried succsessfully");
				return GeneralConstants.ExitCode.Success;
			}
			catch (Exception e)
			{
				_logger.ErrorException("Unhandled exception during unregistry command.", e);
				return GeneralConstants.ExitCode.Failed;
			}
		}

		// TODO: to override ToString method.
	}
}