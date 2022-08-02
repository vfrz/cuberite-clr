#include "ClrWrapper.h"
#include "ClrCommandHandler.h"

// Cuberite internal
void ClrWrapper::log_default(char * message) { LOG(message); }

void ClrWrapper::log_info(char * message) { LOGINFO(message); }

void ClrWrapper::log_warning(char * message) { LOGWARNING(message); }

void ClrWrapper::log_error(char * message) { LOGERROR(message); }

void ClrWrapper::log_debug(char * message) { LOGD(message); }

bool ClrWrapper::bind_command(
	char * name, void * callback, char * permission, char * helpString)
{
	auto commandHandler = std::make_shared<ClrCommandHandler>(callback);
	return cRoot::Get()->GetPluginManager()->BindCommand(
		name, nullptr, commandHandler, permission, helpString);
}

// Entity
float ClrWrapper::entity_get_health(cEntity * entity)
{
	return entity->GetHealth();
}

void ClrWrapper::entity_set_health(cEntity * entity, float health)
{
	entity->SetHealth(health);
}

bool ClrWrapper::entity_is_invisible(cEntity * entity)
{
	return entity->IsInvisible();
}

cWorld * ClrWrapper::entity_get_world(cEntity * entity)
{
	return entity->GetWorld();
}

void ClrWrapper::entity_take_damage_1(cEntity * entity, cEntity & attacker)
{
	entity->TakeDamage(attacker);
}

void ClrWrapper::entity_take_damage_2(
	cEntity * entity, eDamageType type, cEntity * attacker, int rawDamage,
	double knockbackAmount)
{
	entity->TakeDamage(type, attacker, rawDamage, knockbackAmount);
}

void ClrWrapper::entity_take_damage_3(
	cEntity * entity, eDamageType type, int attacker, int rawDamage,
	double knockbackAmount)
{
	entity->TakeDamage(type, attacker, rawDamage, knockbackAmount);
}

void ClrWrapper::entity_take_damage_4(
	cEntity * entity, eDamageType type, cEntity * attacker, int rawDamage,
	float finalDamage, double knockbackAmount)
{
	entity->TakeDamage(type, attacker, rawDamage, finalDamage, knockbackAmount);
}

void ClrWrapper::entity_heal(cEntity * entity, int hitPoints)
{
	entity->Heal(hitPoints);
}

cEntity::eEntityType ClrWrapper::entity_get_entity_type(cEntity * entity)
{
	return entity->GetEntityType();
}

const Vector3d * ClrWrapper::entity_get_position(cEntity * entity)
{
	return &entity->GetPosition();
}


// Inventory
char ClrWrapper::inventory_add_item(cInventory * inventory, cItem * item)
{
	return inventory->AddItem(*item);
}

// Player
eGameMode ClrWrapper::player_get_game_mode(cPlayer * player)
{
	return player->GetGameMode();
}

void ClrWrapper::player_set_game_mode(cPlayer * player, eGameMode gameMode)
{
	player->SetGameMode(gameMode);
}

const cInventory * ClrWrapper::player_get_inventory(cPlayer * player)
{
	return &player->GetInventory();
}

const char * ClrWrapper::player_get_name(cPlayer * player)
{
	return player->GetName().c_str();
}

void ClrWrapper::player_set_visible(cPlayer * player, bool visible)
{
	player->SetVisible(visible);
}

std::array<Byte, 16> ClrWrapper::player_get_uuid(cPlayer * player)
{
	return player->GetUUID().ToRaw();
}

const cClientHandle * ClrWrapper::player_get_client_handle(cPlayer * player)
{
	return player->GetClientHandle();
}

void ClrWrapper::player_send_message(cPlayer * player, char * message)
{
	player->SendMessage(message);
}

bool ClrWrapper::player_feed(cPlayer * player, int food, double saturation)
{
	return player->Feed(food, saturation);
}

void ClrWrapper::player_set_respawn_location(
	cPlayer * player, Vector3i position, const cWorld & world)
{
	player->SetRespawnPosition(position, world);
}


// Root
void ClrWrapper::root_broadcast_chat(char * message, eMessageType messageType)
{
	cRoot::Get()->BroadcastChat(message, messageType);
}

cWorld * ClrWrapper::root_get_default_world()
{
	return cRoot::Get()->GetDefaultWorld();
}

bool ClrWrapper::root_for_each_world(void * callback)
{
	auto clrHooks = cRoot::Get()->GetPluginManager()->GetClrHooks();
	return cRoot::Get()->ForEachWorld([&](cWorld & world) {
		return clrHooks.ExecuteForEachWorldCallback(callback, &world);
	});
}

bool ClrWrapper::root_for_each_player(void * callback)
{
	auto clrHooks = cRoot::Get()->GetPluginManager()->GetClrHooks();
	return cRoot::Get()->ForEachPlayer([&](cPlayer & player) {
		return clrHooks.ExecuteForEachPlayerCallback(callback, &player);
	});
}

// Client handle
cPlayer * ClrWrapper::client_handle_get_player(cClientHandle * clientHandle)
{
	return clientHandle->GetPlayer();
}

// World
bool ClrWrapper::world_are_command_blocks_enabled(cWorld * world)
{
	return world->AreCommandBlocksEnabled();
}

void ClrWrapper::world_set_command_blocks_enabled(cWorld * world, bool enabled)
{
	world->SetCommandBlocksEnabled(enabled);
}

BLOCKTYPE ClrWrapper::world_get_block(cWorld * world, Vector3i position)
{
	return world->GetBlock(position);
}

const char * ClrWrapper::world_get_name(cWorld * world)
{
	return world->GetName().c_str();
}

void ClrWrapper::world_set_block(
	cWorld * world, Vector3i position, BLOCKTYPE type, NIBBLETYPE meta)
{
	world->SetBlock(position, type, meta);
}

void ClrWrapper::world_broadcast_chat(
	cWorld * world, char * message, cClientHandle * except,
	eMessageType messageType)
{
	world->BroadcastChat(message, except, messageType);
}

void ClrWrapper::world_dig_block(
	cWorld * world, Vector3i position, cEntity * digger)
{
	world->DigBlock(position, digger);
}

void ClrWrapper::world_do_explosion_at(
	cWorld * world, double size, Vector3d position,
	bool canCauseFire, eExplosionSource source, void * sourceData)
{
	world->DoExplosionAt(size, position.x, position.y, position.z, canCauseFire, source, sourceData);
}

eGameMode ClrWrapper::world_get_game_mode(cWorld * world)
{
	return world->GetGameMode();
}

eWeather ClrWrapper::world_get_weather(cWorld * world)
{
	return world->GetWeather();
}

void ClrWrapper::world_set_weather(cWorld * world, eWeather weather)
{
	world->SetWeather(weather);
}

int ClrWrapper::world_get_time_of_day(cWorld * world)
{
	return world->GetTimeOfDay().count();
}

void ClrWrapper::world_set_time_of_day(cWorld * world, int time)
{
	world->SetTimeOfDay(cTickTime(time));
}

long long int ClrWrapper::world_get_world_age(cWorld * world)
{
	return world->GetWorldAge().count();
}

long long int ClrWrapper::world_get_world_tick_age(cWorld * world)
{
	return world->GetWorldTickAge().count();
}

long long int ClrWrapper::world_get_world_date(cWorld * world)
{
	return world->GetWorldDate().count();
}

bool ClrWrapper::world_for_each_player(cWorld * world, void * callback)
{
	auto clrHooks = cRoot::Get()->GetPluginManager()->GetClrHooks();
	return world->ForEachPlayer([&](cPlayer & player) {
		return clrHooks.ExecuteForEachPlayerCallback(callback, &player);
	});
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
