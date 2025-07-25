using Core.Logging.Formatting;

namespace Core.Logging
{
public class LogInfo
{
    public required string Message { get; init; }
    public LogLevel LogLevel { get; init; } = LogLevel.Information;
    public required string Owner { get; init; }
    public LogFormat Format { get; set; } = LogFormats.Default;

    public void Log(LogMethod logMethod) => logMethod(Format(this));
}
}
