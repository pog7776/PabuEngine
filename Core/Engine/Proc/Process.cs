using Core.Logging;

namespace Core.Engine.Proc
{
public abstract class Process(string name) : IProcess
{
    public string Name => name;
    public Logger Logger { get; protected set; } = new("PROCESS:" + name);

    /// <inheritdoc />
    public virtual void Initialize() => Logger.Log($"Initializing {Name}");

    /// <inheritdoc />
    public virtual void Start() => Logger.Log($"Starting {Name}");

    /// <inheritdoc />
    public virtual void Tick() { }

    /// <inheritdoc />
    public virtual void Shutdown() => Logger.Log($"Shutting down {Name}");
}
}
