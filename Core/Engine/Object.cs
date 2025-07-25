using Core.Logging;

namespace Core.Engine
{
public abstract class Object(string name)
{
    public string Name { get; set; } = name;

    protected Logger Logger { get; } = new($"{nameof(Object)}:{name}");
}
}
