using System;
using System.Linq;

namespace Randometer.Commands.Number
{
    public class DefaultPlan : ExecutionPlan
    {
        public DefaultPlan() => IsDefault = true;

        public override bool Evaluate(CommandArgument[] arguments)
         => !(arguments?.Any() ?? false);

        public override void Run(CommandArgument[] arguments)
        {
            var random = new Random();

            int number = random.Next();

            Console.WriteLine($"Number #: {number}");
        }
    }
}
