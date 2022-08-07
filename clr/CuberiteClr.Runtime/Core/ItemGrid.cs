using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public class ItemGrid : InteropReference, IItemGrid
{
	private ItemGrid(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IItemGrid Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new ItemGrid(handle, fromManaged);
	}
}
