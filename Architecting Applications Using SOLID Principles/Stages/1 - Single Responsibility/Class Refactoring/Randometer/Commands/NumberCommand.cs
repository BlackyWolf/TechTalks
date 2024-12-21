using System;
using System.Text.RegularExpressions;

namespace Randometer.Commands
{
    public class NumberCommand
    {
        /// <summary>
        ///     Generates a random number and outputs it to the console.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments to use for generating the number.
        /// </param>
        public static void Execute(string[] arguments)
        {
            // If there are only two arguments and the second argument is the --help argument,
            // display help information for the command
            if (arguments.Length == 2 && arguments[1] == "--help")
            {
                PrintHelpDocs();

                return;
            }

            if (!HasValidArguments(arguments)) return;

            // Set the min and max nullable variables since we may have one, both,
            // or neither of them
            int? min = null;
            int? max = null;

            // If the user is using the --min and --max arguments
            if (arguments.Length == 5)
            {
                GetMinAndMaxValues(arguments, out min, out max);
            }

            // If the user is only using the max argument
            if (arguments.Length == 3)
            {
                GetMaxValue(arguments, out max);
            }

            // If the min and max values are valid
            if (!HasValidMinAndMaxValues(min.Value, max.Value))
            {
                return;
            }

            int number = GetRandomNumber(min, max);

            Console.WriteLine($"Number #: {number}");
        }

        /// <summary>
        ///     Gets the max value from the passed arguments.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used to get the max value.
        /// </param>
        /// <param name="max">The maximum random bound, if any.</param>
        private static void GetMaxValue(string[] arguments, out int? max)
        {
            var arg1 = arguments[1];
            var arg2 = arguments[2];

            int.TryParse(arg2, out var maxValue);

            max = maxValue;
        }

        /// <summary>
        ///     Gets the min and max values from the passed arguments.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used to get the min and max values.
        /// </param>
        /// <param name="min">The minimum random bound, if any.</param>
        /// <param name="max">The maximum random bound, if any.</param>
        private static void GetMinAndMaxValues(string[] arguments, out int? min, out int? max)
        {
            // Initialize out variables
            min = null;
            max = null;

            var arg1 = arguments[1];
            var arg2 = arguments[2];
            var arg3 = arguments[3];
            var arg4 = arguments[4];

            if (arg1 == "--min")
            {
                int.TryParse(arg2, out var minValue);

                min = minValue;
            }
            else if (arg3 == "--min")
            {
                int.TryParse(arg4, out var minValue);

                min = minValue;
            }

            if (arg1 == "--max")
            {
                int.TryParse(arg2, out var maxValue);

                max = maxValue;
            }
            else if (arg3 == "--max")
            {
                int.TryParse(arg4, out var maxValue);

                max = maxValue;
            }
        }

        /// <summary>
        ///     Gets the random number.
        /// </summary>
        /// <param name="min">The minimum random bound, if any.</param>
        /// <param name="max">The maximum random bound, if any.</param>
        /// <returns>A random integer value.</returns>
        private static int GetRandomNumber(int? min, int? max)
        {
            // Since the maximum bound for Random.Next() is exclusive,
            // we'll increment the max value to include what the number the
            // user set as the max random number boundary.
            if (max.HasValue) max++;

            // If the user gave a valid min and max value
            if (min.HasValue && max.HasValue)
            {
                var random = new Random();

                return random.Next(min.Value, max.Value);
            }
            // If the user only gave the max value
            else if (max.HasValue)
            {
                var random = new Random();

                return random.Next(max.Value);
            }
            else
            {
                var random = new Random();

                return random.Next();
            }
        }

        /// <summary>
        ///     Determines if valid arguments have been passed to the
        ///     method.
        /// </summary>
        /// <param name="arguments">Arguments to check the validity of.</param>
        /// <returns>
        ///     True if arguments are valid, false otherwise.
        /// </returns>
        private static bool HasValidArguments(string[] arguments)
        {
            // Including the command, we only allow more two arguments and their respective values
            // If this number is not correct then exit
            if (arguments.Length > 5 || arguments.Length == 4)
            {
                Console.WriteLine("Invalid arguments. Use 'rdm number --help' to view all available options.");

                return false;
            }

            // If the user is using the --min and --max arguments
            if (arguments.Length == 5)
            {
                var arg1 = arguments[1];
                var arg2 = arguments[2];
                var arg3 = arguments[3];
                var arg4 = arguments[4];

                // If the first and second arguments are not min or max
                if (arg1 != "--min" && arg1 != "--max" && arg3 != "--min" && arg3 != "--max")
                {
                    Console.WriteLine("Invalid arguments. Use 'rdm number --help' to view all available options.");

                    return false;
                }

                // If min is used without max
                if (arg1 == "--min" && arg3 != "--max" || arg3 == "--min" && arg1 != "--max")
                {
                    Console.WriteLine("If --min is used --max is required.");

                    return false;
                }

                // If the arguments used for min and max are not numbers
                if (!Regex.IsMatch(arg2, @"^\d*$") || !Regex.IsMatch(arg4, @"^\d*$"))
                {
                    Console.WriteLine("Please remove all invalid characters from the number, such as commas and dashes. Only digits are allowed.");

                    return false;
                }

                if (arg1 == "--min")
                {
                    // If the min argument is a valid integer
                    if (!int.TryParse(arg2, out _))
                    {
                        Console.WriteLine("The --min argument must be a valid integer.");

                        return false;
                    }
                }
                else if (arg3 == "--min")
                {
                    // If the min argument is a valid integer
                    if (!int.TryParse(arg4, out _))
                    {
                        Console.WriteLine("The --min argument must be a valid integer.");

                        return false;
                    }
                }

                if (arg1 == "--max")
                {
                    // If the max argument is a valid integer
                    if (!int.TryParse(arg2, out var maxValue))
                    {
                        Console.WriteLine("The --max argument must be a valid integer.");

                        return false;
                    }
                }
                else if (arg3 == "--max")
                {
                    // If the max argument is a valid integer
                    if (!int.TryParse(arg4, out var maxValue))
                    {
                        Console.WriteLine("The --max argument must be a valid integer.");

                        return false;
                    }
                }
            }

            // If the user is only using the max argument
            if (arguments.Length == 3)
            {
                var arg1 = arguments[1];
                var arg2 = arguments[2];

                // If min is given but max is not
                if (arg1 == "--min")
                {
                    Console.WriteLine("If --min is used --max is required.");

                    return false;
                }

                // If the first argument is not max
                if (arg1 != "--max")
                {
                    Console.WriteLine("Invalid arguments. Use 'rdm number --help' to view all available options.");

                    return false;
                }

                // If the max argument value is not a number
                if (!Regex.IsMatch(arg2, @"^\d*$"))
                {
                    Console.WriteLine("Please remove all invalid characters from the number, such as commas and dashes. Only digits are allowed.");

                    return false;
                }

                // If the max argument is a valid integer
                if (!int.TryParse(arg2, out var maxValue))
                {
                    Console.WriteLine("The --max argument must be a valid integer.");

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines if the max and min values are valid.
        /// </summary>
        /// <param name="min">The minimum random bound, if any.</param>
        /// <param name="max">The maximum random bound, if any.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool HasValidMinAndMaxValues(int? min, int? max)
        {
            var invalidBounds = min.HasValue && max.HasValue && min > max;

            // If min is greater than max
            if (invalidBounds)
            {
                Console.WriteLine("The max value must be greater than the min value.");
            }

            return !invalidBounds;
        }

        /// <summary>
        ///     Prints help information for the command to the console.
        /// </summary>
        private static void PrintHelpDocs()
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

            return;
        }
    }
}
