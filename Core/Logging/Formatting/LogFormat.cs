namespace Core.Logging.Formatting
{
public delegate string LogFormat(LogInfo logInfo);

public static class LogFormats
{
    public static string Default(LogInfo logInfo)
    {
        return $"[{DateTime.Now:HH:mm:ss}] {logInfo.Owner} :: {logInfo.LogLevel} | {logInfo.Message}";
    }
}
}
