using System;

namespace Randometer.Commands.Guid
{
    public class HelpPlan : IExecutionPlan
    {
        public bool IsDefault => true;

        public bool Evaluate(CommandArgument[] arguments)
            => arguments?.Length == 1 && arguments[0].Name == "--help";

        public void Run(CommandArgument[] arguments)
        {
            Console.WriteLine("Usage: rdm guid");
            Console.WriteLine("\r\nExample:");
            Console.WriteLine("  rdm guid");
            Console.WriteLine("Output:");
            Console.WriteLine($"  GUID: {System.Guid.NewGuid()}");
        }
    }
}
