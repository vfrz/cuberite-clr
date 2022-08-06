using System;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Core;

public unsafe class ClientHandle : InteropReference, IClientHandle
{
	private ClientHandle(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IClientHandle Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new ClientHandle(handle, fromManaged);
	}

	public IPlayer GetPlayer()
	{
		return Entity.Create(WrapperFunctions.client_handle_get_player(Handle)) as IPlayer;
	}
}
