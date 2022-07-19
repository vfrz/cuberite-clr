using System;

namespace CuberiteClr.Runtime.Interop;

public abstract class InteropReference
{
	public IntPtr Handle { get; }

	public InteropReference(IntPtr handle)
	{
		Handle = handle;
	}
}
