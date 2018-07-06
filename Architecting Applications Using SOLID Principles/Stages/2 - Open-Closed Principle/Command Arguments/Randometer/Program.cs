using Randometer.Commands;

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
            // Process the arguments given by the user and get the command
            Command command = CommandFactory.GetCommand(arguments);

            command.Execute();
        }
    }
}
