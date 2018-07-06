using System;

namespace Randometer.Commands.Help
{
    public class HelpCommand : Command
    {
        public HelpCommand() : base("help") {}

        /// <summary>
        ///     Generates help documentation about available commands.
        /// </summary>
        public override void Execute() => PrintHelpInfo();

        protected override void PrintHelpInfo()
        {
            // Display help information
            Console.WriteLine("Usage: rdm <command>");
            Console.WriteLine("  help          Displays a list of the available commands with their descriptions.");
            Console.WriteLine("  number        Generates a random number.");
            Console.WriteLine("  guid          Generates a random Globally Unique Identifier (GUID).");
            Console.WriteLine("\r\n  Use rdm [command] --help for more information about a command.");
        }
    }
}
