using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;
using TestPlugin.Services;

namespace TestPlugin;

[ClrPlugin("kill-plugin")]
[DependsOn("dev-test-plugin")]
public class KillPlugin : IClrPlugin
{
	private readonly IRoot _root;

	private readonly IRoleService _roleService;

	public KillPlugin(IRoleService roleService, IRoot root)
	{
		_roleService = roleService;
		_root = root;
	}

	public void Load()
	{
		_root.BindCommand("/kill", KillCallback);
	}

	private bool KillCallback(string command, string[] split, IPlayer player)
	{
		if (!_roleService.IsAdmin(player))
			return true;

		if (split.Length == 1)
			player.TakeDamage(DamageType.Admin, null, 1000, 1000, 0);
		return true;
	}
}
