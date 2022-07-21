using System;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Inventory : InteropReference, IInventory
{
	public Inventory(IntPtr handle) : base(handle)
	{
	}

	public byte AddItem(IItem item)
	{
		var itemHandle = ((Item) item).Handle; // Maybe find a way to avoid cast
		return WrappersFunctions.inventory_add_item(Handle, itemHandle);
	}
}
