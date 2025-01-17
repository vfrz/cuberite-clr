using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class Root : IRoot
{
	public bool BindCommand(string name, CommandCallback callback, string permission = null, string helpString = null)
	{
		var gcHandle = GCHandle.Alloc(callback, GCHandleType.Normal);
		var callbackPtr = GCHandle.ToIntPtr(gcHandle);
		return WrapperFunctions.bind_command(name, callbackPtr, permission ?? string.Empty, helpString ?? string.Empty);
	}

	public void BroadcastChat(string message, MessageType type = MessageType.Custom)
	{
		WrapperFunctions.root_broadcast_chat(message, type);
	}

	public IWorld GetDefaultWorld()
	{
		var handle = WrapperFunctions.root_get_default_world();
		return World.Create(handle);
	}

	public bool ForEachWorld(ForEachWorldCallback callback)
	{
		var gcHandle = GCHandle.Alloc(callback, GCHandleType.Normal);
		var callbackPointer = GCHandle.ToIntPtr(gcHandle);
		return WrapperFunctions.root_for_each_world(callbackPointer);
	}

	public bool ForEachPlayer(ForEachPlayerCallback callback)
	{
		var gcHandle = GCHandle.Alloc(callback, GCHandleType.Normal);
		var callbackPointer = GCHandle.ToIntPtr(gcHandle);
		return WrapperFunctions.root_for_each_player(callbackPointer);
	}

	public string ItemTypeToString(short itemType)
	{
		return WrapperFunctions.item_type_to_string(itemType).ToStringAnsi();
	}

	// Objects creation
	public IItem CreateItem(short type, byte count = 1, short damage = 0, string enchantments = null, string customName = null, string[] loreTable = null)
	{
		var loreTableIntPtr = IntPtr.Zero;

		if (loreTable is not null && loreTable.Length > 0)
		{
			// Not tested
			var loreTableReferences = new IntPtr[loreTable.Length];
			for (var i = 0; i < loreTable.Length; i++)
				loreTableReferences[i] = Marshal.StringToHGlobalAnsi(loreTable[i]);

			fixed (void* loreTablePtr = &loreTableReferences[0])
			{
				loreTableIntPtr = new IntPtr(loreTablePtr);
			}
		}

		var itemPtr = WrapperFunctions.create_item(type, count, damage, enchantments ?? string.Empty, customName ?? string.Empty, loreTableIntPtr, loreTable?.Length ?? 0);
		var item = Item.Create(itemPtr, true);
		return item;
	}

	public IPickup CreatePickup(Vector3d position, IItem item, bool isPlayerCreated, Vector3f speed = default, int lifetimeTicks = 6000, bool canCombine = true)
	{
		var pickupPtr = WrapperFunctions.create_pickup(position, item.GetOptionalInteropHandle(), isPlayerCreated,
			speed, lifetimeTicks, canCombine);
		var pickup = Entity.Create<IPickup>(pickupPtr, true);
		return pickup;
	}

	public ICompositeChat CreateCompositeChat()
	{
		var compositeChatPtr = WrapperFunctions.create_composite_chat_1();
		var compositeChat = CompositeChat.Create(compositeChatPtr, true);
		return compositeChat;
	}

	public ICompositeChat CreateCompositeChat(string message, MessageType type = MessageType.Custom)
	{
		var compositeChatPtr = WrapperFunctions.create_composite_chat_2(message, type);
		var compositeChat = CompositeChat.Create(compositeChatPtr, true);
		return compositeChat;
	}
}
