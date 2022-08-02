using System;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

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
		return WrapperFunctions.player_get_name(Handle).ToStringAuto();
	}

	public Guid GetUUID()
	{
		return WrapperFunctions.player_get_uuid(Handle).FixGuidBytesOrder();
	}

	public void SendMessage(string message)
	{
		WrapperFunctions.player_send_message(Handle, message);
	}

	public void Feed(int food, double saturation)
	{
		WrapperFunctions.player_feed(Handle, food, saturation);
	}

	public void SetRespawnLocation(Vector3i position, IWorld world)
	{
		WrapperFunctions.player_set_respawn_location(Handle, position, world.GetInteropHandle());
	}
}
