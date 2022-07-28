// This file is auto-generated, please do not modify manually
#pragma once

#include "../Root.h"

typedef void (*CallPluginsLoadDef) ();
typedef bool (*ExecuteCommandCallbackDef) (void *, const AString &, void *, int, cPlayer *);
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
	CallPluginsLoadDef CallPluginsLoad;
	ExecuteCommandCallbackDef ExecuteCommandCallback;
	OnTickDef OnTick;
	OnChatDef OnChat;
	OnExecuteCommandDef OnExecuteCommand;
	OnPlayerBreakingBlockDef OnPlayerBreakingBlock;
	OnPlayerBrokenBlockDef OnPlayerBrokenBlock;
	OnPlayerSpawnedDef OnPlayerSpawned;
	OnWorldTickDef OnWorldTick;

	inline void initializeHooks(void ** hooks)
	{
		CallPluginsLoad = (void(*)())(*(hooks + 0));
		ExecuteCommandCallback = (bool(*)(void *, const AString &, void *, int, cPlayer *))(*(hooks + 1));
		OnTick = (void(*)(float))(*(hooks + 2));
		OnChat = (bool(*)(cPlayer *, const char *))(*(hooks + 3));
		OnExecuteCommand = (bool(*)(cPlayer *, void *, int, const char *))(*(hooks + 4));
		OnPlayerBreakingBlock = (bool(*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 5));
		OnPlayerBrokenBlock = (bool(*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 6));
		OnPlayerSpawned = (bool(*)(cPlayer *))(*(hooks + 7));
		OnWorldTick = (bool(*)(cWorld *, float, float))(*(hooks + 8));

	}
};
