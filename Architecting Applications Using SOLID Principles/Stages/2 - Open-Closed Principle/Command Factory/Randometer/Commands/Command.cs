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
        protected IEnumerable<ExecutionPlan> ExecutionPlans { get; }

        public CommandArgument[] Arguments { get; set; }

        public string Name { get; }

        protected Command(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentNullException(nameof(commandName));
            }

            Name = commandName;
        }

        protected Command(string commandName, params ExecutionPlan[] executionPlans)
            : this(commandName)
        {
            ExecutionPlans = executionPlans;
        }

        public abstract void Execute();
    }
}
