using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public class BlockEntity : InteropReference, IBlockEntity
{
	private BlockEntity(IntPtr handle) : base(handle)
	{
	}

	public static IBlockEntity Create(IntPtr handle)
	{
		return handle.IsNullPtr() ? null : new BlockEntity(handle);
	}
}
