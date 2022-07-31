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
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime;

public delegate bool ExecuteCommandInternal(IntPtr callback, string command, IntPtr player);

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

	public static bool ExecuteCommandCallback(IntPtr callback, IntPtr command, IntPtr split, int splitCount, IntPtr player)
	{
#pragma warning disable CA1420
		var commandCallback = Marshal.GetDelegateForFunctionPointer<CommandCallback>(callback);
#pragma warning restore CA1420
		return commandCallback(command.ReadStringAuto(), split.ReadStringArrayAuto(splitCount), Player.CreateNullable(player));
	}

	// Hooks
	public static bool OnChat(IntPtr player, IntPtr message)
	{
		return CallBooleanFunction(plugin => plugin.OnChat(new Player(player), message.ReadStringAuto()));
	}

	public static bool OnPlayerBreakingBlock(IntPtr player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return CallBooleanFunction(plugin => plugin.OnPlayerBreakingBlock(new Player(player), x, y, z, face, type, meta));
	}

	public static bool OnPlayerBrokenBlock(IntPtr player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return CallBooleanFunction(plugin => plugin.OnPlayerBrokenBlock(new Player(player), x, y, z, face, type, meta));
	}

	public static void OnTick(float delta)
	{
		CallVoidFunction(plugin => plugin.OnTick(delta));
	}

	public static bool OnWorldTick(IntPtr world, float delta, float lastTickDuration)
	{
		return CallBooleanFunction(plugin => plugin.OnWorldTick(new World(world), delta, lastTickDuration));
	}

	public static bool OnPlayerSpawned(IntPtr player)
	{
		return CallBooleanFunction(plugin => plugin.OnPlayerSpawned(new Player(player)));
	}

	public static bool OnExecuteCommand(IntPtr player, IntPtr split, int splitLength, IntPtr entireCommand)
	{
		return CallBooleanFunction(plugin => plugin.OnExecuteCommand(Player.CreateNullable(player),
			split.ReadStringArrayAuto(splitLength), entireCommand.ReadStringAuto()));
	}
}
