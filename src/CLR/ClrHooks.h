// This file is auto-generated, please do not modify manually
#pragma once

#include "../Root.h"

typedef void (*CallPluginsLoadDef) ();
typedef bool (*ExecuteCommandCallbackDef) (void *, const AString &, void *, int, cPlayer *);
typedef bool (*ExecuteForEachWorldCallbackDef) (void *, cWorld *);
typedef bool (*ExecuteForEachPlayerCallbackDef) (void *, cPlayer *);
typedef void (*OnTickDef) (float);
typedef bool (*OnChatDef) (cPlayer *, const char *);
typedef bool (*OnExecuteCommandDef) (cPlayer *, void *, int, const char *, CommandResult &);
typedef bool (*OnPlayerBreakingBlockDef) (cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerBrokenBlockDef) (cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerSpawnedDef) (cPlayer *);
typedef bool (*OnWorldTickDef) (cWorld *, float, float);


class ClrHooks
{
  public:
	CallPluginsLoadDef CallPluginsLoad;
	ExecuteCommandCallbackDef ExecuteCommandCallback;
	ExecuteForEachWorldCallbackDef ExecuteForEachWorldCallback;
	ExecuteForEachPlayerCallbackDef ExecuteForEachPlayerCallback;
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
		ExecuteForEachWorldCallback = (bool(*)(void *, cWorld *))(*(hooks + 2));
		ExecuteForEachPlayerCallback = (bool(*)(void *, cPlayer *))(*(hooks + 3));
		OnTick = (void(*)(float))(*(hooks + 4));
		OnChat = (bool(*)(cPlayer *, const char *))(*(hooks + 5));
		OnExecuteCommand = (bool(*)(cPlayer *, void *, int, const char *, CommandResult &))(*(hooks + 6));
		OnPlayerBreakingBlock = (bool(*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 7));
		OnPlayerBrokenBlock = (bool(*)(cPlayer *, int, int, int, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 8));
		OnPlayerSpawned = (bool(*)(cPlayer *))(*(hooks + 9));
		OnWorldTick = (bool(*)(cWorld *, float, float))(*(hooks + 10));

	}
};
