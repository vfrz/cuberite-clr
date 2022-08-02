using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CuberiteClr.Sdk.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Vector3i : IEquatable<Vector3i>, IFormattable
{
	public readonly int X, Y, Z;

	public static Vector3i Zero { get; } = new(0, 0, 0);

	public static Vector3i One { get; } = new(1, 1, 1);

	public Vector3i(int x, int y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i Add(Vector3i left, Vector3i right)
	{
		return left + right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i Subtract(Vector3i left, Vector3i right)
	{
		return left - right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i Multiply(Vector3i left, Vector3i right)
	{
		return left * right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i Divide(Vector3i left, Vector3i right)
	{
		return left / right;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i operator +(Vector3i left, Vector3i right)
	{
		return new Vector3i(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i operator -(Vector3i left, Vector3i right)
	{
		return new Vector3i(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i operator *(Vector3i left, Vector3i right)
	{
		return new Vector3i(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i operator /(Vector3i left, Vector3i right)
	{
		return new Vector3i(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Vector3i left, Vector3i right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Vector3i left, Vector3i right)
	{
		return !(left == right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3i operator -(Vector3i value)
	{
		return Zero - value;
	}

	public bool Equals(Vector3i other)
	{
		return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
	}

	public override bool Equals(object? obj)
	{
		return obj is Vector3i other && Equals(other);
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
