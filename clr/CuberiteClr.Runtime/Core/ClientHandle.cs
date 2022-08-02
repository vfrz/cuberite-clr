using System;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Core;

public unsafe class ClientHandle : InteropReference, IClientHandle
{
	public ClientHandle(IntPtr handle) : base(handle)
	{
	}

	public IPlayer GetPlayer()
	{
		return Player.CreateNullable(WrapperFunctions.client_handle_get_player(Handle));
	}
}
