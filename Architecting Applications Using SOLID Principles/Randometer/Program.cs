using System;
using System.Text.RegularExpressions;

namespace Randometer
{
    class Program
    {
        static void Main(string[] arguments)
        {
            string command;

            // If no arguments given, go ahead and show the help information
            if (arguments == null || arguments.Length == 0)
            {
                command = "help";
            }
            // Else assume the first argument is the command to execute
            else
            {
                command = arguments[0];
            }

            switch (command)
            {
                case "guid":
                    // Write a random guid to the console
                    Console.WriteLine($"GUID: {Guid.NewGuid()}");

                    break;
                case "help":
                    // Display help information
                    Console.WriteLine("Usage: rdm <command>");
                    Console.WriteLine("  help          Displays a list of the available commands with their descriptions.");
                    Console.WriteLine("  number        Generates a random number.");
                    Console.WriteLine("  guid          Generates a random Globally Unique Identifier (GUID).");
                    Console.WriteLine("\r\n  Use rdm [command] --help for more information about a command.");

                    break;
                case "number":
                    // Including the command, we only allow more two arguments and their respective values
                    // If this number is not correct then exit
                    if (arguments.Length > 5 || arguments.Length == 4)
                    {
                        Console.WriteLine("Invalid arguments. Use 'rdm number --help' to view all available options.");

                        break;
                    }

                    // If there are only two arguments
                    if (arguments.Length == 2)
                    {
                        // If the second argument is the --help argument, display help information for the command
                        if (arguments[1] == "--help")
                        {
                            Console.WriteLine("Usage: rdm number [<arguments>]");
                            Console.WriteLine("Arguments:");
                            Console.WriteLine("  --max <number>          Sets the upper, inclusive, bound of the random number that can be generated.");
                            Console.WriteLine("                          Only whole numbers (integers) are allowed. If --min is not used, the");
                            Console.WriteLine("                          lower boundary is 0.");
                            Console.WriteLine("  --min <number>          Sets the lower, inclusive, bound of the random number that can be generated.");
                            Console.WriteLine("                          Only whole numbers (integers) are allowed. If --min is used then");
                            Console.WriteLine("                          --max must also be specified.");
                        }

                        break;
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

                        // If the first and second arguments are not min or max
                        if (arg1 != "--min" && arg1 != "--max" && arg3 != "--min" && arg3 != "--max")
                        {
                            Console.WriteLine("Invalid arguments. Use 'rdm number --help' to view all available options.");

                            break;
                        }

                        // If min is used without max
                        if (arg1 == "--min" && arg3 != "--max" || arg3 == "--min" && arg1 != "--max")
                        {
                            Console.WriteLine("If --min is used --max is required.");

                            break;
                        }

                        // If the arguments used for min and max are not numbers
                        if (!Regex.IsMatch(arg2, @"^\d*$") || !Regex.IsMatch(arg4, @"^\d*$"))
                        {
                            Console.WriteLine("Please remove all invalid characters from the number, such as commas and dashes. Only digits are allowed.");

                            break;
                        }

                        if (arg1 == "--min")
                        {
                            // If the min argument is a valid integer
                            if (int.TryParse(arg2, out var minValue))
                            {
                                min = minValue;
                            }
                            else
                            {
                                Console.WriteLine("The --min argument must be a valid integer.");

                                break;
                            }
                        }
                        else if (arg3 == "--min")
                        {
                            // If the min argument is a valid integer
                            if (int.TryParse(arg4, out var minValue))
                            {
                                min = minValue;
                            }
                            else
                            {
                                Console.WriteLine("The --min argument must be a valid integer.");

                                break;
                            }
                        }

                        if (arg1 == "--max")
                        {
                            // If the max argument is a valid integer
                            if (int.TryParse(arg2, out var maxValue))
                            {
                                max = maxValue;
                            }
                            else
                            {
                                Console.WriteLine("The --max argument must be a valid integer.");

                                break;
                            }
                        }
                        else if (arg3 == "--max")
                        {
                            // If the max argument is a valid integer
                            if (int.TryParse(arg4, out var maxValue))
                            {
                                max = maxValue;
                            }
                            else
                            {
                                Console.WriteLine("The --max argument must be a valid integer.");

                                break;
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

                            break;
                        }

                        // If the first argument is not max
                        if (arg1 != "--max")
                        {
                            Console.WriteLine("Invalid arguments. Use 'rdm number --help' to view all available options.");

                            break;
                        }

                        // If the max argument value is not a number
                        if (!Regex.IsMatch(arg2, @"^\d*$"))
                        {
                            Console.WriteLine("Please remove all invalid characters from the number, such as commas and dashes. Only digits are allowed.");

                            break;
                        }

                        // If the max argument is a valid integer
                        if (int.TryParse(arg2, out var maxValue))
                        {
                            max = maxValue;
                        }
                        else
                        {
                            Console.WriteLine("The --max argument must be a valid integer.");

                            break;
                        }
                    }

                    max++;

                    int number;

                    // If the user gave a valid min and max value
                    if (min.HasValue && max.HasValue)
                    {
                        // If min is greater than max
                        if (min > max)
                        {
                            Console.WriteLine("The max value must be greater than the min value.");

                            break;
                        }

                        var random = new Random();

                        number = random.Next(min.Value, max.Value);
                    }
                    // If the user only gave the max value
                    else if (max.HasValue)
                    {
                        var random = new Random();

                        number = random.Next(max.Value);
                    }
                    else
                    {
                        var random = new Random();

                        number = random.Next();
                    }

                    Console.WriteLine($"Number #: {number}");

                    break;
                default:
                    Console.Write("Invalid command. Enter help to see a list of available commands.");

                    break;
            }
        }
    }
}
