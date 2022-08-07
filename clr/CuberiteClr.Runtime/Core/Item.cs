using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Item : InteropReference, IItem
{
	public short Type => WrapperFunctions.item_get_type(Handle);

	public byte Count => WrapperFunctions.item_get_count(Handle);

	public short Damage => WrapperFunctions.item_get_damage(Handle);

	public string CustomName => WrapperFunctions.item_get_custom_name(Handle).ToStringAnsi();

	public IEnchantments Enchantments => Core.Enchantments.Create(WrapperFunctions.item_get_enchantments(Handle));

	private Item(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IItem Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new Item(handle, fromManaged);
	}

	protected override void Delete()
	{
		WrapperFunctions.delete_item(Handle);
	}
}
