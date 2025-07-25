namespace Core.Vector
{
public class Vector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public static implicit operator Vector2(Vector3 vector) => new() { X = vector.X, Y = vector.Y };
}
}
