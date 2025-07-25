using System.Numerics;

namespace Core.Engine.Components
{
public class Transform(Entity entity) : Component(nameof(Transform), entity)
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 Scale { get; set; }
}
}
