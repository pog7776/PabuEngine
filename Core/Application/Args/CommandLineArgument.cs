using Core.Logging;

namespace Core.Application.Args
{
public abstract class CommandLineArgument
{
    public abstract string[] Flags { get; }
    public abstract bool HasValue { get; }
    public abstract string HelpMessage { get; }

    protected static Logger Logger { get; } = new("COMMAND_LINE_ARGUMENT");

    /// <summary>
    /// Action to take if expected argument is present.
    /// </summary>
    /// <param name="args">Provided command line args</param>
    /// <returns>True if process is successful</returns>
    public abstract bool ProcessArguments(string[] args);

    protected virtual void OnFailure(LogLevel logLevel = LogLevel.Warning) { Logger.Log(HelpMessage, logLevel); }

    public bool FlagPresent(string[] args, out int index)
    {
        for(index = 0; index < args.Length; index++)
        {
            string part = args[index];

            if(Flags.Contains(part)) { return true; }
        }

        index = 0;
        return false;
    }

    public bool FlagPresent(string[] args) => FlagPresent(args, out _);

    public string GetValue(string[] args)
    {
        if(! HasValue) { return ""; }

        bool flagPresent = FlagPresent(args, out int index);

        if(index + 1 >= args.Length) { return ""; }

        return flagPresent ? args[index + 1] : "";
    }

    public bool TryGetValue(string[] args, out string value)
    {
        return ! string.IsNullOrEmpty(value = GetValue(args));
    }
}
}
