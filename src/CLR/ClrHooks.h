// This file is auto-generated, please do not modify manually
#pragma once

#include "../Root.h"

typedef void (*OnTickDef) (float);
typedef bool (*OnChatDef) (cPlayer *,const char *);
typedef bool (*OnPlayerBreakingBlockDef) (cPlayer *,int,int,int,eBlockFace,BLOCKTYPE,NIBBLETYPE);
typedef bool (*OnPlayerBrokenBlockDef) (cPlayer *,int,int,int,eBlockFace,BLOCKTYPE,NIBBLETYPE);
typedef bool (*OnPlayerSpawnedDef) (cPlayer *);
typedef bool (*OnWorldTickDef) (cWorld *,float,float);


class ClrHooks
{
  public:
	OnTickDef OnTick;
	OnChatDef OnChat;
	OnPlayerBreakingBlockDef OnPlayerBreakingBlock;
	OnPlayerBrokenBlockDef OnPlayerBrokenBlock;
	OnPlayerSpawnedDef OnPlayerSpawned;
	OnWorldTickDef OnWorldTick;

	inline void initializeHooks(void ** hooks)
	{
		OnTick = (void(*)(float))(*(hooks + 0));
		OnChat = (bool(*)(cPlayer *,const char *))(*(hooks + 1));
		OnPlayerBreakingBlock = (bool(*)(cPlayer *,int,int,int,eBlockFace,BLOCKTYPE,NIBBLETYPE))(*(hooks + 2));
		OnPlayerBrokenBlock = (bool(*)(cPlayer *,int,int,int,eBlockFace,BLOCKTYPE,NIBBLETYPE))(*(hooks + 3));
		OnPlayerSpawned = (bool(*)(cPlayer *))(*(hooks + 4));
		OnWorldTick = (bool(*)(cWorld *,float,float))(*(hooks + 5));

	}
};
