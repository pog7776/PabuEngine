namespace Core.Logging
{
public interface ILogger
{
    public string Name { get; }
    public LogInfo Log(string message, LogLevel level);
}
}
