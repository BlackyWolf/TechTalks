using System;
using System.Collections.Generic;
using System.Linq;
using Randometer.Commands.Extensions;

namespace Randometer.Commands
{
    /// <summary>
    ///     Represents an available CLI command for a user.
    /// </summary>
    public class Command : ICommand
    {
        protected IEnumerable<IExecutionPlan> ExecutionPlans { get; }

        public CommandArgument[] Arguments { get; set; }

        public string Name { get; }

        public Command(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentNullException(nameof(commandName));
            }

            Name = commandName;
        }

        public Command(string commandName, params IExecutionPlan[] executionPlans)
            : this(commandName)
            => ExecutionPlans = executionPlans;

        public virtual void Execute()
        {
            IExecutionPlan executionPlan = ExecutionPlans?.FirstOrDefault(x => x.Evaluate(Arguments));

            if (executionPlan == null)
            {
                executionPlan = ExecutionPlans?.SingleOrDefault(x => x.IsDefault);
            }

            executionPlan?.Run(Arguments);
        }
    }
}
