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
	public static delegate* unmanaged[Cdecl]<short, IntPtr> item_type_to_string;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> composite_chat_clear;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, string, void> composite_chat_add_text_part;
	public static delegate* unmanaged[Cdecl]<IntPtr, MessageType> composite_chat_get_message_type;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> composite_chat_get_additional_message_type_data;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> composite_chat_extract_text;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> enchantments_to_string;
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
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3d> entity_get_position;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> entity_get_class;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, bool> entity_is_a;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> entity_get_parent_class;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3d, void> entity_teleport_to_coords;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> entity_teleport_to_entity;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool, byte> inventory_add_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, bool, byte> inventory_add_items;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> inventory_clear;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool, int> inventory_how_many_can_fit_1;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, int, bool, int> inventory_how_many_can_fit_2;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int> inventory_remove_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr> inventory_find_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> inventory_remove_one_equipped_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool, bool> inventory_replace_one_equipped_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int> inventory_how_many_items;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool> inventory_has_items;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> inventory_get_owner;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr> inventory_get_slot;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr> inventory_get_armor_slot;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr> inventory_get_inventory_slot;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr> inventory_get_hotbar_slot;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> inventory_get_shield_slot;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> inventory_get_armor_grid;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> inventory_get_inventory_grid;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> inventory_get_hotbar_grid;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> inventory_get_equipped_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, short> item_get_type;
	public static delegate* unmanaged[Cdecl]<IntPtr, byte> item_get_count;
	public static delegate* unmanaged[Cdecl]<IntPtr, short> item_get_damage;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> item_get_custom_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> item_get_enchantments;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> pickup_is_player_created;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> pickup_is_collected;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> pickup_can_combine;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool, void> pickup_set_can_combine;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool> pickup_collected_by;
	public static delegate* unmanaged[Cdecl]<IntPtr, int> pickup_get_age;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, void> pickup_set_age;
	public static delegate* unmanaged[Cdecl]<IntPtr, int> pickup_get_lifetime;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, void> pickup_set_lifetime;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> pickup_get_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, GameMode> player_get_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr, GameMode, void> player_set_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_inventory;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool, void> player_set_visible;
	public static delegate* unmanaged[Cdecl]<IntPtr, Guid> player_get_uuid;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_client_handle;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message_info;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message_failure;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message_success;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message_warning;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_message_fatal;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, string, void> player_send_message_private_msg;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> player_send_message_composite;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, ChatType, void> player_send_message_raw;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_system_message;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, void> player_send_above_action_bar_message;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> player_send_system_message_composite;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> player_send_above_action_bar_message_composite;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, double, bool> player_feed;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3i, IntPtr, void> player_set_respawn_location;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> player_get_equipped_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3d, void> player_freeze;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> player_is_frozen;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> player_unfreeze;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, bool> player_has_permission;
	public static delegate* unmanaged[Cdecl]<string, MessageType, void> root_broadcast_chat;
	public static delegate* unmanaged[Cdecl]<IntPtr> root_get_default_world;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> root_for_each_world;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> root_for_each_player;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> client_handle_get_player;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool> world_are_command_blocks_enabled;
	public static delegate* unmanaged[Cdecl]<IntPtr, bool, void> world_set_command_blocks_enabled;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> world_get_name;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3i, BlockType> world_get_block;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3i, BlockType, byte, void> world_set_block;
	public static delegate* unmanaged[Cdecl]<IntPtr, string, IntPtr, MessageType, void> world_broadcast_chat;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3i, IntPtr, void> world_dig_block;
	public static delegate* unmanaged[Cdecl]<IntPtr, double, Vector3d, bool, ExplosionSource, IntPtr, void> world_do_explosion_at;
	public static delegate* unmanaged[Cdecl]<IntPtr, GameMode> world_get_game_mode;
	public static delegate* unmanaged[Cdecl]<IntPtr, Weather> world_get_weather;
	public static delegate* unmanaged[Cdecl]<IntPtr, Weather, void> world_set_weather;
	public static delegate* unmanaged[Cdecl]<IntPtr, int> world_get_time_of_day;
	public static delegate* unmanaged[Cdecl]<IntPtr, int, void> world_set_time_of_day;
	public static delegate* unmanaged[Cdecl]<IntPtr, long> world_get_world_age;
	public static delegate* unmanaged[Cdecl]<IntPtr, long> world_get_world_tick_age;
	public static delegate* unmanaged[Cdecl]<IntPtr, long> world_get_world_date;
	public static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool> world_for_each_player;
	public static delegate* unmanaged[Cdecl]<IntPtr, Vector3i, void> world_cast_thunderbolt;
	public static delegate* unmanaged[Cdecl]<short, byte, short, string, string, IntPtr, int, IntPtr> create_item;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> delete_item;
	public static delegate* unmanaged[Cdecl]<Vector3d, IntPtr, bool, Vector3f, int, bool, IntPtr> create_pickup;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> delete_pickup;
	public static delegate* unmanaged[Cdecl]<IntPtr> create_composite_chat_1;
	public static delegate* unmanaged[Cdecl]<string, MessageType, IntPtr> create_composite_chat_2;
	public static delegate* unmanaged[Cdecl]<IntPtr, void> delete_composite_chat;


	public static void Initialize(IntPtr* ptr)
	{
		log_default = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 0);
		log_info = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 1);
		log_warning = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 2);
		log_error = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 3);
		log_debug = (delegate* unmanaged[Cdecl]<string, void>) *(ptr + 4);
		bind_command = (delegate* unmanaged[Cdecl]<string, IntPtr, string, string, bool>) *(ptr + 5);
		item_type_to_string = (delegate* unmanaged[Cdecl]<short, IntPtr>) *(ptr + 6);
		composite_chat_clear = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 7);
		composite_chat_add_text_part = (delegate* unmanaged[Cdecl]<IntPtr, string, string, void>) *(ptr + 8);
		composite_chat_get_message_type = (delegate* unmanaged[Cdecl]<IntPtr, MessageType>) *(ptr + 9);
		composite_chat_get_additional_message_type_data = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 10);
		composite_chat_extract_text = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 11);
		enchantments_to_string = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 12);
		entity_get_health = (delegate* unmanaged[Cdecl]<IntPtr, float>) *(ptr + 13);
		entity_set_health = (delegate* unmanaged[Cdecl]<IntPtr, float, void>) *(ptr + 14);
		entity_is_invisible = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 15);
		entity_get_world = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 16);
		entity_take_damage_1 = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>) *(ptr + 17);
		entity_take_damage_2 = (delegate* unmanaged[Cdecl]<IntPtr, DamageType, IntPtr, int, double, void>) *(ptr + 18);
		entity_take_damage_3 = (delegate* unmanaged[Cdecl]<IntPtr, DamageType, int, int, double, void>) *(ptr + 19);
		entity_take_damage_4 = (delegate* unmanaged[Cdecl]<IntPtr, DamageType, IntPtr, int, float, double, void>) *(ptr + 20);
		entity_heal = (delegate* unmanaged[Cdecl]<IntPtr, int, void>) *(ptr + 21);
		entity_get_entity_type = (delegate* unmanaged[Cdecl]<IntPtr, EntityType>) *(ptr + 22);
		entity_get_position = (delegate* unmanaged[Cdecl]<IntPtr, Vector3d>) *(ptr + 23);
		entity_get_class = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 24);
		entity_is_a = (delegate* unmanaged[Cdecl]<IntPtr, string, bool>) *(ptr + 25);
		entity_get_parent_class = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 26);
		entity_teleport_to_coords = (delegate* unmanaged[Cdecl]<IntPtr, Vector3d, void>) *(ptr + 27);
		entity_teleport_to_entity = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>) *(ptr + 28);
		inventory_add_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool, byte>) *(ptr + 29);
		inventory_add_items = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, bool, byte>) *(ptr + 30);
		inventory_clear = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 31);
		inventory_how_many_can_fit_1 = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool, int>) *(ptr + 32);
		inventory_how_many_can_fit_2 = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, int, bool, int>) *(ptr + 33);
		inventory_remove_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>) *(ptr + 34);
		inventory_find_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr>) *(ptr + 35);
		inventory_remove_one_equipped_item = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 36);
		inventory_replace_one_equipped_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool, bool>) *(ptr + 37);
		inventory_how_many_items = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>) *(ptr + 38);
		inventory_has_items = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>) *(ptr + 39);
		inventory_get_owner = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 40);
		inventory_get_slot = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr>) *(ptr + 41);
		inventory_get_armor_slot = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr>) *(ptr + 42);
		inventory_get_inventory_slot = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr>) *(ptr + 43);
		inventory_get_hotbar_slot = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr>) *(ptr + 44);
		inventory_get_shield_slot = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 45);
		inventory_get_armor_grid = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 46);
		inventory_get_inventory_grid = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 47);
		inventory_get_hotbar_grid = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 48);
		inventory_get_equipped_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 49);
		item_get_type = (delegate* unmanaged[Cdecl]<IntPtr, short>) *(ptr + 50);
		item_get_count = (delegate* unmanaged[Cdecl]<IntPtr, byte>) *(ptr + 51);
		item_get_damage = (delegate* unmanaged[Cdecl]<IntPtr, short>) *(ptr + 52);
		item_get_custom_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 53);
		item_get_enchantments = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 54);
		pickup_is_player_created = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 55);
		pickup_is_collected = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 56);
		pickup_can_combine = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 57);
		pickup_set_can_combine = (delegate* unmanaged[Cdecl]<IntPtr, bool, void>) *(ptr + 58);
		pickup_collected_by = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>) *(ptr + 59);
		pickup_get_age = (delegate* unmanaged[Cdecl]<IntPtr, int>) *(ptr + 60);
		pickup_set_age = (delegate* unmanaged[Cdecl]<IntPtr, int, void>) *(ptr + 61);
		pickup_get_lifetime = (delegate* unmanaged[Cdecl]<IntPtr, int>) *(ptr + 62);
		pickup_set_lifetime = (delegate* unmanaged[Cdecl]<IntPtr, int, void>) *(ptr + 63);
		pickup_get_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 64);
		player_get_game_mode = (delegate* unmanaged[Cdecl]<IntPtr, GameMode>) *(ptr + 65);
		player_set_game_mode = (delegate* unmanaged[Cdecl]<IntPtr, GameMode, void>) *(ptr + 66);
		player_get_inventory = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 67);
		player_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 68);
		player_set_visible = (delegate* unmanaged[Cdecl]<IntPtr, bool, void>) *(ptr + 69);
		player_get_uuid = (delegate* unmanaged[Cdecl]<IntPtr, Guid>) *(ptr + 70);
		player_get_client_handle = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 71);
		player_send_message = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 72);
		player_send_message_info = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 73);
		player_send_message_failure = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 74);
		player_send_message_success = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 75);
		player_send_message_warning = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 76);
		player_send_message_fatal = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 77);
		player_send_message_private_msg = (delegate* unmanaged[Cdecl]<IntPtr, string, string, void>) *(ptr + 78);
		player_send_message_composite = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>) *(ptr + 79);
		player_send_message_raw = (delegate* unmanaged[Cdecl]<IntPtr, string, ChatType, void>) *(ptr + 80);
		player_send_system_message = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 81);
		player_send_above_action_bar_message = (delegate* unmanaged[Cdecl]<IntPtr, string, void>) *(ptr + 82);
		player_send_system_message_composite = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>) *(ptr + 83);
		player_send_above_action_bar_message_composite = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>) *(ptr + 84);
		player_feed = (delegate* unmanaged[Cdecl]<IntPtr, int, double, bool>) *(ptr + 85);
		player_set_respawn_location = (delegate* unmanaged[Cdecl]<IntPtr, Vector3i, IntPtr, void>) *(ptr + 86);
		player_get_equipped_item = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 87);
		player_freeze = (delegate* unmanaged[Cdecl]<IntPtr, Vector3d, void>) *(ptr + 88);
		player_is_frozen = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 89);
		player_unfreeze = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 90);
		player_has_permission = (delegate* unmanaged[Cdecl]<IntPtr, string, bool>) *(ptr + 91);
		root_broadcast_chat = (delegate* unmanaged[Cdecl]<string, MessageType, void>) *(ptr + 92);
		root_get_default_world = (delegate* unmanaged[Cdecl]<IntPtr>) *(ptr + 93);
		root_for_each_world = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 94);
		root_for_each_player = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 95);
		client_handle_get_player = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 96);
		world_are_command_blocks_enabled = (delegate* unmanaged[Cdecl]<IntPtr, bool>) *(ptr + 97);
		world_set_command_blocks_enabled = (delegate* unmanaged[Cdecl]<IntPtr, bool, void>) *(ptr + 98);
		world_get_name = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) *(ptr + 99);
		world_get_block = (delegate* unmanaged[Cdecl]<IntPtr, Vector3i, BlockType>) *(ptr + 100);
		world_set_block = (delegate* unmanaged[Cdecl]<IntPtr, Vector3i, BlockType, byte, void>) *(ptr + 101);
		world_broadcast_chat = (delegate* unmanaged[Cdecl]<IntPtr, string, IntPtr, MessageType, void>) *(ptr + 102);
		world_dig_block = (delegate* unmanaged[Cdecl]<IntPtr, Vector3i, IntPtr, void>) *(ptr + 103);
		world_do_explosion_at = (delegate* unmanaged[Cdecl]<IntPtr, double, Vector3d, bool, ExplosionSource, IntPtr, void>) *(ptr + 104);
		world_get_game_mode = (delegate* unmanaged[Cdecl]<IntPtr, GameMode>) *(ptr + 105);
		world_get_weather = (delegate* unmanaged[Cdecl]<IntPtr, Weather>) *(ptr + 106);
		world_set_weather = (delegate* unmanaged[Cdecl]<IntPtr, Weather, void>) *(ptr + 107);
		world_get_time_of_day = (delegate* unmanaged[Cdecl]<IntPtr, int>) *(ptr + 108);
		world_set_time_of_day = (delegate* unmanaged[Cdecl]<IntPtr, int, void>) *(ptr + 109);
		world_get_world_age = (delegate* unmanaged[Cdecl]<IntPtr, long>) *(ptr + 110);
		world_get_world_tick_age = (delegate* unmanaged[Cdecl]<IntPtr, long>) *(ptr + 111);
		world_get_world_date = (delegate* unmanaged[Cdecl]<IntPtr, long>) *(ptr + 112);
		world_for_each_player = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>) *(ptr + 113);
		world_cast_thunderbolt = (delegate* unmanaged[Cdecl]<IntPtr, Vector3i, void>) *(ptr + 114);
		create_item = (delegate* unmanaged[Cdecl]<short, byte, short, string, string, IntPtr, int, IntPtr>) *(ptr + 115);
		delete_item = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 116);
		create_pickup = (delegate* unmanaged[Cdecl]<Vector3d, IntPtr, bool, Vector3f, int, bool, IntPtr>) *(ptr + 117);
		delete_pickup = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 118);
		create_composite_chat_1 = (delegate* unmanaged[Cdecl]<IntPtr>) *(ptr + 119);
		create_composite_chat_2 = (delegate* unmanaged[Cdecl]<string, MessageType, IntPtr>) *(ptr + 120);
		delete_composite_chat = (delegate* unmanaged[Cdecl]<IntPtr, void>) *(ptr + 121);

	}
}
