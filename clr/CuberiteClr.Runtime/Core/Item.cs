using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Item : InteropReference, IItem, IDisposable
{
	public short Type => WrapperFunctions.item_get_type(Handle);

	public byte Count => WrapperFunctions.item_get_count(Handle);

	public short Damage => WrapperFunctions.item_get_damage(Handle);

	public string CustomName => WrapperFunctions.item_get_custom_name(Handle).ToStringAuto();

	public IEnchantments Enchantments => Core.Enchantments.Create(WrapperFunctions.item_get_enchantments(Handle));

	private bool _disposed;

	private Item(IntPtr handle) : base(handle)
	{
	}

	public static IItem Create(IntPtr handle)
	{
		return handle.IsNullPtr() ? null : new Item(handle);
	}

	~Item()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (_disposed)
			return;

		WrapperFunctions.delete_item(Handle);
		_disposed = true;

		GC.SuppressFinalize(this);
	}
}
