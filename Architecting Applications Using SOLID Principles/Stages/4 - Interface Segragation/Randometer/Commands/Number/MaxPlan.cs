using System;
using System.Text.RegularExpressions;

namespace Randometer.Commands.Number
{
    public class MaxPlan : IExecutionPlan
    {
        public bool IsDefault => false;

        public bool Evaluate(CommandArgument[] arguments)
        {
            if (arguments.Length != 1) return false;

            var arg1 = arguments[0];

            // If min is given but max is not
            if (arg1.Name == "--min") return false;

            // If the first argument is not max
            if (arg1.Name != "--max") return false;

            // If the max argument value is not a number
            if (!Regex.IsMatch(arg1.Value, @"^\d*$")) return false;

            // If the max argument is not a valid integer
            if (!int.TryParse(arg1.Value, out var maxValue)) return false;

            return true;
        }

        public void Run(CommandArgument[] arguments)
        {
            var arg1 = arguments[0];

            int.TryParse(arg1.Value, out var max);

            max++;

            var random = new Random();

            int number = random.Next(max);

            Console.WriteLine($"Number #: {number}");
        }
    }
}
