using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Player : Pawn, IPlayer
{
	public Player(IntPtr handle) : base(handle)
	{
	}

	public string GetName()
	{
		return WrappersFunctions.player_get_name(Handle).ReadStringAuto();
	}

	public Guid GetUUID()
	{
		return WrappersFunctions.player_get_uuid(Handle).FixGuidBytesOrder();
	}
}
