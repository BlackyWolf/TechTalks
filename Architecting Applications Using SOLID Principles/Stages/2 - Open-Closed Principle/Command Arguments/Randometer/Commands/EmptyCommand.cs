namespace Randometer.Commands
{
    public class EmptyCommand : Command
    {
        public EmptyCommand(string commandName)
            : base(commandName) { }

        public override void Execute() { }

        protected override void PrintHelpInfo() { }
    }
}
