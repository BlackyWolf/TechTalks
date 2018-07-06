using System;
using Randometer.Commands.Guid;
using Randometer.Commands.Help;
using Randometer.Commands.Number;

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
        public static Command GetCommand(string[] arguments)
        {
            string commandName = GetCommandName(arguments);

            switch (commandName)
            {
                case "guid":
                    return new GuidCommand(
                        arguments,
                        new Guid.HelpPlan(),
                        new Guid.DefaultPlan());

                case "help":
                    return new HelpCommand();

                case "number":
                    return new NumberCommand(
                        arguments,
                        new Number.HelpPlan(),
                        new Number.MinAndMaxPlan(),
                        new Number.MaxPlan(),
                        new Number.DefaultPlan());

                default:
                    Console.Write("Invalid command. Enter help to see a list of available commands.");

                    return new EmptyCommand("empty");
            }
        }

        /// <summary>
        ///     Gets the command based off of the given arguments.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used for executing the console app.
        /// </param>
        /// <returns>The command name.</returns>
        private static string GetCommandName(string[] arguments)
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
