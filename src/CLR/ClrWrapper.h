#ifndef CUBERITE_CLRWRAPPER_H
#define CUBERITE_CLRWRAPPER_H

#include "Entities/Player.h"

namespace ClrWrapper
{


extern "C"
{
	// Player
	float entities_player_get_health(cPlayer * player);
	void entities_player_set_health(cPlayer * player, float health);
	const char * entities_player_get_name(cPlayer * player);
	std::array<Byte, 16> entities_player_get_uuid(cPlayer * player);


	// Root
	void root_broadcast_chat(char * message, eMessageType messageType);
}
}


#endif
