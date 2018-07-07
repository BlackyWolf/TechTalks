using System;
using System.Linq;

namespace Randometer.Commands.Number
{
    public class DefaultPlan : IExecutionPlan
    {
        public bool IsDefault => true;

        public bool Evaluate(CommandArgument[] arguments)
         => !(arguments?.Any() ?? false);

        public void Run(CommandArgument[] arguments)
        {
            var random = new Random();

            int number = random.Next();

            Console.WriteLine($"Number #: {number}");
        }
    }
}
