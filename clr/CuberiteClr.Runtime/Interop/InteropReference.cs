using System;

namespace CuberiteClr.Runtime.Interop;

public abstract class InteropReference
{
	public IntPtr Handle { get; }

	protected InteropReference(IntPtr handle)
	{
		Handle = handle;
	}
}
