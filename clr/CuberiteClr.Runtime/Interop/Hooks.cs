// This file is auto-generated, please do not modify manually
using System;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Interop;

public static class Hooks
{
	private delegate void CallPluginsLoadDelegate();
	private delegate bool ExecuteCommandCallbackDelegate(IntPtr callback, IntPtr entireCommand, IntPtr split, int splitLength, IntPtr player);
	private delegate bool ExecuteForEachWorldCallbackDelegate(IntPtr callback, IntPtr world);
	private delegate bool ExecuteForEachPlayerCallbackDelegate(IntPtr callback, IntPtr player);
	private delegate void OnTickDelegate(float delta);
	private delegate bool OnChatDelegate(IntPtr player, IntPtr message);
	private delegate bool OnExecuteCommandDelegate(IntPtr player, IntPtr split, int splitLength, IntPtr entireCommand, ref CommandResult result);
	private delegate bool OnLoginDelegate(IntPtr client, uint protocolVersion, IntPtr username);
	private delegate bool OnDisconnectDelegate(IntPtr client, IntPtr reason);
	private delegate bool OnPlayerBreakingBlockDelegate(IntPtr player, Vector3i position, BlockFace face, BlockType type, byte meta);
	private delegate bool OnPlayerBrokenBlockDelegate(IntPtr player, Vector3i position, BlockFace face, BlockType type, byte meta);
	private delegate bool OnPlayerSpawnedDelegate(IntPtr player);
	private delegate bool OnWorldTickDelegate(IntPtr world, float delta, float lastTickDuration);
	private delegate bool OnBlockSpreadDelegate(IntPtr world, Vector3i position, SpreadSource source);
	private delegate bool OnBlockToPickupsDelegate(IntPtr world, Vector3i position, BlockType blockType, byte blockMeta, IntPtr blockEntity, IntPtr digger, IntPtr tool, IntPtr pickups, int pickupsLength);
	private delegate bool OnCollectingPickupDelegate(IntPtr player, IntPtr pickup);

	public static Delegate[] Delegates { get; } = {
		new CallPluginsLoadDelegate(CuberiteClrManager.CallPluginsLoad),
		new ExecuteCommandCallbackDelegate(CuberiteClrManager.ExecuteCommandCallback),
		new ExecuteForEachWorldCallbackDelegate(CuberiteClrManager.ExecuteForEachWorldCallback),
		new ExecuteForEachPlayerCallbackDelegate(CuberiteClrManager.ExecuteForEachPlayerCallback),
		new OnTickDelegate(CuberiteClrManager.OnTick),
		new OnChatDelegate(CuberiteClrManager.OnChat),
		new OnExecuteCommandDelegate(CuberiteClrManager.OnExecuteCommand),
		new OnLoginDelegate(CuberiteClrManager.OnLogin),
		new OnDisconnectDelegate(CuberiteClrManager.OnDisconnect),
		new OnPlayerBreakingBlockDelegate(CuberiteClrManager.OnPlayerBreakingBlock),
		new OnPlayerBrokenBlockDelegate(CuberiteClrManager.OnPlayerBrokenBlock),
		new OnPlayerSpawnedDelegate(CuberiteClrManager.OnPlayerSpawned),
		new OnWorldTickDelegate(CuberiteClrManager.OnWorldTick),
		new OnBlockSpreadDelegate(CuberiteClrManager.OnBlockSpread),
		new OnBlockToPickupsDelegate(CuberiteClrManager.OnBlockToPickups),
		new OnCollectingPickupDelegate(CuberiteClrManager.OnCollectingPickup),

	};
}
