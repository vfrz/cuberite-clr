using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Inventory : InteropReference, IInventory
{
	private Inventory(IntPtr handle) : base(handle)
	{
	}

	public static IInventory Create(IntPtr handle)
	{
		return handle.IsNullPtr() ? null : new Inventory(handle);
	}

	public byte AddItem(IItem item)
	{
		var itemHandle = item.GetInteropHandle();
		return WrapperFunctions.inventory_add_item(Handle, itemHandle);
	}
}
