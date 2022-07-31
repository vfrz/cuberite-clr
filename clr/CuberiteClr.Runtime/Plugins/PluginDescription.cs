using System;
using System.Reflection;
using CuberiteClr.Sdk;

namespace CuberiteClr.Runtime.Plugins;

public record PluginDescription(string Identifier, Type Type, string[] Dependencies)
{
	public static PluginDescription FromType(Type type)
	{
		var pluginAttribute = type.GetCustomAttribute<ClrPluginAttribute>();
		if (pluginAttribute is null)
			throw new Exception($"Can't load plugin from type: {type} because {nameof(ClrPluginAttribute)} is missing.");
		var dependsOnAttribute = type.GetCustomAttribute<DependsOnAttribute>();
		var dependencies = dependsOnAttribute?.Dependencies ?? Array.Empty<string>();
		return new PluginDescription(pluginAttribute.Identifier, type, dependencies);
	}

	public virtual bool Equals(PluginDescription other)
	{
		if (other is null)
			return false;
		return Identifier == other.Identifier;
	}

	public override int GetHashCode()
	{
		return Identifier != null ? Identifier.GetHashCode() : 0;
	}
}
