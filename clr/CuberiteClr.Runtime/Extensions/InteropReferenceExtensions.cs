using System;
using CuberiteClr.Runtime.Interop;

namespace CuberiteClr.Runtime.Extensions;

public static class InteropReferenceExtensions
{
	public static InteropReference GetInteropReference<T>(this T obj)
	{
		if (obj is InteropReference interopReference)
			return interopReference;
		throw new Exception($"This object is not an interop reference object: {obj.GetType()}");
	}

	public static IntPtr GetOptionalInteropHandle<T>(this T obj)
	{
		if (obj is null)
			return IntPtr.Zero;
		return obj.GetInteropReference().Handle;
	}
}
