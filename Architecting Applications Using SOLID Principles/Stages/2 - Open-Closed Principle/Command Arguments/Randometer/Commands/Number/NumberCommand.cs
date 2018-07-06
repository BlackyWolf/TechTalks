using System;
using System.Linq;

namespace Randometer.Commands.Number
{
    public class NumberCommand : Command
    {
        public NumberCommand(string[] arguments, params ExecutionPlan[] executionPlans)
            : base("number", arguments, executionPlans)
        {
            if (Arguments.Length > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(arguments),
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

        /// <summary>
        ///     Prints help information for the command to the console.
        /// </summary>
        protected override void PrintHelpInfo()
        {
            throw new NotImplementedException();
        }
    }
}
