using System;

namespace Randometer.Commands
{
    public class GuidCommand
    {
        /// <summary>
        ///     Generates a random GUID and outputs it to the console.
        /// </summary>
        public static void Execute(string[] arguments)
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
    }
}
