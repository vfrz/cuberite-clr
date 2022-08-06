using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Enchantments : InteropReference, IEnchantments
{
	private Enchantments(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IEnchantments Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new Enchantments(handle, fromManaged);
	}

	public override string ToString()
	{
		return WrapperFunctions.enchantments_to_string(Handle).ToStringAnsi();
	}
}
