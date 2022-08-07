using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CuberiteClr.Sdk.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Vector3f : IEquatable<Vector3f>, IFormattable
{
	public readonly float X, Y, Z;

	public static Vector3f Zero { get; } = new(0, 0, 0);

	public static Vector3f One { get; } = new(1, 1, 1);

	public Vector3f(float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f Add(Vector3f left, Vector3f right)
	{
		return left + right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f Subtract(Vector3f left, Vector3f right)
	{
		return left - right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f Multiply(Vector3f left, Vector3f right)
	{
		return left * right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f Divide(Vector3f left, Vector3f right)
	{
		return left / right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f operator +(Vector3f left, Vector3f right)
	{
		return new Vector3f(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f operator -(Vector3f left, Vector3f right)
	{
		return new Vector3f(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f operator *(Vector3f left, Vector3f right)
	{
		return new Vector3f(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f operator /(Vector3f left, Vector3f right)
	{
		return new Vector3f(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Vector3f left, Vector3f right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Vector3f left, Vector3f right)
	{
		return !(left == right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3f operator -(Vector3f value)
	{
		return Zero - value;
	}

	public Vector3f Round()
	{
		return new Vector3f(MathF.Round(X), MathF.Round(Y), MathF.Round(Z));
	}

	public Vector3i ToVector3i()
	{
		return new Vector3i((int) X, (int) Y, (int) Z);
	}

	public Vector3d ToVector3d()
	{
		return new Vector3d(X, Y, Z);
	}

	public bool Equals(Vector3f other)
	{
		return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
	}

	public override bool Equals(object? obj)
	{
		return obj is Vector3f other && Equals(other);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y, Z);
	}

	public override string ToString()
	{
		return $"[{X};{Y};{Z}]";
	}

	public string ToString(string? format, IFormatProvider? formatProvider)
	{
		//TODO
		return ToString();
	}
}
