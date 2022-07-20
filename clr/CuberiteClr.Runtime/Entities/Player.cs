using System;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Player : InteropReference, IPlayer
{
	public Player(IntPtr handle) : base(handle)
	{
	}

	public float GetHealth()
	{
		return WrappersFunctions.entities_player_get_health(Handle);
	}

	public void SetHealth(float health)
	{
		WrappersFunctions.entities_player_set_health(Handle, health);
	}

	public string GetName()
	{
		return WrappersFunctions.entities_player_get_name(Handle).ReadStringAuto();
	}

	public Guid GetUUID()
	{
		return WrappersFunctions.entities_player_get_uuid(Handle);
	}
}
