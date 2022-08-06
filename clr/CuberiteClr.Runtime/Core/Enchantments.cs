using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Enchantments : InteropReference, IEnchantments
{
	private Enchantments(IntPtr handle) : base(handle)
	{
	}

	public static IEnchantments Create(IntPtr handle)
	{
		return handle.IsNullPtr() ? null : new Enchantments(handle);
	}

	public override string ToString()
	{
		return WrapperFunctions.enchantments_to_string(Handle).ToStringAnsi();
	}
}
