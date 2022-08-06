using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Extensions;

internal static class IntPtrExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToStringAuto(this IntPtr ptr)
	{
		return ptr.IsNullPtr() ? null : Marshal.PtrToStringAnsi(ptr);
	}

	public static string[] ToStringArrayAuto(this IntPtr ptr, int length)
	{
		if (length == 0)
			return Array.Empty<string>();
		var result = new string[length];
		for (var i = 0; i < length; i++)
			result[i] = ToStringAuto(Marshal.ReadIntPtr(ptr + 32 * i)); //TODO Try this on 32-bits
		return result;
	}

	public static T[] ToArrayOf<T>(this IntPtr ptr, int length, Func<IntPtr, T> construction)
	{
		if (length == 0)
			return Array.Empty<T>();
		var result = new T[length];
		for (var i = 0; i < length; i++)
			result[i] = construction(Marshal.ReadIntPtr(ptr + IntPtr.Size * i));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3d ToVector3d(this IntPtr ptr)
	{
		return Marshal.PtrToStructure<Vector3d>(ptr);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNullPtr(this IntPtr ptr)
	{
		return ptr == IntPtr.Zero;
	}
}
