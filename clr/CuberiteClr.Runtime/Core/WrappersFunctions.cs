using System;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public static unsafe class WrappersFunctions
{
	// Player
	public static delegate* unmanaged[Cdecl]<IntPtr, float> entities_player_get_health;
	public static delegate* unmanaged[Cdecl]<IntPtr, float, void> entities_player_set_health;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> entities_player_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, Guid> entities_player_get_uuid;

	// Root
	public static delegate* unmanaged[Cdecl]<string, MessageType, void> root_broadcast_chat;

	public static void Initialize(IntPtr* ptr)
	{
		// Player
		entities_player_get_health = (delegate* unmanaged[Cdecl]<IntPtr, float>) *(ptr + 0);
		entities_player_set_health = (delegate* unmanaged[Cdecl]<IntPtr, float, void>) *(ptr + 1);
		entities_player_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 2);
		entities_player_get_uuid = (delegate* unmanaged[Cdecl]<IntPtr, Guid>) *(ptr + 3);

		// Root
		root_broadcast_chat = (delegate* unmanaged[Cdecl]<string, MessageType, void>) *(ptr + 50);
	}
}
