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
typedef bool (*OnLoginDef) (cClientHandle &, UInt32, const AString &);
typedef bool (*OnDisconnectDef) (cClientHandle &, const AString &);
typedef bool (*OnKilledDef) (cEntity *, TakeDamageInfo, const char *);
typedef bool (*OnKillingDef) (cEntity *, cEntity *, TakeDamageInfo);
typedef bool (*OnPlayerBreakingBlockDef) (cPlayer *, Vector3i, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerBrokenBlockDef) (cPlayer *, Vector3i, eBlockFace, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerSpawnedDef) (cPlayer *);
typedef bool (*OnPlayerMovingDef) (cPlayer *, Vector3d, Vector3d, bool);
typedef bool (*OnPlayerJoinedDef) (cPlayer *);
typedef bool (*OnPlayerUsedBlockDef) (cPlayer *, Vector3i, eBlockFace, Vector3i, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerUsedItemDef) (cPlayer *, Vector3i, eBlockFace, Vector3i);
typedef bool (*OnPlayerUsingBlockDef) (cPlayer *, Vector3i, eBlockFace, Vector3i, BLOCKTYPE, NIBBLETYPE);
typedef bool (*OnPlayerUsingItemDef) (cPlayer *, Vector3i, eBlockFace, Vector3i);
typedef bool (*OnPlayerTossingItemDef) (cPlayer *);
typedef bool (*OnPlayerPlacedBlockDef) (cPlayer *, sSetBlock);
typedef bool (*OnPlayerPlacingBlockDef) (cPlayer *, sSetBlock);
typedef bool (*OnWorldTickDef) (cWorld *, float, float);
typedef bool (*OnBlockSpreadDef) (cWorld *, Vector3i, eSpreadSource);
typedef bool (*OnBlockToPickupsDef) (cWorld *, Vector3i, BLOCKTYPE, NIBBLETYPE, const cBlockEntity *, const cEntity *, const cItem *, void *, int);
typedef bool (*OnCollectingPickupDef) (cPlayer *, cPickup *);


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
	OnLoginDef OnLogin;
	OnDisconnectDef OnDisconnect;
	OnKilledDef OnKilled;
	OnKillingDef OnKilling;
	OnPlayerBreakingBlockDef OnPlayerBreakingBlock;
	OnPlayerBrokenBlockDef OnPlayerBrokenBlock;
	OnPlayerSpawnedDef OnPlayerSpawned;
	OnPlayerMovingDef OnPlayerMoving;
	OnPlayerJoinedDef OnPlayerJoined;
	OnPlayerUsedBlockDef OnPlayerUsedBlock;
	OnPlayerUsedItemDef OnPlayerUsedItem;
	OnPlayerUsingBlockDef OnPlayerUsingBlock;
	OnPlayerUsingItemDef OnPlayerUsingItem;
	OnPlayerTossingItemDef OnPlayerTossingItem;
	OnPlayerPlacedBlockDef OnPlayerPlacedBlock;
	OnPlayerPlacingBlockDef OnPlayerPlacingBlock;
	OnWorldTickDef OnWorldTick;
	OnBlockSpreadDef OnBlockSpread;
	OnBlockToPickupsDef OnBlockToPickups;
	OnCollectingPickupDef OnCollectingPickup;

	inline void initializeHooks(void ** hooks)
	{
		CallPluginsLoad = (void(*)())(*(hooks + 0));
		ExecuteCommandCallback = (bool(*)(void *, const AString &, void *, int, cPlayer *))(*(hooks + 1));
		ExecuteForEachWorldCallback = (bool(*)(void *, cWorld *))(*(hooks + 2));
		ExecuteForEachPlayerCallback = (bool(*)(void *, cPlayer *))(*(hooks + 3));
		OnTick = (void(*)(float))(*(hooks + 4));
		OnChat = (bool(*)(cPlayer *, const char *))(*(hooks + 5));
		OnExecuteCommand = (bool(*)(cPlayer *, void *, int, const char *, CommandResult &))(*(hooks + 6));
		OnLogin = (bool(*)(cClientHandle &, UInt32, const AString &))(*(hooks + 7));
		OnDisconnect = (bool(*)(cClientHandle &, const AString &))(*(hooks + 8));
		OnKilled = (bool(*)(cEntity *, TakeDamageInfo, const char *))(*(hooks + 9));
		OnKilling = (bool(*)(cEntity *, cEntity *, TakeDamageInfo))(*(hooks + 10));
		OnPlayerBreakingBlock = (bool(*)(cPlayer *, Vector3i, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 11));
		OnPlayerBrokenBlock = (bool(*)(cPlayer *, Vector3i, eBlockFace, BLOCKTYPE, NIBBLETYPE))(*(hooks + 12));
		OnPlayerSpawned = (bool(*)(cPlayer *))(*(hooks + 13));
		OnPlayerMoving = (bool(*)(cPlayer *, Vector3d, Vector3d, bool))(*(hooks + 14));
		OnPlayerJoined = (bool(*)(cPlayer *))(*(hooks + 15));
		OnPlayerUsedBlock = (bool(*)(cPlayer *, Vector3i, eBlockFace, Vector3i, BLOCKTYPE, NIBBLETYPE))(*(hooks + 16));
		OnPlayerUsedItem = (bool(*)(cPlayer *, Vector3i, eBlockFace, Vector3i))(*(hooks + 17));
		OnPlayerUsingBlock = (bool(*)(cPlayer *, Vector3i, eBlockFace, Vector3i, BLOCKTYPE, NIBBLETYPE))(*(hooks + 18));
		OnPlayerUsingItem = (bool(*)(cPlayer *, Vector3i, eBlockFace, Vector3i))(*(hooks + 19));
		OnPlayerTossingItem = (bool(*)(cPlayer *))(*(hooks + 20));
		OnPlayerPlacedBlock = (bool(*)(cPlayer *, sSetBlock))(*(hooks + 21));
		OnPlayerPlacingBlock = (bool(*)(cPlayer *, sSetBlock))(*(hooks + 22));
		OnWorldTick = (bool(*)(cWorld *, float, float))(*(hooks + 23));
		OnBlockSpread = (bool(*)(cWorld *, Vector3i, eSpreadSource))(*(hooks + 24));
		OnBlockToPickups = (bool(*)(cWorld *, Vector3i, BLOCKTYPE, NIBBLETYPE, const cBlockEntity *, const cEntity *, const cItem *, void *, int))(*(hooks + 25));
		OnCollectingPickup = (bool(*)(cPlayer *, cPickup *))(*(hooks + 26));

	}
};
