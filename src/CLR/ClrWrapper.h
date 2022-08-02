// This file is auto-generated, please do not modify manually
#pragma once

#include <vector>
#include "Entities/Player.h"
#include "Entities/Entity.h"
#include "Globals.h"

namespace ClrWrapper
{
extern "C"
{
	void log_default(char * message);
	void log_info(char * message);
	void log_warning(char * message);
	void log_error(char * message);
	void log_debug(char * message);
	bool bind_command(char * name, void * callback, char * permission, char * helpString);
	float entity_get_health(cEntity * entity);
	void entity_set_health(cEntity * entity, float health);
	bool entity_is_invisible(cEntity * entity);
	cWorld * entity_get_world(cEntity * entity);
	void entity_take_damage_1(cEntity * entity, cEntity & attacker);
	void entity_take_damage_2(cEntity * entity, eDamageType type, cEntity * attacker, int rawDamage, double knockbackAmount);
	void entity_take_damage_3(cEntity * entity, eDamageType type, int attacker, int rawDamage, double knockbackAmount);
	void entity_take_damage_4(cEntity * entity, eDamageType type, cEntity * attacker, int rawDamage, float finalDamage, double knockbackAmount);
	void entity_heal(cEntity * entity, int hitPoints);
	cEntity::eEntityType entity_get_entity_type(cEntity * entity);
	const Vector3d * entity_get_position(cEntity * entity);
	char inventory_add_item(cInventory * inventory, cItem * item);
	eGameMode player_get_game_mode(cPlayer * player);
	void player_set_game_mode(cPlayer * player, eGameMode gameMode);
	const cInventory * player_get_inventory(cPlayer * player);
	const char * player_get_name(cPlayer * player);
	void player_set_visible(cPlayer * player, bool visible);
	std::array<Byte, 16> player_get_uuid(cPlayer * player);
	const cClientHandle * player_get_client_handle(cPlayer * player);
	void player_send_message(cPlayer * player, char * message);
	bool player_feed(cPlayer * player, int food, double saturation);
	void player_set_respawn_location(cPlayer * player, Vector3i position, const cWorld & world);
	void root_broadcast_chat(char * message, eMessageType type);
	cWorld * root_get_default_world();
	bool root_for_each_world(void * callback);
	bool root_for_each_player(void * callback);
	cPlayer * client_handle_get_player(cClientHandle * clientHandle);
	bool world_are_command_blocks_enabled(cWorld * world);
	void world_set_command_blocks_enabled(cWorld * world, bool enabled);
	const char * world_get_name(cWorld * world);
	BLOCKTYPE world_get_block(cWorld * world, Vector3i position);
	void world_set_block(cWorld * world, Vector3i position, BLOCKTYPE type, NIBBLETYPE meta);
	void world_broadcast_chat(cWorld * world, char * message, cClientHandle * except, eMessageType type);
	void world_dig_block(cWorld * world, Vector3i position, cEntity * digger);
	void world_do_explosion_at(cWorld * world, double size, Vector3d position, bool canCauseFire, eExplosionSource source, void * sourceData);
	eGameMode world_get_game_mode(cWorld * world);
	eWeather world_get_weather(cWorld * world);
	void world_set_weather(cWorld * world, eWeather weather);
	int world_get_time_of_day(cWorld * world);
	void world_set_time_of_day(cWorld * world, int time);
	long long int world_get_world_age(cWorld * world);
	long long int world_get_world_tick_age(cWorld * world);
	long long int world_get_world_date(cWorld * world);
	bool world_for_each_player(cWorld * world, void * callback);
	const cItem * create_item(short type, char count, short damage, char * enchantments, char * customName, char ** loreTable, int loreTableLength);
	void delete_item(cItem * item);

}

inline std::vector<void *> get_wrapper_functions()
{
	std::vector<void *> wrappers_functions(52);

	wrappers_functions[0] = (void *)&ClrWrapper::log_default;
	wrappers_functions[1] = (void *)&ClrWrapper::log_info;
	wrappers_functions[2] = (void *)&ClrWrapper::log_warning;
	wrappers_functions[3] = (void *)&ClrWrapper::log_error;
	wrappers_functions[4] = (void *)&ClrWrapper::log_debug;
	wrappers_functions[5] = (void *)&ClrWrapper::bind_command;
	wrappers_functions[6] = (void *)&ClrWrapper::entity_get_health;
	wrappers_functions[7] = (void *)&ClrWrapper::entity_set_health;
	wrappers_functions[8] = (void *)&ClrWrapper::entity_is_invisible;
	wrappers_functions[9] = (void *)&ClrWrapper::entity_get_world;
	wrappers_functions[10] = (void *)&ClrWrapper::entity_take_damage_1;
	wrappers_functions[11] = (void *)&ClrWrapper::entity_take_damage_2;
	wrappers_functions[12] = (void *)&ClrWrapper::entity_take_damage_3;
	wrappers_functions[13] = (void *)&ClrWrapper::entity_take_damage_4;
	wrappers_functions[14] = (void *)&ClrWrapper::entity_heal;
	wrappers_functions[15] = (void *)&ClrWrapper::entity_get_entity_type;
	wrappers_functions[16] = (void *)&ClrWrapper::entity_get_position;
	wrappers_functions[17] = (void *)&ClrWrapper::inventory_add_item;
	wrappers_functions[18] = (void *)&ClrWrapper::player_get_game_mode;
	wrappers_functions[19] = (void *)&ClrWrapper::player_set_game_mode;
	wrappers_functions[20] = (void *)&ClrWrapper::player_get_inventory;
	wrappers_functions[21] = (void *)&ClrWrapper::player_get_name;
	wrappers_functions[22] = (void *)&ClrWrapper::player_set_visible;
	wrappers_functions[23] = (void *)&ClrWrapper::player_get_uuid;
	wrappers_functions[24] = (void *)&ClrWrapper::player_get_client_handle;
	wrappers_functions[25] = (void *)&ClrWrapper::player_send_message;
	wrappers_functions[26] = (void *)&ClrWrapper::player_feed;
	wrappers_functions[27] = (void *)&ClrWrapper::player_set_respawn_location;
	wrappers_functions[28] = (void *)&ClrWrapper::root_broadcast_chat;
	wrappers_functions[29] = (void *)&ClrWrapper::root_get_default_world;
	wrappers_functions[30] = (void *)&ClrWrapper::root_for_each_world;
	wrappers_functions[31] = (void *)&ClrWrapper::root_for_each_player;
	wrappers_functions[32] = (void *)&ClrWrapper::client_handle_get_player;
	wrappers_functions[33] = (void *)&ClrWrapper::world_are_command_blocks_enabled;
	wrappers_functions[34] = (void *)&ClrWrapper::world_set_command_blocks_enabled;
	wrappers_functions[35] = (void *)&ClrWrapper::world_get_name;
	wrappers_functions[36] = (void *)&ClrWrapper::world_get_block;
	wrappers_functions[37] = (void *)&ClrWrapper::world_set_block;
	wrappers_functions[38] = (void *)&ClrWrapper::world_broadcast_chat;
	wrappers_functions[39] = (void *)&ClrWrapper::world_dig_block;
	wrappers_functions[40] = (void *)&ClrWrapper::world_do_explosion_at;
	wrappers_functions[41] = (void *)&ClrWrapper::world_get_game_mode;
	wrappers_functions[42] = (void *)&ClrWrapper::world_get_weather;
	wrappers_functions[43] = (void *)&ClrWrapper::world_set_weather;
	wrappers_functions[44] = (void *)&ClrWrapper::world_get_time_of_day;
	wrappers_functions[45] = (void *)&ClrWrapper::world_set_time_of_day;
	wrappers_functions[46] = (void *)&ClrWrapper::world_get_world_age;
	wrappers_functions[47] = (void *)&ClrWrapper::world_get_world_tick_age;
	wrappers_functions[48] = (void *)&ClrWrapper::world_get_world_date;
	wrappers_functions[49] = (void *)&ClrWrapper::world_for_each_player;
	wrappers_functions[50] = (void *)&ClrWrapper::create_item;
	wrappers_functions[51] = (void *)&ClrWrapper::delete_item;


	return wrappers_functions;
}
}  // namespace ClrWrapper
