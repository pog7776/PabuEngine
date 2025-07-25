namespace Core.Vector
{
public class Vector2
{
    public float X { get; set; }
    public float Y { get; set; }

    public static implicit operator Vector3(Vector2 vector) => new() { X = vector.X, Y = vector.Y };
}
}
