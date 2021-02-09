namespace Stonksy.Api.Framework.Infrastructure.Logging
{
    public class SerilogOptions
    {
        public bool ConsoleEnabled { get; init; } = true;
        public string MinimumLevel { get; init; } = "Information";
        public string Format { get; init; } = "compact";
    }
}