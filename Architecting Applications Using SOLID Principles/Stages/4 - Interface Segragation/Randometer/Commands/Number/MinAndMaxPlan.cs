using System;
using System.Text.RegularExpressions;

namespace Randometer.Commands.Number
{
    public class MinAndMaxPlan : IExecutionPlan
    {
        public bool IsDefault => false;

        public bool Evaluate(CommandArgument[] arguments)
        {
            // If the number of arguments for this plan isn't correct
            if (arguments.Length != 2) return false;

            var arg1 = arguments[0];
            var arg2 = arguments[1];

            // If the min and max arguments weren't used
            if (arg1.Name != "--min" && arg1.Name != "--max" && arg2.Name != "--min" && arg2.Name != "--max")
            {
                return false;
            }

            // If the min argument was used without the max argument
            if (arg1.Name == "--min" && arg2.Name != "--max" || arg2.Name == "--min" && arg1.Name != "--max")
            {
                return false;
            }

            // If anything other than numbers were used for the min and max bounds
            if (!Regex.IsMatch(arg1.Value, @"^\d*$") || !Regex.IsMatch(arg2.Value, @"^\d*$"))
            {
                return false;
            }

            // The first argument's value isn't a valid integer
            if (!int.TryParse(arg1.Value, out _))
            {
                return false;
            }

            // If the second arguments value isn't an integer
            if (!int.TryParse(arg2.Value, out _))
            {
                return false;
            }

            return true;
        }

        public void Run(CommandArgument[] arguments)
        {
            // Initialize out variables
            int min = 0;
            int max = 0;

            var arg1 = arguments[0];
            var arg2 = arguments[1];

            if (arg1.Name == "--min")
            {
                int.TryParse(arg1.Value, out min);
            }
            else if (arg2.Name == "--min")
            {
                int.TryParse(arg2.Value, out min);
            }

            if (arg1.Name == "--max")
            {
                int.TryParse(arg1.Value, out max);
            }
            else if (arg2.Name == "--max")
            {
                int.TryParse(arg2.Value, out max);
            }

            // If min is greater than max
            if (min > max)
            {
                Console.WriteLine("The max value must be greater than the min value.");

                return;
            }

            max++;

            var random = new Random();

            int number = random.Next(min, max);

            Console.WriteLine($"Number #: {number}");
        }
    }
}
