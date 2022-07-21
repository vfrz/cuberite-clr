using System;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Interop;

public static unsafe class WrappersFunctions
{
	// Cuberite internal
	public static delegate* unmanaged[Cdecl]<string, void> cuberite_log;
	public static delegate* unmanaged[Cdecl]<string, void> cuberite_log_info;
	public static delegate* unmanaged[Cdecl]<string, void> cuberite_log_warn;
	public static delegate* unmanaged[Cdecl]<string, void> cuberite_log_error;
	public static delegate* unmanaged[Cdecl]<string, void> cuberite_log_debug;

	// Entity
	public static delegate* unmanaged[Cdecl]<IntPtr, float> entity_get_health;
	public static delegate* unmanaged[Cdecl]<IntPtr, float, void> entity_set_health;

	// Inventory
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, byte> inventory_add_item;

	// Player
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, Guid> player_get_uuid;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_inventory;

	// Root
	public static delegate* unmanaged[Cdecl]<string, MessageType, void> root_broadcast_chat;

	// Objects creation
	public static delegate* unmanaged[Cdecl]<short, byte, short, string, string, IntPtr, int, IntPtr> create_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> delete_item;

	public static void Initialize(IntPtr* ptr)
	{
		// Cuberite internal
		cuberite_log = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 0);
		cuberite_log_info = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 1);
		cuberite_log_warn = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 2);
		cuberite_log_error = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 3);
		cuberite_log_debug = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 4);

		// Entity
		entity_get_health = (delegate* unmanaged[Cdecl]<IntPtr, float>) *(ptr + 32);
		entity_set_health = (delegate* unmanaged[Cdecl]<IntPtr, float, void>) *(ptr + 33);

		// Inventory
		inventory_add_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, byte>) *(ptr + 92);

		// Player
		player_get_inventory = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 130);
		player_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 131);
		player_get_uuid = (delegate* unmanaged[Cdecl]<IntPtr, Guid>) *(ptr + 133);

		// Root
		root_broadcast_chat = (delegate* unmanaged[Cdecl]<string, MessageType, void>) *(ptr + 192);

		// Objects creation
		create_item = (delegate* unmanaged[Cdecl]<short, byte, short, string, string, IntPtr, int, IntPtr>) *(ptr + 256);
		delete_item = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 257);
	}
}
