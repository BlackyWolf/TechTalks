using System;

namespace Randometer.Commands.Number
{
    public class HelpPlan : ExecutionPlan
    {
        public override bool Evaluate(CommandArgument[] arguments)
        {
            return arguments?.Length == 1 && arguments[0].Name == "--help";
        }

        public override void Run(CommandArgument[] arguments)
        {
            Console.WriteLine("Usage: rdm number [<arguments>]");
            Console.WriteLine("Arguments:");
            Console.WriteLine("  --max <number>          Sets the upper, inclusive, bound of the random number that can be generated.");
            Console.WriteLine("                          Only whole numbers (integers) are allowed. If --min is not used, the");
            Console.WriteLine("                          lower boundary is 0.");
            Console.WriteLine("  --min <number>          Sets the lower, inclusive, bound of the random number that can be generated.");
            Console.WriteLine("                          Only whole numbers (integers) are allowed. If --min is used then");
            Console.WriteLine("                          --max must also be specified.");
            Console.WriteLine("\r\nExample:");
            Console.WriteLine("  rdm number --min 1 --max 10");
            Console.WriteLine("Output:");
            Console.WriteLine("  Number #: 7");
        }
    }
}
