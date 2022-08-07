// This file is auto-generated, please do not modify manually
#pragma once

#include <vector>
#include "Entities/Pickup.h"
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
	const char * item_type_to_string(short itemType);
	const char * enchantments_to_string(cEnchantments * enchantments);
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
	const char * entity_get_class(cEntity * entity);
	bool entity_is_a(cEntity * entity, char * className);
	const char * entity_get_parent_class(cEntity * entity);
	char inventory_add_item(cInventory * inventory, cItem * item);
	short item_get_type(cItem * item);
	char item_get_count(cItem * item);
	short item_get_damage(cItem * item);
	const char * item_get_custom_name(cItem * item);
	cEnchantments * item_get_enchantments(cItem * item);
	bool pickup_is_player_created(cPickup * pickup);
	bool pickup_is_collected(cPickup * pickup);
	bool pickup_can_combine(cPickup * pickup);
	void pickup_set_can_combine(cPickup * pickup, bool canCombine);
	bool pickup_collected_by(cPickup * pickup, cEntity * entity);
	int pickup_get_age(cPickup * pickup);
	void pickup_set_age(cPickup * pickup, int age);
	int pickup_get_lifetime(cPickup * pickup);
	void pickup_set_lifetime(cPickup * pickup, int lifetime);
	cItem * pickup_get_item(cPickup * pickup);
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
	const cItem * player_get_equipped_item(cPlayer * player);
	void player_freeze(cPlayer * player, Vector3d position);
	bool player_is_frozen(cPlayer * player);
	void player_unfreeze(cPlayer * player);
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
	const cPickup * create_pickup(Vector3d position, cItem * item, bool isPlayerCreated, Vector3f speed, int lifetimeTicks, bool canCombine);
	void delete_pickup(cPickup * pickup);

}

inline std::vector<void *> get_wrapper_functions()
{
	std::vector<void *> wrappers_functions(78);

	wrappers_functions[0] = (void *)&ClrWrapper::log_default;
	wrappers_functions[1] = (void *)&ClrWrapper::log_info;
	wrappers_functions[2] = (void *)&ClrWrapper::log_warning;
	wrappers_functions[3] = (void *)&ClrWrapper::log_error;
	wrappers_functions[4] = (void *)&ClrWrapper::log_debug;
	wrappers_functions[5] = (void *)&ClrWrapper::bind_command;
	wrappers_functions[6] = (void *)&ClrWrapper::item_type_to_string;
	wrappers_functions[7] = (void *)&ClrWrapper::enchantments_to_string;
	wrappers_functions[8] = (void *)&ClrWrapper::entity_get_health;
	wrappers_functions[9] = (void *)&ClrWrapper::entity_set_health;
	wrappers_functions[10] = (void *)&ClrWrapper::entity_is_invisible;
	wrappers_functions[11] = (void *)&ClrWrapper::entity_get_world;
	wrappers_functions[12] = (void *)&ClrWrapper::entity_take_damage_1;
	wrappers_functions[13] = (void *)&ClrWrapper::entity_take_damage_2;
	wrappers_functions[14] = (void *)&ClrWrapper::entity_take_damage_3;
	wrappers_functions[15] = (void *)&ClrWrapper::entity_take_damage_4;
	wrappers_functions[16] = (void *)&ClrWrapper::entity_heal;
	wrappers_functions[17] = (void *)&ClrWrapper::entity_get_entity_type;
	wrappers_functions[18] = (void *)&ClrWrapper::entity_get_position;
	wrappers_functions[19] = (void *)&ClrWrapper::entity_get_class;
	wrappers_functions[20] = (void *)&ClrWrapper::entity_is_a;
	wrappers_functions[21] = (void *)&ClrWrapper::entity_get_parent_class;
	wrappers_functions[22] = (void *)&ClrWrapper::inventory_add_item;
	wrappers_functions[23] = (void *)&ClrWrapper::item_get_type;
	wrappers_functions[24] = (void *)&ClrWrapper::item_get_count;
	wrappers_functions[25] = (void *)&ClrWrapper::item_get_damage;
	wrappers_functions[26] = (void *)&ClrWrapper::item_get_custom_name;
	wrappers_functions[27] = (void *)&ClrWrapper::item_get_enchantments;
	wrappers_functions[28] = (void *)&ClrWrapper::pickup_is_player_created;
	wrappers_functions[29] = (void *)&ClrWrapper::pickup_is_collected;
	wrappers_functions[30] = (void *)&ClrWrapper::pickup_can_combine;
	wrappers_functions[31] = (void *)&ClrWrapper::pickup_set_can_combine;
	wrappers_functions[32] = (void *)&ClrWrapper::pickup_collected_by;
	wrappers_functions[33] = (void *)&ClrWrapper::pickup_get_age;
	wrappers_functions[34] = (void *)&ClrWrapper::pickup_set_age;
	wrappers_functions[35] = (void *)&ClrWrapper::pickup_get_lifetime;
	wrappers_functions[36] = (void *)&ClrWrapper::pickup_set_lifetime;
	wrappers_functions[37] = (void *)&ClrWrapper::pickup_get_item;
	wrappers_functions[38] = (void *)&ClrWrapper::player_get_game_mode;
	wrappers_functions[39] = (void *)&ClrWrapper::player_set_game_mode;
	wrappers_functions[40] = (void *)&ClrWrapper::player_get_inventory;
	wrappers_functions[41] = (void *)&ClrWrapper::player_get_name;
	wrappers_functions[42] = (void *)&ClrWrapper::player_set_visible;
	wrappers_functions[43] = (void *)&ClrWrapper::player_get_uuid;
	wrappers_functions[44] = (void *)&ClrWrapper::player_get_client_handle;
	wrappers_functions[45] = (void *)&ClrWrapper::player_send_message;
	wrappers_functions[46] = (void *)&ClrWrapper::player_feed;
	wrappers_functions[47] = (void *)&ClrWrapper::player_set_respawn_location;
	wrappers_functions[48] = (void *)&ClrWrapper::player_get_equipped_item;
	wrappers_functions[49] = (void *)&ClrWrapper::player_freeze;
	wrappers_functions[50] = (void *)&ClrWrapper::player_is_frozen;
	wrappers_functions[51] = (void *)&ClrWrapper::player_unfreeze;
	wrappers_functions[52] = (void *)&ClrWrapper::root_broadcast_chat;
	wrappers_functions[53] = (void *)&ClrWrapper::root_get_default_world;
	wrappers_functions[54] = (void *)&ClrWrapper::root_for_each_world;
	wrappers_functions[55] = (void *)&ClrWrapper::root_for_each_player;
	wrappers_functions[56] = (void *)&ClrWrapper::client_handle_get_player;
	wrappers_functions[57] = (void *)&ClrWrapper::world_are_command_blocks_enabled;
	wrappers_functions[58] = (void *)&ClrWrapper::world_set_command_blocks_enabled;
	wrappers_functions[59] = (void *)&ClrWrapper::world_get_name;
	wrappers_functions[60] = (void *)&ClrWrapper::world_get_block;
	wrappers_functions[61] = (void *)&ClrWrapper::world_set_block;
	wrappers_functions[62] = (void *)&ClrWrapper::world_broadcast_chat;
	wrappers_functions[63] = (void *)&ClrWrapper::world_dig_block;
	wrappers_functions[64] = (void *)&ClrWrapper::world_do_explosion_at;
	wrappers_functions[65] = (void *)&ClrWrapper::world_get_game_mode;
	wrappers_functions[66] = (void *)&ClrWrapper::world_get_weather;
	wrappers_functions[67] = (void *)&ClrWrapper::world_set_weather;
	wrappers_functions[68] = (void *)&ClrWrapper::world_get_time_of_day;
	wrappers_functions[69] = (void *)&ClrWrapper::world_set_time_of_day;
	wrappers_functions[70] = (void *)&ClrWrapper::world_get_world_age;
	wrappers_functions[71] = (void *)&ClrWrapper::world_get_world_tick_age;
	wrappers_functions[72] = (void *)&ClrWrapper::world_get_world_date;
	wrappers_functions[73] = (void *)&ClrWrapper::world_for_each_player;
	wrappers_functions[74] = (void *)&ClrWrapper::create_item;
	wrappers_functions[75] = (void *)&ClrWrapper::delete_item;
	wrappers_functions[76] = (void *)&ClrWrapper::create_pickup;
	wrappers_functions[77] = (void *)&ClrWrapper::delete_pickup;


	return wrappers_functions;
}
}  // namespace ClrWrapper
