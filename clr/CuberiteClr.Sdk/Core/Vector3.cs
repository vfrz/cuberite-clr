using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CuberiteClr.Sdk.Core;

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
	public double Length()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public double LengthSquared()
	{
		return X * X + Y * Y + Z * Z;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Distance(Vector3 vector1, Vector3 vector2)
	{
		var dx = vector1.X - vector2.X;
		var dy = vector1.Y - vector2.Y;
		var dz = vector1.Z - vector2.Z;

		return Math.Sqrt(dx * dx + dy * dy + dz * dz);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double DistanceSquared(Vector3 vector1, Vector3 vector2)
	{
		var dx = vector1.X - vector2.X;
		var dy = vector1.Y - vector2.Y;
		var dz = vector1.Z - vector2.Z;

		return dx * dx + dy * dy + dz * dz;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d Normalize(Vector3 vector)
	{
		var ls = vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z;
		var length = Math.Sqrt(ls);
		return new Vector3d(vector.X / length, vector.Y / length, vector.Z / length);
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
