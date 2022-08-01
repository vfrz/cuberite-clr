using System;
using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Extensions;

internal static class IntPtrExtensions
{
	public static string ToStringAuto(this IntPtr ptr)
	{
		return Marshal.PtrToStringAnsi(ptr);
	}

	public static string[] ToStringArrayAuto(this IntPtr ptr, int length)
	{
		var result = new string[length];
		for (var i = 0; i < length; i++)
			result[i] = ToStringAuto(Marshal.ReadIntPtr(ptr + 32 * i));
		return result;
	}

	public static Vector3d ToVector3d(this IntPtr ptr)
	{
		return Marshal.PtrToStructure<Vector3d>(ptr);
	}
}
