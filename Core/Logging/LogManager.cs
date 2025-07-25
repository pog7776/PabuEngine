namespace Core.Logging
{
public class LogManager
{
    private static LogManager? s_instance;
    public static LogManager Instance => s_instance ??= new LogManager();

    public event Action<LogInfo>? PreLog;
    public event Action<LogInfo>? PostLog;

    public LogMethod LogMethod { get; set; } = Console.WriteLine;

    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    public virtual void RouteLog(LogInfo logInfo)
    {
        if(logInfo.LogLevel < LogLevel) { return; }

        PreLog?.Invoke(logInfo);
        logInfo.Log(LogMethod);
        PostLog?.Invoke(logInfo);
    }
}
}
