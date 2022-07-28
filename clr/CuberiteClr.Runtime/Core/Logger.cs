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
		WrapperFunctions.log_default(message);
	}

	public void LogInfo(string message)
	{
		WrapperFunctions.log_info(message);
	}

	public void LogWarning(string message)
	{
		WrapperFunctions.log_warning(message);
	}

	public void LogError(string message)
	{
		WrapperFunctions.log_error(message);
	}

	public void LogDebug(string message)
	{
		WrapperFunctions.log_debug(message);
	}
}
