using System;
using System.Text.RegularExpressions;

namespace Randometer
{
    /// <summary>
    ///     The entry class for running the application.
    /// </summary>
    class Program
    {
        /// <summary>
        ///     The entry method for running the application.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used for executing application commands.
        /// </param>
        static void Main(string[] arguments)
        {
            string command = GetCommand(arguments);

            switch (command)
            {
                case "guid":
                    GenerateGuid(arguments);

                    break;
                case "help":
                    GenerateHelpDocs();

                    break;
                case "number":
                    GenerateNumber(arguments);

                    break;
                default:
                    Console.Write("Invalid command. Enter help to see a list of available commands.");

                    break;
            }
        }

        /// <summary>
        ///     Generates help documentation about available commands.
        /// </summary>
        static void GenerateHelpDocs()
        {
            // Display help information
            Console.WriteLine("Usage: rdm <command>");
            Console.WriteLine("  help          Displays a list of the available commands with their descriptions.");
            Console.WriteLine("  number        Generates a random number.");
            Console.WriteLine("  guid          Generates a random Globally Unique Identifier (GUID).");
            Console.WriteLine("\r\n  Use rdm [command] --help for more information about a command.");
        }

        /// <summary>
        ///     Generates a random GUID and outputs it to the console.
        /// </summary>
        static void GenerateGuid(string[] arguments)
        {
            if (arguments.Length == 2 && arguments[1] == "--help")
            {
                Console.WriteLine("Usage: rdm guid");
                Console.WriteLine("\r\nExample:");
                Console.WriteLine("  rdm guid");
                Console.WriteLine("Output:");
                Console.WriteLine($"  GUID: {Guid.NewGuid()}");

                return;
            }

            Console.WriteLine($"GUID: {Guid.NewGuid()}");
        }

        /// <summary>
        ///     Generates a random number and outputs it to the console.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments to use for generating the number.
        /// </param>
        static void GenerateNumber(string[] arguments)
        {
            if (HasValidArguments()) return;

            // If there are only two arguments and the second argument is the --help argument,
            // display help information for the command
            if (arguments.Length == 2 && arguments[1] == "--help")
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

            // Set the min and max nullable variables since we may have one or neither of them
            int? min = null;
            int? max = null;

            // If the user is using the --min and --max arguments
            if (arguments.Length == 5)
            {
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

            // If the user is only using the max argument
            if (arguments.Length == 3)
            {
                var arg1 = arguments[1];
                var arg2 = arguments[2];

                int.TryParse(arg2, out var maxValue);

                max = maxValue;
            }

            if (!HasValidMinAndMaxValues()) return;

            if (max.HasValue) max++;

            int number = GetRandomNumber();

            Console.WriteLine($"Number #: {number}");

            /// <summary>
            ///     Gets the random number.
            /// </summary>
            /// <returns>A random integer value.</returns>
            int GetRandomNumber()
            {
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
            /// <returns>
            ///     True if arguments are valid, false otherwise.
            /// </returns>
            bool HasValidArguments()
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
            /// <returns>True if valid, false otherwise.</returns>
            bool HasValidMinAndMaxValues()
            {
                // If min is greater than max
                if (min.HasValue && max.HasValue && min > max)
                {
                    Console.WriteLine("The max value must be greater than the min value.");

                    return false;
                }

                return true;
            }
        }

        /// <summary>
        ///     Gets the command based off of the given arguments.
        /// </summary>
        /// <param name="arguments">
        ///     Arguments used for executing the console app.
        /// </param>
        /// <returns>The command name.</returns>
        static string GetCommand(string[] arguments)
        {
            // If no arguments given, go ahead and show the help information
            if (arguments == null || arguments.Length == 0)
            {
               return "help";
            }

            return arguments[0];
        }
    }
}
