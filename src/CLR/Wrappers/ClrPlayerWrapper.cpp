#include "ClrPlayerWrapper.h"

const char * ClrPlayerWrapper::entities_player_get_name(cPlayer * player) {
	if (player != nullptr)
		return player->GetName().c_str();
	return nullptr;
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
