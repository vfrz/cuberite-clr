using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CuberiteClr.Runtime;

public delegate bool ExecuteCommandInternal(IntPtr callback, string command, IntPtr player);

public static unsafe class CuberiteClrManager
{
	private const string PluginDirectory = "./ClrPlugins";

	private static IClrPlugin[] LoadedPlugins { get; set; } = Array.Empty<IClrPlugin>();

	private delegate void* InitializeDelegate(IntPtr* wrappersFunctionsPtr);

	private static void* Initialize(IntPtr* wrappersFunctionsPtr)
	{
		WrapperFunctions.Initialize(wrappersFunctionsPtr);

		var hooksPointers = Hooks.Delegates.Select(Marshal.GetFunctionPointerForDelegate).ToArray();

		LoadClrPlugins();

		fixed (void* fixedPointer = &hooksPointers[0])
		{
			return fixedPointer;
		}
	}

	private static void LoadClrPlugins()
	{
		Logger.Instance.Log("Loading CLR plugins...");

		if (!Directory.Exists(PluginDirectory))
			Directory.CreateDirectory(PluginDirectory);

		var pluginDirectory = new DirectoryInfo(PluginDirectory);

		var assemblyFiles = pluginDirectory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

		var services = new ServiceCollection()
			.AddSingleton<IRoot, Root>()
			.AddSingleton<ILogger, Logger>();

		var serviceProvider = services.BuildServiceProvider();

		var loadedPlugins = new List<IClrPlugin>();

		var loadContext = AssemblyLoadContext.GetLoadContext(Assembly.GetExecutingAssembly())!;

		foreach (var assemblyFile in assemblyFiles)
		{
			var assembly = loadContext.LoadFromAssemblyPath(assemblyFile.FullName);
			var pluginTypes = assembly
				.GetTypes()
				.Where(type => typeof(IClrPlugin).IsAssignableFrom(type) && !type.IsAbstract)
				.ToList();

			loadedPlugins.AddRange(pluginTypes
				.Select(type => (IClrPlugin) ActivatorUtilities.CreateInstance(serviceProvider, type)));
		}

		LoadedPlugins = loadedPlugins.ToArray();

		Logger.Instance.Log($"Loaded {LoadedPlugins.Length} CLR plugin(s)");
	}

	private static void CallVoidFunction(Action<IClrPlugin> call)
	{
		for (var i = 0; i < LoadedPlugins.Length; i++)
			call(LoadedPlugins[i]);
	}

	private static bool CallBooleanFunction(Func<IClrPlugin, bool> call)
	{
		for (var i = 0; i < LoadedPlugins.Length; i++)
			if (call(LoadedPlugins[i]))
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
		var commandCallback = Marshal.GetDelegateForFunctionPointer<CommandCallback>(callback);
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
