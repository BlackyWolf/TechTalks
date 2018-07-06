using System;
using System.Linq;

namespace Randometer.Commands.Number
{
    public class NumberCommand : Command
    {
        public NumberCommand(params ExecutionPlan[] executionPlans)
            : base("number", executionPlans)
        {
            if (Arguments?.Length > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(executionPlans),
                    Arguments.Length,
                    "Too many arguments specified for the number command.");
            }
        }

        /// <summary>
        ///     Generates a random number and outputs it to the console.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments to use for generating the number.
        /// </param>
        public override void Execute()
        {
            ExecutionPlan executionPlan = ExecutionPlans.FirstOrDefault(x => x.Evaluate(Arguments));

            if (executionPlan == null)
            {
                executionPlan = ExecutionPlans.SingleOrDefault(x => x.IsDefault);
            }

            executionPlan?.Run(Arguments);
        }
    }
}
