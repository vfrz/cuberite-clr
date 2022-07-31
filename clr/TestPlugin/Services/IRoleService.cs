using CuberiteClr.Sdk.Entities;

namespace TestPlugin.Services;

public interface IRoleService
{
	public bool IsAdmin(IPlayer player);

	public void SwitchAdmin(IPlayer player);
}
