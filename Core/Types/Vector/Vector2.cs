namespace Core.Vector
{
[Obsolete("Use System.Numerics.Vector2 instead")]
public class Vector2
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vector2() { }
    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static implicit operator Vector3(Vector2 vector) => new() { X = vector.X, Y = vector.Y };
}
}
