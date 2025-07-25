namespace Core.Engine.Proc
{
public interface IProcess
{
    public string Name { get; }
    public void Initialize();
    public void Start();
    public void Tick();
    public void Shutdown();
}
}
