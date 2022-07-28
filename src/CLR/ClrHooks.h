// This file is auto-generated, please do not modify manually
#pragma once

#include "../Root.h"

typedef void (*LoadPluginsDef) ();
typedef void (*OnTickDef) (float);
typedef bool (*OnChatDef) (cPlayer *, const char *);
typedef bool (*OnExecuteCommandDef) (cPlayer *, void *, int, const char *);
typedef bool (*OnPlayerBreakingBlockDef) (cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerBrokenBlockDef) (cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerSpawnedDef) (cPlayer *);
typedef bool (*OnWorldTickDef) (cWorld *, float, float);


class ClrHooks
{
  public:
	LoadPluginsDef LoadPlugins;
	OnTickDef OnTick;
	OnChatDef OnChat;
	OnExecuteCommandDef OnExecuteCommand;
	OnPlayerBreakingBlockDef OnPlayerBreakingBlock;
	OnPlayerBrokenBlockDef OnPlayerBrokenBlock;
	OnPlayerSpawnedDef OnPlayerSpawned;
	OnWorldTickDef OnWorldTick;

	inline void initializeHooks(void ** hooks)
	{
		LoadPlugins = (void(*)())(*(hooks + 0));
		OnTick = (void(*)(float))(*(hooks + 1));
		OnChat = (bool(*)(cPlayer *, const char *))(*(hooks + 2));
		OnExecuteCommand = (bool(*)(cPlayer *, void *, int, const char *))(*(hooks + 3));
		OnPlayerBreakingBlock = (bool(*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 4));
		OnPlayerBrokenBlock = (bool(*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 5));
		OnPlayerSpawned = (bool(*)(cPlayer *))(*(hooks + 6));
		OnWorldTick = (bool(*)(cWorld *, float, float))(*(hooks + 7));

	}
};
