using System;

namespace Randometer.Commands
{
    /// <summary>
    ///     Handles how commands are ran and executed for the application.
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        ///     Processes the passed arguments and execute the appropriate
        ///     command.
        /// </summary>
        /// <param name="arguments">Arguments used to execute commands.</param>
        public static void RunArguments(string[] arguments)
        {
            string command = GetCommand(arguments);

            // Lower case the command name so we don't have to switch on case also
            if (!string.IsNullOrWhiteSpace(command)) command = command.ToLower();

            switch (command)
            {
                case "guid":
                    GuidCommand.Execute(arguments);

                    break;
                case "help":
                    HelpCommand.Execute();

                    break;
                case "number":
                    NumberCommand.Execute(arguments);

                    break;
                default:
                    Console.Write("Invalid command. Enter help to see a list of available commands.");

                    break;
            }
        }

        /// <summary>
        ///     Gets the command based off of the given arguments.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used for executing the console app.
        /// </param>
        /// <returns>The command name.</returns>
        private static string GetCommand(string[] arguments)
        {
            // If no arguments given, go ahead and show the help information
            if (arguments == null || arguments.Length == 0)
            {
                return "help";
            }

            return arguments[0];
        }
    }
}
