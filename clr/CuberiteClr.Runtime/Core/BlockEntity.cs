using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public class BlockEntity : InteropReference, IBlockEntity
{
	private BlockEntity(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IBlockEntity Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new BlockEntity(handle, fromManaged);
	}
}
