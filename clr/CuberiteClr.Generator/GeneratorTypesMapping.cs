using System;
using System.Collections.Generic;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Generator;

public static class GeneratorTypesMapping
{
	private static readonly Dictionary<string, string> _cppToCsTypesMap = new()
	{
		// Primitive
		{"char *", "string"},
		{"int", "int"},
		{"bool", "bool"},
		{"double", "double"},
		{"float", "float"},
		{"void", "void"},
		{"short", "short"},
		{"char", "byte"},
		{"std::array<Byte, 16>", nameof(Guid)},
		{"long long int", "long"},

		// Specific
		{"eBlockFace", nameof(BlockFace)},
		{"eDamageType", nameof(DamageType)},
		{"cEntity::eEntityType", nameof(EntityType)},
		{"eExplosionSource", nameof(ExplosionSource)},
		{"eGameMode", nameof(GameMode)},
		{"eMessageType", nameof(MessageType)},
		{"eWeather", nameof(Weather)},
		{"BLOCKTYPE", nameof(BlockType)},
		{"NIBBLETYPE", "byte"},
		{"CommandResult &", $"ref {nameof(CommandResult)}"}
	};

	public static string MapCppToCsType(string type)
	{
		if (_cppToCsTypesMap.ContainsKey(type))
			return _cppToCsTypesMap[type];

		if (type.Contains('*') || type.Contains('&'))
			return "IntPtr";

		throw new Exception($"Unknown type: {type}");
	}
}
