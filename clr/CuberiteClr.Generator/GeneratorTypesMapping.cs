using System;
using System.Collections.Generic;

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
		{"std::array<Byte, 16>", "Guid"},
		{"long long int", "long"},

		// Specific
		{"eBlockFace", "BlockFace"},
		{"eDamageType", "DamageType"},
		{"eExplosionSource", "ExplosionSource"},
		{"eGameMode", "GameMode"},
		{"eMessageType", "MessageType"},
		{"eWeather", "Weather"},
		{"BLOCKTYPE", "BlockType"},
		{"NIBBLETYPE", "byte"},
		{"CommandResult", "CommandResult"},
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
