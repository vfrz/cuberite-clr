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

	// Player
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, Guid> player_get_uuid;

	// Root
	public static delegate* unmanaged[Cdecl]<string, MessageType, void> root_broadcast_chat;

	public static void Initialize(IntPtr* ptr)
	{
		// Cuberite internal
		cuberite_log = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 0);
		cuberite_log_info = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 1);
		cuberite_log_warn = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 2);
		cuberite_log_error = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 3);
		cuberite_log_debug = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 4);

		// Entity
		entity_get_health = (delegate* unmanaged[Cdecl]<IntPtr, float>) *(ptr + 10);
		entity_set_health = (delegate* unmanaged[Cdecl]<IntPtr, float, void>) *(ptr + 11);

		// Player
		player_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 50);
		player_get_uuid = (delegate* unmanaged[Cdecl]<IntPtr, Guid>) *(ptr + 51);

		// Root
		root_broadcast_chat = (delegate* unmanaged[Cdecl]<string, MessageType, void>) *(ptr + 100);
	}
}
