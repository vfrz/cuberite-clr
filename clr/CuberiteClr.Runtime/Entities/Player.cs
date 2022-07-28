using System;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Player : Pawn, IPlayer
{
	public Player(IntPtr handle) : base(handle)
	{
	}

	internal static IPlayer CreateNullable(IntPtr handle)
	{
		return handle != IntPtr.Zero ? new Player(handle) : null;
	}

	public IInventory GetInventory()
	{
		var inventoryPtr = WrapperFunctions.player_get_inventory(Handle);
		return new Inventory(inventoryPtr);
	}

	public string GetName()
	{
		return WrapperFunctions.player_get_name(Handle).ReadStringAuto();
	}

	public Guid GetUUID()
	{
		return WrapperFunctions.player_get_uuid(Handle).FixGuidBytesOrder();
	}
}
