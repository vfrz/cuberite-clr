using System;

namespace CuberiteClr.Runtime.Interop;

public abstract class InteropReference
{
	public IntPtr Handle { get; }

	public InteropReference(IntPtr handle)
	{
		if (handle == IntPtr.Zero)
			throw new Exception($"Failed to instantiate {GetType().Name} because handle is a null pointer");
		Handle = handle;
	}
}
