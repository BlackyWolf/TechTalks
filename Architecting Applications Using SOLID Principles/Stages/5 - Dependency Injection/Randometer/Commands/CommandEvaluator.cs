using Randometer.Commands.Services;

namespace Randometer.Commands
{
    public class CommandEvaluator : IEvaluate<string[]>
    {
        public bool Evaluate(string[] data)
        {
            return data == null || data.Length == 0;
        }
    }
}
