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
	internal Player(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}

	public IInventory GetInventory()
	{
		var inventoryPtr = WrapperFunctions.player_get_inventory(Handle);
		return Inventory.Create(inventoryPtr);
	}

	public string GetName()
	{
		return WrapperFunctions.player_get_name(Handle).ToStringAnsi();
	}

	public Guid GetUUID()
	{
		return WrapperFunctions.player_get_uuid(Handle).FixGuidBytesOrder();
	}

	public void SendMessage(string message)
	{
		WrapperFunctions.player_send_message(Handle, message);
	}

	public void SendMessageInfo(string message)
	{
		WrapperFunctions.player_send_message_info(Handle, message);
	}

	public void SendMessageFailure(string message)
	{
		WrapperFunctions.player_send_message_failure(Handle, message);
	}

	public void SendMessageSuccess(string message)
	{
		WrapperFunctions.player_send_message_success(Handle, message);
	}

	public void SendMessageWarning(string message)
	{
		WrapperFunctions.player_send_message_warning(Handle, message);
	}

	public void SendMessageFatal(string message)
	{
		WrapperFunctions.player_send_message_fatal(Handle, message);
	}

	public void SendPrivateMessage(string message, string sender)
	{
		WrapperFunctions.player_send_message_private_msg(Handle, message, sender);
	}

	public void SendMessage(ICompositeChat message)
	{
		WrapperFunctions.player_send_message_composite(Handle, message.GetInteropHandle());
	}

	public void SendMessageRaw(string message, ChatType type = ChatType.System)
	{
		WrapperFunctions.player_send_message_raw(Handle, message, type);
	}

	public void SendSystemMessage(string message)
	{
		WrapperFunctions.player_send_system_message(Handle, message);
	}

	public void SendAboveActionBarMessage(string message)
	{
		WrapperFunctions.player_send_above_action_bar_message(Handle, message);
	}

	public void SendSystemMessage(ICompositeChat message)
	{
		WrapperFunctions.player_send_system_message_composite(Handle, message.GetInteropHandle());
	}

	public void SendAboveActionBarMessage(ICompositeChat message)
	{
		WrapperFunctions.player_send_above_action_bar_message_composite(Handle, message.GetInteropHandle());
	}

	public void Feed(int food, double saturation)
	{
		WrapperFunctions.player_feed(Handle, food, saturation);
	}

	public void SetRespawnLocation(Vector3i position, IWorld world)
	{
		WrapperFunctions.player_set_respawn_location(Handle, position, world.GetInteropHandle());
	}

	public IItem GetEquippedItem()
	{
		var itemPtr = WrapperFunctions.player_get_equipped_item(Handle);
		return Item.Create(itemPtr);
	}

	public void Freeze(Vector3d position)
	{
		WrapperFunctions.player_freeze(Handle, position);
	}

	public bool IsFrozen()
	{
		return WrapperFunctions.player_is_frozen(Handle);
	}

	public void Unfreeze()
	{
		WrapperFunctions.player_unfreeze(Handle);
	}

	public GameMode GetGameMode()
	{
		return WrapperFunctions.player_get_game_mode(Handle);
	}

	public void SetGameMode(GameMode gameMode)
	{
		WrapperFunctions.player_set_game_mode(Handle, gameMode);
	}

	public void SetVisible(bool visible)
	{
		WrapperFunctions.player_set_visible(Handle, visible);
	}

	public IClientHandle GetClientHandle()
	{
		var clientHandlePtr = WrapperFunctions.player_get_client_handle(Handle);
		return ClientHandle.Create(clientHandlePtr);
	}

	public bool HasPermission(string permission)
	{
		return WrapperFunctions.player_has_permission(Handle, permission);
	}
}
