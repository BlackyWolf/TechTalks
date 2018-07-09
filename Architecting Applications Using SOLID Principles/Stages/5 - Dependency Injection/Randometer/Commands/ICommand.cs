namespace Randometer.Commands
{
    public interface ICommand
    {
        CommandArgument[] Arguments { get; set; }

        string Name { get; }

        void Execute();
    }
}
