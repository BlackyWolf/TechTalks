using System;

namespace Randometer.Commands
{
    public class EmptyCommand : Command
    {
        public EmptyCommand(string commandName) : base(commandName) { }

        public override void Execute()
        {
            Console.Write("Invalid command. Enter help to see a list of available commands.");
        }
    }
}
