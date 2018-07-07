using System;
using Randometer.Commands;
using Randometer.Commands.Guid;
using Randometer.Commands.Help;
using Randometer.Commands.Number;
using Randometer.Commands.Services;

namespace Randometer
{
    /// <summary>
    ///     The entry class for running the application.
    /// </summary>
    class Program
    {
        /// <summary>
        ///     The entry method for running the application.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used for executing application commands.
        /// </param>
        static void Main(string[] arguments)
        {
            IFactory<string[], ICommand> factory = CreateCommandFactory();

            // Process the arguments given by the user and get the command
            ICommand command = factory[arguments];

            command.Execute();
        }

        private static IFactory<string[], ICommand> CreateCommandFactory()
        {
            return new CommandFactory(
                new Command(
                    "guid",
                    new Commands.Guid.HelpPlan(),
                    new Commands.Guid.DefaultPlan()),

                new HelpCommand(),

                new Command(
                    "number",
                    new Commands.Number.HelpPlan(),
                    new Commands.Number.MinAndMaxPlan(),
                    new Commands.Number.MaxPlan(),
                    new Commands.Number.DefaultPlan()));
        }
    }
}
