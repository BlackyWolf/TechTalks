using System;
using System.Linq;

namespace Randometer.Commands.Guid
{
    public class DefaultPlan : ExecutionPlan
    {
        public DefaultPlan() => IsDefault = true;

        public override bool Evaluate(CommandArgument[] arguments)
        {
            return !(arguments?.Any() ?? false);
        }

        public override void Run(CommandArgument[] arguments)
        {
            Console.WriteLine($"GUID: {System.Guid.NewGuid()}");
        }
    }
}
