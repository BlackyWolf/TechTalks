using System;
using System.Collections.Generic;

namespace Randometer.Commands.Extensions
{
    /// <summary>
    ///     Convenient extensions to use on strings for commands and arguments.
    /// </summary>
    public static class StringExtensions
    {
        public static IEnumerable<CommandArgument> ToArguments(this string[] arguments, string commandName)
        {
            if (arguments == null || arguments.Length < 1) yield break;

            for (int i = 0, totalLength = arguments.Length; i < totalLength; i++)
            {
                var argument = arguments[i]?.Trim();
                var nextIndex = i + 1;
                var previousIndex = i - 1;

                if (string.IsNullOrWhiteSpace(argument)
                    || argument == commandName
                    || (previousIndex > 0 && arguments[previousIndex].StartsWith("--")))
                {
                    continue;
                }

                if (argument.StartsWith("--"))
                {
                    var commandArgument = new CommandArgument
                    {
                        Name = argument
                    };

                    if (nextIndex < totalLength && !arguments[nextIndex].StartsWith("--"))
                    {
                        commandArgument.Value = arguments[nextIndex];
                    }

                    yield return commandArgument;
                }
            }
        }
    }
}
