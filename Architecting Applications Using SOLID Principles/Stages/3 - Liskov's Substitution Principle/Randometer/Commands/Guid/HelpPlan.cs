using System;

namespace Randometer.Commands.Guid
{
    public class HelpPlan : ExecutionPlan
    {
        public override bool Evaluate(CommandArgument[] arguments)
            => arguments?.Length == 1 && arguments[0].Name == "--help";

        public override void Run(CommandArgument[] arguments)
        {
            Console.WriteLine("Usage: rdm guid");
            Console.WriteLine("\r\nExample:");
            Console.WriteLine("  rdm guid");
            Console.WriteLine("Output:");
            Console.WriteLine($"  GUID: {System.Guid.NewGuid()}");
        }
    }
}
