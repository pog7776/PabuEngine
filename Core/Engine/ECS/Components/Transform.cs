using System.Numerics;

namespace Core.Engine.Components
{
public class Transform(Entity entity) : Component(nameof(Transform), entity)
{
    public Vector3 Position { get; set; } = Vector3.Zero;
    public Quaternion Rotation { get; set; } = Quaternion.Identity;
    public Vector3 Scale { get; set; } = Vector3.One;
}
}
