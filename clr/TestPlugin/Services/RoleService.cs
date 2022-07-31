using CuberiteClr.Sdk.Entities;

namespace TestPlugin.Services;

public class RoleService : IRoleService
{
	public bool IsAdmin(IPlayer player)
	{
		return player.GetName() == "vfrz";
	}
}
