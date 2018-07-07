using System;
using System.Linq;
using Randometer.Commands.Extensions;
using Randometer.Commands.Guid;
using Randometer.Commands.Help;
using Randometer.Commands.Number;
using Randometer.Commands.Services;

namespace Randometer.Commands
{
    /// <summary>
    ///     Handles how commands are ran and executed for the application.
    /// </summary>
    public class CommandFactory : IFactory<string[], ICommand>
    {
        private readonly Command[] commands;

        public CommandFactory(params Command[] commands)
            => this.commands = commands ?? throw new ArgumentNullException(nameof(commands));

        /// <summary>
        ///     Processes the passed arguments and execute the appropriate
        ///     command.
        /// </summary>
        /// <param name="arguments">Arguments used to execute commands.</param>
        public ICommand this[string[] arguments]
        {
            get
            {
                string commandName = GetCommandName(arguments);

                Command command = commands.SingleOrDefault(x => x.Name == commandName)
                    ?? new EmptyCommand("empty");

                command.Arguments = arguments.ToArguments(commandName)?.ToArray();

                return command;
            }
        }

        /// <summary>
        ///     Gets the command based off of the given arguments.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used for executing the console app.
        /// </param>
        /// <returns>The command name.</returns>
        private string GetCommandName(string[] arguments)
        {
            // If no arguments given, go ahead and show the help information
            if (arguments == null || arguments.Length == 0) return "help";

            return arguments[0];
        }
    }
}
