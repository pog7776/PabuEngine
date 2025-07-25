using Core.Application.Args;
using Core.Engine;
using Core.Engine.Proc;
using Core.Logging;

using GameEngine.Engine;

namespace GameEngine
{
internal static class Program
{
    private static Logger Logger { get; } = new("BOOTSTRAP");

    public static ProcessHost ProcessHost => ProcessHost.Instance;
    public static LogManager LogManager => LogManager.Instance;

    private static void Main(string[] args)
    {
        Logger.Log(Info.EngineInfo);
        Logger.Log($"Start Time: {DateTime.Now}");

        ProcessArgs(args);

        GameProcess gameProcess = new(nameof(GameProcess));

        ProcessHost.RegisterProcess(gameProcess);
        ProcessHost.Start(TickCallback);
    }

    private static void ProcessArgs(string[] args)
    {
        LogLevelArgument logLevel = new();
        logLevel.ProcessArguments(args);
    }

    private static void TickCallback() { }
}
}
