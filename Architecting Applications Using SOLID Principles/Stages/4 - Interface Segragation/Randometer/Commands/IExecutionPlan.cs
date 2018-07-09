using Randometer.Commands.Services;

namespace Randometer.Commands
{
    public interface IExecutionPlan : IEvaluate<CommandArgument[]>
    {
        bool IsDefault { get; }

        void Run(CommandArgument[] arguments);
    }
}
