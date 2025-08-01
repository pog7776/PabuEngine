using Core.Engine.Components;
using Core.Logging;

namespace Core.Engine
{
public class Entity : Object
{
    private readonly List<Component> _components = [];
    private IReadOnlyList<Component> Components => _components;

    public Transform Transform { get; init; }

    public Entity(string name) : base(name)
    {
        Logger.Name = $"{nameof(Entity)}:{Name}";

        AddComponent(Transform = new Transform(this));
    }

    public void AddComponent(Component component)
    {
        Logger.Log($"Adding component: {component}", LogLevel.Debug);
        _components.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        Logger.Log($"Removing component: {component}", LogLevel.Debug);
        _components.Remove(component);
    }
}
}
