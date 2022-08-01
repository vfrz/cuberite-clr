// This file is auto-generated, please do not modify manually
using System;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Interop;

public static unsafe class WrapperFunctions
{
	public static delegate* unmanaged[Cdecl]<string, void> log_default;
	public static delegate* unmanaged[Cdecl]<string, void> log_info;
	public static delegate* unmanaged[Cdecl]<string, void> log_warning;
	public static delegate* unmanaged[Cdecl]<string, void> log_error;
	public static delegate* unmanaged[Cdecl]<string, void> log_debug;
	public static delegate* unmanaged[Cdecl]<string, IntPtr, string, string, bool> bind_command;
	public static delegate* unmanaged[Cdecl]<IntPtr, float> entity_get_health;
	public static delegate* unmanaged[Cdecl]<IntPtr, float, void> entity_set_health;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> entity_is_invisible;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> entity_get_world;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> entity_take_damage_1;
	public static delegate* unmanaged[Cdecl]<IntPtr, DamageType, IntPtr, int, double, void> entity_take_damage_2;
	public static delegate* unmanaged[Cdecl]<IntPtr, DamageType, int, int, double, void> entity_take_damage_3;
	public static delegate* unmanaged[Cdecl]<IntPtr, DamageType, IntPtr, int, float, double, void> entity_take_damage_4;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, void> entity_heal;
	public static delegate* unmanaged[Cdecl]<IntPtr, EntityType> entity_get_entity_type;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> entity_get_position;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, byte> inventory_add_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, GameMode> player_get_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr, GameMode, void> player_set_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_inventory;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool, void> player_set_visible;
	public static delegate* unmanaged[Cdecl]<IntPtr, Guid> player_get_uuid;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_client_handle;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, double, bool> player_feed;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, int, int, IntPtr, void> player_set_respawn_location;
	public static delegate* unmanaged[Cdecl]<string, MessageType, void> root_broadcast_chat;
	public static delegate* unmanaged[Cdecl]<IntPtr> root_get_default_world;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> root_for_each_world;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> root_for_each_player;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> world_are_command_blocks_enabled;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool, void> world_set_command_blocks_enabled;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> world_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, int, int, BlockType> world_get_block;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, int, int, BlockType, byte, void> world_set_block;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, IntPtr, MessageType, void> world_broadcast_chat;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, int, int, IntPtr, void> world_dig_block;
	public static delegate* unmanaged[Cdecl]<IntPtr, double, double, double, double, bool, ExplosionSource, IntPtr, void> world_do_explosion_at;
	public static delegate* unmanaged[Cdecl]<IntPtr, GameMode> world_get_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr, Weather> world_get_weather;
	public static delegate* unmanaged[Cdecl]<IntPtr, Weather, void> world_set_weather;
	public static delegate* unmanaged[Cdecl]<IntPtr, int> world_get_time_of_day;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, void> world_set_time_of_day;
	public static delegate* unmanaged[Cdecl]<IntPtr, long> world_get_world_age;
	public static delegate* unmanaged[Cdecl]<IntPtr, long> world_get_world_tick_age;
	public static delegate* unmanaged[Cdecl]<IntPtr, long> world_get_world_date;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool> world_for_each_player;
	public static delegate* unmanaged[Cdecl]<short, byte, short, string, string, IntPtr, int, IntPtr> create_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> delete_item;


	public static void Initialize(IntPtr* ptr)
	{
		log_default = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 0);
		log_info = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 1);
		log_warning = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 2);
		log_error = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 3);
		log_debug = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 4);
		bind_command = (delegate* unmanaged[Cdecl]<string, IntPtr, string, string, bool>) *(ptr + 5);
		entity_get_health = (delegate* unmanaged[Cdecl]<IntPtr, float>) *(ptr + 6);
		entity_set_health = (delegate* unmanaged[Cdecl]<IntPtr, float, void>) *(ptr + 7);
		entity_is_invisible = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 8);
		entity_get_world = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 9);
		entity_take_damage_1 = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>) *(ptr + 10);
		entity_take_damage_2 = (delegate* unmanaged[Cdecl]<IntPtr, DamageType, IntPtr, int, double, void>) *(ptr + 11);
		entity_take_damage_3 = (delegate* unmanaged[Cdecl]<IntPtr, DamageType, int, int, double, void>) *(ptr + 12);
		entity_take_damage_4 = (delegate* unmanaged[Cdecl]<IntPtr, DamageType, IntPtr, int, float, double, void>) *(ptr + 13);
		entity_heal = (delegate* unmanaged[Cdecl]<IntPtr, int, void>) *(ptr + 14);
		entity_get_entity_type = (delegate* unmanaged[Cdecl]<IntPtr, EntityType>) *(ptr + 15);
		entity_get_position = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 16);
		inventory_add_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, byte>) *(ptr + 17);
		player_get_game_mode = (delegate* unmanaged[Cdecl]<IntPtr, GameMode>) *(ptr + 18);
		player_set_game_mode = (delegate* unmanaged[Cdecl]<IntPtr, GameMode, void>) *(ptr + 19);
		player_get_inventory = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 20);
		player_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 21);
		player_set_visible = (delegate* unmanaged[Cdecl]<IntPtr, bool, void>) *(ptr + 22);
		player_get_uuid = (delegate* unmanaged[Cdecl]<IntPtr, Guid>) *(ptr + 23);
		player_get_client_handle = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 24);
		player_send_message = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 25);
		player_feed = (delegate* unmanaged[Cdecl]<IntPtr, int, double, bool>) *(ptr + 26);
		player_set_respawn_location = (delegate* unmanaged[Cdecl]<IntPtr, int, int, int, IntPtr, void>) *(ptr + 27);
		root_broadcast_chat = (delegate* unmanaged[Cdecl]<string, MessageType, void>) *(ptr + 28);
		root_get_default_world = (delegate* unmanaged[Cdecl]<IntPtr>) *(ptr + 29);
		root_for_each_world = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 30);
		root_for_each_player = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 31);
		world_are_command_blocks_enabled = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 32);
		world_set_command_blocks_enabled = (delegate* unmanaged[Cdecl]<IntPtr, bool, void>) *(ptr + 33);
		world_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 34);
		world_get_block = (delegate* unmanaged[Cdecl]<IntPtr, int, int, int, BlockType>) *(ptr + 35);
		world_set_block = (delegate* unmanaged[Cdecl]<IntPtr, int, int, int, BlockType, byte, void>) *(ptr + 36);
		world_broadcast_chat = (delegate* unmanaged[Cdecl]<IntPtr, string, IntPtr, MessageType, void>) *(ptr + 37);
		world_dig_block = (delegate* unmanaged[Cdecl]<IntPtr, int, int, int, IntPtr, void>) *(ptr + 38);
		world_do_explosion_at = (delegate* unmanaged[Cdecl]<IntPtr, double, double, double, double, bool, ExplosionSource, IntPtr, void>) *(ptr + 39);
		world_get_game_mode = (delegate* unmanaged[Cdecl]<IntPtr, GameMode>) *(ptr + 40);
		world_get_weather = (delegate* unmanaged[Cdecl]<IntPtr, Weather>) *(ptr + 41);
		world_set_weather = (delegate* unmanaged[Cdecl]<IntPtr, Weather, void>) *(ptr + 42);
		world_get_time_of_day = (delegate* unmanaged[Cdecl]<IntPtr, int>) *(ptr + 43);
		world_set_time_of_day = (delegate* unmanaged[Cdecl]<IntPtr, int, void>) *(ptr + 44);
		world_get_world_age = (delegate* unmanaged[Cdecl]<IntPtr, long>) *(ptr + 45);
		world_get_world_tick_age = (delegate* unmanaged[Cdecl]<IntPtr, long>) *(ptr + 46);
		world_get_world_date = (delegate* unmanaged[Cdecl]<IntPtr, long>) *(ptr + 47);
		world_for_each_player = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>) *(ptr + 48);
		create_item = (delegate* unmanaged[Cdecl]<short, byte, short, string, string, IntPtr, int, IntPtr>) *(ptr + 49);
		delete_item = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 50);

	}
}
