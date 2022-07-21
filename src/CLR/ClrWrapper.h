#ifndef CUBERITE_CLRWRAPPER_H
#define CUBERITE_CLRWRAPPER_H

#include "Entities/Player.h"

namespace ClrWrapper
{
extern "C"
{
	// Cuberite internal
	void cuberite_log(char * message);
	void cuberite_log_info(char * message);
	void cuberite_log_warning(char * message);
	void cuberite_log_error(char * message);
	void cuberite_log_debug(char * message);

	// Entity
	float entity_get_health(cEntity * entity);
	void entity_set_health(cEntity * entity, float health);
	bool entity_is_invisible(cEntity * entity);

	// Inventory
	char inventory_add_item(cInventory * inventory, cItem * item);
	cItem * inventory_find_item(const cItem & a_RecipeItem);

	// Player
	eGameMode player_get_game_mode(cPlayer * player);
	void player_set_game_mode(cPlayer * player, eGameMode gameMode);
	const cInventory * player_get_inventory(cPlayer * player);
	const char * player_get_name(cPlayer * player);
	void player_set_visible(cPlayer * player, bool visible);
	std::array<Byte, 16> player_get_uuid(cPlayer * player);
	const cClientHandle * player_get_client_handle(cPlayer * player);

	// Root
	void root_broadcast_chat(char * message, eMessageType messageType);

	// World
	bool world_are_command_blocks_enabled(cWorld * world);
	void world_set_command_blocks_enabled(cWorld * world, bool enabled);
	BLOCKTYPE world_get_block(cWorld * world, int x, int y, int z);
	void world_set_block(
		cWorld * world, int x, int y, int z, BLOCKTYPE type, NIBBLETYPE meta);
	void world_broadcast_chat(
		cWorld * world, char * message, cClientHandle * except,
		eMessageType messageType);
	void world_dig_block(cWorld * world, int x, int y, int z, cEntity * digger);
	void world_do_explosion_at(
		cWorld * world, double size, double x, double y, double z,
		bool canCauseFire, eExplosionSource source, void * sourceData);
	eGameMode world_get_game_mode(cWorld * world);
	eWeather world_get_weather(cWorld * world);
	void world_set_weather(cWorld * world, eWeather weather);

	// Objects creation
	void delete_item(cItem * item);
	const cItem * create_item(
		short itemType, char itemCount, short itemDamage, char * enchantments,
		char * customName, char ** loreTable, int loreTableLength);
}
}  // namespace ClrWrapper

#endif
