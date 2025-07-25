using Core.Logging;

namespace Core.Engine
{
public abstract class Object(string name)
{
    public string Name { get; set; } = name;

    protected static Logger Logger { get; } = new("OBJECT");
}
}
