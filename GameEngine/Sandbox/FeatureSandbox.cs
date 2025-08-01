using System.Numerics;

using Core.Engine;
using Core.Logging;

namespace GameEngine.Sandbox
{
public class FeatureSandbox : Entity
{
    /// <inheritdoc />
    public FeatureSandbox(string name) : base(name)
    {
        Entity entity = new("Dude!");

        PrintEntity(entity);

        entity.Transform.Position = new Vector3(100, 1, 5);
        entity.Transform.Scale = Vector3.E;
        entity.Transform.Rotation = Quaternion.Inverse(entity.Transform.Rotation);

        entity.RemoveComponent(entity.Transform);

        PrintEntity(entity);
    }

    private void PrintEntity(Entity entity)
    {
        Vector3 transformPosition = entity.Transform.Position;
        Vector3 transformScale = entity.Transform.Scale;
        Quaternion transformRotation = entity.Transform.Rotation;

        Logger.Log($"{nameof(transformPosition)}: {transformPosition}");
        Logger.Log($"{nameof(transformScale)}: {transformScale}");
        Logger.Log($"{nameof(transformRotation)}: {transformRotation}");
    }
}
}
