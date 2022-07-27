using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime;

public static unsafe class CuberiteClrManager
{
	private const string PluginDirectory = "./ClrPlugins";

	private static ClrPlugin[] LoadedPlugins { get; set; } = Array.Empty<ClrPlugin>();

	private static IntPtr[] _hooksPointers;

	private delegate void* InitializeDelegate(IntPtr* wrappersFunctionsPtr);

	private static void* Initialize(IntPtr* wrappersFunctionsPtr)
	{
		WrapperFunctions.Initialize(wrappersFunctionsPtr);

		_hooksPointers = Hooks.GetHooksPointers();

		LoadPlugins();

		fixed (void* fixedPointer = &_hooksPointers[0])
		{
			return fixedPointer;
		}
	}

	private static void LoadPlugins()
	{
		Logger.Instance.Log("Loading CLR plugins...");

		if (!Directory.Exists(PluginDirectory))
			Directory.CreateDirectory(PluginDirectory);

		var pluginDirectory = new DirectoryInfo(PluginDirectory);

		var assemblyFiles = pluginDirectory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

		var loadedPlugins = new List<ClrPlugin>();

		var loadContext = AssemblyLoadContext.GetLoadContext(Assembly.GetExecutingAssembly())!;

		foreach (var assemblyFile in assemblyFiles)
		{
			var assembly = loadContext.LoadFromAssemblyPath(assemblyFile.FullName);
			var pluginTypes = assembly
				.GetTypes()
				.Where(type => typeof(ClrPlugin).IsAssignableFrom(type) && !type.IsAbstract)
				.ToList();

			loadedPlugins.AddRange(pluginTypes
				.Select(type => (ClrPlugin) Activator.CreateInstance(type, Root.Instance, Logger.Instance)));
		}

		LoadedPlugins = loadedPlugins.ToArray();

		Logger.Instance.Log($"Loaded {LoadedPlugins.Length} CLR plugin(s)");
	}

	private static bool CallBooleanFunction(Func<ClrPlugin, bool> call)
	{
		for (var i = 0; i < LoadedPlugins.Length; i++)
			if (call(LoadedPlugins[i]))
				return true;
		return false;
	}

	internal static bool OnChatMessage(IntPtr player, IntPtr message)
	{
		return CallBooleanFunction(plugin => plugin.OnChatMessage(new Player(player), message.ReadStringAuto()));
	}

	internal static bool OnPlayerBreakingBlock(IntPtr player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return CallBooleanFunction(plugin => plugin.OnPlayerBreakingBlock(new Player(player), x, y, z, face, type, meta));
	}

	internal static bool OnPlayerBrokenBlock(IntPtr player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return CallBooleanFunction(plugin => plugin.OnPlayerBrokenBlock(new Player(player), x, y, z, face, type, meta));
	}
}
