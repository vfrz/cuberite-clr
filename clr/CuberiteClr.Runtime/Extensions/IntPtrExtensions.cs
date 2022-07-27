using System;
using System.Runtime.InteropServices;

namespace CuberiteClr.Runtime.Extensions;

internal static class IntPtrExtensions
{
	public static string ReadStringAuto(this IntPtr ptr)
	{
		return Marshal.PtrToStringAnsi(ptr);
	}

	public static string[] ReadStringArrayAuto(this IntPtr ptr, int length)
	{
		var result = new string[length];
		for (var i = 0; i < length; i++)
			result[i] = ReadStringAuto(Marshal.ReadIntPtr(ptr + 32 * i));
		return result;
	}
}
