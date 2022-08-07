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

const char * ClrWrapper::item_type_to_string(short itemType)
{
	auto name = std::make_shared<AString>(ItemTypeToString(itemType));
	return name->c_str();
}

// CompositeChat
void ClrWrapper::composite_chat_clear(cCompositeChat * compositeChat)
{
	compositeChat->Clear();
}

void ClrWrapper::composite_chat_add_text_part(
	cCompositeChat * compositeChat, char * message, char * style)
{
	compositeChat->AddTextPart(message, style);
}

eMessageType
ClrWrapper::composite_chat_get_message_type(cCompositeChat * compositeChat)
{
	return compositeChat->GetMessageType();
}

const char * ClrWrapper::composite_chat_get_additional_message_type_data(
	cCompositeChat * compositeChat)
{
	auto messageTypeData = std::make_shared<AString>(
		compositeChat->GetAdditionalMessageTypeData());
	return messageTypeData->c_str();
}

const char *
ClrWrapper::composite_chat_extract_text(cCompositeChat * compositeChat)
{
	auto text = std::make_shared<AString>(compositeChat->ExtractText());
	return text->c_str();
}

// Enchantments
const char * ClrWrapper::enchantments_to_string(cEnchantments * enchantments)
{
	auto name = std::make_shared<AString>(enchantments->ToString());
	return name->c_str();
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

Vector3d ClrWrapper::entity_get_position(cEntity * entity)
{
	return entity->GetPosition();
}

const char * ClrWrapper::entity_get_class(cEntity * entity)
{
	return entity->GetClass();
}

bool ClrWrapper::entity_is_a(cEntity * entity, char * className)
{
	return entity->IsA(className);
}

const char * ClrWrapper::entity_get_parent_class(cEntity * entity)
{
	return entity->GetParentClass();
}

void ClrWrapper::entity_teleport_to_coords(cEntity * entity, Vector3d position)
{
	entity->TeleportToCoords(position.x, position.y, position.z);
}

void ClrWrapper::entity_teleport_to_entity(cEntity * entity, cEntity * target)
{
	entity->TeleportToEntity(*target);
}

// Inventory
char ClrWrapper::inventory_add_item(
	cInventory * inventory, cItem * item, bool allowNewStacks)
{
	return inventory->AddItem(*item, allowNewStacks);
}

char ClrWrapper::inventory_add_items(
	cInventory * inventory, cItem ** itemStackList, int itemStackListLength,
	bool allowNewStacks)
{
	auto items = cItems();
	for (int i = 0; i < itemStackListLength; ++i)
		items.Add(*itemStackList[i]);
	return inventory->AddItems(items, allowNewStacks);
}

void ClrWrapper::inventory_clear(cInventory * inventory) { inventory->Clear(); }

int ClrWrapper::inventory_how_many_can_fit_1(
	cInventory * inventory, cItem * itemStack, bool considerEmptySlots)
{
	return inventory->HowManyCanFit(*itemStack, considerEmptySlots);
}

int ClrWrapper::inventory_how_many_can_fit_2(
	cInventory * inventory, cItem * itemStack, int beginSlotNum, int endSlotNum,
	bool considerEmptySlots)
{
	return inventory->HowManyCanFit(
		*itemStack, beginSlotNum, endSlotNum, considerEmptySlots);
}

int ClrWrapper::inventory_remove_item(cInventory * inventory, cItem * itemStack)
{
	return inventory->RemoveItem(*itemStack);
}

cItem *
ClrWrapper::inventory_find_item(cInventory * inventory, cItem * recipeItem)
{
	return inventory->FindItem(*recipeItem);
}

bool ClrWrapper::inventory_remove_one_equipped_item(cInventory * inventory)
{
	return inventory->RemoveOneEquippedItem();
}

bool ClrWrapper::inventory_replace_one_equipped_item(
	cInventory * inventory, cItem * item, bool tryOtherSlots)
{
	return inventory->ReplaceOneEquippedItem(*item, tryOtherSlots);
}

int ClrWrapper::inventory_how_many_items(cInventory * inventory, cItem * item)
{
	return inventory->HowManyItems(*item);
}

bool ClrWrapper::inventory_has_items(cInventory * inventory, cItem * itemStack)
{
	return inventory->HasItems(*itemStack);
}

cPlayer * ClrWrapper::inventory_get_owner(cInventory * inventory)
{
	return &inventory->GetOwner();
}

const cItem * ClrWrapper::inventory_get_slot(cInventory * inventory, int slotNum)
{
	return &inventory->GetSlot(slotNum);
}

const cItem *
ClrWrapper::inventory_get_armor_slot(cInventory * inventory, int armorSlotNum)
{
	return &inventory->GetArmorSlot(armorSlotNum);
}

const cItem * ClrWrapper::inventory_get_inventory_slot(
	cInventory * inventory, int inventorySlotNum)
{
	return &inventory->GetInventorySlot(inventorySlotNum);
}

const cItem *
ClrWrapper::inventory_get_hotbar_slot(cInventory * inventory, int hotbarSlotNum)
{
	return &inventory->GetHotbarSlot(hotbarSlotNum);
}

const cItem * ClrWrapper::inventory_get_shield_slot(cInventory * inventory)
{
	return &inventory->GetShieldSlot();
}

cItemGrid * ClrWrapper::inventory_get_armor_grid(cInventory * inventory)
{
	return &inventory->GetArmorGrid();
}

cItemGrid * ClrWrapper::inventory_get_inventory_grid(cInventory * inventory)
{
	return &inventory->GetInventoryGrid();
}

cItemGrid * ClrWrapper::inventory_get_hotbar_grid(cInventory * inventory)
{
	return &inventory->GetHotbarGrid();
}

const cItem * ClrWrapper::inventory_get_equipped_item(cInventory * inventory)
{
	return &inventory->GetEquippedItem();
}

// Item
short ClrWrapper::item_get_type(cItem * item) { return item->m_ItemType; }

char ClrWrapper::item_get_count(cItem * item) { return item->m_ItemCount; }

short ClrWrapper::item_get_damage(cItem * item) { return item->m_ItemDamage; }

const char * ClrWrapper::item_get_custom_name(cItem * item)
{
	return item->m_CustomName.c_str();
}

cEnchantments * ClrWrapper::item_get_enchantments(cItem * item)
{
	return &item->m_Enchantments;
}

// Pickup
bool ClrWrapper::pickup_is_player_created(cPickup * pickup)
{
	return pickup->IsPlayerCreated();
}

bool ClrWrapper::pickup_is_collected(cPickup * pickup)
{
	return pickup->IsCollected();
}

bool ClrWrapper::pickup_can_combine(cPickup * pickup)
{
	return pickup->CanCombine();
}

void ClrWrapper::pickup_set_can_combine(cPickup * pickup, bool canCombine)
{
	pickup->SetCanCombine(canCombine);
}

bool ClrWrapper::pickup_collected_by(cPickup * pickup, cEntity * entity)
{
	return pickup->CollectedBy(*entity);
}

int ClrWrapper::pickup_get_age(cPickup * pickup) { return pickup->GetAge(); }

void ClrWrapper::pickup_set_age(cPickup * pickup, int age)
{
	pickup->SetAge(age);
}

int ClrWrapper::pickup_get_lifetime(cPickup * pickup)
{
	return pickup->GetLifetime();
}

void ClrWrapper::pickup_set_lifetime(cPickup * pickup, int lifetime)
{
	pickup->SetLifetime(lifetime);
}

cItem * ClrWrapper::pickup_get_item(cPickup * pickup)
{
	return &pickup->GetItem();
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

const cItem * ClrWrapper::player_get_equipped_item(cPlayer * player)
{
	return &player->GetEquippedItem();
}

void ClrWrapper::player_freeze(cPlayer * player, Vector3d position)
{
	player->Freeze(position);
}

bool ClrWrapper::player_is_frozen(cPlayer * player)
{
	return player->IsFrozen();
}

void ClrWrapper::player_unfreeze(cPlayer * player) { player->Unfreeze(); }

void ClrWrapper::player_send_message_info(cPlayer * player, char * message)
{
	player->SendMessageInfo(message);
}

void ClrWrapper::player_send_message_failure(cPlayer * player, char * message)
{
	player->SendMessageFailure(message);
}

void ClrWrapper::player_send_message_success(cPlayer * player, char * message)
{
	player->SendMessageSuccess(message);
}

void ClrWrapper::player_send_message_warning(cPlayer * player, char * message)
{
	player->SendMessageWarning(message);
}

void ClrWrapper::player_send_message_fatal(cPlayer * player, char * message)
{
	player->SendMessageFatal(message);
}

void ClrWrapper::player_send_message_private_msg(
	cPlayer * player, char * message, char * sender)
{
	player->SendMessagePrivateMsg(message, sender);
}

void ClrWrapper::player_send_message_composite(
	cPlayer * player, cCompositeChat * message)
{
	player->SendMessage(*message);
}

void ClrWrapper::player_send_message_raw(
	cPlayer * player, char * message, eChatType type)
{
	player->SendMessageRaw(message, type);
}

void ClrWrapper::player_send_system_message(cPlayer * player, char * message)
{
	player->SendSystemMessage(message);
}

void ClrWrapper::player_send_above_action_bar_message(
	cPlayer * player, char * message)
{
	player->SendAboveActionBarMessage(message);
}

void ClrWrapper::player_send_system_message_composite(
	cPlayer * player, cCompositeChat * message)
{
	player->SendSystemMessage(*message);
}

void ClrWrapper::player_send_above_action_bar_message_composite(
	cPlayer * player, cCompositeChat * message)
{
	player->SendAboveActionBarMessage(*message);
}

bool ClrWrapper::player_has_permission(cPlayer * player, char * permission)
{
	return player->HasPermission(permission);
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
	cWorld * world, double size, Vector3d position, bool canCauseFire,
	eExplosionSource source, void * sourceData)
{
	world->DoExplosionAt(
		size, position.x, position.y, position.z, canCauseFire, source,
		sourceData);
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

void ClrWrapper::world_cast_thunderbolt(cWorld * world, Vector3i block)
{
	world->CastThunderbolt(block);
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

const cPickup * ClrWrapper::create_pickup(
	Vector3d position, cItem * item, bool isPlayerCreated, Vector3f speed,
	int lifetimeTicks, bool canCombine)
{
	const cPickup * pickup = new cPickup(
		position, *item, isPlayerCreated, speed, lifetimeTicks, canCombine);
	return pickup;
}

void ClrWrapper::delete_pickup(cPickup * pickup) { delete pickup; }

const cCompositeChat * ClrWrapper::create_composite_chat_1()
{
	const cCompositeChat * compositeChat = new cCompositeChat();
	return compositeChat;
}

const cCompositeChat *
ClrWrapper::create_composite_chat_2(char * parseText, eMessageType messageType)
{
	const cCompositeChat * compositeChat =
		new cCompositeChat(parseText, messageType);
	return compositeChat;
}

void ClrWrapper::delete_composite_chat(cCompositeChat * compositeChat)
{
	delete compositeChat;
}
