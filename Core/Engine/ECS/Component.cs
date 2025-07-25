namespace Core.Engine
{
public abstract class Component(string name, Entity entity) : Object(name)
{
    public Entity Entity { get; } = entity;
}
}
