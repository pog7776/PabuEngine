using System.Numerics;

using Core.Engine;
using Core.Engine.Proc;

using GameEngine.Sandbox;

namespace GameEngine.Engine
{
public class GameProcess(string name) : Process(name)
{
    private FeatureSandbox _sandbox;

    /// <inheritdoc />
    public override void Start()
    {
        base.Start();

        _sandbox = new FeatureSandbox("Testing");
    }

    /// <inheritdoc />
    public override void Tick()
    {
        base.Tick();
        Console.WriteLine($"Game Process Ticked: {Name} {DateTime.Now}");
        Console.WriteLine("\nPress Q to quit.");
        ConsoleKeyInfo key = Console.ReadKey();

        if(key.Key == ConsoleKey.Q)
        {
            Console.WriteLine("");
            ProcessHost.Instance.Stop();
        }
    }
}
}
