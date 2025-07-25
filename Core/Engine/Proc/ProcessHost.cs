using Core.Logging;

namespace Core.Engine.Proc
{
public class ProcessHost
{
    private static ProcessHost? s_instance;
    public static ProcessHost Instance => s_instance ??= new ProcessHost();

    private Logger Logger { get; } = new("PROCESS_HOST");

    private readonly HashSet<IProcess> _processes = [];

    private bool _stop;

    public void RegisterProcess(IProcess process)
    {
        Logger.Log($"Registering {nameof(IProcess)}: {process.Name}", LogLevel.Debug);

        _processes.Add(process);
        process.Initialize();
    }

    public void RemoveProcess(IProcess process)
    {
        Logger.Log($"Removing {nameof(IProcess)}: {process.Name}", LogLevel.Debug);

        _processes.Remove(process);
        process.Shutdown();
    }

    public void Start(Action tickCallback)
    {
        Logger.Log($"Start {nameof(ProcessHost)}", LogLevel.Debug);

        _stop = false;

        StartProcesses(_processes);
        Loop(tickCallback);
        Cleanup();
    }

    public void Stop()
    {
        Logger.Log($"Request Stop {nameof(ProcessHost)}", LogLevel.Debug);
        _stop = true;
    }

    private void Loop(Action tickCallback)
    {
        Logger.Log($"Begin Loop {nameof(ProcessHost)}", LogLevel.Trace);

        while(! _stop)
        {
            TickProcesses(_processes);
            tickCallback.Invoke();
        }

        Logger.Log($"End Loop {nameof(ProcessHost)}", LogLevel.Trace);
    }

    private void Cleanup()
    {
        Logger.Log($"Cleanup {nameof(ProcessHost)}", LogLevel.Trace);

        ShutdownProcesses(_processes);
        _processes.Clear();
    }

    private static void StartProcesses(ICollection<IProcess> processes)
    {
        foreach(IProcess process in processes) { process.Start(); }
    }

    private static void TickProcesses(ICollection<IProcess> processes)
    {
        foreach(IProcess process in processes) { process.Tick(); }
    }

    private static void ShutdownProcesses(ICollection<IProcess> processes)
    {
        foreach(IProcess process in processes) { process.Shutdown(); }
    }
}
}
