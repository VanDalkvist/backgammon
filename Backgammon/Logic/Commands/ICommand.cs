namespace Backgammon.Logic.Commands
{
	public interface ICommand
	{
		// XML: to add xml-comments

		void Execute();

		void Unexecute();

		// TODO: to add some commands.
	}
}