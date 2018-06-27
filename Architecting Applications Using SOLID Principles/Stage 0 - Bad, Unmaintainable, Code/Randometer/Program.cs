using System;

namespace Randometer
{
    class Program
    {
        static void Main(string[] arguments)
        {
            string command;

            if (arguments == null || arguments.Length == 0)
            {
                command = "help";
            }
            else
            {
                command = arguments[0];
            }

            switch (command)
            {
                case "help":
                    Console.WriteLine("Usage: rdm [command]");
                    Console.WriteLine("  help          Displays a list of the available commands with their descriptions.");
                    Console.WriteLine("  number        Generates a random number.");
                    Console.WriteLine("  guid          Generates a random Globally Unique Identifier (GUID).");
                    Console.WriteLine("\r\n  Use rdm [command] --help for more information about a command.");
                    break;
                case "number":
                    var random = new Random();

                    if (arguments.Length == 3)
                    {
                        var argument = arguments[1];


                    }

                    var number = random.Next();

                    Console.Write("Number #: ");



                    break;
            }
        }
    }
}
