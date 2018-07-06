namespace Randometer.Commands
{
    public class CommandArgument
    {
        public bool HasValue => !string.IsNullOrWhiteSpace(Value);

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
