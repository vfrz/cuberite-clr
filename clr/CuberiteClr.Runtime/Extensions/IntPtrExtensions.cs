using System;
using System.Runtime.InteropServices;

namespace CuberiteClr.Runtime.Extensions;

internal static class IntPtrExtensions
{
	public static string ReadStringAuto(this IntPtr ptr)
	{
		return Marshal.PtrToStringAnsi(ptr);
	}
}
