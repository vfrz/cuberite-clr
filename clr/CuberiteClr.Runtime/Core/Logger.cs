using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Logger : ILogger
{
	public static ILogger Instance { get; } = new Logger();

	private Logger()
	{
	}

	public void Log(string message)
	{
		WrappersFunctions.cuberite_log(message);
	}

	public void LogInfo(string message)
	{
		WrappersFunctions.cuberite_log_info(message);
	}

	public void LogWarning(string message)
	{
		WrappersFunctions.cuberite_log_warn(message);
	}

	public void LogError(string message)
	{
		WrappersFunctions.cuberite_log_error(message);
	}

	public void LogDebug(string message)
	{
		WrappersFunctions.cuberite_log_debug(message);
	}
}
