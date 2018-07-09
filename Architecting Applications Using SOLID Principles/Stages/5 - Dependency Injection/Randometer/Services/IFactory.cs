namespace Randometer.Commands.Services
{
    public interface IFactory<in TKey, out TService>
    {
        TService this[TKey key] { get; }
    }
}
