namespace Randometer.Commands.Services
{
    public interface IEvaluate<TData>
    {
        bool Evaluate(TData data);
    }
}
