using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CuberiteClr.Generator;

public static class Program
{
	public static async Task Main(string[] args)
	{
		Console.WriteLine("Starting generation...");

		var deserializer = new DeserializerBuilder()
			.WithNamingConvention(HyphenatedNamingConvention.Instance)
			.Build();

		var wrapperFunctionsYaml = await File.ReadAllTextAsync("wrapper-functions.yaml");

		var wrapperFunctions = deserializer.Deserialize<WrapperFunction[]>(wrapperFunctionsYaml);

		var wrapperFunctionsCsTemplate = await File.ReadAllTextAsync("WrapperFunctions.cs.template");
		var wrapperFunctionsCsDeclarations = GenerateWrapperFunctionsCsDeclarations(wrapperFunctions);
		var wrapperFunctionsCsInitializations = GenerateWrapperFunctionsCsInitializations(wrapperFunctions);
		var wrapperFunctionsCs = wrapperFunctionsCsTemplate
			.Replace("{Declarations}", wrapperFunctionsCsDeclarations)
			.Replace("{Initializations}", wrapperFunctionsCsInitializations);
		await File.WriteAllTextAsync("../CuberiteClr.Runtime/Interop/WrapperFunctions.cs", wrapperFunctionsCs);

		var clrWrapperHTemplate = await File.ReadAllTextAsync("ClrWrapper.h.template");
		var clrWrapperHDeclarations = GenerateClrWrapperHDeclarations(wrapperFunctions);
		var clrWrapperHAssignations = GenerateClrWrapperHAssignations(wrapperFunctions);
		var clrWrapperH = clrWrapperHTemplate
			.Replace("{FunctionsCount}", wrapperFunctions.Length.ToString())
			.Replace("{Declarations}", clrWrapperHDeclarations)
			.Replace("{Assignations}", clrWrapperHAssignations);
		await File.WriteAllTextAsync("../../src/CLR/ClrWrapper.h", clrWrapperH);

		Console.WriteLine("Generation successful!");
	}

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

		// Specific
		{"eGameMode", "GameMode"},
		{"eMessageType", "MessageType"},
		{"eExplosionSource", "ExplosionSource"},
		{"eWeather", "Weather"},
		{"BLOCKTYPE", "BlockType"},
		{"NIBBLETYPE", "byte"},
	};

	private static string MapCppToCsType(string type)
	{
		if (_cppToCsTypesMap.ContainsKey(type))
			return _cppToCsTypesMap[type];

		if (type.Contains("*"))
			return "IntPtr";

		throw new Exception($"Unknown type: {type}");
	}

	private static string GenerateClrWrapperHDeclarations(WrapperFunction[] functions)
	{
		var builder = new StringBuilder();
		for (var i = 0; i < functions.Length; i++)
		{
			var function = functions[i];
			builder.Append('\t');
			var args = function.Args
				.Select(arg => $"{arg.Type} {arg.Name}");
			builder.Append($"{function.Return} {function.Name}({string.Join(',', args)});");
			if (i < functions.Length - 1)
				builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateClrWrapperHAssignations(WrapperFunction[] functions)
	{
		var builder = new StringBuilder();
		for (var i = 0; i < functions.Length; i++)
		{
			var function = functions[i];
			builder.Append('\t');
			builder.Append($"wrappers_functions[{i}] = (void *)&ClrWrapper::{function.Name};");
			if (i < functions.Length - 1)
				builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateWrapperFunctionsCsDeclarations(WrapperFunction[] functions)
	{
		var builder = new StringBuilder();
		for (var i = 0; i < functions.Length; i++)
		{
			var function = functions[i];
			builder.Append('\t');
			var generics = function.Args
				.Select(arg => MapCppToCsType(arg.Type))
				.Concat(new[] {MapCppToCsType(function.Return)});
			builder.Append($"public static delegate* unmanaged[Cdecl]<{string.Join(',', generics)}> {function.Name};");
			if (i < functions.Length - 1)
				builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateWrapperFunctionsCsInitializations(WrapperFunction[] functions)
	{
		var builder = new StringBuilder();
		for (var i = 0; i < functions.Length; i++)
		{
			var function = functions[i];
			builder.Append("\t\t");
			var generics = function.Args
				.Select(arg => MapCppToCsType(arg.Type))
				.Concat(new[] {MapCppToCsType(function.Return)});
			builder.Append($"{function.Name} = (delegate* unmanaged[Cdecl]<{string.Join(',', generics)}>) *(ptr + {i});");
			if (i < functions.Length - 1)
				builder.Append('\n');
		}

		return builder.ToString();
	}
}
