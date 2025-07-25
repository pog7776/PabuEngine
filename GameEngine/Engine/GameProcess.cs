using Core.Engine.Proc;

namespace GameEngine.Engine
{
public class GameProcess(string name) : Process(name)
{
    /// <inheritdoc />
    public override void Tick()
    {
        base.Tick();
        Console.WriteLine($"Game Process Ticked: {Name} {DateTime.Now}");
        //Console.WriteLine("");
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
