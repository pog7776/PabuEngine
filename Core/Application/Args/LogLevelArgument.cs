using Core.Logging;

namespace Core.Application.Args
{
public class LogLevelArgument : CommandLineArgument
{
    /// <inheritdoc />
    public override string[] Flags => ["-loglevel", "-l"];

    /// <inheritdoc />
    public override bool HasValue => true;

    /// <inheritdoc />
    public override string HelpMessage => $"[ -loglevel, -l ] Valid: (0-8) [See {nameof(LogLevel)}]";

    /// <inheritdoc />
    public override bool ProcessArguments(string[] args)
    {
        if(! TryGetValue(args, out string value)) { return false; }

        if(! int.TryParse(value, out int intValue))
        {
            OnFailure();
            return false;
        }

        if(intValue > Enum.GetValues<LogLevel>().Length - 1)
        {
            OnFailure();
            return false;
        }

        LogManager.Instance.LogLevel = (LogLevel) intValue;
        Logger.Log($"Setting loglevel: {LogManager.Instance.LogLevel} ({value})", LogLevel.Debug);

        return true;
    }
}
}
