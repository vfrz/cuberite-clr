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

		//  Wrapper functions
		var wrapperFunctionsYaml = await File.ReadAllTextAsync("wrapper-functions.yaml");

		var wrapperFunctions = deserializer.Deserialize<Dictionary<string, WrapperFunction>>(wrapperFunctionsYaml);

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
			.Replace("{FunctionsCount}", wrapperFunctions.Keys.Count.ToString())
			.Replace("{Declarations}", clrWrapperHDeclarations)
			.Replace("{Assignations}", clrWrapperHAssignations);
		await File.WriteAllTextAsync("../../src/CLR/ClrWrapper.h", clrWrapperH);

		// Hooks
		var hooksYaml = await File.ReadAllTextAsync("hooks.yaml");
		var hooks = deserializer.Deserialize<Dictionary<string, Hook>>(hooksYaml);

		var hooksCsTemplate = await File.ReadAllTextAsync("Hooks.cs.template");
		var hooksCsDelegates = GenerateHooksCsDelegates(hooks);
		var hooksCsDelegatesCreation = GenerateHooksCsDelegatesCreation(hooks);
		var hooksCs = hooksCsTemplate
			.Replace("{Delegates}", hooksCsDelegates)
			.Replace("{DelegatesCreation}", hooksCsDelegatesCreation);
		await File.WriteAllTextAsync("../CuberiteClr.Runtime/Interop/Hooks.cs", hooksCs);

		var clrHooksHTemplate = await File.ReadAllTextAsync("ClrHooks.h.template");
		var clrHooksHTypeDefinitions = GenerateClrHooksHTypeDefinitions(hooks);
		var clrHooksHDeclarations = GenerateClrHooksHDeclarations(hooks);
		var clrHooksHInitializations = GenerateClrHooksHInitializations(hooks);
		var clrHooksH = clrHooksHTemplate
			.Replace("{TypeDefinitions}", clrHooksHTypeDefinitions)
			.Replace("{Declarations}", clrHooksHDeclarations)
			.Replace("{Initializations}", clrHooksHInitializations);
		await File.WriteAllTextAsync("../../src/CLR/ClrHooks.h", clrHooksH);

		Console.WriteLine("Generation successful!");
	}

	private static string GenerateClrHooksHInitializations(Dictionary<string, Hook> hooks)
	{
		var builder = new StringBuilder();
		var i = 0;
		foreach (var hook in hooks)
		{
			builder.Append("\t\t");
			var args = hook.Value.Args
				.Select(arg => arg.Value);
			builder.Append($"{hook.Key} = ({hook.Value.Return}(*)({string.Join(", ", args)}))(*(hooks + {i}));");
			builder.Append('\n');
			i++;
		}

		return builder.ToString();
	}

	private static string GenerateClrHooksHDeclarations(Dictionary<string, Hook> hooks)
	{
		var builder = new StringBuilder();
		foreach (var hook in hooks)
		{
			builder.Append('\t');
			builder.Append($"{hook.Key}Def {hook.Key};");
			builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateClrHooksHTypeDefinitions(Dictionary<string, Hook> hooks)
	{
		var builder = new StringBuilder();
		foreach (var hook in hooks)
		{
			var args = hook.Value.Args
				.Select(arg => arg.Value);
			builder.Append($"typedef {hook.Value.Return} (*{hook.Key}Def) ({string.Join(", ", args)});");
			builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateHooksCsDelegatesCreation(Dictionary<string, Hook> hooks)
	{
		var builder = new StringBuilder();
		foreach (var hook in hooks)
		{
			builder.Append("\t\t");
			builder.Append($"new {hook.Key}Delegate(CuberiteClrManager.{hook.Key}),");
			builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateHooksCsDelegates(Dictionary<string, Hook> hooks)
	{
		var builder = new StringBuilder();
		foreach (var hook in hooks)
		{
			builder.Append('\t');
			var args = hook.Value.Args
				.Select(arg => $"{GeneratorTypesMapping.MapCppToCsType(arg.Value)} {arg.Key}");
			builder.Append($"private delegate {GeneratorTypesMapping.MapCppToCsType(hook.Value.Return)} {hook.Key}Delegate({string.Join(", ", args)});");
			builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateClrWrapperHDeclarations(Dictionary<string, WrapperFunction> functions)
	{
		var builder = new StringBuilder();
		foreach (var function in functions)
		{
			builder.Append('\t');
			var args = function.Value.Args
				.Select(arg => $"{arg.Value} {arg.Key}");
			builder.Append($"{function.Value.Return} {function.Key}({string.Join(", ", args)});");
			builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateClrWrapperHAssignations(Dictionary<string, WrapperFunction> functions)
	{
		var builder = new StringBuilder();
		var i = 0;
		foreach (var function in functions)
		{
			builder.Append('\t');
			builder.Append($"wrappers_functions[{i}] = (void *)&ClrWrapper::{function.Key};");
			builder.Append('\n');
			i++;
		}

		return builder.ToString();
	}

	private static string GenerateWrapperFunctionsCsDeclarations(Dictionary<string, WrapperFunction> functions)
	{
		var builder = new StringBuilder();
		foreach (var function in functions)
		{
			builder.Append('\t');
			var generics = function.Value.Args
				.Select(arg => GeneratorTypesMapping.MapCppToCsType(arg.Value))
				.Concat(new[] {GeneratorTypesMapping.MapCppToCsType(function.Value.Return)});
			builder.Append($"public static delegate* unmanaged[Cdecl]<{string.Join(", ", generics)}> {function.Key};");
			builder.Append('\n');
		}

		return builder.ToString();
	}

	private static string GenerateWrapperFunctionsCsInitializations(Dictionary<string, WrapperFunction> functions)
	{
		var builder = new StringBuilder();
		var i = 0;
		foreach (var function in functions)
		{
			builder.Append("\t\t");
			var generics = function.Value.Args
				.Select(arg => GeneratorTypesMapping.MapCppToCsType(arg.Value))
				.Concat(new[] {GeneratorTypesMapping.MapCppToCsType(function.Value.Return)});
			builder.Append($"{function.Key} = (delegate* unmanaged[Cdecl]<{string.Join(", ", generics)}>) *(ptr + {i});");
			builder.Append('\n');
			i++;
		}

		return builder.ToString();
	}
}
