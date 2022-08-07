using System;
using System.Linq;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Runtime.Plugins;
using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime;

public static unsafe class CuberiteClrManager
{
	public static PluginLoader PluginLoader { get; } = new();

	private delegate void* InitializeDelegate(IntPtr* wrappersFunctionsPtr);

	private static void* Initialize(IntPtr* wrappersFunctionsPtr)
	{
		WrapperFunctions.Initialize(wrappersFunctionsPtr);

		var hooksPointers = Hooks.Delegates.Select(Marshal.GetFunctionPointerForDelegate).ToArray();

		PluginLoader.ReloadPlugins();

		fixed (void* fixedPointer = &hooksPointers[0])
		{
			return fixedPointer;
		}
	}

	private static void CallVoidFunction(Action<IClrPlugin> call)
	{
		for (var i = 0; i < PluginLoader.LoadedPlugins.Length; i++)
			call(PluginLoader.LoadedPlugins[i]);
	}

	private static bool CallBooleanFunction(Func<IClrPlugin, bool> call)
	{
		for (var i = 0; i < PluginLoader.LoadedPlugins.Length; i++)
			if (call(PluginLoader.LoadedPlugins[i]))
				return true;
		return false;
	}

	// Internal
	public static void CallPluginsLoad()
	{
		CallVoidFunction(plugin => plugin.Load());
	}

	public static bool ExecuteCommandCallback(IntPtr callbackPtr, IntPtr commandPtr, IntPtr splitPtr, int splitCount,
		IntPtr playerPtr)
	{
		var callbackGCHandle = GCHandle.FromIntPtr(callbackPtr);
		var callback = (CommandCallback) callbackGCHandle.Target!;
		var player = Entity.Create<Player>(playerPtr);
		var command = commandPtr.ToStringAnsi();
		var split = splitPtr.ToStringArrayAuto(splitCount);
		return callback(command, split, player);
	}

	// Hooks
	public static bool OnChat(IntPtr playerPtr, IntPtr messagePtr)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		var message = messagePtr.ToStringAnsi();
		return CallBooleanFunction(plugin => plugin.OnChat(player, message));
	}

	public static bool OnPlayerBreakingBlock(IntPtr playerPtr, Vector3i position, BlockFace face, BlockType type, byte meta)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerBreakingBlock(player, position, face, type, meta));
	}

	public static bool OnPlayerBrokenBlock(IntPtr playerPtr, Vector3i position, BlockFace face, BlockType type, byte meta)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerBrokenBlock(player, position, face, type, meta));
	}

	public static void OnTick(float delta)
	{
		CallVoidFunction(plugin => plugin.OnTick(delta));
	}

	public static bool OnWorldTick(IntPtr worldPtr, float delta, float lastTickDuration)
	{
		var world = World.Create(worldPtr);
		return CallBooleanFunction(plugin => plugin.OnWorldTick(world, delta, lastTickDuration));
	}

	public static bool OnPlayerSpawned(IntPtr playerPtr)
	{
		var player = Entity.Create<Player>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerSpawned(player));
	}

	public static bool OnExecuteCommand(IntPtr playerPtr, IntPtr splitPtr, int splitLength, IntPtr entireCommandPtr, ref CommandResult result)
	{
		var player = Entity.Create<Player>(playerPtr);
		var split = splitPtr.ToStringArrayAuto(splitLength);
		var entireCommand = entireCommandPtr.ToStringAnsi();

		// Can't use the CallBooleanFunction because of the ref parameter
		for (var i = 0; i < PluginLoader.LoadedPlugins.Length; i++)
			if (PluginLoader.LoadedPlugins[i].OnExecuteCommand(player, split, entireCommand, ref result))
				return true;
		return false;
	}

	public static bool OnLogin(IntPtr clientPtr, uint protocolVersion, IntPtr usernamePtr)
	{
		var client = ClientHandle.Create(clientPtr);
		var username = usernamePtr.ToStringAnsi();
		return CallBooleanFunction(plugin => plugin.OnLogin(client, protocolVersion, username));
	}

	public static bool OnDisconnect(IntPtr clientPtr, IntPtr reasonPtr)
	{
		var client = ClientHandle.Create(clientPtr);
		var reason = reasonPtr.ToStringAnsi();
		return CallBooleanFunction(plugin => plugin.OnDisconnect(client, reason));
	}

	public static bool ExecuteForEachWorldCallback(IntPtr callbackPtr, IntPtr worldPtr)
	{
		var callbackGCHandle = GCHandle.FromIntPtr(callbackPtr);
		var callback = (ForEachWorldCallback) callbackGCHandle.Target!;
		var world = World.Create(worldPtr);
		return callback(world);
	}

	public static bool ExecuteForEachPlayerCallback(IntPtr callbackPtr, IntPtr playerPtr)
	{
		var callbackGCHandle = GCHandle.FromIntPtr(callbackPtr);
		var callback = (ForEachPlayerCallback) callbackGCHandle.Target!;
		var player = Entity.Create<Player>(playerPtr);
		return callback(player);
	}

	public static bool OnBlockSpread(IntPtr worldPtr, Vector3i position, SpreadSource source)
	{
		var world = World.Create(worldPtr);
		return CallBooleanFunction(plugin => plugin.OnBlockSpread(world, position, source));
	}

	public static bool OnBlockToPickups(IntPtr worldPtr, Vector3i position, BlockType blockType, byte blockMeta,
		IntPtr blockEntityPtr, IntPtr diggerPtr, IntPtr toolPtr, IntPtr pickupsPtr, int pickupsLength)
	{
		var world = World.Create(worldPtr);
		var blockEntity = BlockEntity.Create(blockEntityPtr);
		var digger = Entity.Create(diggerPtr);
		var tool = Item.Create(toolPtr);
		var pickups = pickupsPtr.ToArrayOf(pickupsLength, itemPtr => Item.Create(itemPtr));

		return CallBooleanFunction(plugin => plugin.OnBlockToPickups(world, position, blockType, blockMeta, blockEntity,
			digger, tool, pickups));
	}

	public static bool OnCollectingPickup(IntPtr playerPtr, IntPtr pickupPtr)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		var pickup = Entity.Create<IPickup>(pickupPtr);
		return CallBooleanFunction(plugin => plugin.OnCollectingPickup(player, pickup));
	}

	public static bool OnPlayerMoving(IntPtr playerPtr, Vector3d oldPosition, Vector3d newPosition, bool previousIsOnGround)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerMoving(player, oldPosition, newPosition, previousIsOnGround));
	}

	public static bool OnPlayerJoined(IntPtr playerPtr)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerJoined(player));
	}

	public static bool OnPlayerUsedBlock(IntPtr playerPtr, Vector3i blockPosition, BlockFace blockFace,
		Vector3i cursorPosition, BlockType blockType, byte blockMeta)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerUsedBlock(player, blockPosition, blockFace, cursorPosition,
			blockType, blockMeta));
	}

	public static bool OnPlayerUsedItem(IntPtr playerPtr, Vector3i blockPosition, BlockFace blockFace, Vector3i cursorPosition)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerUsedItem(player, blockPosition, blockFace, cursorPosition));
	}

	public static bool OnPlayerUsingBlock(IntPtr playerPtr, Vector3i blockPosition, BlockFace blockFace,
		Vector3i cursorPosition, BlockType blockType, byte blockMeta)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerUsingBlock(player, blockPosition, blockFace, cursorPosition,
			blockType, blockMeta));
	}

	public static bool OnPlayerUsingItem(IntPtr playerPtr, Vector3i blockPosition, BlockFace blockFace, Vector3i cursorPosition)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerUsingItem(player, blockPosition, blockFace, cursorPosition));
	}

	public static bool OnPlayerTossingItem(IntPtr playerPtr)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerTossingItem(player));
	}

	public static bool OnKilled(IntPtr victimPtr, TakeDamageInfoInternal takeDamageInfoInternal, IntPtr deathMessagePtr)
	{
		var victim = Entity.Create(victimPtr);
		var takeDamageInfo = takeDamageInfoInternal.ToTakeDamageInfo();
		var deathMessage = deathMessagePtr.ToStringAnsi();
		return CallBooleanFunction(plugin => plugin.OnKilled(victim, takeDamageInfo, deathMessage));
	}

	public static bool OnKilling(IntPtr victimPtr, IntPtr killerPtr, TakeDamageInfoInternal takeDamageInfoInternal)
	{
		var victim = Entity.Create(victimPtr);
		var killer = Entity.Create(killerPtr);
		var takeDamageInfo = takeDamageInfoInternal.ToTakeDamageInfo();
		return CallBooleanFunction(plugin => plugin.OnKilling(victim, killer, takeDamageInfo));
	}

	public static bool OnPlayerPlacedBlock(IntPtr playerPtr, SetBlock blockChange)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerPlacedBlock(player, blockChange));
	}

	public static bool OnPlayerPlacingBlock(IntPtr playerPtr, SetBlock blockChange)
	{
		var player = Entity.Create<IPlayer>(playerPtr);
		return CallBooleanFunction(plugin => plugin.OnPlayerPlacingBlock(player, blockChange));
	}
}
