using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime;

public unsafe class CuberiteClrManager
{
	private const string PluginDirectory = "./ClrPlugins";

	private static ClrPlugin[] LoadedPlugins { get; set; } = Array.Empty<ClrPlugin>();

	private static IntPtr[] _clrFunctions;

	private delegate void* InitializeDelegate(IntPtr* functions);

	private static void* Initialize(IntPtr* wrappersFunctionsPtr)
	{
		WrappersFunctions.Initialize(wrappersFunctionsPtr);

		_clrFunctions = new[]
		{
			Marshal.GetFunctionPointerForDelegate<OnPlayerBrokenBlockDelegate>(OnPlayerBrokenBlock),
			Marshal.GetFunctionPointerForDelegate<OnPlayerBreakingBlockDelegate>(OnPlayerBreakingBlock)
		};

		LoadPlugins();

		fixed (void* a = &_clrFunctions[0])
		{
			return a;
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

		LoadedPlugins = loadedPlugins.OrderByDescending(plugin => plugin.Priority).ToArray();

		Logger.Instance.Log($"Loaded {LoadedPlugins.Length} CLR plugin(s)");
	}

	private static bool CallBooleanFunction(Func<ClrPlugin, bool> call)
	{
		for (var i = 0; i < LoadedPlugins.Length; i++)
			if (call(LoadedPlugins[i]))
				return true;
		return false;
	}

	private delegate bool OnPlayerBreakingBlockDelegate(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type, byte meta);
	private static bool OnPlayerBreakingBlock(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return CallBooleanFunction(plugin => plugin.PlayerBreakingBlock(new Player(playerPtr), x, y, z, face, type, meta));
	}

	private delegate bool OnPlayerBrokenBlockDelegate(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type, byte meta);
	private static bool OnPlayerBrokenBlock(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return CallBooleanFunction(plugin => plugin.PlayerBrokenBlock(new Player(playerPtr), x, y, z, face, type, meta));
	}
}
