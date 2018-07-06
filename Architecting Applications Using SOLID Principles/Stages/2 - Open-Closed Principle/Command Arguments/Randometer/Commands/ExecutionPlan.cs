namespace Randometer.Commands
{
    public abstract class ExecutionPlan
    {
        public bool IsDefault { get; protected set; }

        public abstract bool Evaluate(CommandArgument[] arguments);

        public abstract void Run(CommandArgument[] arguments);
    }
}
