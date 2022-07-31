using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Database;
using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CuberiteClr.Runtime.Plugins;

public class PluginLoader
{
	public const string PluginsFolder = "./ClrPlugins";

	public const string PluginDatabasesFolder = "./ClrPlugins/Databases";

	public IClrPlugin[] LoadedPlugins { get; private set; } = Array.Empty<IClrPlugin>();

	public void ReloadPlugins()
	{
		Logger.Instance.Log("Loading CLR plugins...");

		if (!Directory.Exists(PluginsFolder))
			Directory.CreateDirectory(PluginsFolder);

		if (!Directory.Exists(PluginDatabasesFolder))
			Directory.CreateDirectory(PluginDatabasesFolder);

		var pluginDirectory = new DirectoryInfo(PluginsFolder);

		var assemblyFiles = pluginDirectory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

		var loadContext = AssemblyLoadContext.GetLoadContext(Assembly.GetExecutingAssembly())!;

		var plugins = assemblyFiles
			.Select(assemblyFile => loadContext.LoadFromAssemblyPath(assemblyFile.FullName))
			.SelectMany(assembly => assembly.GetTypes().Where(IsPluginType))
			.Select(PluginDescription.FromType)
			.ToDictionary(p => p.Identifier, p => p);

		var nodes = plugins.Values.ToHashSet();
		var edges = plugins.Where(p => p.Value.Dependencies.Length > 0)
			.SelectMany(p =>
			{
				return p.Value.Dependencies
					.Select(d => new Tuple<PluginDescription, PluginDescription>(plugins[d], p.Value))
					.ToHashSet();
			}).ToHashSet();

		var sortedPlugins = TopologicalSort(nodes, edges);

		var services = new ServiceCollection()
			.AddSingleton<IRoot, Root>()
			.AddSingleton<ILogger, Logger>();

		foreach (var plugin in sortedPlugins)
		{
			if (plugin.PluginAttribute.HasDatabase)
				services.AddSingleton(typeof(IDatabase<>).MakeGenericType(plugin.Type),
					typeof(LiteDbDatabase<>).MakeGenericType(plugin.Type));

			var exposedServices = plugin.Type.GetCustomAttributes<ExposeServiceAttribute>();
			foreach (var exposedService in exposedServices)
				services.AddSingleton(exposedService.ServiceType, exposedService.ImplementationType);
		}

		var serviceProvider = services.BuildServiceProvider();

		LoadedPlugins = sortedPlugins
			.Select(plugin => (IClrPlugin) ActivatorUtilities.CreateInstance(serviceProvider, plugin.Type))
			.ToArray();

		Logger.Instance.Log($"Loaded {LoadedPlugins.Length} CLR plugin(s)");
	}

	private static bool IsPluginType(Type type)
	{
		return typeof(IClrPlugin).IsAssignableFrom(type) && !type.IsAbstract;
	}

	private static List<T> TopologicalSort<T>(HashSet<T> nodes, HashSet<Tuple<T, T>> edges) where T : IEquatable<T>
	{
		var result = new List<T>();
		var nodesWithoutDependencies = new HashSet<T>(nodes.Where(n => edges.All(e => e.Item2.Equals(n) is false)));
		while (nodesWithoutDependencies.Any())
		{
			var currentNode = nodesWithoutDependencies.First();
			nodesWithoutDependencies.Remove(currentNode);
			result.Add(currentNode);
			foreach (var edge in edges.Where(e => e.Item1.Equals(currentNode)).ToList())
			{
				var m = edge.Item2;
				edges.Remove(edge);
				if (edges.All(me => me.Item2.Equals(m) == false))
					nodesWithoutDependencies.Add(m);
			}
		}

		if (edges.Any())
			throw new Exception("Dependency loop detected");

		return result;
	}
}
