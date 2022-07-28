using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Logger : ILogger
{
	internal static ILogger Instance { get; } = new Logger();

	public Logger()
	{
	}

	public void Log(string message)
	{
		WrapperFunctions.cuberite_log(message);
	}

	public void LogInfo(string message)
	{
		WrapperFunctions.cuberite_log_info(message);
	}

	public void LogWarning(string message)
	{
		WrapperFunctions.cuberite_log_warning(message);
	}

	public void LogError(string message)
	{
		WrapperFunctions.cuberite_log_error(message);
	}

	public void LogDebug(string message)
	{
		WrapperFunctions.cuberite_log_debug(message);
	}
}
