namespace Core.Vector
{
[Obsolete("Use System.Numerics.Vector3 instead")]
public class Vector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3() { }
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static implicit operator Vector2(Vector3 vector) => new() { X = vector.X, Y = vector.Y };
}
}
