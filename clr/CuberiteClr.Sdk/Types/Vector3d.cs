using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CuberiteClr.Sdk.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Vector3d : IEquatable<Vector3d>, IFormattable
{
	public readonly double X, Y, Z;

	public static Vector3d Zero { get; } = new(0, 0, 0);

	public static Vector3d One { get; } = new(1, 1, 1);

	public Vector3d(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d Add(Vector3d left, Vector3d right)
	{
		return left + right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d Subtract(Vector3d left, Vector3d right)
	{
		return left - right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d Multiply(Vector3d left, Vector3d right)
	{
		return left * right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d Divide(Vector3d left, Vector3d right)
	{
		return left / right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d operator +(Vector3d left, Vector3d right)
	{
		return new Vector3d(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d operator -(Vector3d left, Vector3d right)
	{
		return new Vector3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d operator *(Vector3d left, Vector3d right)
	{
		return new Vector3d(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d operator /(Vector3d left, Vector3d right)
	{
		return new Vector3d(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Vector3d left, Vector3d right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Vector3d left, Vector3d right)
	{
		return !(left == right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d operator -(Vector3d value)
	{
		return Zero - value;
	}

	public Vector3d Round()
	{
		return new Vector3d(Math.Round(X), Math.Round(Y), Math.Round(Z));
	}

	public Vector3i ToVector3i()
	{
		return new Vector3i((int) X, (int) Y, (int) Z);
	}

	public bool Equals(Vector3d other)
	{
		return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
	}

	public override bool Equals(object? obj)
	{
		return obj is Vector3d other && Equals(other);
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
