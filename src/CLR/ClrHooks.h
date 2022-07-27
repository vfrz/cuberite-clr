#pragma once

#include "../Root.h"

typedef bool (*OnChatTypeDef) (cPlayer *, const char *);
typedef bool (*OnPlayerBreakingBlockTypeDef) (cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerBrokenBlockTypeDef) (cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE);

class ClrHooks
{
  public:
	void initializeHooks(void ** hooks);
	OnChatTypeDef OnChat;
	OnPlayerBreakingBlockTypeDef OnPlayerBreakingBlock;
	OnPlayerBrokenBlockTypeDef OnPlayerBrokenBlock;
};

