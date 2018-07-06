using System;
using System.Collections.Generic;
using System.Linq;
using Randometer.Commands.Extensions;

namespace Randometer.Commands
{
    /// <summary>
    ///     Represents an available CLI command for a user.
    /// </summary>
    public abstract class Command
    {
        protected CommandArgument[] Arguments { get; }

        protected IEnumerable<ExecutionPlan> ExecutionPlans { get; }

        protected string Value { get; set; }

        public string Name { get; }

        protected Command(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentNullException(nameof(commandName));
            }

            Name = commandName;
        }

        protected Command(string commandName, string[] arguments) : this(commandName)
        {
            Arguments = arguments?.ToArguments(commandName)?.ToArray();
        }

        protected Command(string commandName, params ExecutionPlan[] executionPlans) : this(commandName)
        {
            ExecutionPlans = executionPlans;
        }

        protected Command(string commandName, string[] arguments, params ExecutionPlan[] executionPlans) : this(commandName)
        {
            Arguments = arguments?.ToArguments(commandName)?.ToArray();
            ExecutionPlans = executionPlans;
        }

        public abstract void Execute();

        /// <summary>
        ///     Prints help information for the command to the console.
        /// </summary>
        protected abstract void PrintHelpInfo();
    }
}
