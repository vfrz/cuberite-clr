using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
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
		return new World(handle);
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
		return new Item(itemPtr);
	}
}
