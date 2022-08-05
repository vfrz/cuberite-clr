using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Entities;

namespace TestPlugin.Services;

internal class RoleService : IRoleService
{
	private readonly IDatabase<DevTestPlugin> _db;

	public RoleService(IDatabase<DevTestPlugin> db)
	{
		_db = db;
	}

	public bool IsAdmin(IPlayer player)
	{
		var playerId = player.GetUUID();
		var admins = _db.GetCollection<AdminRecord>("admins");
		return admins.Exists(record => record.PlayerId == playerId);
	}

	public void SwitchAdmin(IPlayer player)
	{
		var admins = _db.GetCollection<AdminRecord>("admins");
		var playerId = player.GetUUID();
		if (admins.Exists(record => record.PlayerId == playerId))
			admins.Delete(playerId);
		else
			admins.Insert(new AdminRecord
			{
				PlayerId = playerId
			});
	}
}
