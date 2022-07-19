#ifndef CUBERITE_CLRPLAYERWRAPPER_H
#define CUBERITE_CLRPLAYERWRAPPER_H

#include <Entities/Player.h>

namespace ClrPlayerWrapper
{
extern "C"
{
	const char * entities_player_get_name(cPlayer * player);
}
}


#endif
