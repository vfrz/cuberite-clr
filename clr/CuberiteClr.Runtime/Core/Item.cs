using System;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Item : InteropReference, IItem, IDisposable
{
	private bool _disposed;

	public Item(IntPtr handle) : base(handle)
	{
	}

	~Item()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (_disposed)
			return;

		WrappersFunctions.delete_item(Handle);
		_disposed = true;

		GC.SuppressFinalize(this);
	}
}
