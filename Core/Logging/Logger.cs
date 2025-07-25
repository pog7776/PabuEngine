namespace Core.Logging
{
public class Logger(string loggerName) : ILogger
{
    public string Name { get; set; } = loggerName;

    public event Action<LogInfo>? PreLog;
    public event Action<LogInfo>? PostLog;

    /// <inheritdoc />
    public virtual LogInfo Log(string message, LogLevel level = LogLevel.Information)
    {
        LogInfo log = PrepareLog(message, level);

        PreLog?.Invoke(log);
        LogManager.Instance.RouteLog(log);
        PostLog?.Invoke(log);

        return log;
    }

    public virtual LogInfo LogWarning(string message) => Log(message, LogLevel.Warning);
    public virtual LogInfo LogError(string message) => Log(message, LogLevel.Error);

    protected virtual LogInfo PrepareLog(string message, LogLevel level)
    {
        return new LogInfo { Message = message, LogLevel = level, Owner = Name };
    }
}
}
