using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class Root : IRoot
{
	public static IRoot Instance { get; } = new Root();

	private Root()
	{
	}

	public void BroadcastChat(string message, MessageType type = MessageType.Custom)
	{
		WrappersFunctions.root_broadcast_chat(message, type);
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

		var itemPtr = WrappersFunctions.create_item(type, count, damage, enchantments ?? string.Empty, customName ?? string.Empty, loreTableIntPtr, loreTable?.Length ?? 0);
		return new Item(itemPtr);
	}
}
