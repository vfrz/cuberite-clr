#include "ClrWrapper.h"

// Player
float ClrWrapper::entities_player_get_health(cPlayer * player)
{
	if (player != nullptr)
		return player->GetHealth();
	return -1;
}

void ClrWrapper::entities_player_set_health(cPlayer * player, float health)
{
	if (player != nullptr)
		player->SetHealth(health);
}

const char * ClrWrapper::entities_player_get_name(cPlayer * player)
{
	if (player != nullptr)
		return player->GetName().c_str();
	return nullptr;
}

std::array<Byte, 16> ClrWrapper::entities_player_get_uuid(cPlayer * player)
{
	if (player != nullptr)
		return player->GetUUID().ToRaw();
	return {};
}



// Root
void ClrWrapper::root_broadcast_chat(char * message, eMessageType messageType)
{
	cRoot::Get()->BroadcastChat(message, messageType);
}


/*
cPlayer * ClrPlayerWrapper::get_player()
{
	cPlayer * player = nullptr;
	cRoot::Get()->ForEachPlayer([&](cPlayer & p) {
		player = &p;
		return true;
	});
	return player;
}*/
