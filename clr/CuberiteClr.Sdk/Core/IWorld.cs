using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public interface IWorld
{
	public Weather GetWeather();

	public void SetWeather(Weather weather);

	public int GetTimeOfDay();

	public void SetTimeOfDay(int time);

	public long GetWorldAge();

	public long GetWorldTickAge();

	public long GetWorldDate();
}
