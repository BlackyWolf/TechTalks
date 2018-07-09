using System;
using System.Linq;

namespace Randometer.Commands.Guid
{
    public class DefaultPlan : IExecutionPlan
    {
        public bool IsDefault => true;

        public bool Evaluate(CommandArgument[] arguments)
        {
            return !(arguments?.Any() ?? false);
        }

        public void Run(CommandArgument[] arguments)
        {
            Console.WriteLine($"GUID: {System.Guid.NewGuid()}");
        }
    }
}
