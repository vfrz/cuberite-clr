// This file is auto-generated, please do not modify manually
using System;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Interop;

public static unsafe class WrapperFunctions
{
	public static delegate* unmanaged[Cdecl]<string,void> cuberite_log;
	public static delegate* unmanaged[Cdecl]<string,void> cuberite_log_info;
	public static delegate* unmanaged[Cdecl]<string,void> cuberite_log_warning;
	public static delegate* unmanaged[Cdecl]<string,void> cuberite_log_error;
	public static delegate* unmanaged[Cdecl]<string,void> cuberite_log_debug;
	public static delegate* unmanaged[Cdecl]<IntPtr,float> entity_get_health;
	public static delegate* unmanaged[Cdecl]<IntPtr,float,void> entity_set_health;
	public static delegate* unmanaged[Cdecl]<IntPtr,bool> entity_is_invisible;
	public static delegate* unmanaged[Cdecl]<IntPtr,IntPtr,byte> inventory_add_item;
	public static delegate* unmanaged[Cdecl]<IntPtr,GameMode> player_get_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr,GameMode,void> player_set_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr,IntPtr> player_get_inventory;
	public static delegate* unmanaged[Cdecl]<IntPtr,IntPtr> player_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr,bool,void> player_set_visible;
	public static delegate* unmanaged[Cdecl]<IntPtr,Guid> player_get_uuid;
	public static delegate* unmanaged[Cdecl]<IntPtr,IntPtr> player_get_client_handle;
	public static delegate* unmanaged[Cdecl]<string,MessageType,void> root_broadcast_chat;
	public static delegate* unmanaged[Cdecl]<IntPtr> root_get_default_world;
	public static delegate* unmanaged[Cdecl]<IntPtr,bool> world_are_command_blocks_enabled;
	public static delegate* unmanaged[Cdecl]<IntPtr,bool,void> world_set_command_blocks_enabled;
	public static delegate* unmanaged[Cdecl]<IntPtr,int,int,int,BlockType> world_get_block;
	public static delegate* unmanaged[Cdecl]<IntPtr,int,int,int,BlockType,byte,void> world_set_block;
	public static delegate* unmanaged[Cdecl]<IntPtr,string,IntPtr,MessageType,void> world_broadcast_chat;
	public static delegate* unmanaged[Cdecl]<IntPtr,int,int,int,IntPtr,void> world_dig_block;
	public static delegate* unmanaged[Cdecl]<IntPtr,double,double,double,double,bool,ExplosionSource,IntPtr,void> world_do_explosion_at;
	public static delegate* unmanaged[Cdecl]<IntPtr,GameMode> world_get_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr,Weather> world_get_weather;
	public static delegate* unmanaged[Cdecl]<IntPtr,Weather,void> world_set_weather;
	public static delegate* unmanaged[Cdecl]<short,byte,short,string,string,IntPtr,int,IntPtr> create_item;
	public static delegate* unmanaged[Cdecl]<IntPtr,void> delete_item;


	public static void Initialize(IntPtr* ptr)
	{
		cuberite_log = (delegate* unmanaged[Cdecl]<string,void>) *(ptr + 0);
		cuberite_log_info = (delegate* unmanaged[Cdecl]<string,void>) *(ptr + 1);
		cuberite_log_warning = (delegate* unmanaged[Cdecl]<string,void>) *(ptr + 2);
		cuberite_log_error = (delegate* unmanaged[Cdecl]<string,void>) *(ptr + 3);
		cuberite_log_debug = (delegate* unmanaged[Cdecl]<string,void>) *(ptr + 4);
		entity_get_health = (delegate* unmanaged[Cdecl]<IntPtr,float>) *(ptr + 5);
		entity_set_health = (delegate* unmanaged[Cdecl]<IntPtr,float,void>) *(ptr + 6);
		entity_is_invisible = (delegate* unmanaged[Cdecl]<IntPtr,bool>) *(ptr + 7);
		inventory_add_item = (delegate* unmanaged[Cdecl]<IntPtr,IntPtr,byte>) *(ptr + 8);
		player_get_game_mode = (delegate* unmanaged[Cdecl]<IntPtr,GameMode>) *(ptr + 9);
		player_set_game_mode = (delegate* unmanaged[Cdecl]<IntPtr,GameMode,void>) *(ptr + 10);
		player_get_inventory = (delegate* unmanaged[Cdecl]<IntPtr,IntPtr>) *(ptr + 11);
		player_get_name = (delegate* unmanaged[Cdecl]<IntPtr,IntPtr>) *(ptr + 12);
		player_set_visible = (delegate* unmanaged[Cdecl]<IntPtr,bool,void>) *(ptr + 13);
		player_get_uuid = (delegate* unmanaged[Cdecl]<IntPtr,Guid>) *(ptr + 14);
		player_get_client_handle = (delegate* unmanaged[Cdecl]<IntPtr,IntPtr>) *(ptr + 15);
		root_broadcast_chat = (delegate* unmanaged[Cdecl]<string,MessageType,void>) *(ptr + 16);
		root_get_default_world = (delegate* unmanaged[Cdecl]<IntPtr>) *(ptr + 17);
		world_are_command_blocks_enabled = (delegate* unmanaged[Cdecl]<IntPtr,bool>) *(ptr + 18);
		world_set_command_blocks_enabled = (delegate* unmanaged[Cdecl]<IntPtr,bool,void>) *(ptr + 19);
		world_get_block = (delegate* unmanaged[Cdecl]<IntPtr,int,int,int,BlockType>) *(ptr + 20);
		world_set_block = (delegate* unmanaged[Cdecl]<IntPtr,int,int,int,BlockType,byte,void>) *(ptr + 21);
		world_broadcast_chat = (delegate* unmanaged[Cdecl]<IntPtr,string,IntPtr,MessageType,void>) *(ptr + 22);
		world_dig_block = (delegate* unmanaged[Cdecl]<IntPtr,int,int,int,IntPtr,void>) *(ptr + 23);
		world_do_explosion_at = (delegate* unmanaged[Cdecl]<IntPtr,double,double,double,double,bool,ExplosionSource,IntPtr,void>) *(ptr + 24);
		world_get_game_mode = (delegate* unmanaged[Cdecl]<IntPtr,GameMode>) *(ptr + 25);
		world_get_weather = (delegate* unmanaged[Cdecl]<IntPtr,Weather>) *(ptr + 26);
		world_set_weather = (delegate* unmanaged[Cdecl]<IntPtr,Weather,void>) *(ptr + 27);
		create_item = (delegate* unmanaged[Cdecl]<short,byte,short,string,string,IntPtr,int,IntPtr>) *(ptr + 28);
		delete_item = (delegate* unmanaged[Cdecl]<IntPtr,void>) *(ptr + 29);

	}
}
