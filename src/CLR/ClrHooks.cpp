#include "ClrHooks.h"

void ClrHooks::initializeHooks(void ** hooks)
{
	OnChat = (bool(*)(cPlayer *, const char *))(*(hooks + 0));
	OnPlayerBrokenBlock = (bool (*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 1));
	OnPlayerBreakingBlock = (bool (*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 2));
}
