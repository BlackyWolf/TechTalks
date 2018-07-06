using System;
using System.Linq;
using Randometer.Commands.Extensions;

namespace Randometer.Commands.Guid
{
    public class GuidCommand : Command
    {
        public GuidCommand(string[] arguments, params ExecutionPlan[] executionPlans)
            : base("guid", arguments, executionPlans) { }

        /// <summary>
        ///     Generates a random GUID and outputs it to the console.
        /// </summary>
        public override void Execute()
        {
            ExecutionPlan executionPlan = ExecutionPlans.FirstOrDefault(x => x.Evaluate(Arguments));

            if (executionPlan == null)
            {
                executionPlan = ExecutionPlans.SingleOrDefault(x => x.IsDefault);
            }

            executionPlan?.Run(Arguments);
        }

        protected override void PrintHelpInfo()
        {
            throw new NotImplementedException();
        }
    }
}
