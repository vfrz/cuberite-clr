namespace CuberiteClr.Sdk.Core;

public interface ILogger
{
	public void Log(string message);

	public void LogInfo(string message);

	public void LogWarning(string message);

	public void LogError(string message);

	public void LogDebug(string message);
}
