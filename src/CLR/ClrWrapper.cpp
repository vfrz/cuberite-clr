#include "ClrWrapper.h"

// Cuberite internal
void ClrWrapper::cuberite_log(char * message) { LOG(message); }

void ClrWrapper::cuberite_log_info(char * message) { LOGINFO(message); }

void ClrWrapper::cuberite_log_warning(char * message) { LOGWARNING(message); }

void ClrWrapper::cuberite_log_error(char * message) { LOGERROR(message); }

void ClrWrapper::cuberite_log_debug(char * message) { LOGD(message); }

// Entity
float ClrWrapper::entity_get_health(cEntity * entity)
{
	if (entity != nullptr)
		return entity->GetHealth();
	return -1;
}

void ClrWrapper::entity_set_health(cEntity * entity, float health)
{
	if (entity != nullptr)
		entity->SetHealth(health);
}

bool ClrWrapper::entity_is_invisible(cEntity * entity)
{
	if (entity != nullptr)
		return entity->IsInvisible();
	return false;
}

// Inventory
char ClrWrapper::inventory_add_item(cInventory * inventory, cItem * item)
{
	if (inventory != nullptr)
		return inventory->AddItem(*item);
	return 0;
}

// Player
eGameMode ClrWrapper::player_get_game_mode(cPlayer * player)
{
	if (player != nullptr)
		player->GetGameMode();
	return eGameMode::eGameMode_NotSet;
}

void ClrWrapper::player_set_game_mode(cPlayer * player, eGameMode gameMode)
{
	if (player != nullptr)
		player->SetGameMode(gameMode);
}

const cInventory * ClrWrapper::player_get_inventory(cPlayer * player)
{
	if (player != nullptr)
		return &player->GetInventory();
	return nullptr;
}

const char * ClrWrapper::player_get_name(cPlayer * player)
{
	if (player != nullptr)
		return player->GetName().c_str();
	return nullptr;
}

void ClrWrapper::player_set_visible(cPlayer * player, bool visible)
{
	if (player != nullptr)
		player->SetVisible(visible);
}

std::array<Byte, 16> ClrWrapper::player_get_uuid(cPlayer * player)
{
	if (player != nullptr)
		return player->GetUUID().ToRaw();
	return {};
}

const cClientHandle * ClrWrapper::player_get_client_handle(cPlayer * player)
{
	if (player != nullptr)
		return player->GetClientHandle();
	return nullptr;
}

// Root
void ClrWrapper::root_broadcast_chat(char * message, eMessageType messageType)
{
	cRoot::Get()->BroadcastChat(message, messageType);
}

// World
bool ClrWrapper::world_are_command_blocks_enabled(cWorld * world)
{
	if (world != nullptr)
		return world->AreCommandBlocksEnabled();
	return false;
}

void ClrWrapper::world_set_command_blocks_enabled(cWorld * world, bool enabled)
{
	if (world != nullptr)
		world->SetCommandBlocksEnabled(enabled);
}

BLOCKTYPE ClrWrapper::world_get_block(cWorld * world, int x, int y, int z)
{
	if (world != nullptr)
		return world->GetBlock(Vector3i(x, y, z));
	return ENUM_BLOCK_TYPE::E_BLOCK_AIR;
}

void ClrWrapper::world_set_block(
	cWorld * world, int x, int y, int z, BLOCKTYPE type, NIBBLETYPE meta)
{
	if (world != nullptr)
		world->SetBlock(Vector3i(x, y, z), type, meta);
}

void ClrWrapper::world_broadcast_chat(
	cWorld * world, char * message, cClientHandle * except,
	eMessageType messageType)
{
	if (world != nullptr)
		world->BroadcastChat(message, except, messageType);
}

void ClrWrapper::world_dig_block(
	cWorld * world, int x, int y, int z, cEntity * digger)
{
	if (world != nullptr)
		world->DigBlock(Vector3i(x, y, z), digger);
}

void ClrWrapper::world_do_explosion_at(
	cWorld * world, double size, double x, double y, double z,
	bool canCauseFire, eExplosionSource source, void * sourceData)
{
	if (world != nullptr)
		world->DoExplosionAt(size, x, y, z, canCauseFire, source, sourceData);
}

eGameMode ClrWrapper::world_get_game_mode(cWorld * world)
{
	if (world != nullptr)
		return world->GetGameMode();
	return eGameMode::eGameMode_NotSet;
}

eWeather ClrWrapper::world_get_weather(cWorld * world)
{
	if (world != nullptr)
		return world->GetWeather();
	return eWeather::eWeather_Sunny;
}

void ClrWrapper::world_set_weather(cWorld * world, eWeather weather)
{
	if (world != nullptr)
		world->SetWeather(weather);
}

// Objects creation
const cItem * ClrWrapper::create_item(
	short itemType, char itemCount, short itemDamage, char * enchantments,
	char * customName, char ** loreTable, int loreTableLength)
{
	const cItem * item = new cItem(
		itemType, itemCount, itemDamage, enchantments, customName,
		AStringVector(loreTable, loreTable + loreTableLength));
	return item;
}

void ClrWrapper::delete_item(cItem * item) { delete item; }