// This file is auto-generated, please do not modify manually
#pragma once

#include "Entities/Player.h"

namespace ClrWrapper
{
extern "C"
{
	void cuberite_log(char * message);
	void cuberite_log_info(char * message);
	void cuberite_log_warning(char * message);
	void cuberite_log_error(char * message);
	void cuberite_log_debug(char * message);
	float entity_get_health(cEntity * entity);
	void entity_set_health(cEntity * entity, float health);
	bool entity_is_invisible(cEntity * entity);
	char inventory_add_item(cInventory * inventory, cItem * item);
	eGameMode player_get_game_mode(cPlayer * player);
	void player_set_game_mode(cPlayer * player, eGameMode gameMode);
	const cInventory * player_get_inventory(cPlayer * player);
	const char * player_get_name(cPlayer * player);
	void player_set_visible(cPlayer * player, bool visible);
	std::array<Byte, 16> player_get_uuid(cPlayer * player);
	const cClientHandle * player_get_client_handle(cPlayer * player);
	void root_broadcast_chat(char * message, eMessageType type);
	cWorld * root_get_default_world();
	bool world_are_command_blocks_enabled(cWorld * world);
	void world_set_command_blocks_enabled(cWorld * world, bool enabled);
	BLOCKTYPE world_get_block(cWorld * world, int x, int y, int z);
	void world_set_block(cWorld * world, int x, int y, int z, BLOCKTYPE type, NIBBLETYPE meta);
	void world_broadcast_chat(cWorld * world, char * message, cClientHandle * except, eMessageType type);
	void world_dig_block(cWorld * world, int x, int y, int z, cEntity * digger);
	void world_do_explosion_at(cWorld * world, double size, double x, double y, double z, bool canCauseFire, eExplosionSource source, void * sourceData);
	eGameMode world_get_game_mode(cWorld * world);
	eWeather world_get_weather(cWorld * world);
	void world_set_weather(cWorld * world, eWeather weather);
	const cItem * create_item(short type, char count, short damage, char * enchantments, char * customName, char ** loreTable, int loreTableLength);
	void delete_item(cItem * item);

}

inline std::vector<void *> get_wrapper_functions()
{
	std::vector<void *> wrappers_functions(30);

	wrappers_functions[0] = (void *)&ClrWrapper::cuberite_log;
	wrappers_functions[1] = (void *)&ClrWrapper::cuberite_log_info;
	wrappers_functions[2] = (void *)&ClrWrapper::cuberite_log_warning;
	wrappers_functions[3] = (void *)&ClrWrapper::cuberite_log_error;
	wrappers_functions[4] = (void *)&ClrWrapper::cuberite_log_debug;
	wrappers_functions[5] = (void *)&ClrWrapper::entity_get_health;
	wrappers_functions[6] = (void *)&ClrWrapper::entity_set_health;
	wrappers_functions[7] = (void *)&ClrWrapper::entity_is_invisible;
	wrappers_functions[8] = (void *)&ClrWrapper::inventory_add_item;
	wrappers_functions[9] = (void *)&ClrWrapper::player_get_game_mode;
	wrappers_functions[10] = (void *)&ClrWrapper::player_set_game_mode;
	wrappers_functions[11] = (void *)&ClrWrapper::player_get_inventory;
	wrappers_functions[12] = (void *)&ClrWrapper::player_get_name;
	wrappers_functions[13] = (void *)&ClrWrapper::player_set_visible;
	wrappers_functions[14] = (void *)&ClrWrapper::player_get_uuid;
	wrappers_functions[15] = (void *)&ClrWrapper::player_get_client_handle;
	wrappers_functions[16] = (void *)&ClrWrapper::root_broadcast_chat;
	wrappers_functions[17] = (void *)&ClrWrapper::root_get_default_world;
	wrappers_functions[18] = (void *)&ClrWrapper::world_are_command_blocks_enabled;
	wrappers_functions[19] = (void *)&ClrWrapper::world_set_command_blocks_enabled;
	wrappers_functions[20] = (void *)&ClrWrapper::world_get_block;
	wrappers_functions[21] = (void *)&ClrWrapper::world_set_block;
	wrappers_functions[22] = (void *)&ClrWrapper::world_broadcast_chat;
	wrappers_functions[23] = (void *)&ClrWrapper::world_dig_block;
	wrappers_functions[24] = (void *)&ClrWrapper::world_do_explosion_at;
	wrappers_functions[25] = (void *)&ClrWrapper::world_get_game_mode;
	wrappers_functions[26] = (void *)&ClrWrapper::world_get_weather;
	wrappers_functions[27] = (void *)&ClrWrapper::world_set_weather;
	wrappers_functions[28] = (void *)&ClrWrapper::create_item;
	wrappers_functions[29] = (void *)&ClrWrapper::delete_item;


	return wrappers_functions;
}
}  // namespace ClrWrapper
