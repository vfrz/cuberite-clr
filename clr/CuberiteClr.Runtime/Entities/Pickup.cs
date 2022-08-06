using System;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Pickup : Entity, IPickup
{
	public Pickup(IntPtr handle) : base(handle)
	{
	}

	public bool IsPlayerCreated()
	{
		return WrapperFunctions.pickup_is_player_created(Handle);
	}

	public bool IsCollected()
	{
		return WrapperFunctions.pickup_is_collected(Handle);
	}
}
