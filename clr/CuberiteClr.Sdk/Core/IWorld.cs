using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public interface IWorld
{
	public Weather GetWeather();

	public void SetWeather(Weather weather);
}
